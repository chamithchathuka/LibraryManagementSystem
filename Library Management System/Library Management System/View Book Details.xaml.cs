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
    /// Interaction logic for View_Book_Details.xaml
    /// </summary>
    public partial class View_Book_Details : Window
    {

        BookController bookController;
        Book_Detail bookDetail; 
        public View_Book_Details()
        {
            InitializeComponent();
            bookController = new BookController();

        }

        public View_Book_Details(int bookID)
        {

            
            InitializeComponent();
            bookController = new BookController();
            bookDetail =  bookController.findByBookID(bookID);
            txt_bookid.Text = bookDetail.book_id+"";
            txt_title.Text = bookDetail.title;
            txt_author.Text = bookDetail.author;
            txt_description.Text = bookDetail.description;
            txt_isbn.Text = bookDetail.description;
            txt_price.Text = bookDetail.price + "";
            txt_publisher.Text = bookDetail.publisher;
            txt_year.Text = bookDetail.year;

            if (bookDetail.image != null)
            {
                BitmapImage image = ToImage(bookDetail.image);
                image_view.Source = image;
            }
            else {
                image_view.Source = new BitmapImage(new Uri(@"image/book.png", UriKind.Relative));

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

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Escape)
            {
                this.Close();
            }


        }


    }
}
