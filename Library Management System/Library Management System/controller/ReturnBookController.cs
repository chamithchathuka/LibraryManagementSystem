using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace Library_Management_System.controller
{
    public class ReturnBookController
    {
        public Boolean addReturnBook(Return_Book returnbook)
        {
            Boolean status = false;
            try
            {
                using (var db = new ModelDB())
                {

                    db.Return_Book.Add(returnbook);
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

        public Boolean updateReturnBook(Return_Book returnbook)
        {
            Boolean status = false;
            try
            {
                using (var db = new ModelDB())
                {

                    db.Return_Book.AddOrUpdate(returnbook);
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

        public List<Return_Book> searchReturnedBook(string constraint, string term, DateTime dob, int bookid, int memberid,DateTime issuedate, DateTime duedate)
        {
            List<Return_Book> returnedBooks = null;

            try
            {
                using (var db = new ModelDB())
                {

                    if (constraint == "book_id")
                    {

                        returnedBooks = db.Return_Book
                       .Where(b => b.book_id == bookid)
                       .ToList();
                    }
                    if (constraint == "member_id")
                    {

                        returnedBooks = db.Return_Book
                       .Where(b => b.member_id == memberid)
                       .ToList();
                    }
                    if (constraint == "issue_date")
                    {

                        returnedBooks = db.Return_Book
                       .Where(b => b.issue_date == issuedate)
                       .ToList();
                    }
                    if (constraint == "due_date")
                    {

                        returnedBooks = db.Return_Book
                       .Where(b => b.due_date == duedate)
                       .ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            return returnedBooks;
        }



    }
}
