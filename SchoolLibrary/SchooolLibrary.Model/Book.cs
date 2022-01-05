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

    [Table("tbBook")]
    public class Book : IBook
    {
        public Book()
        {

        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string AuthorName { get; set; }

        [Required]
        public DateTime BirthDateAuthor { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }


        [Required]
        [StringLength(50)]
        public string BookTitle { get; set; }

        [Required]
        public DateTime DateRelease { get; set; }


        public async Task<IEnumerable<SchoolLibrary.DTO.BookDto>> GetBooks()
        {
            var response = new List<SchoolLibrary.DTO.BookDto>();

            try
            {
                using (var ctx = new SchoolLibraryDBContext())
                {
                    response = await ctx.Book.Select(x =>
                   new SchoolLibrary.DTO.BookDto()
                   {
                       Id = x.Id,
                       AuthorName = x.AuthorName,
                       BirthDateAuthor = x.BirthDateAuthor,
                       Country = x.Country,
                       BookTitle = x.BookTitle,
                       DateRelease = x.DateRelease
                   }).ToListAsync();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return response;
        }


        public async Task<bool> saveBook(SchoolLibrary.DTO.BookDto book)
        {


            var response = false;

            try
            {
                using (var ctx = new SchoolLibraryDBContext())
                {
                    var bookDb = ctx.Book.Where(x => x.Id == book.Id).FirstOrDefault();

                    if (bookDb != null)
                    {
                        bookDb.AuthorName = book.AuthorName;
                        bookDb.BirthDateAuthor = book.BirthDateAuthor;
                        bookDb.Country = book.Country;
                        bookDb.BookTitle = book.BookTitle;
                        bookDb.DateRelease = book.DateRelease;
                    }
                    else
                    {
                        ctx.Book.Add(new Book()
                        {
                            AuthorName = book.AuthorName,
                            BirthDateAuthor = book.BirthDateAuthor,
                            Country = book.Country,
                            BookTitle = book.BookTitle,
                            DateRelease = book.DateRelease
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

        public async Task<SchoolLibrary.DTO.BookDto> GetBook(int bookId)
        {
            var response = new SchoolLibrary.DTO.BookDto();

            try
            {
                using (var ctx = new SchoolLibraryDBContext())
                {
                    response = await ctx.Book.Where(x => x.Id == bookId).Select(x =>
                      new SchoolLibrary.DTO.BookDto()
                      {
                          Id = x.Id,
                          AuthorName = x.AuthorName,
                          BirthDateAuthor = x.BirthDateAuthor,
                          Country = x.Country,
                          BookTitle = x.BookTitle,
                          DateRelease = x.DateRelease
                      }).SingleOrDefaultAsync();

                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return response;
        }

        public async Task<bool> DeleteBook(int bookId)
        {
            var response = false;

            try
            {
                using (var ctx = new SchoolLibraryDBContext())
                {
                    var bookDb = ctx.Book.Where(x => x.Id == bookId).FirstOrDefault();
                    ctx.Book.Remove(bookDb);
                    await ctx.SaveChangesAsync();
                    response = true;
                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return response;
        }

    }
}
