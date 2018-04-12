using HaarlemFestival_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HaarlemFestival_Web.Contexts;
using System.Data.Entity;

namespace HaarlemFestival_Web.Repositories
{
    public class DiningRepository : IRepository<Dining>
    {

        private FestivalContext context = new FestivalContext();

        private DiningRepository() { }

        public static DiningRepository instance = null;

        public static DiningRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DiningRepository();
                }
                return instance;
            }
        }

        public bool Delete(Dining objectToDelete)
        {
            context.Dining.Remove(objectToDelete);
            return true;
        }

        public IEnumerable<Dining> GetAll()
        {
            return context.Dining
                .Include(m => m.Location)
                .Include(m => m.Subject)
                .Include(m => m.Tickets)
                .Include(m => m.Restaurant);
        }

        public Dining GetById(int id)
        {
            return context.Dining.Find(id);
        }

        public Dining Insert(Dining objectToInsert)
        {
            // context.Dining.Add(objectToInsert);
            throw new NotImplementedException();
        }

        public Dining Update(Dining objectToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}