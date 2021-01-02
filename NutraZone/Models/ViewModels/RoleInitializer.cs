using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NutraZone.Data;
using NutraZone.Models;
using ShoeDesignz.Data;

namespace ShoeDesignz.Models.ViewModels
{
    public class RoleInitializer
    {
        private static readonly List<IdentityRole> Roles = new List<IdentityRole>()
        {
            new IdentityRole{Name= ApplicationRoles.Member, NormalizedName = ApplicationRoles.Member.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() },
            new IdentityRole{Name = ApplicationRoles.Admin, NormalizedName = ApplicationRoles.Admin.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString()}
        };


        public static void SeedData(IServiceProvider serviceProvider)
        {
            using (var dbContext = new NutraZoneIdentityContext(serviceProvider.GetRequiredService<DbContextOptions<NutraZoneIdentityContext>>()))
            {
                dbContext.Database.EnsureCreated();
                AddRoles(dbContext);
            }
        }
        private static void AddRoles(NutraZoneIdentityContext context)
        {
            if (context.Roles.Any()) return;

            foreach (var role in Roles)
            {
                context.Roles.Add(role);
                context.SaveChanges();
            }
        }
    }
}
