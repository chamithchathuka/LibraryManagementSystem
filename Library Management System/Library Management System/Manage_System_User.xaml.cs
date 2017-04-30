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
    /// Interaction logic for Manage_System_User.xaml
    /// </summary>
    public partial class Manage_System_User : Window
    {
        User_Detail sysUser = new User_Detail();
        
        UserDetailController userController = new UserDetailController();
        public Manage_System_User()
        {
            InitializeComponent();

            txt_username.TabIndex = 0;
            txt_password.TabIndex = 1;
            txt_password_confirm.TabIndex = 2;
            txt_name.TabIndex = 3;
            txt_address.TabIndex = 4;
            txt_phone.TabIndex = 5;
            txt_email.TabIndex = 6;
            comboBox.TabIndex = 7;
            btn_add_user.TabIndex = 8;
            
        }

        private void btn_add_user_Click(object sender, RoutedEventArgs e)
        {
           
            string username = txt_username.Text.Trim();
            string password = txt_password.Password.Trim();
            string passconfirm = txt_password_confirm.Password.Trim();
            string name = txt_name.Text.Trim();
            string address = txt_address.Text.Trim();
            string phone = txt_phone.Text.Trim();
            string email = txt_email.Text.Trim();
            string type = "admin";

            sysUser.name = name;
            if (passconfirm.Equals(password))
            {
                sysUser.password = password;

            }
            else {
                Console.Write("passwords are not matching");
       
            }

            Console.WriteLine("Name"+name);
            Console.WriteLine("passwords"+password);
            Console.WriteLine("name"+name);
            Console.WriteLine("address"+address);
            Console.WriteLine("phone"+phone);
            Console.WriteLine("email" + email);
            Console.WriteLine("type" + type);

            sysUser.user_name = username;
            sysUser.name = name;
            sysUser.address = address;
            sysUser.phone_number = phone;
            sysUser.email = email;
            sysUser.type = type;
            
            userController.addUserDetail(sysUser);
            MessageBox.Show("Done");
        }
    }
}
