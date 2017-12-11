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
        public DbSet<Account>       Accounts    { get; set; }
        public DbSet<Activity>      Activities  { get; set; }
        public DbSet<Cuisine>       Cuisine     { get; set; }
        public DbSet<Customer>      Customers   { get; set; }
        public DbSet<Dining>        Dining      { get; set; }
        public DbSet<Jazz>          Jazz        { get; set; }
        public DbSet<Location>      Location    { get; set; }
        public DbSet<Subject>       Subjects    { get; set; }
        public DbSet<Talking>       Talking     { get; set; }
        public DbSet<Ticket>        Tickets     { get; set; }
        public DbSet<TourGuide>     TourGuide   { get; set; }
        public DbSet<TourLocation>  TourLocation{ get; set; }
        public DbSet<Walking>       Walking     { get; set; }
    }
}