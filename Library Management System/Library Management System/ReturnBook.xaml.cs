using Library_Management_System.controller;
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
       
      
        public ReturnBook()
        {
            InitializeComponent();
          
            issueContoller = new IssueContoller();
            bookController = new BookController();

            //dataGrid.ItemsSource = issueContoller.loadIssuedBooks();
        }

        private void btn_check_member_Click(object sender, RoutedEventArgs e)
        {
       

        }

        private void button_click(object sender, RoutedEventArgs e) {

        

            Issue_Detail issueDetail = dataGrid.SelectedItem as Issue_Detail;
            issueDetail.return_date = DateTime.Now;

            issueContoller.bookReturnedUpdate(issueDetail);
            
            int memberid = Int32.Parse(txt_memberid.Text.Trim());

            dataGrid.ItemsSource = issueContoller.getReturnBookDetail(memberid);



        }

        private void selectionChanged(object sender, RoutedEventArgs e)
        {


            //Issue_Detail issueDetail = dataGrid.SelectedItem as Issue_Detail;
            //int bookId = (int)issueDetail.book_id;

            //bookDetail = bookController.findByBookID(bookId);

            //lbl_book_id_replace.Content = bookDetail.book_id;
            //lbl_book_name_replace.Content = bookDetail.title;
            //lbl_book_publisher_replace.Content = bookDetail.publisher;
            //lbl_edition_replace.Content = bookDetail.year;
            //lbl_isbn_replace.Content = bookDetail.isbn;
            //lbl_availablility_replace.Content = bookDetail.no_of_copies;
            //lbl_cat_replace.Content = bookDetail.category;

           // MessageBox.Show("changed");



        }

        private void btn_check_member_Click_1(object sender, RoutedEventArgs e)
        {

            int memberid = Int32.Parse(txt_memberid.Text.Trim());
            dataGrid.ItemsSource = issueContoller.getReturnBookDetail(memberid);

        }
    }
}
