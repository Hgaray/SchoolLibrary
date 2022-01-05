using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibrary.VM
{
    public class StudentVM
    {

        public Student student { get; set; }
        public List<Student> students { get; set; }

    }

    public class Student
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
