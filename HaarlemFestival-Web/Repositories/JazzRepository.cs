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

        public List<Jazz> GetByDay(string Day)
        {
            int _Day = 0;

            //Day omzetten naar een int
            if (Day == "Thursday")
            {
                _Day = 26;
            }
            else if (Day == "Friday")
            {
                _Day = 27;
            }
            else if (Day == "Saturday")
            {
                _Day = 28;
            }
            else if (Day == "Sunday")
            {
                _Day = 29;
            }

            if (_Day == 0)
            {
                //Dag is niet correct
                return new List<Jazz>();
            }

            return context.Jazz.Where(x => (x.StartTime.Day == _Day)).ToList();
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