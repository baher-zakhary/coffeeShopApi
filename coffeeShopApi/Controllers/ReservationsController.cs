using coffeeShopApi.Data;
using coffeeShopApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coffeeShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private ApplicationDbContext _dbContext;

        public ReservationsController(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

    [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dbContext.Reservations.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var reservation = _dbContext.Reservations.FirstOrDefault(r => r.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }
            return Ok(reservation);
        }

        [HttpPost]
        public IActionResult Post(Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var newReservation = _dbContext.Reservations.Add(reservation);
            _dbContext.SaveChanges();
            return Ok(newReservation);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Reservation reservation)
        {
            var reservationToUpdate = _dbContext.Reservations.FirstOrDefault(r => r.Id == id);
            if (reservationToUpdate == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            reservationToUpdate.Email = reservation.Email;
            reservationToUpdate.Date = reservation.Date;
            reservationToUpdate.Name = reservation.Name;
            reservationToUpdate.Phone = reservation.Phone;
            reservationToUpdate.Time = reservation.Time;
            reservationToUpdate.TotalPeople = reservation.TotalPeople;
            _dbContext.SaveChanges();
            return Ok(reservationToUpdate);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var reservationToDelete = _dbContext.Reservations.FirstOrDefault(r => r.Id == id);
            if (reservationToDelete == null)
            {
                return NotFound();
            }
            _dbContext.Reservations.Remove(reservationToDelete);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
