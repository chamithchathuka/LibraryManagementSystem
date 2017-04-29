using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Management_System.Util;

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

                    db.User_Detail.Add(userDetail);
                    db.SaveChanges();
                    status = true;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            return status;
        }

        public User_Detail checkUserLogin(string username,string password) {

            string encrypted = EncryptionUtil.ToSHA256(password);
            User_Detail userdetail = null;
            try
            {
                using (var db = new ModelDB())
                {
                    userdetail = db.User_Detail
                        .FirstOrDefault(u => u.email == username
                        && u.password == encrypted);
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.Write(ex.StackTrace);
            }
            
            return userdetail;
        }

    }
}
