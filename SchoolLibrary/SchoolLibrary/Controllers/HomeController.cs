using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchooolLibrary.Model;

namespace SchoolLibrary.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SchooolLibrary.Model.IStudent dbModel = new SchooolLibrary.Model.Student();

            var response = dbModel.GetStudents();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}