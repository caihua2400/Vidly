using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        // GET: Movies/Random
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index() {
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");
            else return View("ReadOnlyList");
        }
        [Route("Movies/Details/{id}")]
        public ActionResult Details(int id) {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
            if (movie == null) return HttpNotFound();
            return View(movie);
        }
        [Authorize(Roles =RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel {Genres=genres };
            return View("MovieForm",viewModel);
        }


        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Single(m=>m.Id==id);
            if (movie == null) return HttpNotFound();
            var viewModel = new MovieFormViewModel { Movie = movie, Genres = _context.Genres.ToList() };
            return View("MovieForm", viewModel);
        }


        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
        public ActionResult Random()
        {

            var movie = new Movie() {Name="Shrek" };
            var customers = new List<Customer> {
                new Customer{Name="Customer 1" },new Customer{ Name="Customer 2"}
            };
            var viewModel = new RandomMovieViewModel() { Movie=movie,Customers=customers};
            return View(viewModel);
        }
        
        

        
        
    }
}