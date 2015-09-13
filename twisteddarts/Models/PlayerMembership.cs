using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TwistedDarts.Models
{
    public enum Role {Captain, CoCaptain, Player }

    public class PlayerMembership : Membership
    {
        [ForeignKey("Player")]
        public int PlayerID { get; set; }

        public Role Role { get; set; }
        public virtual Person Player { get; set; }
        public virtual ICollection<AllStarPoint> AllStarPoints { get; set; }
    }
}