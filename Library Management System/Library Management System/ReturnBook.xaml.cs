using Library_Management_System.controller;
using Library_Management_System.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Library_Management_System
{
    /// <summary>
    /// Interaction logic for ReturnBook.xaml
    /// </summary>
    public partial class ReturnBook : Window
    {

        private IssueContoller issueContoller;
        private BookController bookController;
        private MemberController memberContoller;
        private double finePerDay;
        private double total;
        
       
      
        public ReturnBook()
        {
            InitializeComponent();
            total = 0;
            dp_returndate.SelectedDate =   DateTime.Now;
            finePerDay = 10;
            issueContoller = new IssueContoller();
            bookController = new BookController();
            memberContoller = new MemberController();
            
            txt_memberid.Focus();

            //dataGrid.ItemsSource = issueContoller.loadIssuedBooks();
        }

        private void btn_check_member_Click(object sender, RoutedEventArgs e)
        {
       

        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = dataGrid.SelectedItem;
            Book_Detail bk = new Book_Detail();
            Member_Detail member = new Member_Detail();
            Issue_Detail issue = new Issue_Detail();

            
            if (issue.GetType().Equals(item.GetType()) == true)
            {
              
                issue = (Issue_Detail)dataGrid.SelectedItem;
                bk = bookController.findByBookID((int)issue.book_id);
                if (!bk.title.Equals("")) {
                    lbl_availablility_replace.Content = bk.no_of_copies;
                    lbl_book_name_replace.Content = bk.title;
                    lbl_book_publisher_replace.Content = bk.publisher;
                    lbl_cat_replace.Content = bk.category;
                    lbl_isbn_replace.Content = bk.isbn;

                    if (bk.image != null)
                    {
                        BitmapImage image = Convertor.ToImage(bk.image);
                        image_book_detail.Source = image;
                    }
                    else
                    {
                        image_book_detail.Source = new BitmapImage(new Uri(@"image/profile3.jpg", UriKind.Relative));
                    }

                }

            }

        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string memberID = txt_memberid.Text.Trim();
                if (memberID.Equals(null) || memberID.Equals(""))
                {
                    MessageBox.Show("Please insert member ID");
                }
                else {
                    btn_check_member_Click_1(sender, e);       
                }
              
            }
            

            if (e.Key == Key.Escape)
            {
                this.Close();
                new Library_Management_System.Home().Show();
                
            }
        }

        private void button_click(object sender, RoutedEventArgs e) {
            
            Issue_Detail issueDetail = dataGrid.SelectedItem as Issue_Detail;

            issueDetail.return_date = DateTime.Now;
            DateTime dateDue = (DateTime) issueDetail.due_date;

            DateTime returnDate = (DateTime)dp_returndate.SelectedDate;

            if (returnDate > dateDue) {
                               
                double noOfDays = (returnDate - dateDue).TotalDays;
                MessageBox.Show("Delayed return of a book");
                total += noOfDays * finePerDay;
                lbl_fine.Content = total;

            }

            bool result = issueContoller.bookReturnedUpdate(issueDetail);

            if (result)
            {

                int memberid = Int32.Parse(txt_memberid.Text.Trim());

                List<Issue_Detail> issueDetails = issueContoller.getReturnBookDetail(memberid);

                if (issueDetails.Count > 0) {
                   dataGrid.ItemsSource = issueContoller.getReturnBookDetail(memberid);
                    Console.WriteLine("Returned book count "+issueDetails.Count);
                } else {
                    MessageBox.Show("No books to return for the current user");
                }

            }
            else {

                MessageBox.Show("Faild to Update ");

            }


        }

        private void selectionChanged(object sender, RoutedEventArgs e)
        {


        }

        private void btn_check_member_Click_1(object sender, RoutedEventArgs e)
        {
                      
            if (txt_memberid.Text.Equals(null) || txt_memberid.Text.Equals(""))
            {
                MessageBox.Show("Text Filed is empty");

            }
            else {
                string memberidStr = txt_memberid.Text.Trim();

                int memberid;

                bool parseResult = int.TryParse(memberidStr, out memberid);

                if (parseResult)
                {
                    Member_Detail memberDetail = memberContoller.findMemberById(memberid);
                                 
                    if (memberDetail != null)
                    {
                        lbl_member_id.Content = memberDetail.member_id;
                        lbl_student_name.Content = memberDetail.first_name + " " + memberDetail.last_name;
                        lbl_phone_number.Content = memberDetail.phone_number;

                        if (memberDetail.photo != null)
                        {

                            byte[] imageByte = memberDetail.photo;
                            BitmapImage mem_image = ToImage(imageByte);
                            image_member.Source = mem_image;
                        }
                       
                              else {
                                image_member.Source = new BitmapImage(new Uri(@"image/profile3.jpg", UriKind.Relative));
                            }


                       

                        List<Issue_Detail> issueDetails = issueContoller.getReturnBookDetail(memberid);
                        
                        if (issueDetails.Count > 0)
                        {
                                                       
                            dataGrid.ItemsSource = issueContoller.getReturnBookDetail(memberid);
                            Console.WriteLine("Returned book count " + issueDetails.Count);
                        }
                        else
                        {
                            MessageBox.Show("No books to Return for the current user");
                        }
                    }
                    else {
                        MessageBox.Show("no such member");

                    }
                }
                else {
                    MessageBox.Show("Please input a number");
                }

            }

        }

        public BitmapImage ToImage(byte[] array)
        {
            var image = new BitmapImage();
            using (var ms = new System.IO.MemoryStream(array))
            {

                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad; // here
                image.StreamSource = ms;
                image.EndInit();

            }
            return image;
        }


        private void btn_complete_checkout_Click(object sender, RoutedEventArgs e)
        {
                       
        }
    }
}
