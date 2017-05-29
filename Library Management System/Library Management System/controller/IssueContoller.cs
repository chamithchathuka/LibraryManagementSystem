using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.controller
{
    class IssueContoller
    {

        public Boolean issueBook(Book_Detail book,Member_Detail member,DateTime issueDate, int daysToReturn)
        {
            Issue_Detail issueDetail = new Issue_Detail();
            Boolean status = false;
            try
            {
                using (var db = new ModelDB())
                {

                    db.Issue_Detail.Add(issueDetail);
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
    }
}
