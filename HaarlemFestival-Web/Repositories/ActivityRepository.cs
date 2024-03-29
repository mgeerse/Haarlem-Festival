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

        private ActivityRepository() { }

        public static ActivityRepository instance = null;

        public static ActivityRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ActivityRepository();
                }
                return instance;
            }
        }

        public bool Delete(Activity objectToDelete)
        {
            try
            {
                context.Activities.Attach(objectToDelete);
                context.Activities.Remove(objectToDelete);
                context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Activity> GetAll()
        {
            return context.Activities.Include(m => m.Location).Include(m => m.Subject).Include(m => m.Tickets);
        }

        public Activity GetById(int id)
        {
            return context.Activities.FirstOrDefault(a => a.Id == id);
        }

        public Activity Insert(Activity objectToInsert)
        {
            context.Activities.Add(objectToInsert);
            context.SaveChanges();

            return objectToInsert;
        }

        public Activity Update(int id, Activity objectToUpdate)
        {
            Activity existingActivity = context.Activities.Where(a => a.Id == id).FirstOrDefault();
            existingActivity.Name = objectToUpdate.Name;
            existingActivity.Description = objectToUpdate.Description;
            existingActivity.Capacity = objectToUpdate.Capacity;
            existingActivity.Price = objectToUpdate.Price;
            existingActivity.StartTime = objectToUpdate.StartTime;
            existingActivity.EndTime = objectToUpdate.EndTime;
            context.SaveChanges();

            return objectToUpdate;
        }

        public Activity Update(Activity objectToUpdate)
        {
            throw new NotImplementedException();
        }

        public int GetLastId()
        {
            return context.Activities.Last().Id;
        }
    }
}