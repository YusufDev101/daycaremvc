using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DayCareMvc.Models
{
    public class MoviesModel
    {
        public int count { get; set; }
        public Datum[] data { get; set; }
        public bool success { get; set; }

        public class Datum
        {
            public int MoviesId { get; set; }
            public int MovieNo { get; set; }
            public string MovieName { get; set; }
            public string FormattedMovieName { get; set; }
            public string MovieDescription { get; set; }
            public int GenreId { get; set; }
            public string Genre { get; set; }
            public string Image { get; set; }
            public string isHD { get; set; }
            public string MoviesPath { get; set; }
            public string Watched { get; set; }
            public string CreatedOn { get; set; }
        }
    }
}
