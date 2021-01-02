using System.Collections.Generic;

namespace NutraZone.Models
{
    public class GroceryItems
    {
        public int ID { get; set; }       
        public int Quantity { get; set; }


        public List<Ingredient> Ingredients { get; set; }
    }
}
