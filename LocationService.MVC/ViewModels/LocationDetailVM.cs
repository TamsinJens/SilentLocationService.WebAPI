using LocationService.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SilentLocationService.WebAPI.ViewModels
{
    public class LocationDetailVM
    {
        public LocationDetail LocationDetail { get; set; }
    }

    public enum Color
    {
        Blue,
        Red,
        Orange,
        Green,
    }
}
