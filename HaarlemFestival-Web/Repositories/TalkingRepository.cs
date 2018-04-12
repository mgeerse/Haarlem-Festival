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

        private TalkingRepository() { }

        public static TalkingRepository instance = null;

        public static TalkingRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TalkingRepository();
                }
                return instance;
            }
        }

        public bool Delete(Talking objectToDelete)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Talking> GetAll()
        {
            IEnumerable<Talking> talking = context.Talking.Include(model => model.SpeakerOne).Include(model => model.SpeakerTwo);
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
            try
            {
                Talking oudObject = context.Talking.Single(x => (x.Id == objectToUpdate.Id));

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