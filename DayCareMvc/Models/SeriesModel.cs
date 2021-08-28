using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DayCareMvc.Models
{
    public class SeriesModel
    {
        public int SeriesParentId { get; set; }
        public string SeriesParentName { get; set; }
        public string Episodes { get; set; }
        public string Season { get; set; }
        public string Image { get; set; }
        public int ImdbId { get; set; }
    }
}
