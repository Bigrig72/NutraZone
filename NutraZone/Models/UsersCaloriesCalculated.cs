using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutraZone.Models
{
    public class UsersCaloriesCalculated
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Age { get; set; }
        public decimal Weight { get; set; }
        public int HeightInCentimeters { get; set; }
        public string Gender { get; set; }
        public string DietType { get; set; }
        public decimal ActivityLevel { get; set; }
        public string TotalCalories { get; set; }


        public RegisterUser UsersInfo { get; set; }
    }
}
