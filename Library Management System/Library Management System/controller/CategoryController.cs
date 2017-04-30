using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace Library_Management_System.controller
{
    public class CategoryController
    {
        public Boolean addCategory(Category category)
        {
            Boolean status = false;
            try
            {
                using (var db = new ModelDB())
                {

                    db.Category.Add(category);
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

        public Boolean updateCategory(Category category)
        {
            Boolean status = false;
            try
            {
                using (var db = new ModelDB())
                {

                    db.Category.AddOrUpdate(category);
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
        public Category findCategorybyID(string categoryid)
        {
            Category category= null;
            try
            {
                using (var db = new ModelDB())
                {

                    category = db.Category.Find(categoryid);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            return category;
        }


    }
}
