using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission6.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Mission6.Controllers
{
    public class HomeController : Controller
    {
        private MovieFormContext _context;

        public HomeController(MovieFormContext temp) //Constructor
        {
            _context = temp;
        }

        //Pulls up the index
        public IActionResult Index()
        {
            return View();
        }

        //Pulls up the get to know you page
        public IActionResult GetToKnow()
        {
            return View();
        }
        //Get to get the form
        [HttpGet]
        public IActionResult MovieForm()
        {
            ViewBag.Categories = _context.Categories
               .OrderBy(x => x.CategoryName)
               .ToList(); //Get all majors
            return View();
        }

        //Post to put everything from the form to the database
        [HttpPost]
        public IActionResult MovieForm(Movie response)
        {
            if (response.MovieId > 0)
            {
                // This is an edit operation
                _context.Update(response);
            }
            else
            {
                // This is a new application
                _context.Movies.Add(response);
            }
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }

        public IActionResult MovieList()
        {
            //Linq query to get all movies
            var applications = _context.Movies
                .OrderBy(x => x.MovieId).ToList();

            return View(applications);
        }

        //This gets the Movie record and puts it in an application so that we can edit it.
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList(); //Get all majors
            return View("MovieForm", recordToEdit);
        }

        //This is the post that will post the changes to the movie record.
        [HttpPost]
        public IActionResult Edit(Movie updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }

        //This is a delete action. This pulls up the specific record and also the view to confirm the deletion
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        //This actually deletes the movie record when we hit confirm
        [HttpPost]
        public IActionResult Delete(Movie application)
        {
            _context.Movies.Remove(application);
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }
    }
}
