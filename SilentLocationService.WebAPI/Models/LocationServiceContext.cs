using Microsoft.EntityFrameworkCore;
using SilentLocationService.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SilentLocationService.WebAPI.Models
{
    public class LocationServiceContext : DbContext
    {
        public LocationServiceContext(DbContextOptions<LocationServiceContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>().HasKey(x => x.Id);
            modelBuilder.Entity<Location>()
                .ToTable("Location")
                .HasData(new Location {
                    Id = 21,
                    backgroundColor = "Blue",
                    coordinates = "51.20839,3.43907",
                    name = "SilentLocation Inc."
                    });
        }
        public DbSet<Location> Locations { get; set; }
    }
}
