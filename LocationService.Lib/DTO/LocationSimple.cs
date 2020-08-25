using System.ComponentModel.DataAnnotations;

namespace SilentLocationService.Lib.DTO
{
    public class LocationSimple
    {
        public int id { get; set; }

        [Display(Name = "Name: "),Required(ErrorMessage = "Name is required.")]
        public string name { get; set; }

        [Display(Name = "Color: "), Required(ErrorMessage = "Color is required")]
        public string backgroundColor { get; set; }

        [Display(Name = "Turned on: "), Required]
        public bool turnedOn { get; set; }
    }
}
