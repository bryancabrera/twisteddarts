using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwistedDarts.Models

{
    
    public enum AllStarPointName { HighOn, HighOff, HighPoints, RoundOf, Corks }
    public class AllStarPoint

    {
        public int AllStarPointID { get; set; }
        public AllStarPointName AllStarPointName { get; set; }
        public int Value { get; set; }

        public GameCategory PointType
        {
            get
            {

                switch (this.AllStarPointName)
                {
                    case AllStarPointName.HighOff:
                    case AllStarPointName.HighOn:
                    case AllStarPointName.HighPoints:
                        return GameCategory.O1;

                    default:
                        return GameCategory.Cricket;


                }
            }
        }

        public int GameResultID { get; set; }
        public virtual GameResult GameResult { get; set; }

        public int PointTotal
        {
            get
            {
                switch (this.AllStarPointName)
                {
                    case AllStarPointName.Corks:
                        int[] validCorkValues = { 3, 4, 5, 6 };
                        int pos = Array.IndexOf(validCorkValues, this.Value);
                        if (pos > -1)
                        {
                            if (this.Value == 6)
                                return 180;
                            else
                            {
                                return 25 * this.Value;
                            }
                        }
                        else
                        {
                            //throw new System.ArgumentException("Invalid Cork Value, must be in the range of 3-6");
                            return -1;
                        }
                    case AllStarPointName.RoundOf:
                        // if(this.Value > 5 && this.Value < 10)
                        int total = this.Value > 5 && this.Value < 10 ? this.Value * 20 : -1;
                        return total;

                    case AllStarPointName.HighOn:
                    case AllStarPointName.HighOff:
                    case AllStarPointName.HighPoints:
                        return this.Value;
                    default: { return -1; }

                }
            }
        }
        public int PlayerPhaseID { get; set; }
        public virtual PlayerPhase PlayerPhase { get; set; }
        
    }
}