using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SilentLocationService.Lib.Models;
using SilentLocationService.WebAPI.Repositories;

namespace SilentLocationService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerCrudBase<Location, LocationRepository<Location>>
    {
        public LocationsController(LocationRepository<Location> locationRepository) : base(locationRepository) 
        { 
        }

        [HttpGet]
        [Route("Simple")]
        public IActionResult GetLocationSimple()
        {
            var locations = repository.ListSimple();
            return Ok(locations);
        }
    }
}