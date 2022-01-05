using SchoolLibrary.DTO;
using SchoolLibrary.VM;
using SchooolLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SchoolLibrary.Controllers
{
    public class BookLoanController : Controller
    {
        #region Private Fields
        private IBookLoan bookLoanModel;
        private BookLoanVM bookLoanVM;
        #endregion
        #region Constructor
        public BookLoanController()
        {
            this.bookLoanModel = new SchooolLibrary.Model.BookLoan();
            this.bookLoanVM = new BookLoanVM() { BookLoan = new BookLoanCreateDto() };
        }

        #endregion
        // GET: BookLoan
        public async Task<ActionResult> Index()
        {


            return View(await this.bookLoanModel.GetBookLoans());
        }

        [HttpGet]
        [Route("CreateBookLoan")]
        public async Task<ActionResult> CreateBookLoan()
        {
            ViewBag.Title = "Create Book Loan";
            
            this.bookLoanVM = await this.bookLoanModel.GetData();

            return View(this.bookLoanVM);
        }

        [HttpPost]
        public async Task<ActionResult> SaveBookLoan(BookLoanCreateDto bookLoan, IEnumerable<SelectListItem> students)
        {
            if (ModelState.IsValid)
            {
                await this.bookLoanModel.saveBookLoan(bookLoan);
                return Redirect("~/BookLoan");
            }
            else
            {
                this.bookLoanVM= await this.bookLoanModel.GetData();
                this.bookLoanVM.BookLoan = bookLoan;

                return View("CreateBookLoan", this.bookLoanVM);

            }

        }
    }
}