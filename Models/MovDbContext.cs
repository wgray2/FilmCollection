using IS_413_Assignemnt_3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCollection.Models
{
    public class MovDbContext : DbContext
    {
        public MovDbContext(DbContextOptions<MovDbContext> options) : base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
    }
}
