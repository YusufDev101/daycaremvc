using DayCareMvc.HttpService;
using DayCareMvc.Interfaces;
using DayCareMvc.Models;
using Flurl.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DayCareMvc.Repository
{
    public class SeriesRepository : ISeriesRepository
    {
        private List<SeriesModel> SeriesModel = new List<SeriesModel>();

        public SeriesRepository()
        {            
            GetData();
        }

        public SeriesModel Get(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SeriesModel> GetAll()
        {
         
            GetData();
            return SeriesModel;
        }

        public IEnumerable<SeriesModel> GetSummary()
        {
            throw new NotImplementedException();
        }

        private void GetData()
        {
            try
            {
                SeriesModel = new();

                var readAsStringAsync = Endpoints.BaseUrl
                            .PostJsonAsync(new
                            {
                                serviceKey = "api_Movies_v1_List",
                                GenreId = 0
                            }).ReceiveString().Result;

                var ObjResult = JsonConvert.DeserializeObject<SeriesModel>(readAsStringAsync);

                //foreach (SeriesModel item in ObjResult)
                //{
                //    //SeriesModel.Add(new Models.SeriesModel
                //    //{
                //    //    SeriesParentId = item.SeriesParentId,
                //    //    SeriesParentName = item.SeriesParentName,
                //    //    Episodes = "Episodes: " + item.Episodes,
                //    //    Season = "Seasons: " + item.Season,
                //    //    Image = item.ImageUrl,
                //    //    ImdbId = item.ImdbId

                //    //});
                //}
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
