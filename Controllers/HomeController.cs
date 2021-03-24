using FilmCollection.Models;
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
        //private MovDbContext context { get; set; }
        //, MovDbContext con
        private IMovRepository _repository;

        public HomeController(ILogger<HomeController> logger, IMovRepository repository)
        {
            _logger = logger;
            //context = con;
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
                
                _repository.AddMovie(movResponse);

                return View("MovieList", movResponse);
            }
            else
            {
                return View();
            }

        }

        public IActionResult MoviesListed()
        {
            return View(_repository.Movies);
        }

        public IActionResult EditMovie(int movid)
        {
            Movie movie = _repository.Movies.Where(m => m.MovieID == movid).FirstOrDefault();
            
            return View(movie);
        }

        [HttpPost]
        public IActionResult EditMovie(Movie movie, int movid)
        {
            _repository.Movies.Where(m => m.MovieID == movid).FirstOrDefault().Title = movie.Title;
            _repository.Movies.Where(m => m.MovieID == movid).FirstOrDefault().Category = movie.Category;
            _repository.Movies.Where(m => m.MovieID == movid).FirstOrDefault().Year = movie.Year;
            _repository.Movies.Where(m => m.MovieID == movid).FirstOrDefault().Director = movie.Director;
            _repository.Movies.Where(m => m.MovieID == movid).FirstOrDefault().Rating = movie.Rating;
            _repository.Movies.Where(m => m.MovieID == movid).FirstOrDefault().Edited = movie.Edited;
            _repository.Movies.Where(m => m.MovieID == movid).FirstOrDefault().LentTo = movie.LentTo;
            _repository.Movies.Where(m => m.MovieID == movid).FirstOrDefault().Notes = movie.Notes;
            _repository.EditMovie(movie);
            return RedirectToAction("MoviesListed");
        }

        [HttpPost]
        public IActionResult DeleteMovie(int movid)
        {
            Movie movie = _repository.Movies.Where(m => m.MovieID == movid).FirstOrDefault();
            _repository.DeleteMovie(movie);
            return RedirectToAction("MoviesListed");
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
