using IS_413_Assignemnt_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCollection.Models
{
    public class EFMovRepository : IMovRepository
    {
        private MovDbContext _context;

        //Constructor
        public EFMovRepository(MovDbContext context)
        {
            _context = context;
        }
        public IQueryable<Movie> Movies => _context.Movies;

        public void AddMovie(Movie mov)
        {
            _context.Add(mov);
            _context.SaveChanges();
        }

        public void DeleteMovie(Movie mov)
        {
            _context.Remove(mov);
            _context.SaveChanges();
        }

        public void EditMovie(Movie mov)
        {
            _context.SaveChanges();
        }

    }
}
