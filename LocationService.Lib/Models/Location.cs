﻿using System.ComponentModel.DataAnnotations;

namespace SilentLocationService.Lib.Models
{
    public class Location : EntityBase
    {
        [Display(Name = "Name: "),Required(ErrorMessage = "Name is required.")]
        public string name { get; set; }
        public string description { get; set; }
        [Display(Name = "Coördinates: "),Required(ErrorMessage = "No coördinates found")]
        public string coordinates { get; set; }

        [Display(Name = "Color: "), Required(ErrorMessage = "Color is required")]
        public string backgroundColor { get; set; }

        [Display(Name = "Phone on silent: "), Required(ErrorMessage = "No coördinates found")]
        public bool silent { get; set; }

        [Display(Name = "Phone on vibrate: "), Required]
        public bool vibrate { get; set; }

        [Display(Name = "Bluetooth off: "), Required]
        public bool bluetoothOff { get; set; }

        [Display(Name = "Turned on: "), Required]
        public bool turnedOn { get; set; }
    }
}
