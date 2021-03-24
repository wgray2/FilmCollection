using IS_413_Assignemnt_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCollection.Models
{
    public interface IMovRepository
    {
        IQueryable<Movie> Movies { get; }

        private static List<Movie> allMovies = new List<Movie>();
        public static IEnumerable<Movie> AllMovies
        {
            get { return allMovies; }
        }
        public static void Delete(Movie movie)
        {
            Movies.Remove(movie);
        }
    }
}
