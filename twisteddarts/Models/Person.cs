using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TwistedDarts.Models
{
    public enum Gender { Male, Female }

    public class Person
    {
        public int PersonID { get; set; }
        [Display(Name = "First Name")]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [DataType(DataType.Text)]
        [StringLength(50)]
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
        //public int AddressID { get; set; }
        public bool IsApproved { get; set; } = false;
        public virtual IList<Address> Addresses { get; set; }

        //public virtual ICollection<Team> Teams { get; set; }
        //public virtual ICollection<AllStarPoint> AllStarPoints { get; set; }

        //internal Person() { }
        //public Person(string firstName, string lastName)
        //{
        //    this.FirstName = firstName;
        //    this.LastName = lastName;
        //}
        [DisplayName("Name")]
        public string FullName => $"{this.FirstName} {this.LastName}";
    }
}