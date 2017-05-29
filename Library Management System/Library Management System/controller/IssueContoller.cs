using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.controller
{
    class IssueContoller
    {

        public Boolean issueBook(Book_Detail book,Member_Detail member,DateTime issueDate, DateTime retrunDate)
        {
            Issue_Detail issueDetail = new Issue_Detail();
            issueDetail.book_id = book.book_id;
            issueDetail.member_id = member.member_id;

            int copies =(int) book.no_of_copies;
            Console.WriteLine("Number of copies now"+copies);
            copies--;
            book.no_of_copies = copies;

            issueDetail.issue_date = issueDate;
            issueDetail.due_date = retrunDate;
                       
            Console.WriteLine("issue book contoller called issue book" + issueDetail);
            
            Boolean status = false;
            try
            {
                using (var db = new ModelDB())
                {

                    db.Issue_Detail.Add(issueDetail);
                    db.SaveChanges();
                    status = true;

                    BookController bookController = new BookController();
                    bookController.updateBook(book);
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
