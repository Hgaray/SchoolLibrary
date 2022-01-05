using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibrary.DTO
{
    public class BookLoanDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public  StudentDto Student { get; set; }

        [Required]
        public  BookDto Book { get; set; }


        [Required]
        public DateTime DateCheckOut { get; set; } = DateTime.Now;

        [Required]
        public DateTime DateReturn { get; set; } = DateTime.Now;

    }
}
