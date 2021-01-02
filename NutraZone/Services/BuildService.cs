using NutraZone.Data;
using NutraZone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutraZone.Services
{
    public class BuildService //: //IBuild
    {
        private NutraZoneDbContext _context { get; }

        public BuildService(NutraZoneDbContext context)
        {
            _context = context;
        }

        //public Task AddUsersPersonalCalculatedCaloriePlan(UsersCaloriesCalculated info)
        //{
        //    _context.CartItems.Add(CartItem);
        //    await _context.SaveChangesAsync();
        //}
    }
}
