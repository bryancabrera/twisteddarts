using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TwistedDarts.Models
{
    public enum Gender { Male, Female}
  
    public class Person
    {
        public int PersonID { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength (50)]
        public string LastName { get; set; }
        [StringLength(1)]
        public string MiddleInitial { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RegistrationDate { get; set; }
        [DisplayFormat]
        public string ContactNumber { get; set; }
        public string AltNumber { get; set; }
        public string EmailAddress { get; set; }
        public Gender? Gender { get; set; }
        public DateTime? DOB { get; set; }
        public Address Address { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<AllStarPoint> AllStarPoints { get; set; }

    }
}