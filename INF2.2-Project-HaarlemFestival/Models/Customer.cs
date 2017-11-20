using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INF2._2_Project_HaarlemFestival.Models
{
    public class Customer
    {
        public int CustomerId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Address { get; private set; }
        public string EmailAddress { get; private set; }
        public string Country { get; private set; }

        //Constructor:
        public Customer(int CustomerId, string FirstName, string LastName, string Address, string EmailAddress, string Country)
        {
            this.CustomerId = CustomerId;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Address = Address;
            this.EmailAddress = EmailAddress;
            this.Country = Country;
        }

        //TODO: Hier methodes om properties binnen dit object te wijzigen:
        //....
    }
}