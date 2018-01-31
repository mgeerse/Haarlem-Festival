using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HaarlemFestival_Web.Models
{
    public class Account
    {
        [Key]
        public int Id { get; private set; }

        [Required(ErrorMessage = "The 'Name' field cannot be empty.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The 'Username' field cannot be empty.")]
        public string Username { get; set; }

        // TODO: Encrypt passwords. Extra points.
        [Required(ErrorMessage = "The 'Password' field cannot be empty.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //[NotMapped]
        //[Compare("Password", ErrorMessage = "Passwords must be equal.")]
        //[DataType(DataType.Password)]
        //public string ConfirmPassword { get; set; }

        public AccountType AccountType { get; set; }
    }
}