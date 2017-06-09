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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity.Migrations;
using Library_Management_System.controller;

namespace Library_Management_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btn_login_Click(sender, e);
            }
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            string username = txt_username.Text;
            string password = txt_password.Password;

            UserDetailController userContoller = new UserDetailController();
           //  Boolean result =  userContoller.checkUserLogin(username, password);
            Boolean result = true;
            if (result)
            {
                this.Hide();
                
                Home home = new Home(username);
                home.ShowDialog();
            }
            else {
              
                MessageBox.Show("Please check user name and password!", "Bookshelf Libarary management System ", MessageBoxButton.OK, MessageBoxImage.Error);
                txt_password.Password = "";
                txt_username.Text = "";
            }


            Console.Write("after window close ");
           
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
