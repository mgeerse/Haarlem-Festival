using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HaarlemFestival_Web.Models.ViewModels
{
    [NotMapped]
    public class SubjectViewModel : Subject
    {
        public SubjectViewModel(string Name, string Description)
        {
            this.Name = Name;
            this.Description = Description;
        }
    }
}