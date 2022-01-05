using SchooolLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SchoolLibrary.Controllers
{
    public class BookController : Controller
    {
        #region Private Fields
        private IBook bookModel;
        #endregion
        #region Constructor
        public BookController()
        {
            this.bookModel = new SchooolLibrary.Model.Book();
        }

        #endregion
        // GET: Book
        public async Task<ActionResult> Index()
        {
            
            return View(await this.bookModel.GetBooks());
        }

        [HttpGet]
        [Route("CreateBook")]
        public async Task<ActionResult> CreateBook()
        {
            ViewBag.Title = "Create Book";

            return View(new SchoolLibrary.DTO.BookDto());
        }

        [HttpPost]
        public async Task<ActionResult> SaveBook(SchoolLibrary.DTO.BookDto book)
        {
            if (ModelState.IsValid)
            {
                await this.bookModel.saveBook(book);
                return Redirect("~/Book");
            }
            else
            {
                return View("CreateBook", book);

            }
        }

        [HttpGet]
        [Route("ModifyBook")]
        public async Task<ActionResult> ModifyBook(int bookId)
        {
            try
            {
                var response = await this.bookModel.GetBook(bookId);
                ViewBag.Title = "Modify Book";
                return View("CreateBook", response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("DeleteBook")]
        public async Task<ActionResult> DeleteBook(int bookId)
        {
            try
            {
                var response = await this.bookModel.DeleteBook(bookId);
                if (response)
                {
                    return Redirect("~/Book");
                }
                else
                {
                    return Redirect("~/Book");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}