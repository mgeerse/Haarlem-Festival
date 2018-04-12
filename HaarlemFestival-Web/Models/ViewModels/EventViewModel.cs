using HaarlemFestival_Web.Contexts;
using HaarlemFestival_Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFestival_Web.Models.ViewModels
{
    public class EventViewModel
    {
        FestivalContext Db = new FestivalContext();
        public List<Ticket> SoldTickets { get; set; }
        public List<Activity> ActivitiesList { get; set; }

        public EventViewModel()
        {
            SoldTickets = GetAllTickets().OrderBy(o => o.SoldAt).ToList();
            ActivitiesList = GetAllActivities().OrderBy(o => o.StartTime).ToList();
        }

        public string GetSubjectById(int id)
        {
            var obj = Db.Subjects.Where(s => s.Id == id).FirstOrDefault();

            return obj.Name;
        }

        public string GetLocationById(int id)
        {
            var obj = Db.Location.Where(s => s.Id == id).FirstOrDefault();

            return obj.Name;
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            return Db.Tickets.ToList();
        }

        public IEnumerable<Activity> GetAllActivities()
        {
            ActivityRepository ar = ActivityRepository.Instance;

            return ar.GetAll();
        }
    }
}