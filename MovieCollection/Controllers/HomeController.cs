using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MovieCollection.Models;
using SQLitePCL;

namespace MovieCollection.Controllers
{
    public class HomeController : Controller
    {
        private MovieFormContext _context;
        public HomeController(MovieFormContext temp)//Constructor
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult KnowJoel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(Application response)
        {
            _context.Applications.Add(response);//Add record to the database
            _context.SaveChanges();

            return View("Confirmation",response);
        }

        //public IActionResult MovieList()
        //{
        //    var applications = _context.Applications
        //        .OrderBy(x => x.FormID).ToList();
        //}

    }
}
