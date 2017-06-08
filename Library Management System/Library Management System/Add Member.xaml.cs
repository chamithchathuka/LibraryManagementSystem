using Library_Management_System.controller;
using Library_Management_System.Validator;
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
using FluentValidation;

namespace Library_Management_System
{
    /// <summary>
    /// Interaction logic for Add_Member.xaml
    /// </summary>
    public partial class Add_Member : Window
    {

        MemberController mbController = new MemberController();
        private Member_Detail mb = null;
        private Boolean isNewMemberAdded = false;
       
        public Add_Member()
        {
            InitializeComponent();
            mb = new Member_Detail();
            mbController.addMember(mb);
            txt_member_id.Text = mb.member_id.ToString();
           

        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btn_addmember_Click(sender, e);
            }
            if (e.Key == Key.Enter)
            {
                this.Close();
                new Home().Show();

            }


        }


        private void btn_addmember_Click(object sender, RoutedEventArgs e)
        {
            string firstName = txt_firstname.Text.Trim();
            string lastName = txt_firstname.Text;
            DateTime? dob = null;
            try
            {
                 dob = dpdob.SelectedDate.Value;
            }
            catch {
                MessageBox.Show("select date of Birth"); 
            }

            string email = txt_email.Text;
            string address = txt_address.Text;
            string phone = txt_phonenumber.Text;
            string addmission = txt_admissionnumber.Text;

            Member_Detail md = new Member_Detail();
            md.first_name = firstName;
            md.last_name = lastName;
            md.email = email;
            md.admission_number = addmission;
            md.address = address;
            md.phone_number = phone;
            md.dob = dob;


            Member_Validator validator = new Member_Validator();
            FluentValidation.Results.ValidationResult results = validator.Validate(md);
            Console.WriteLine("validation result "+ results.IsValid);
            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    MessageBox.Show(failure.ErrorMessage);
                }
               
            }
            else {

                
            //      if (firstName == null || firstName == "" || lastName == null || lastName == "" || address == null || address == "" || addmission == 0 )
           
        //    else {
                isNewMemberAdded =  mbController.updateMember(md);

                if (isNewMemberAdded)
                {
                    MessageBox.Show("New Member Added");
                }
                else {
                    MessageBox.Show("Failed to Add New Member");
                }
         }
                
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new Home().Show();
        }


    }
}
