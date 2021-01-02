using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutraZone.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public string Aisle { get; set; }
        public string Original { get; set; }
        public int Amount { get; set; }

        public Recipe RecipeInfo { get; set; }



    }
}
