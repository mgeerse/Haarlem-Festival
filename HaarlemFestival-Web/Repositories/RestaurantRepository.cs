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


        private RestaurantRepository() { }

        public static RestaurantRepository instance = null;

        public static RestaurantRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RestaurantRepository();
                }
                return instance;
            }
        }

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
            throw new NotImplementedException();
        }
    }
}