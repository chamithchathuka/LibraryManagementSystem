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
    /// Interaction logic for Manage_Members.xaml
    /// </summary>
    public partial class Manage_Members : Window
    {
        public Manage_Members()
        {
            InitializeComponent();
        }

        private void btn_setpackage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
                new Home().Show();

            }

        }
        private void btn_addnew_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Add_Member mem = new Add_Member();
            mem.Show();
        }
    }
}
