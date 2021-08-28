using DayCareMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DayCareMvc.Interfaces
{
    public interface ISeriesRepository
    {
        IEnumerable<SeriesModel> GetAll();
        IEnumerable<SeriesModel> GetSummary();
        SeriesModel Get(int Id);
    }
}
