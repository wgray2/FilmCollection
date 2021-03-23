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
    }
}
