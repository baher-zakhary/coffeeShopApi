using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace coffeeShopApi.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [Phone]
        public int Phone { get; set; }
        
        [Required]
        public int TotalPeople { get; set; }
        
        [Required]
        public DateTime Date { get; set; }
        
        [Required]
        [DataType(DataType.Time)]
        public string Time { get; set; }
    }
}
