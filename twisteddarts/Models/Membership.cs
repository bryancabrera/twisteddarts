using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwistedDarts.Models
{
    public enum Role { EstContact, Captain, CoCaptain, Player }
    public class Membership
    {
        public int MembershipID { get; set; }
        public int TeamID { get; set; } 
        public int PersonID { get; set; }
        public Role Role { get; set; }
        public decimal Fee { get; set; }
        public decimal FeeReceived { get; set; }
        public DateTime DateEnrolled { get; set; }
        public DateTime DateResigned { get; set; }
        public Season Season { get; set; }
        public virtual ICollection<AllStarPoint> AllStarPoints { get; set; }
        public virtual Person Person { get; set; }
        public virtual Team Team { get; set; }

    }
}