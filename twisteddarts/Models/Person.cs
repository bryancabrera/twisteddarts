using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwistedDarts.Models
{
    public enum Gender { Male, Female}
  
    public class Person
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleInitial { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string MobileNumber { get; set; }
        public string AltNumber { get; set; }
        public string EmailAddress { get; set; }
        public Gender? Gender { get; set; }
        public DateTime DOB { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<AllStarPoint> AllStarPoints { get; set; }

    }
}