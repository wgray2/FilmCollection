using FilmCollection.Models;
using FilmCollection.Models.ViewModels;
using IS_413_Assignemnt_3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IS_413_Assignemnt_3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //Used for updating the database
        private MovDbContext context { get; set; }
        //
        private IMovRepository _repository;

        public HomeController(ILogger<HomeController> logger, MovDbContext con, IMovRepository repository)
        {
            _logger = logger;
            context = con;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewMovie(Movie movResponse)
        {
            if (ModelState.IsValid)
            {
                //Update database
                
                context.Movies.Add(movResponse);
                context.SaveChanges();

                return View("MoviesListed");
            }
            else
            {
                return View();
            }

        }

        public IActionResult MoviesListed()
        {
            return View(new MovieViewModel
            {
                Movies = _repository.Movies
            });
        }

        public IActionResult EditMovie(int movid)
        {
            Movie movie = _repository.AllMovies.Where(m => m.MovieID == movid)
            
            return View(movie);
        }

        [HttpPost]
        public IActionResult EditMovie(Movie movie)
        {

            context.SaveChanges();
            return View();
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
