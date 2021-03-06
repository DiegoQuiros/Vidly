﻿using System;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using Vidly.Models.DTOs;
using System.Data.Entity;
using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.Controllers.API 
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDTO newRental)
        {
            Customer customer = _context.Customers
                .Single(c => c.Id == newRental.CustomerId);

            IEnumerable<Movie> movies = _context.Movies
                .Where(m => newRental.MovieIds.Contains(m.Id))
                .ToList();

            foreach(var movie in movies)
            {
                movie.NumberAvailable--;

                if (movie.NumberAvailable <= 0)
                    return BadRequest("Movie is not available.");

                Rental rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}