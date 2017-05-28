using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Management_System.Util;
using System.Data.Entity.Validation;

namespace Library_Management_System.controller
{
   public class UserDetailController
    {
        public Boolean addUserDetail(User_Detail userDetail)
        {
            Boolean status = false;
          

            try
            {
                using (var db = new ModelDB())
                {

                    string passencripted = EncryptionUtil.ToSHA256(userDetail.password);
                    Console.WriteLine(passencripted);
                    userDetail.password = passencripted;
                    db.User_Detail.Add(userDetail);
                    db.SaveChanges();
                    status = true;

                }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Console.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            return status;
        }

        public Boolean checkUserLogin(string username,string password) {
            Console.Write("username " + username + " password " + password);

            string encrypted = EncryptionUtil.ToSHA256(password);
            Console.Write("encrypted " + encrypted);

            User_Detail userdetail = null;
            Boolean user_status = false;
            try
            {
                using (var db = new ModelDB())
                {
                    Console.Write("user detail"+db.User_Detail.FirstOrDefault());
                    userdetail = db.User_Detail.Where(u => u.user_name == username && u.password == encrypted ).FirstOrDefault();
                    Console.Write("user detail " + userdetail);
                    if (userdetail != null) {
                        user_status = true;
                   }
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.Write(ex.StackTrace);
            }
            
            return user_status;
        }

    }
}
