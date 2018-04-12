using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HaarlemFestival_Web.Models;
using HaarlemFestival_Web.Contexts;

namespace HaarlemFestival_Web.Repositories
{
    public class TicketRepository : IRepository<Ticket>
    {
        private FestivalContext db = new FestivalContext();

        public static TicketRepository instance = null;

        private TicketRepository() { }

        public static TicketRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TicketRepository();
                }
                return instance;
            }
        }

        public IEnumerable<Ticket> GetAll()
        {
            return db.Tickets;
        }

        public Ticket GetById(int id)
        {
            return db.Tickets.Single(x => x.Id == id);
        }

        public Ticket Insert(Ticket objectToInsert)
        {
            db.Tickets.Add(objectToInsert);
            db.SaveChanges();

            return objectToInsert;
        }

        //De onderstaande methodes hoeven niet geïmplementeerd te worden
        public bool Delete(Ticket objectToDelete)
        {
            try
            {
                db.Tickets.Remove(objectToDelete);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Ticket Update(Ticket objectToUpdate)
        {
            throw new NotImplementedException();
        }

        public int GetAmountOfOrderedTicketsPerActivity(int ActivityId)
        {
            return db.Tickets.Where(m => m.ActivityId == ActivityId).Count();
        }
    }
}