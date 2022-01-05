using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchooolLibrary.Model
{
    public interface IBook
    {
        Task<IEnumerable<SchoolLibrary.DTO.BookDto>> GetBooks();

        Task<bool> saveBook(SchoolLibrary.DTO.BookDto book);

        Task<SchoolLibrary.DTO.BookDto> GetBook(int bookId);

        Task<bool> DeleteBook(int bookId);
    }
}
