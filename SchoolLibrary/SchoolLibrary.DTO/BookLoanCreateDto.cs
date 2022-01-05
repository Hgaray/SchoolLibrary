using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SchoolLibrary.DTO
{
    public class BookLoanCreateDto
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please Select Student")]
        public int StudentId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please Select Book")]
        public int  BookId { get; set; }

        [Required]
        [Range(typeof(DateTime), "1/1/1500", "1/1/2099", ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime DateCheckOut { get; set; } = DateTime.Now;

        [Required]
        [Range(typeof(DateTime), "1/1/1500", "1/1/2099", ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime DateReturn { get; set; } = DateTime.Now;
    }
}
