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
    public class StudentController : Controller
    {
        #region Private Fields
        private IStudent studentModel;
        #endregion
        #region Constructor
        public StudentController()
        {
            this.studentModel = new SchooolLibrary.Model.Student();
        }

        #endregion
        // GET: Student
        public async Task<ActionResult> Index()
        {
            return View(await this.studentModel.GetStudents());
        }

        [HttpGet]
        [Route("CreateStudent")]
        public async Task<ActionResult> CreateStudent()
        {
            ViewBag.Title = "Create Student";

            return View(new SchoolLibrary.DTO.StudentDto());
        }

        [HttpPost]
        public async Task<ActionResult> SaveStudent(SchoolLibrary.DTO.StudentDto student)
        {
            if (ModelState.IsValid)
            {
                await this.studentModel.saveStudent(student);
                return Redirect("~/Student");
            }
            else
            {
                return View("CreateStudent", student);

            }
        }

        [HttpGet]
        [Route("ModifyStudent")]
        public async Task<ActionResult> ModifyStudent(int studentId)
        {
            try
            {
                var response = await this.studentModel.GetStudent(studentId);
                ViewBag.Title = "Modify Student";
                return View("CreateStudent", response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("DeleteStudent")]
        public async Task<ActionResult> DeleteStudent(int studentId)
        {
            try
            {
                var response = await this.studentModel.DeleteStudent(studentId);
                if (response)
                {
                    return Redirect("~/Student");
                }
                else {
                    return Redirect("~/Student");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        
    }
}