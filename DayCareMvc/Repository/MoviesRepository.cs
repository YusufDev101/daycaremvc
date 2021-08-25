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
    public class MoviesRepository: IMoviesRepository
    {
        private List<MovieModel> MovieModel = new List<MovieModel>();

        public MoviesRepository()
        {            
            GetData();
        }

        public MovieModel Get(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MovieModel> GetAll()
        {
            GetData();
            return MovieModel;
        }

        public IEnumerable<MovieModel> GetSummary()
        {
            throw new NotImplementedException();
        }

        private void GetData()
        {
            try
            {
                MovieModel = new();

                var readAsStringAsync = Endpoints.BaseUrl
                            .PostJsonAsync(new
                            {
                                serviceKey = "api_Movies_v1_List",
                                GenreId = 0
                            }).ReceiveString().Result;

                var ObjResult = JsonConvert.DeserializeObject<MoviesModel>(readAsStringAsync);

                foreach (var item in ObjResult.data)
                {
                    MovieModel.Add(new Models.MovieModel
                    {
                        //count = ObjResult.count,
                        CreatedOn = item.CreatedOn,
                        FormattedMovieName = item.FormattedMovieName,
                        Genre = item.Genre,
                        Image = item.Image,
                        GenreId = item.GenreId,
                        isHD = item.isHD,
                        MovieDescription = item.MovieDescription,
                        MoviesId = item.MoviesId,
                        MovieName = item.MovieName,
                        MovieNo = item.MovieNo,
                        MoviesPath = item.MoviesPath,
                        Watched = item.Watched,

                    });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
