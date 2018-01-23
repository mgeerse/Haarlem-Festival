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

        public bool Delete(Jazz objectToDelete)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Jazz> GetAll()
        {
            return context.Jazz;
        }

        public Jazz GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Jazz Insert(Jazz objectToInsert)
        {
            throw new NotImplementedException();
        }

        public Jazz Update(Jazz objectToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}