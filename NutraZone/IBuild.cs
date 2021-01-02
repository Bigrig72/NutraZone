using NutraZone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutraZone
{
    public interface IBuild
    {
        Task AddUsersPersonalCalculatedCaloriePlan(UsersCaloriesCalculated info);
    }
}
