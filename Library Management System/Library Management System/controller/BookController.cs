using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace Library_Management_System.controller
{
    class BookController
    {
        public Boolean addBook(Book_Detail book) {
            Boolean status = false;
             try
            {
                using (var db = new ModelDB())
                {
                    
                    db.Book_Detail.Add(book);
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

        public Boolean updateBook(Book_Detail book)
        {
            Boolean status = false;
            try
            {
                using (var db = new ModelDB())
                {

                    db.Book_Detail.AddOrUpdate(book);
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

        public Book_Detail findByBookNumber(string book_no)
        {
            Book_Detail bookDetail = null;
            try
            {
                using (var db = new ModelDB())
                {

                    bookDetail =  db.Book_Detail.Find(book_no);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            return bookDetail;
        }

        

        public Book_Detail findByISBN(string isbn)
        {
            Book_Detail bookDetail = null;
            try
            {
                using (var db = new ModelDB())
                {

                    bookDetail = db.Book_Detail.Find(isbn);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            return bookDetail;
        }


        public List<Book_Detail> searchBooks(string constraint, string term,DateTime date)
        {
            List<Book_Detail> bookDetails = null;
            try
            {
                using (var db = new ModelDB())
                {
                    if(constraint == "category") { 
                    bookDetails= db.Book_Detail
                   .Where(b => b.category == term)
                   .ToList();
                    }

                    if (constraint == "date")
                    {
                        bookDetails = db.Book_Detail
                       .Where(b => b.date_added == date)
                       .ToList();
                    }

                    if (constraint == "author")
                    {
                        bookDetails = db.Book_Detail
                       .Where(b => b.author == term)
                       .ToList();
                    }
                    if (constraint == "title")
                    {
                        bookDetails = db.Book_Detail
                       .Where(b => b.title == term)
                       .ToList();
                    }
                    if (constraint == "publisher")
                    {
                        bookDetails = db.Book_Detail
                       .Where(b => b.publisher == term)
                       .ToList();
                    }
                    if (constraint == "language")
                    {
                        bookDetails = db.Book_Detail
                       .Where(b => b.language == term)
                       .ToList();
                    }
                    if (constraint == "isbn")
                    {
                        bookDetails = db.Book_Detail
                       .Where(b => b.isbn == term)
                       .ToList();
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            return bookDetails;
        }

        public Boolean deletebyBookID(int id)
        {
            Boolean status = false;

            try {
                using (var db = new ModelDB())
                {
                    Book_Detail bookdetail = db.Book_Detail.First(b => b.book_id == id);

                    db.Book_Detail.Remove(bookdetail);
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
