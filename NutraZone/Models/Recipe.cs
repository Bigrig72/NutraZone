using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NutraZone.Models
{
    public class Recipe
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public Classification Diet { get; set; }
        public string PrepTime { get; set; }
        public int Calories { get; set; }
        public int Protein { get; set; }
        public int Carbs { get; set; }
        public int Fats { get; set; }
        public string PrepInstructions { get; set; }
        public List<Ingredients> Ingredients { get; set; }
    }

    public enum Classification
    {
        Keto = 1,
        Paleo,
        [Display(Name = "Low Carb")]
        LowCarb,
        [Display(Name = "High Carb")]
        HighCarb,
        Performance,
        Vegan,
        mediterranean
    }
}
