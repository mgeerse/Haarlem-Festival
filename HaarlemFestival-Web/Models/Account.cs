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

        // Non-referencing properties
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name Required")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Username Required")]
        public string Username { get; set; }

        // TODO: Encrypt passwords. Extra points.
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password Required")]
        [MinLength(6, ErrorMessage = "Minimum of 6 characters required")]
        public string Password { get; set; }

        public AccountType AccountType { get; set; }
    }
}