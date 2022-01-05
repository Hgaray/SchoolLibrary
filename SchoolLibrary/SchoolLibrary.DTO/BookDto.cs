using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibrary.DTO
{
    public class BookDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Author Name")]
        public string AuthorName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Author BirthDate")]
        [Range(typeof(DateTime), "1/1/1500", "1/1/2099", ErrorMessage = "Value for {0} must be between {1} and {2}")]

        public DateTime BirthDateAuthor { get; set; } = DateTime.Now;

        [Required]
        [StringLength(50)]
        [Display(Name = "Author Country")]
        public string Country { get; set; }


        [Required]
        [StringLength(50)]
        [Display(Name = "Book Title")]
        public string BookTitle { get; set; }

        [Required]        
       [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Release Date")]
        [Range(typeof(DateTime), "1/1/1500", "1/1/2099", ErrorMessage = "Value for {0} must be between {1} and {2}")]

        public DateTime DateRelease { get; set; } = DateTime.Now;
    }
}
