﻿using HaarlemFestival_Web.Contexts;
using HaarlemFestival_Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HaarlemFestival_Web.Repositories
{
    public class ActivityRepository : IRepository<Activity>
    {

        private FestivalContext context = new FestivalContext();

        public bool Delete(Activity objectToDelete)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Activity> GetAll()
        {
            return context.Activities.Include(m => m.Location).Include(m => m.Subject).Include(m => m.Tickets);
        }

        public Activity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Activity Insert(Activity objectToInsert)
        {
            throw new NotImplementedException();
        }

        public Activity Update(Activity objectToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}