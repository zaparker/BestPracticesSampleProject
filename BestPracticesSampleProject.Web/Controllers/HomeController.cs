using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BestPracticesSampleProject.Web.Controllers
{
    /// <summary>
    /// MVC controller for retrieving the home page of the site.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Returns the home page of the site.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
