using System;
using System.Collections.Generic;
using System.Web.Helpers;
using System.Web.Mvc;
using Craig.Extensions;
using Craig.Models.Movies;
using Craig.Settings;
using Movies;

namespace Craig.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieRepository _moviesRepository;
        private readonly PageSize _pageSize;

        public MoviesController(IMovieRepository movieRepository, PageSize pageSize)
        {
            _moviesRepository = movieRepository;
            _pageSize = pageSize;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _Movies(string sortColumn = "Title", SortDirection sortDirection = SortDirection.Ascending , int page = 1)
        {
            var allMovies = _moviesRepository
                .GetAll();

            var movies = AutoMapper.Mapper.Map<List<Movie>, List<MovieModel>>(allMovies);
            var model = new MoviesModel
            {
                Movies = movies
                    .Sort(sortDirection, sortColumn)
                    .ApplyPaging(_pageSize, page),
                NumberOfPages = allMovies.NumberOfPages(_pageSize),
                Page = page,
                SortDirection = sortDirection,
                SortColumn = sortColumn
            };

            return PartialView(model);
        }

        public ActionResult _Movie(int movieId)
        {
            var movie = _moviesRepository.GetById(movieId);
            var model = AutoMapper.Mapper.Map<Movie, MovieDetailModel>(movie);
            return PartialView(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateModel model)
        {
            var movie = AutoMapper.Mapper.Map<CreateModel, Movie>(model);

            try
            {
                _moviesRepository.Create(movie);
                return RedirectToAction("Index").WithSuccess("Movie created", this);
            }
            catch (Exception)
            {
                return RedirectToAction("Create").WithError("Failed to create movie", this);
            }
        }
	}
}