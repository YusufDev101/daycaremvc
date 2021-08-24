using DayCareMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DayCareMvc.Interfaces
{
    public interface IMoviesRepository
    {
        IEnumerable<MovieModel> GetAll();
        IEnumerable<MovieModel> GetSummary();
        MovieModel Get(int Id);
    }
}
