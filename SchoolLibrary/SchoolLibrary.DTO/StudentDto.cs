using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibrary.DTO
{
    public class StudentDto
    {

        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Student Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Student Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(10)]
        public string Identification { get; set; }

        [Required]
        [StringLength(100)]
        public string Program { get; set; }
    }
}
