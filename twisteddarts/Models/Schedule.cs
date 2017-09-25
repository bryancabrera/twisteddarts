using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwistedDarts.Models
{
    public enum ScheduleType { RegularSeason = 1, Playoffs = 2 }
    public class Schedule
    {
        public int ScheduleID { get; set; }
        public string ScheduleName { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public ScheduleType ScheduleType { get; set; }

        public int SeasonID { get; set; }
        public virtual Season Season { get; set; }

        //public int ScheduleDateID { get; set; }
        public virtual List<ScheduleDate> ScheduleDates { get; set; }


    }
}