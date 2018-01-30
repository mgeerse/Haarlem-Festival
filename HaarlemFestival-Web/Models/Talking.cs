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
        public Interviewee SpeakerOne { get; set; }
        public Interviewee SpeakerTwo { get; set; }
    }
}