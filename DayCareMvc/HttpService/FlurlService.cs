using DayCareMvc.Models;
using Flurl.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DayCareMvc.HttpService
{
    public class FlurlService
    {

        public FlurlService()
        {

        }

        public async Task<MoviesModel> GetMovies(int GenreId)
        {
            try
            {
                var moviesModelList = new List<MoviesModel>();

                var readAsStringAsync = Endpoints.BaseUrl
                                .PostJsonAsync(new
                                {
                                    serviceKey = "api_Movies_v1_List",
                                    GenreId = GenreId
                                }).ReceiveString().Result;

                var ObjResult = JsonConvert.DeserializeObject<MoviesModel>(readAsStringAsync);

                return ObjResult;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
