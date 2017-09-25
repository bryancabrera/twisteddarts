using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TwistedDarts.Models
{
    public enum Role { Captain, CoCaptain, Player }
    public enum SkillLevel { Unknown, Beginner, Intermediate, Advanced }

    public class PlayerPhase
    {
        //[Key]
        //[Column(Order =1)]
        public int PlayerPhaseID { get; set; }
        public Role Role { get; set; }
        public SkillLevel SkillLevel { get; set; }

        [Display(Name = "Registration Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }
        [Index("IX_UniquePersonTeamSeason", 3, IsUnique = true)]
        public int TeamID { get; set; }
        public virtual Team Team { get; set; }
        [Index("IX_UniquePersonTeamSeason",1, IsUnique =true)]
        public int PersonID { get; set; }
        public virtual Person Person { get; set; }

        [Index("IX_UniquePersonTeamSeason", 2, IsUnique = true)]
        public int SeasonID { get; set; }
        public virtual Season Season { get; set; }

        public virtual IList<AllStarPoint> AllStarPoints { get; set; }

        //public virtual List<GameResult>GameResults { get; set; }

    }
}