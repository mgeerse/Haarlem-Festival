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
        public string Name { get; set; }
        public string Username { get; set; }
        // TODO: Encrypt passwords. Extra points.
        public string Password { get; set; }
        public AccountType AccountType { get; set; }
    }
}