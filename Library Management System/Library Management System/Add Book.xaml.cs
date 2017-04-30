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
using System.Data.Entity.Migrations;

namespace Library_Management_System
{
    /// <summary>
    /// Interaction logic for Add_Book.xaml
    /// </summary>
    /// 
    
    public partial class Add_Book : Window
    {
        Book_Detail bk = null;
        Boolean isNewBookAdded = false;
        controller.BookController bkcontoller = new controller.BookController();
        public Add_Book()
        {

            InitializeComponent();
            bk = new Book_Detail();

            bkcontoller.addBook(bk);
            txt_bookid.Text = "BKID"+bk.book_id.ToString();

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!isNewBookAdded) { 
            Boolean result = bkcontoller.deletebyBookID(bk.book_id);
                Console.Write("Closing event Called ......"+ result);   
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (!isNewBookAdded)
            {
                bkcontoller.deletebyBookID(bk.book_id);
                Console.Write("Closed event Called ......");
            }
        }

        private void btn_addbook_Click(object sender, RoutedEventArgs e)
        {

            string booknumber =  txt_booknumber.Text;
            string title = txt_title.Text;
            string author = txt_author.Text;
            //string category = cmb_category.SelectedValue.ToString();
            string category = "cat 1";
            string publisher = txt_publisher.Text;
            string language = txtlanguage.Text;
            string isbn = txt_isbn.Text;
            string year = txt_year.Text;
            string noofPage = txt_no_of_pages.Text;

            DateTime date_added = new DateTime();
            //string type = cmb_booktype.SelectedItem.ToString();
            string type = "Book";
            //            decimal price = Decimal.Parse(txt_price.Text);

            decimal price = 10;

            string description = txt_description.Text;
            int noofCopies = Int32.Parse(txt_no_of_copies.Text); 

            bk.book_no = booknumber;
            bk.title = title;
            bk.author = author;
            bk.category = category;
            bk.publisher = publisher;
            bk.language = language;
            bk.isbn = isbn;
            bk.year = year;
            bk.pages = noofPage;
            bk.date_added = date_added;
            bk.type = type;
            bk.price = price;
            bk.description = description;
            bk.no_of_copies = noofCopies;

            isNewBookAdded  = bkcontoller.updateBook(bk);
            

        }
    }
}
