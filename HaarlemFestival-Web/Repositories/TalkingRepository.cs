using HaarlemFestival_Web.Contexts;
using HaarlemFestival_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            IEnumerable<Talking> talking = context.Talking.Include(model => model.SpeakerOne).Include(model =>model.SpeakerTwo);
            return talking;
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