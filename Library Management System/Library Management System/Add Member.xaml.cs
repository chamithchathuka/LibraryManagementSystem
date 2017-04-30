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
    /// Interaction logic for Add_Member.xaml
    /// </summary>
    public partial class Add_Member : Window
    {

        MemberController mbController = new MemberController();
        private Member_Detail mb = null; 
        public Add_Member()
        {
            InitializeComponent();
            mb = new Member_Detail();
            mbController.addMember(mb);
            txt_member_id.Text = mb.member_id.ToString();
            

        }

        private void btn_addmember_Click(object sender, RoutedEventArgs e)
        {
            string firstName = txt_firstname.Text;
            string lastName = txt_firstname.Text;
            DateTime dob = dpdob.SelectedDate.Value;
            string email = txt_email.Text;
            string address = txt_block_address.Text;
            int phone = Int32.Parse(txt_phonenumber.Text);
            int addmission = Int32.Parse(txt_admissionnumber.Text);

            Member_Detail md = new Member_Detail();
            md.first_name = firstName;
            md.last_name = lastName;
            md.email = email;
            md.admission_number = addmission;
            md.address = address;
            md.phone_number = phone; 

            if (firstName == null || firstName == "" || lastName == null || lastName == "" || address == null || address == "" || addmission == 0 )
                MessageBox.Show("Please fill required fields");
            else {
                mbController.updateMember(md);
            }
                
        }


   
    }
}
