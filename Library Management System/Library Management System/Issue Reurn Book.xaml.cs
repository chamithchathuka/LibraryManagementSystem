
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

namespace Library_Management_System
{
    /// <summary>
    /// Interaction logic for Issue_Reurn_Book.xaml
    /// </summary>
    public partial class Issue_Reurn_Book : Window
    {
        BookController bkController;
       
        Member_Detail member_detail;
        MemberController memberController;
        Book_Detail currBook;
        List<Book_Detail> bookBucket = new List<Book_Detail>();
        public Issue_Reurn_Book()
        {
            InitializeComponent();
            bkController = new BookController();
            memberController = new MemberController();


        }

        private void txt_admission_number_Copy1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btn_check_member_Click(object sender, RoutedEventArgs e)
        {
            string memberID = txt_memberid.Text;
            int num = Int32.Parse(memberID);

            // int id = Util.StandardID_Generator.idExtractorGenerator(memID);
            //  Console.Write("ID :" + id + "mem ID" + memID);
            member_detail = memberController.findMemberById(num);
            
            if (member_detail != null)
            {
                lbl_member_id.Content = member_detail.member_id;
                lbl_student_name.Content = member_detail.first_name +" "+ member_detail.last_name;
                lbl_phone_number.Content = member_detail.phone_number;
               
            }
            else
            {
                MessageBox.Show("No User Found");
            }
        }

        private void btn_check_book_Click(object sender, RoutedEventArgs e)
        {
            string bookID = txt_bookid.Text.Trim();
            int num = Int32.Parse(bookID);
            Book_Detail bk_detail = new Book_Detail();
            

            // int id = Util.StandardID_Generator.idExtractorGenerator(memID);
            //  Console.Write("ID :" + id + "mem ID" + memID);
            bk_detail = bkController.findByBookID(num);
            currBook = bk_detail;
            if (bk_detail != null)
            {
                lbl_book_id_replace.Content = bk_detail.book_id;
                lbl_book_name_replace.Content = bk_detail.title;
                lbl_book_publisher_replace.Content = bk_detail.publisher;
                lbl_isbn_replace.Content = bk_detail.isbn;
                lbl_availablility_replace.Content = bk_detail.available;
                lbl_cat_replace.Content = bk_detail.category;


            }
            else
            {
                MessageBox.Show("No Book Found");
            }

        }

        private void btn_issue_Click(object sender, RoutedEventArgs e)
        {
            
        }


        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            if (currBook != null) {
                MessageBox.Show("Book is Added to the bucket");

                Console.Write("Real Book I found " + currBook.title);
            //Console.WriteLine(currBook.book_id);
            bookBucket.Add(currBook);
                PrintValues(bookBucket);
            }

        }


        public static void PrintValues(IEnumerable myList)
        {
            foreach (Book_Detail obj in myList) { 
              
                Console.WriteLine("Book Title "+obj.title);
            }
           
        }

    }
}
