using Microsoft.AspNetCore.Identity;
using System;

namespace NutraZone.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
    }
    public static class ApplicationRoles
    {
        public const string Member = "Member";
        public const string Admin = "Admin";
        //This one is for bonus points from Amanda
        public const string Owner = "ReganDufort";
    }
}
