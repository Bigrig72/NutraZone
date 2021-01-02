using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NutraZone.Models
{
    public class Recipe
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public Classification Diet { get; set; }
        public int ReadyInMinutes  { get; set; }
        public int CookingMinutes { get; set; }
        public int PreparationMinutes { get; set; }
        public int Calories { get; set; }
        public int Protein { get; set; }
        public int Carbs { get; set; }
        public int Fats { get; set; }
        public string Instructions { get; set; }

        [NotMapped]
        public List<string> Diets { get; set; }
        [NotMapped]
        public List<string> Steps { get; set; }

        public List<Ingredient> ListOfIngredients { get; set; }
       // public Ingredient Ingredient { get; set; }
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
