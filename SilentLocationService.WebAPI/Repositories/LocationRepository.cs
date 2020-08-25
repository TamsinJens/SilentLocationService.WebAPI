using SilentLocationService.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SilentLocationService.Lib.Models;
using SilentLocationService.Lib.DTO;

namespace SilentLocationService.WebAPI.Repositories
{
    public class LocationRepository<T> : Repository<Location>
    {
        public LocationRepository(LocationServiceContext context): base(context)
        {

        }

        public List<LocationSimple> ListSimple()
        {
            return db.Locations.Select(l => new LocationSimple 
            { 
                id = l.Id, 
                name = l.name, 
                backgroundColor = l.backgroundColor,
                turnedOn = l.turnedOn
            })
                .OrderBy(l => l.name)
                .ToList();
        }
    }
}
