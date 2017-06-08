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
using Microsoft.Win32;
using System.IO;

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
        BitmapImage image ;

        controller.BookController bkcontoller = new controller.BookController();
        public Add_Book()
        {

            InitializeComponent();
            bk = new Book_Detail();
                       
            bkcontoller.addBook(bk);

            txt_bookid.Text = "BKID"+bk.book_id.ToString();

            fillLanguages();
            fillBookType();

        }

        private void fillLanguages()
        {
                       
            cmb_languages.Items.Add("Englsh");
            cmb_languages.Items.Add("Sinahala");
            cmb_languages.Items.Add("Tamil");
        }

        private void fillBookType() {

            cmb_booktype.Items.Add("Book");
            cmb_booktype.Items.Add("Magazine");
            cmb_booktype.Items.Add("Journal");
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!isNewBookAdded) { 
            Boolean result = bkcontoller.deletebyBookID(bk.book_id);
                Console.Write("Closing event Called ......"+ result);   
            }
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
                new Home().Show();

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

            //   string language = ((ComboBoxItem)cmb_languages.SelectedItem).Content.ToString();

            string language = "English";

            string isbn = txt_isbn.Text;
            string year = txt_year.Text;
            string noofPage = txt_no_of_pages.Text;

         
            // string type = ((ComboBoxItem)cmb_booktype.SelectedItem).Content.ToString();

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
            bk.date_added = DateTime.Now;
            bk.type = type;
            bk.price = price;
            bk.description = description;
            bk.no_of_copies = noofCopies;

            if(image!=null)
            bk.image=(imageToByteArray(image));


            isNewBookAdded  = bkcontoller.updateBook(bk);
            Console.Write("is book added" + isNewBookAdded);

            if (isNewBookAdded) {
                MessageBox.Show("Book added Successfully !", "Library MS", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            new Add_Book().Show();
        }

        private void btn_chooseimage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                image = new BitmapImage(new Uri(op.FileName));
                image_view.Source = image;
            }

        }

        public byte[] imageToByteArray(BitmapImage imageIn)
        {
            byte[] data;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageIn));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
               return data = ms.ToArray();
            }
        }

 
    }
}
