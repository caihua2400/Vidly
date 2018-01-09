using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController:ApiController
    {
        private ApplicationDbContext _context;
        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }
       
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental) {
            var customer = _context.Customers.SingleOrDefault(c=>c.Id==newRental.CustomerId);
            if (customer == null) return BadRequest();
            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();
            if (newRental.MovieIds.Count == 0) return BadRequest("no movie ids is given");
            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0) return BadRequest("Not any movie available");
                movie.NumberAvailable--;
                var rental = new Rental {Customer=customer,Movie=movie,DateRented=DateTime.Now };
                _context.Rentals.Add(rental);
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}