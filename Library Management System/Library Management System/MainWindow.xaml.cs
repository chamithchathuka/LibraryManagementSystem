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

       

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
     
            Application.Current.Shutdown();
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Console.Write("after window cloase ");
            Home home = new Home();
            home.ShowDialog();
        }
    }
}
