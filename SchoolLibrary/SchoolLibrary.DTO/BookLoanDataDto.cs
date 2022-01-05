using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibrary.DTO
{
    public class BookLoanDataDto
    {
        

        public IEnumerable<StudentDto> Students { get; set; }

        public IEnumerable<BookDto> Books { get; set; }
    }
}
