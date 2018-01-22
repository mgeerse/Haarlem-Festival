using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFestival_Web.Models
{
    /*
     * A volunteer is responsible for changing the information on the pages.
     * A manager can do this too, but in addition a manager is able to view
     * financial information about the event.
     */
    public enum AccountType
    {
        Manager,
        Volunteer,
    }
}