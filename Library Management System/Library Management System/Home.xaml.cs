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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
            
        }
        public Home(string username)
        {
            InitializeComponent();
            lbl_username.Content = "Logged in as : "+username;

        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.D1)
            {
                btn_explorer_Click(sender, e);
               
            }

            if (e.Key == Key.D2)
            {
                btn_issue_return_Click(sender, e);
              
            }

            if (e.Key == Key.D3)
            {
                btn_manage_members_Click(sender, e);
            }
            if (e.Key == Key.D3)
            {
                btn_return_Click(sender, e);
            }


        }

        private void btn_return_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ReturnBook mb = new ReturnBook();
            mb.Show();

        }

        private void btn_settigs_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Manage_System_User mb = new Manage_System_User();
            mb.Show();


        }

        private void btn_explorer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Explore_book ex = new Explore_book();
            ex.Show();
        }

        private void btn_issue_return_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Issue_Reurn_Book ex = new Issue_Reurn_Book();
            ex.Show();
        }

     

        private void btn_manage_members_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Manage_Members mb = new Manage_Members();
            mb.Show();
        }

        private void btn_signout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            new MainWindow().Show();
        }
    }
}
