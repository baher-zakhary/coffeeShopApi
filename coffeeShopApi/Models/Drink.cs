using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace coffeeShopApi.Models
{
    public class Drink
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [Range(0, float.MaxValue)]
        public float Price { get; set; }

        [Required]
        [StringLength(600)]
        public string Description { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        [StringLength(150)]
        public string Category { get; set; }
    }
}
