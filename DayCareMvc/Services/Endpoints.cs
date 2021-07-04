using System;

namespace DayCareMvc.Services
{
    public static class Endpoints
    {
        public static string BaseUrl { get; set; } = "http://10.0.0.8:4080/api/v1/svc";
        public static string NotificationUrl { get; set; } = "http://10.0.0.8:4080/api/v1/send";

        public static string SeriesApiUrl(string seriesName)
        {
            try
            {
                return string.Format("https://api.themoviedb.org/3/search/tv?api_key=058cdd6ed66a8efaee56df444b5a8058&language=en-US&page=1&query={0}&include_adult=false", seriesName);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string MoviesApiUrl(string movieName)
        {
            try
            {
                return string.Format("https://api.themoviedb.org/3/search/movie?query=%{0}&api_key=058cdd6ed66a8efaee56df444b5a8058", movieName);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string MovieDetailApi(int moviesId)
        {
            try
            {
                // Todo get movie id information
                return string.Format("https://api.themoviedb.org/3/movie/{0}?api_key=cfe422613b250f702980a3bbf9e90716&language=en-US", moviesId);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static string OtherApiUrl(string movieName)
        {
            try
            {
                // Todo get movie id information
                return string.Format("https://api.themoviedb.org/3/search/movie?query=%{0}&api_key=058cdd6ed66a8efaee56df444b5a8058", movieName);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string OtherApiUrlDemo(string movieName)
        {
            try
            {
                // Todo get movie id information
                return string.Format("https://api.themoviedb.org/3/search/movie?query=%{0}&api_key=058cdd6ed66a8efaee56df444b5a8058", movieName);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string GetMovieUrlCast(int moviesId)
        {
            try
            {
                // Todo get movie id information
                return string.Format("https://api.themoviedb.org/3/movie/{0}/credits?api_key=cfe422613b250f702980a3bbf9e90716&language=en-US", moviesId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
