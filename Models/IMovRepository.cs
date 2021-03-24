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

        void AddMovie(Movie mov);
        void DeleteMovie(Movie mov);
        void EditMovie(Movie mov);
    }
}
