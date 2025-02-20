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

        public IActionResult Index() //Home Page
        {
            return View();
        }

        public IActionResult KnowJoel() //Get to Know Joel Page
        {
            return View();
        }

        public IActionResult EditMovie()
        {
            // Assuming _context is your DbContext with a DbSet<Application> named Applications
            var applications = _context.Applications.ToList();
            return View(applications);
        }


        [HttpGet]
        public IActionResult MovieForm() //Add Movie Form
        {
            return View();
        }



        [HttpPost]
        public IActionResult MovieForm(Application response)
        {
            _context.Applications.Add(response);//Add record to the database
            _context.SaveChanges();//Updates changes

            return View("Confirmation",response);//Sends user a confirmation page
        }

    }
}
