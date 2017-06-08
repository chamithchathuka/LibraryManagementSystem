using iTextSharp.text;
using iTextSharp.text.pdf;
using Library_Management_System.controller;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
    public partial class Explore_book : Window
    {
        BookController bookController ;
        MemberController memberController;
        IssueContoller issueController;
        List<Member_Detail> members;
        List<Book_Detail> books;
        public Explore_book()
        {

            InitializeComponent();
            txt_search.Focus();

            bookController = new BookController();
            memberController = new MemberController();
            issueController = new IssueContoller();

            dp_date_selected.SelectedDate = DateTime.Now;

            btn_get_issued_books.Visibility = Visibility.Hidden;
            btn_get_members_borrowed.Visibility = Visibility.Hidden;
            dp_date_selected.Visibility = Visibility.Hidden;

   
        }

       
        private void btn_search_Click(object sender, RoutedEventArgs e)
        {

            string parameter = (string)cmb_field.SelectedValue;
            
            if (!txt_search.Text.Trim().Equals(""))
            {
                List<Book_Detail> searchList = bookController.searchBooks(parameter, txt_search.Text.Trim(), DateTime.Now);
                if (searchList.Count > 0)
                {
                    data_book_grid.ItemsSource = searchList;
                }
                else
                {
                    MessageBox.Show("No books available for the given criteria");
                }

            }
            else
            {
              
                MessageBox.Show("Search box is Empty");

            }


        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
                new Home().Show();
            }

            if (e.Key == Key.Enter)
            {
                btn_search_Click(sender, e);
            }

            if (e.Key == Key.Tab) {
                radio_btn_book.IsChecked = true;
            }


        }

       

        private void radio_btn_book_Checked(object sender, RoutedEventArgs e)
        {
            if (radio_btn_member.IsChecked == true)
            {

                btn_get_issued_books.Visibility = Visibility.Visible;
                btn_get_members_borrowed.Visibility = Visibility.Visible;
                dp_date_selected.Visibility = Visibility.Visible;
            
                members  = memberController.loadAllMembers();

                lbl_book_total_count.Content = members.Count;
                data_book_grid.ItemsSource = members;

                

                cmb_field.Items.Clear();
                cmb_field.Items.Add("first_name");
                cmb_field.Items.Add("last_name");
                cmb_field.Items.Add("dob");
                cmb_field.Items.Add("add_member");
                cmb_field.Items.Add("email");
                cmb_field.Items.Add("add_number");
                cmb_field.Items.Add("email");
                cmb_field.Items.Add("address");
                cmb_field.Items.Add("phone_number");
                cmb_field.SelectedValue = "first_name";
       
            }
            if (radio_btn_book.IsChecked == true)
            {

                books = bookController.loadAllBooks();
                data_book_grid.ItemsSource = books;
                lbl_book_total_count.Content = books.Count;
                cmb_field.Items.Clear();
                cmb_field.Items.Add("title");
                cmb_field.Items.Add("category");
                cmb_field.Items.Add("date");
                cmb_field.Items.Add("author");
                cmb_field.Items.Add("publisher");
                cmb_field.Items.Add("language");
                cmb_field.Items.Add("isbn");
                cmb_field.SelectedValue = "title";


            }

        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
           var item =  data_book_grid.SelectedItem;
            Book_Detail bk = new Book_Detail();
            Member_Detail member = new Member_Detail();
            Issue_Detail issue = new Issue_Detail();
            
            if (bk.GetType().Equals(item.GetType()) ==  true) {
             
                bk =(Book_Detail) data_book_grid.SelectedItem;
                new View_Book_Details(bk.book_id).Show();
               

            }
            if (member.GetType().Equals(item.GetType()) == true)
            {
                member =(Member_Detail) data_book_grid.SelectedItem;
                new MemberQuickView(member.member_id).Show();

            }
            if (issue.GetType().Equals(item.GetType()) == true)
            {
                MessageBox.Show("Issue data type ");
            }

            
        }


        private void btn_export_Click(object sender, RoutedEventArgs e)
        {

            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "PDF_"+DateTime.Now.Millisecond; // Default file name
            dlg.DefaultExt = ".pdf"; // Default file extension
            dlg.Filter = "Pdf Files|*.pdf"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();
            string filename = "PDF_" + DateTime.Now.Millisecond;
            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                filename = dlg.FileName;
            }

            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
            Document doc = new Document();
           
            if (radio_btn_member.IsChecked == true)
            {
                Boolean headingsDone = false;
                PdfPTable pdfTable = new PdfPTable(9);
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                doc.Open();
                
                 foreach (var obj in members)
                {
                    foreach (var prop in obj.GetType().GetProperties())
                    {

                        if (headingsDone == false)
                        {
                            string heading = prop.Name;

                            pdfTable.AddCell(heading);
                            headingsDone = true;

                        }
                        // Console.WriteLine("{0} = {1}", prop.Name, prop.GetValue(obj, null));
                        pdfTable.AddCell(prop.GetValue(obj, null)+"");
                    }
                }
                doc.Add(pdfTable);
            }

            if (radio_btn_book.IsChecked == true)
            {
                PdfPTable pdfTable = new PdfPTable(17);
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                              
                doc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
                doc.Open();

                Boolean headingsDone = false;
                foreach (var obj in books)
                {
                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        // Console.WriteLine("{0} = {1}", prop.Name, prop.GetValue(obj, null));
                        if (headingsDone == false) {
                            string heading = prop.Name;
                            Console.WriteLine("heading professional"+heading);
                            pdfTable.AddCell(heading);
                            headingsDone = true;

                        }

                        string cell_value = prop.GetValue(obj) +"";

                        pdfTable.AddCell(cell_value);
                    }
                }
                doc.Add(pdfTable);
            }

            doc.Close();

        }

        private void btn_get_issued_books_Click(object sender, RoutedEventArgs e)
        {
            DateTime dateSelcted = (DateTime)dp_date_selected.SelectedDate;
            string memberid = txt_search.Text.Trim();
            int memID;

            int.TryParse(memberid, out memID);
            List<Issue_Detail> issues = issueController.getIssuesforMember(memID);
            data_book_grid.ItemsSource = issues;
        }

        private void btn_get_members_borrowed_Click(object sender, RoutedEventArgs e)
        {
            DateTime dateSelcted = (DateTime)dp_date_selected.SelectedDate;
            string memberid = txt_search.Text.Trim();
            int memID;

            int.TryParse(memberid,out memID);
            List<Issue_Detail> issues = issueController.getDelayedBooksForMember(memID ,dateSelcted);
            data_book_grid.ItemsSource = issues;
        }
    }
}
