using HaarlemFestival_Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HaarlemFestival_Web.Contexts
{
    public class FestivalContext : DbContext
    {
        public DbSet<Account>   Accounts    { get; set; }
        public DbSet<Activity>  Activities  { get; set; }
        public DbSet<Customer>  Customers   { get; set; }
        public DbSet<Subject>   Subjects    { get; set; }
        public DbSet<Ticket>    Tickets     { get; set; }
    }
}