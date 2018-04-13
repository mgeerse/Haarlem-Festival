using HaarlemFestival_Web.Models;
﻿using HaarlemFestival_Web.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace HaarlemFestival_Web.Repositories
{
    public class IntervieweeRepository
    {
        private FestivalContext context = new FestivalContext();

        public Interviewee Update(int id, Interviewee objectToUpdate)
        {
            Interviewee existingInterviewee = context.Interviewees.Where(i => i.Id == id).FirstOrDefault();
            existingInterviewee.Name = objectToUpdate.Name;
            existingInterviewee.Description = objectToUpdate.Description;
            context.SaveChanges();

            return objectToUpdate;
        }

        public List<Interviewee> GetAllInterviewees()
        {
            return context.Interviewees.ToList();
        }

        public Interviewee GetById(int id)
        {
            return context.Interviewees.FirstOrDefault(i => i.Id == id);
        }

        public Interviewee GetByName(string name)
        {
            return context.Interviewees.FirstOrDefault(i => i.Name == name);
        }
    }
}