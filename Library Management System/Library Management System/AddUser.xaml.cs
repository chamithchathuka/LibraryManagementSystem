using Library_Management_System.controller;
using Library_Management_System.Util;
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
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        public AddUser()
        {
            InitializeComponent();
        
        }
       
        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            User_Detail user = new User_Detail();

            user.name = txt_name.Text;
            string password = txt_password.Text;
          
            string encryptedpass = EncryptionUtil.ToSHA256(password);
            Console.Write(encryptedpass);
            user.password = encryptedpass;

            UserDetailController userdetailcontroller = new UserDetailController();
            userdetailcontroller.addUserDetail(user);

        }
    }
}
