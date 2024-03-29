﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HaarlemFestival_Web.Models;
using HaarlemFestival_Web.Contexts;

namespace HaarlemFestival_Web.Repositories
{
    public class SubjectRepository : IRepository<Subject>
    {
        private FestivalContext context = new FestivalContext();

        private SubjectRepository() { }

        public static SubjectRepository instance = null;

        public static SubjectRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SubjectRepository();
                }
                return instance;
            }
        }

        /// <summary>
        /// Deletes the given instance from the database.
        /// </summary>
        /// <param name="objectToDelete"></param>
        /// <returns></returns>
        public bool Delete(Subject objectToDelete)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns all existing Subject instances in the database.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Subject> GetAll()
        {
            return context.Subjects.ToList();
        }

        /// <summary>
        /// Searches the Subject instance with the given Id and returns it. 
        /// </summary>
        /// <param name="id">Id of instance to search</param>
        /// <returns>The subject with the given Id. Returns <code>null</code> if none are found.</returns>
        public Subject GetById(int id)
        {
            return context.Subjects.FirstOrDefault(s => s.Id == id);
        }

        public Subject GetByName(string name)
        {
            return context.Subjects.FirstOrDefault(s => s.Name == name) as Subject;
        }

        public Subject Insert(Subject objectToInsert)
        {
            throw new NotImplementedException();
        }

        public Subject Update(int id, Subject objectToUpdate)
        {
            Subject existingSubject = context.Subjects.Where(s => s.Id == id).FirstOrDefault();
            existingSubject.Name = objectToUpdate.Name;
            existingSubject.Description = objectToUpdate.Description;
            context.SaveChanges();

            return objectToUpdate;
        }

        public Subject Update(Subject objectToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}