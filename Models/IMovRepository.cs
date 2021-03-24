using IS_413_Assignemnt_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCollection.Models
{
    //Set up movie repository with voided methods for adding, deleting, and editing movies. This is made so our repository can access it in the controller
    public interface IMovRepository
    {
        IQueryable<Movie> Movies { get; }

        void AddMovie(Movie mov);
        void DeleteMovie(Movie mov);
        void EditMovie(Movie mov);
    }
}
