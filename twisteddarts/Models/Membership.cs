using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwistedDarts.Models
{
    public enum MembershipType { Player, Establishment }
    public abstract class Membership
    {
        public int MembershipID { get; set; }
        public int TeamID { get; set; }
        // public int EstablishmentID { get; set; }
        
        public decimal Fee { get; set; }
        public bool IsCurrent { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:MM-dd-yyyy}",ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }
        public bool IsActive { get; set; }
        public Season Season { get; set; }

        //public virtual Establishment Establishment { get; set; }
        public virtual Team Team { get; set; }

    }
}