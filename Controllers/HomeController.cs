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
        private IMovRepository _repository;

        public HomeController(ILogger<HomeController> logger, IMovRepository repository)
        {
            _logger = logger;
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
                //Add movie, update database, and send the movie object to the MovieList view
                
                _repository.AddMovie(movResponse);

                return View("MovieList", movResponse);
            }
            else
            {
                return View();
            }

        }

        //Displays all movies in the repository on MoviesListed View 
        public IActionResult MoviesListed()
        {
            return View(_repository.Movies);
        }

        //Grabs the correct movie from what the user picked and uses that to populate the fields in edit view
        public IActionResult EditMovie(int movid)
        {
            Movie movie = _repository.Movies.Where(m => m.MovieID == movid).FirstOrDefault();
            
            return View(movie);
        }

        //Updates the attributes for the movie object we're editing and saves it to the database. Then kicks you back to the list of movies
        [HttpPost]
        public IActionResult EditMovie(Movie movie, int MovieID)
        {
            _repository.Movies.Where(m => m.MovieID == MovieID).FirstOrDefault().Category = movie.Category;
            _repository.Movies.Where(m => m.MovieID == MovieID).FirstOrDefault().Title = movie.Title;
            _repository.Movies.Where(m => m.MovieID == MovieID).FirstOrDefault().Year = movie.Year;
            _repository.Movies.Where(m => m.MovieID == MovieID).FirstOrDefault().Director = movie.Director;
            _repository.Movies.Where(m => m.MovieID == MovieID).FirstOrDefault().Rating = movie.Rating;
            _repository.Movies.Where(m => m.MovieID == MovieID).FirstOrDefault().Edited = movie.Edited;
            _repository.Movies.Where(m => m.MovieID == MovieID).FirstOrDefault().LentTo = movie.LentTo;
            _repository.Movies.Where(m => m.MovieID == MovieID).FirstOrDefault().Notes = movie.Notes;
            _repository.EditMovie(movie);
            return RedirectToAction("MoviesListed");
        }


        //Grabs id of the selected movie and uses method to delete the movie. Updates the database and kicks user to list of movies
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
