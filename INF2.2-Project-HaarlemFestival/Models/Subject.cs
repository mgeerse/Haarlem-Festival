using System;
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

        //Constructor
        public Subject(int Id, string Name, string Description)
        {
            SubjectId = Id;
            this.Name = Name;
            this.Description = Name;
        }
    }
}