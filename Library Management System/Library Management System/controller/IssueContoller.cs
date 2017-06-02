using Library_Management_System;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Library_Management_System.controller
{
    class IssueContoller
    {

        public Boolean issueBook(Book_Detail book, Member_Detail member, DateTime issueDate, DateTime retrunDate)
        {
            Issue_Detail issueDetail = new Issue_Detail();
            issueDetail.book_id = book.book_id;
            issueDetail.member_id = member.member_id;

            int copies = (int)book.no_of_copies;
            Console.WriteLine("Number of copies now" + copies);
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
                Console.WriteLine("issue error "+ex.InnerException);
            }
            return status;
        }

        public List<Issue_Detail> getReturnBookDetail(int memberID)
        {
            List<Issue_Detail> issueBookDetail = null;
            Console.WriteLine("getReturnBookDetail called");
            try
            {
                using (var db = new ModelDB())
                {

                    issueBookDetail = db.Issue_Detail
                    .Where(returnbook => returnbook.member_id == memberID & returnbook.return_date == null)
                    .ToList();
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("get return book details "+ex.InnerException);
            }
            return issueBookDetail;
        }

        public List<Issue_Detail> loadIssuedBooks()
        {
            List<Issue_Detail> issues = new List<Issue_Detail>();

            try
            {
                using (var db = new ModelDB())
                {

                    var query = from issue in db.Issue_Detail select new { issue.book_id, issue.due_date };
                    var list = query.ToList();

                    foreach (var detail in list) {
                        int? num  = detail.book_id;
                        DateTime? datetime =  detail.due_date;

                        Console.WriteLine("number ");

                        Issue_Detail issueD = new Issue_Detail();
                        issueD.due_date = datetime;
                        issueD.book_id = num;

                        issues.Add(issueD);
                    }


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Load exception"+ex.InnerException);
            }

            return issues;
       }

        public Boolean bookReturnedUpdate(Issue_Detail issue)
        {

            BookController bookController = new BookController();
            int bookID = (int) issue.book_id;
            Book_Detail book = bookController.findByBookID(bookID);
            int noOfCopies = (int) book.no_of_copies;

            book.no_of_copies = ++noOfCopies;
            Console.Write("just before the update");
            bookController.updateBook(book);

            Console.WriteLine("Issue ID" +issue.issue_id);
            Boolean status = false;
            try
            {
                using (var db = new ModelDB())
                {

                   
                   
                    DateTime issueD = (DateTime) issue.return_date;
                    Console.WriteLine("Details " + issueD);

                    db.Entry(issue).State = EntityState.Modified;

                    db.Issue_Detail.Attach(issue);
              
                 
                    Console.WriteLine("data is updated" +db.SaveChanges());

                    status = true;


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Book return update error " + ex.InnerException);
            }
            return status;
        }


    }
}
