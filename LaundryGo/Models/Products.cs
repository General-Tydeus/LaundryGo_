using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaundryGo.Models
{
    public class Products
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field is required.")]
        [Display(Name = "Name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "The field is required.")]
        public string Price { get; set; }

        public string Availability { get; set; }

        [Display(Name = "User Id")]
        public string UserId { get; set; }


        public Products()
        {

        }
    }
}
