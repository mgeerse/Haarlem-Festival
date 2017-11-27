using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INF2._2_Project_HaarlemFestival.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //Constructor
        public Subject(int Id, string Name, string Description)
        {
            SubjectId = Id;
            this.Name = Name;
            this.Description = Name;
        }

        public bool changeName(string Name)
        {
            try
            {
                this.Name = Name;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool changeDescription(string Description)
        {
            try
            {
                this.Description = Description;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}