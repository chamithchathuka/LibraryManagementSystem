namespace Library_Management_System
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelDB : DbContext
    {
        public ModelDB()
            : base("name=ModelDB")
        {
        }

        public virtual DbSet<Book_Detail> Book_Detail { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Issue_Detail> Issue_Detail { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<Member_Detail> Member_Detail { get; set; }
        public virtual DbSet<Return_Book> Return_Book { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<User_Detail> User_Detail { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Detail>()
                .Property(e => e.book_no)
                .IsUnicode(false);

            modelBuilder.Entity<Book_Detail>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<Book_Detail>()
                .Property(e => e.author)
                .IsUnicode(false);

            modelBuilder.Entity<Book_Detail>()
                .Property(e => e.category)
                .IsUnicode(false);

            modelBuilder.Entity<Book_Detail>()
                .Property(e => e.publisher)
                .IsUnicode(false);

            modelBuilder.Entity<Book_Detail>()
                .Property(e => e.language)
                .IsUnicode(false);

            modelBuilder.Entity<Book_Detail>()
                .Property(e => e.isbn)
                .IsUnicode(false);

            modelBuilder.Entity<Book_Detail>()
                .Property(e => e.year)
                .IsUnicode(false);

            modelBuilder.Entity<Book_Detail>()
                .Property(e => e.pages)
                .IsUnicode(false);

            modelBuilder.Entity<Book_Detail>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<Book_Detail>()
                .Property(e => e.available)
                .IsUnicode(false);

            modelBuilder.Entity<Book_Detail>()
                .Property(e => e.price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Book_Detail>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.category1)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.shelf)
                .IsUnicode(false);

            modelBuilder.Entity<Language>()
                .Property(e => e.language1)
                .IsUnicode(false);

            modelBuilder.Entity<Member_Detail>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<Member_Detail>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<Member_Detail>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Member_Detail>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<Type>()
                .Property(e => e.type1)
                .IsUnicode(false);

            modelBuilder.Entity<User_Detail>()
                .Property(e => e.user_name)
                .IsUnicode(false);

            modelBuilder.Entity<User_Detail>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<User_Detail>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<User_Detail>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<User_Detail>()
                .Property(e => e.phone_number)
                .IsUnicode(false);

            modelBuilder.Entity<User_Detail>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<User_Detail>()
                .Property(e => e.type)
                .IsUnicode(false);
        }
    }
}
