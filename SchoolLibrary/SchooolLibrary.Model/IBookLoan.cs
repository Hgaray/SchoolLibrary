using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchooolLibrary.Model
{
    public interface IBookLoan
    {
        Task<IEnumerable<SchoolLibrary.DTO.BookLoanDTO>> GetBookLoans();
        Task<SchoolLibrary.VM.BookLoanVM> GetData();
        Task<bool> saveBookLoan(SchoolLibrary.DTO.BookLoanCreateDto bookLoan);
    }
}
