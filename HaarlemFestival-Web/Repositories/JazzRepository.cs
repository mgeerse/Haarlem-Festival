using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HaarlemFestival_Web.Contexts;
using HaarlemFestival_Web.Models;

namespace HaarlemFestival_Web.Repositories
{
    public class JazzRepository : IRepository<Jazz>
    {
        private FestivalContext context = new FestivalContext();


        private JazzRepository() { }

        public static JazzRepository instance = null;

        public static JazzRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JazzRepository();
                }
                return instance;
            }
        }

        public List<string> GetDays()
        {
            List<string> Days = new List<string>();

            Days.AddRange(
                GetAll().
                Select(x => x.StartTime.ToShortDateString()).Distinct());

            return Days;
        }

        public List<Jazz> GetByDay(string Day)
        {
            return GetAll().Where(x => x.StartTime.ToShortDateString() == Day).ToList();
        }


        public bool Delete(Jazz objectToDelete)
        {
            try
            {
                context.Jazz.Remove(objectToDelete);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Jazz> GetAll()
        {
            try
            {
                return context.Jazz;
            }
            catch (Exception)
            { 
                throw;
            }
        }

        public Jazz GetById(int id)
        {
            try
            {
                return context.Jazz.Single(x => (x.Id == id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Jazz Insert(Jazz objectToInsert)
        {
            try
            {
                context.Jazz.Add(objectToInsert);
                context.SaveChanges();
                return objectToInsert;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Jazz Update(Jazz objectToUpdate)
        {
            try
            {
                Jazz oudObject = context.Jazz.Single(x => (x.Id == objectToUpdate.Id));

                oudObject = objectToUpdate;

                context.SaveChanges();

                return oudObject;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}