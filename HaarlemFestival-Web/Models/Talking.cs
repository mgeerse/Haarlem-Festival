using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaarlemFestival_Web.Models
{
    [Table("Talking")]
    public class Talking : Activity
    {
        public string SpeakerOne { get; set; }
        public string SpeakerTwo { get; set; }
        public string SpeakerOneDescription { get; set; }
        public string SpeakerTwoDescription { get; set; }

    }
}