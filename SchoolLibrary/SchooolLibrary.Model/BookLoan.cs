namespace SchooolLibrary.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    [Table("tbBookLoan")]
    public class BookLoan : IBookLoan
    {
        public BookLoan()
        {

        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public virtual Student Student { get; set; }

        [Required]
        public virtual Book Book { get; set; }


        [Required]
        public DateTime DateCheckOut { get; set; }

        [Required]
        public DateTime DateReturn { get; set; }


        public async Task<IEnumerable<SchoolLibrary.DTO.BookLoanDTO>> GetBookLoans()
        {
            var response = new List<SchoolLibrary.DTO.BookLoanDTO>();

            try
            {
                using (var ctx = new SchoolLibraryDBContext())
                {
                    response = await ctx.BookLoan.Select(x =>
                   new SchoolLibrary.DTO.BookLoanDTO()
                   {
                       Id = x.Id,
                       Student = new SchoolLibrary.DTO.StudentDto()
                       {
                           Id = x.Student.Id,
                           Name = x.Student.Name,
                           LastName = x.Student.LastName
                       },
                       Book = new SchoolLibrary.DTO.BookDto()
                       {
                           Id = x.Book.Id,
                           BookTitle = x.Book.BookTitle
                       },
                       DateCheckOut = x.DateCheckOut,
                       DateReturn = x.DateReturn
                   }).ToListAsync();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return response;
        }

        public async Task<SchoolLibrary.VM.BookLoanVM> GetData()
        {
            var response = new SchoolLibrary.VM.BookLoanVM() { BookLoan = new SchoolLibrary.DTO.BookLoanCreateDto() };

            try
            {
                using (var ctx = new SchoolLibraryDBContext())
                {
                    response.Students = await ctx.Student.Select(x =>
                    new SelectListItem()
                    {
                        Value = x.Id.ToString(),
                        Text = x.Name+" "+  x.LastName

                    }).ToListAsync();

                    response.Books = await ctx.Book.Select(x =>
                    new SelectListItem()
                    {

                        Value = x.Id.ToString(),
                        Text = x.BookTitle +" "+x.AuthorName


                    }).ToListAsync();

                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return response;
        }

        public async Task<bool> saveBookLoan(SchoolLibrary.DTO.BookLoanCreateDto bookLoan)
        {
            var response = false;

            try
            {
                using (var ctx = new SchoolLibraryDBContext())
                {
                    var studentDb = ctx.Student.Where(x => x.Id == bookLoan.StudentId).FirstOrDefault();
                    var bookDb = ctx.Book.Where(x => x.Id == bookLoan.BookId).FirstOrDefault();
                    if (studentDb != null && bookDb != null)
                    {
                        ctx.BookLoan.Add(new BookLoan()
                        {
                            Student = studentDb,
                            Book = bookDb,
                            DateCheckOut = bookLoan.DateCheckOut,
                            DateReturn = bookLoan.DateReturn
                        });
                    }
                    await ctx.SaveChangesAsync();
                }

                response = true;

            }
            catch (Exception)
            {

                throw;
            }
            return response;

        }


    }
}
