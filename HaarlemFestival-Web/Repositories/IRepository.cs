using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFestival_Web.Repositories
{
    /// <summary>
    /// Interface for interacting with the database. 
    /// </summary>
    /// <typeparam name="T">The type that gets collected from the database.</typeparam>
    public interface IRepository<T>
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        T Update(T objectToUpdate);
        bool Delete(T objectToDelete);
        T Insert(T objectToInsert);
    }
}