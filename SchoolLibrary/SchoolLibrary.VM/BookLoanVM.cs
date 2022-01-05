using SchoolLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SchoolLibrary.VM
{
    public class BookLoanVM
    {
        public BookLoanCreateDto BookLoan { get; set; }

        public List<SelectListItem> Students { get; set; }

        public List<SelectListItem> Books { get; set; }
    }
}
