
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

namespace Library_Management_System
{
    /// <summary>
    /// Interaction logic for Issue_Reurn_Book.xaml
    /// </summary>
    public partial class Issue_Reurn_Book : Window
    {
        BookController bkController;
        Book_Detail bk_detail;
        public Issue_Reurn_Book()
        {
            InitializeComponent();
            bkController = new BookController();
        }

        private void txt_admission_number_Copy1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btn_check_Click(object sender, RoutedEventArgs e)
        {
            string memID = txt_memberid.Text;
            string bookID = txt_bookid.Text;
            int id = Util.StandardID_Generator.idExtractorGenerator(memID);
            bk_detail = bkController.findByBookID(id);
            lbl_book_id_replace.Content = bk_detail.book_id;
        }
    }
}
