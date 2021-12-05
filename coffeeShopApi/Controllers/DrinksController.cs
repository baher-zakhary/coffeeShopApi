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
    public class DrinksController : ControllerBase
    {
        private ApplicationDbContext _dbContext;

        public DrinksController(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dbContext.Drinks.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var drink = _dbContext.Drinks.FirstOrDefault(r => r.Id == id);
            if (drink == null)
            {
                return NotFound();
            }
            return Ok(drink);
        }

        [HttpPost]
        public IActionResult Post(Drink drink)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var newDrink = _dbContext.Drinks.Add(drink);
            _dbContext.SaveChanges();
            return Ok(newDrink);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Drink drink)
        {
            var drinkToUpdate = _dbContext.Drinks.FirstOrDefault(r => r.Id == id);
            if (drinkToUpdate == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            drinkToUpdate.Category = drink.Category;
            drinkToUpdate.Description = drink.Description;
            drinkToUpdate.Image = drink.Image;
            drinkToUpdate.Name = drink.Name;
            drinkToUpdate.Price = drink.Price;
            _dbContext.SaveChanges();
            return Ok(drinkToUpdate);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var drinkToDelete = _dbContext.Drinks.FirstOrDefault(r => r.Id == id);
            if (drinkToDelete == null)
            {
                return NotFound();
            }
            _dbContext.Drinks.Remove(drinkToDelete);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
