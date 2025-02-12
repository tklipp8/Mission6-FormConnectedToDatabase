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
            return View();
        }

        //Post to put everything from the form to the database
        [HttpPost]
        public IActionResult MovieForm(Form response)
        {
            _context.Forms.Add(response); //Add record to the database
            _context.SaveChanges(); //Save changes

            //Gives us the confirmation page and passes the response
            return View("Confirmation", response);
        }
    }
}
