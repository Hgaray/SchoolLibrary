using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SchooolLibrary.Model
{
    public partial class SchoolLibraryDBContext : DbContext
    {
        public SchoolLibraryDBContext()
            : base("name=SchoolLibraryDBContext")
        {
        }

        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<BookLoan> BookLoan { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Student>()
                .Property(e => e.LastName)
                .IsFixedLength();

            modelBuilder.Entity<Student>()
                .Property(e => e.Identification)
                .IsFixedLength();

            modelBuilder.Entity<Student>()
                .Property(e => e.Program)
                .IsFixedLength();
        }
    }
}
