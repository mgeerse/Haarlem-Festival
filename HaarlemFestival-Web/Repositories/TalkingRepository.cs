using HaarlemFestival_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HaarlemFestival_Web.Contexts;
using System.Data.Entity;

namespace HaarlemFestival_Web.Repositories
{
    public class TalkingRepository : IRepository<Talking>
    {
        private FestivalContext context = new FestivalContext();

        public bool Delete(Talking objectToDelete)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Talking> GetAll()
        {
            return context.Talking;
        }

        public Talking GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Talking Insert(Talking objectToInsert)
        {
            throw new NotImplementedException();
        }

        public Talking Update(Talking objectToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}