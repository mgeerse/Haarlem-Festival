﻿using HaarlemFestival_Web.Contexts;
using HaarlemFestival_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFestival_Web.Repositories
{
    public class WalkingRepository : IRepository<Walking>
    {

        private FestivalContext context = new FestivalContext();

        public bool Delete(Walking objectToDelete)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Walking> GetAll()
        {
            return context.Walking;
        }

        public Walking GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Walking Insert(Walking objectToInsert)
        {
            throw new NotImplementedException();
        }

        public Walking Update(Walking objectToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}