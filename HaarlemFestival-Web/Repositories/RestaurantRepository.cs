using HaarlemFestival_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HaarlemFestival_Web.Contexts;
using System.Data.Entity;

namespace HaarlemFestival_Web.Repositories
{
    public class RestaurantRepository : IRepository<Restaurant>
    {

        private FestivalContext context = new FestivalContext();

        public bool Delete(Restaurant objectToDelete)
        {
            context.Restaurants.Remove(objectToDelete);
            return true;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return context.Restaurants;
        }

        public Restaurant GetById(int id)
        {
            return context.Restaurants.Find(id);
        }

        public Restaurant Insert(Restaurant objectToInsert)
        {
            // context.Restaurant.Add(objectToInsert);
            throw new NotImplementedException();
        }

        public Restaurant Update(Restaurant objectToUpdate)
        {
            try
            {
                Restaurant oudObject = context.Restaurants.Single(x => (x.Id == objectToUpdate.Id));

                oudObject = objectToUpdate;

                context.SaveChanges();

                return objectToUpdate;
            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}