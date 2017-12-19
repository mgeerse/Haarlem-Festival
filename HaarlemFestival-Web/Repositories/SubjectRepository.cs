using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFestival_Web.Repositories
{
    public class SubjectRepository
    {
        private Contexts.FestivalContext db = new Contexts.FestivalContext();

        public IEnumerable<Models.Subject> GetAllSubjects()
        {
            return db.Subjects;
        }

        public Models.Subject GetSubject(int SubjectId)
        {
            Models.Subject Subject = db.Subjects.Find(SubjectId);
            return Subject;
        }
    }
}