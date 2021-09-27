using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Catering.Data
{
    public class FoodItem
    {
        public FoodItem()
        {

        }

        public FoodItem(string description, float unitprice) : this()
        {
            Description = description;
            unitPrice = unitprice;
        }
        public int FoodItemId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public float unitPrice { get; set; }
    }
}
