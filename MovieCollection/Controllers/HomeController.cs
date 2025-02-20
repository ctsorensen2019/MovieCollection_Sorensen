using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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





        [HttpGet]
        public IActionResult MovieForm()
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();



            return View("MovieForm", new Application()); // Ensure a model instance is passed to the view
        }



        [HttpPost]
        public IActionResult MovieForm(Application response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);//Add record to the database
                _context.SaveChanges();//Updates changes

                return View("Confirmation", response);//Sends user a confirmation page
            }
            else//Invalid Data
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(c => c.CategoryName)
                    .ToList();

                return View(response);
            }
        }


        public IActionResult EditMovie()
        {
            
            var movies = _context.Movies
                .Select(m => new Application
                {
                    MovieId = m.MovieId,
                    CategoryId = m.CategoryId,
                    Title = m.Title ?? "Unknown", // Ensure Title is never NULL
                    Year = m.Year, // Should not be NULL due to NOT NULL constraint
                    Director = m.Director != null ? m.Director : "Unknown", // Handle NULL safely
                    Rating = m.Rating ?? "Unrated", // Handle NULL safely
                    Edited = m.Edited ?? false, // Prevent NULL boolean issues
                    LentTo = m.LentTo ?? "",
                    CopiedToPlex = m.CopiedToPlex,
                    Notes = m.Notes ?? "",
                    Category = new Category { CategoryName = m.Category.CategoryName } // Ensure CategoryName is loaded
                })
                .AsEnumerable() // Ensures execution before .ToList()
                .ToList();

            return View(movies);
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("MovieForm",recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Application updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("EditMovie");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Application application)
        {
            _context.Movies.Remove(application);
            _context.SaveChanges();

            return RedirectToAction("EditMovie");
        }
    }
}
