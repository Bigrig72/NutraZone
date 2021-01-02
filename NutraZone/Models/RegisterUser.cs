using System;
using System.ComponentModel.DataAnnotations;

namespace NutraZone.Models
{
    public class RegisterUser
    {
        public int RegisterUserId { get; set; }
        public int GroceryBagId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation do not match")]
        public string ConfirmPassword { get; set; }

        //public GroceryBag PersonalGroceryBag { get; set; }
    }
}
