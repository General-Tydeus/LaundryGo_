using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LaundryGo.Models
{
    [NotMapped]
    public class Users
    {
        [Display(Name = "ID")]
        public string Id { get; set; }
        [Display(Name = "Username")]
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string RoleName { get; set; }
    }
}
