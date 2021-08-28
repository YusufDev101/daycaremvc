using DayCareMvc.Interfaces;
using DayCareMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace DayCareMvc.Controllers
{
    public class MoviesController: Controller
    {
        private readonly ILogger<MoviesController> _logger;
        private IEnumerable<MovieModel> movieModels;

        public MoviesController(ILogger<MoviesController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index([FromServices] IMoviesRepository moviesRepository)
        {
            ViewBag.MovieSummaryObject = moviesRepository.GetAll();
            return View();
        }
    }
}
