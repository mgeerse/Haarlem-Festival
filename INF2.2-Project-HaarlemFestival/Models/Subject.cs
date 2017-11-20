using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INF2._2_Project_HaarlemFestival.Models
{
    public class Subject
    {
        public int SubjectId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        //Verwijzing naar Activity
        [ForeignKey("ActivityId")]
        public List<Activity> Activities { get; private set; }

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