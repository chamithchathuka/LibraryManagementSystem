
using Library_Management_System.controller;
using System;
using System.Collections.Generic;
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
using System.Collections;
using Library_Management_System.Util;

namespace Library_Management_System
{
    /// <summary>
    /// Interaction logic for Issue_Reurn_Book.xaml
    /// </summary>
    public partial class Issue_Reurn_Book : Window
    {
        BookController bkController;
        MemberController memberController;
        IssueContoller issueController;
        ReturnBookController returnController;

        int count = 0;

        Member_Detail member_detail;
        
        Book_Detail currBook;
        List<Book_Detail> bookBasket = new List<Book_Detail>();
        public Issue_Reurn_Book()
        {
            InitializeComponent();

            txt_memberid.Focus();
            bkController = new BookController();
            memberController = new MemberController();
            issueController = new IssueContoller();
            returnController = new ReturnBookController();

            datepicker_issuedate.SelectedDate = DateTime.Today;
            datepicker_returndate.SelectedDate = DateTime.Now.AddDays(7);
            cmb_returnda_selector.Items.Add("3");
            cmb_returnda_selector.Items.Add("5");
            cmb_returnda_selector.Items.Add("7");
            cmb_returnda_selector.Items.Add("14");
            cmb_returnda_selector.Items.Add("21");


        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
                new Home().Show();
            }
            if (e.Key == Key.F2)
            {
                if (!txt_memberid.Text.Equals(null) || !txt_memberid.Text.Equals(""))
                {
                    btn_check_member_Click(sender, e);
                }

            }
            if (e.Key == Key.F3)
            {
                if (!txt_bookid.Text.Equals(null) || !txt_bookid.Text.Equals(""))
                {
                   btn_check_book_Click(sender, e);
                }

            }

            if (e.Key == Key.Enter)
            {
                if (!txt_bookid.Text.Equals(null) || !txt_bookid.Text.Equals("") && txt_bookid.Equals("") || txt_bookid.Equals(null))
                {
                    btn_add_Click(sender, e);
                }
                else {
                    MessageBox.Show("Fill required fields");
                }

            }

        }

        private void btn_check_member_Click(object sender, RoutedEventArgs e)
        {
            string memberID = txt_memberid.Text;
            int num;

            if (!memberID.Equals("") || !memberID.Equals(null))
            {
                Boolean parseSuccess = int.TryParse(memberID, out num);

                if (parseSuccess)
                {
                    // int id = Util.StandardID_Generator.idExtractorGenerator(memID);
                    //  Console.Write("ID :" + id + "mem ID" + memID);
                    member_detail = memberController.findMemberById(num);

                    if (member_detail != null)
                    {
                        lbl_member_id.Content = member_detail.member_id;
                        lbl_student_name.Content = member_detail.first_name + " " + member_detail.last_name;
                        lbl_phone_number.Content = member_detail.phone_number;
                        txt_bookid.Focus();
                        if (member_detail.photo != null) {
                            BitmapImage image = Convertor.ToImage(member_detail.photo);
                            image_member.Source = image;
                        }
                        else
                        {
                            image_member.Source = new BitmapImage(new Uri(@"image/profile3.jpg", UriKind.Relative));

                        }


                    }
                    else
                    {
                        MessageBox.Show("No User Found");
                    }
                }
                else
                {
                    MessageBox.Show("failed to parse");
                }
            }
            else {
                MessageBox.Show("Please insert member ID");
            }
        }
               private void btn_check_book_Click(object sender, RoutedEventArgs e)
        {
            string bookID = txt_bookid.Text.Trim();

            if (!bookID.Equals("")||!bookID.Equals(null)) {
                int num;

                Boolean parseNumberStatus = int.TryParse(bookID, out num);

                if (parseNumberStatus) {
                    Book_Detail bk_detail = new Book_Detail();

                    // int id = Util.StandardID_Generator.idExtractorGenerator(memID);
                    //  Console.Write("ID :" + id + "mem ID" + memID);
                    bk_detail = bkController.findByBookID(num);

                    currBook = bk_detail;
                    if (bk_detail != null)
                    {

                        if (bk_detail.no_of_copies == 0)
                        {
                            
                            lbl_book_id_replace.Content = bk_detail.book_id;
                            lbl_book_name_replace.Content = bk_detail.title;
                            lbl_book_publisher_replace.Content = bk_detail.publisher;
                            lbl_isbn_replace.Content = bk_detail.isbn;
                            lbl_availablility_replace.Content = bk_detail.no_of_copies;
                            lbl_cat_replace.Content = bk_detail.category;

                            if (bk_detail.image != null)
                            {
                                BitmapImage image = Convertor.ToImage(bk_detail.image);
                                image_book.Source = image;
                            }
                            else
                            {
                                image_book.Source = new BitmapImage(new Uri(@"image/profile3.jpg", UriKind.Relative));
                            }

                            MessageBox.Show("Sorry! Copies not available now");
                        } else {
                            lbl_book_id_replace.Content = bk_detail.book_id;
                            lbl_book_name_replace.Content = bk_detail.title;
                            lbl_book_publisher_replace.Content = bk_detail.publisher;
                            lbl_isbn_replace.Content = bk_detail.isbn;
                            lbl_availablility_replace.Content = bk_detail.no_of_copies;
                            lbl_cat_replace.Content = bk_detail.category;

                            if (bk_detail.image != null)
                            {
                                BitmapImage image = Convertor.ToImage(bk_detail.image);
                                image_book.Source = image;
                            }
                            else
                            {
                                image_book.Source = new BitmapImage(new Uri(@"image/profile3.jpg", UriKind.Relative));
                            }

                        }

                    }
                    else
                    {
                        MessageBox.Show("No Book Found");
                    }
                }
            } else {

                MessageBox.Show("Please insert member ID");
            }
        }

        private void btn_issue_Click(object sender, RoutedEventArgs e)
        {
            DateTime returnDate = datepicker_returndate.SelectedDate.Value;
            DateTime issueDate = datepicker_issuedate.SelectedDate.Value;
            int count = 0;
            if (bookBasket.Count > 0) {
                Console.WriteLine("Count size "+bookBasket.Count);
                foreach (Book_Detail book in bookBasket)
                {
                    count++;
                 issueController.issueBook(book, member_detail, issueDate, returnDate);
                }
                txt_memberid.Text = "";
                txt_bookid.Text = "";
                txt_memberid.Focus();

            }
            if (count == bookBasket.Count)
            {
                MessageBox.Show("Issue Process Successful");
            }
            else {

                MessageBox.Show("Problem of issueing books");
            }
        }


        private void btn_add_Click(object sender, RoutedEventArgs e)
        {

           
            if (currBook != null) {
                if (currBook.no_of_copies > 0)
                {
                    MessageBox.Show("Book is Added to the bucket");
                    Console.Write("Real Book I found " + currBook.title);
                    bookBasket.Add(currBook);
                    lbl_bookcount.Content = ++count;
                    lbl_availablility_replace.Content = --currBook.no_of_copies;
                    PrintValues(bookBasket);

                }
                else {
                    MessageBox.Show("Sorry! cannot issue copies are not available");
                }
            }

        }


        public static void PrintValues(IEnumerable myList)
        {
            foreach (Book_Detail obj in myList) { 
              
                Console.WriteLine("Book Title "+obj.title);
            }
           
        }



        private void btn_return_Click(object sender, RoutedEventArgs e)
        {


            //List<Issue_Detail>  listofBooks = issueController.getReturnBookDetail(member_detail.member_id);

            //foreach (Issue_Detail item in listofBooks)
            //{
            //    Console.WriteLine("non returned books "+ item.book_id);
            //}

  

        }
    }
}
