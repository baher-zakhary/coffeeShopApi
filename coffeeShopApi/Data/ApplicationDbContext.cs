using coffeeShopApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coffeeShopApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Drink> Drinks { get; set; }

        public DbSet<Reservation> Reservations { get; set; }
    }
}
