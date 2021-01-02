using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NutraZone.Models;

namespace ShoeDesignz.Data
{
    public class NutraZoneIdentityContext : IdentityDbContext<ApplicationUser>
    {
        public NutraZoneIdentityContext(DbContextOptions<NutraZoneIdentityContext> options) : base(options)
        {

        }
    }
}