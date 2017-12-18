using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
namespace HaarlemFestival_Web.Models
{
    [Table("Jazz")]
    public class Jazz : Activity
    {
        public string Artist { get; set; }
        public string Hall { get; set; }
        public string ImagePath { get; set; }
    }
}