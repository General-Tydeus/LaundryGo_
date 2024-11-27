using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaundryGo.Models
{
    public class Shop
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field is required.")]
        [Display(Name = "Shop Name")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The field is required.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "The field is required.")]
        [Display(Name = "Latitude")]
        public string Coord_lat { get; set; }

        [Required(ErrorMessage = "The field is required.")]
        [Display(Name = "Longitude")]
        public string Coord_long { get; set; }

        [Display(Name = "User Id")]
        public string UserId { get; set; }

        [Display(Name = "Status")]
        public int Approve { get; set; }

        public Shop()
        {

        }
    }
}
