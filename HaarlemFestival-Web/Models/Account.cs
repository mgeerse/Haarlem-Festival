using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HaarlemFestival_Web.Models
{
    public class Account
    {
        [Key]
        public int Id { get; private set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required")]
        public string Username { get; set; }

        // TODO: Encrypt passwords. Extra points.
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Minimum of 6 characters required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public AccountType AccountType { get; set; }
    }
}