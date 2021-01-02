using Microsoft.EntityFrameworkCore;
using NutraZone.Models;

namespace NutraZone.Data
{
    public class NutraZoneDbContext: DbContext
    {
        public NutraZoneDbContext(DbContextOptions<NutraZoneDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersCaloriesCalculated>()
                .Property(o => o.Weight).HasColumnType("decimal(5,3)");

            modelBuilder.Entity<UsersCaloriesCalculated>()
              .Property(o => o.ActivityLevel).HasColumnType("decimal(5,3)");
        }
        public DbSet<RegisterUser> User { get; set; }
        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<UsersCaloriesCalculated> CaloriesCalculated { get; set; }
        
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<GroceryItems> GroceryBag { get; set; }
        public DbSet<BuildPlan> Plan { get; set; }
    }
}
