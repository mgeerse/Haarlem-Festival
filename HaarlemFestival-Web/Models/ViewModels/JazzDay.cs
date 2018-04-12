using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFestival_Web.Models.ViewModels
{
    public class JazzDay
    {
        public string Date { get; set; }
        public List<Jazz> Jazzs { get; set; }
    }
}