using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HaarlemFestival_Web.Models;

namespace HaarlemFestival_Web.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        private Contexts.FestivalContext context = new Contexts.FestivalContext();

        private CustomerRepository() { }

        public static CustomerRepository instance = null;

        public static CustomerRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CustomerRepository();
                }
                return instance;
            }
        }

        public bool Delete(Customer objectToDelete)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Customer Insert(Customer objectToInsert)
        {
            context.Customers.Add(objectToInsert);
            context.SaveChanges();

            return objectToInsert;
        }

        public Customer Update(Customer objectToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}