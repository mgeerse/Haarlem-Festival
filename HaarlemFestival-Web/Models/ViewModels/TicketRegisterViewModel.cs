using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HaarlemFestival_Web.Models.ViewModels
{
    public class TicketRegisterViewModel
    {
        [Display(Name = "First name")]
        [Required]
        [DataType(DataType.Text)]
        public string Firstname;

        [Display(Name = "Sirname")]
        [Required]
        [DataType(DataType.Text)]
        public string Sirname;

        [Display(Name = "E-mail Address")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email;
    }
}