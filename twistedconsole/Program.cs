using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TwistedDarts;
using TwistedDarts.Models;

namespace twistedconsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            p.FirstName = "Bryan";
            p.LastName = "Cabrera";
            p.PersonID = 1;
            Console.Write($"{p.FirstName} {p.LastName}");

            var Twisted = new List<Person>
            {
                new Person {FirstName="Bryan", LastName="Cabrera", PersonID=1,
                    Roles =new List<Role> {Role.CoCaptain, Role.Player },
                    AllStarPoints = new List<AllStarPoint>
                    {
                    new AllStarPoint {AllStarPointID=1,  AllStarPointName = AllStarPointName.Corks, Value=5,},
                    new AllStarPoint {AllStarPointID=2,  AllStarPointName = AllStarPointName.HighOn, Value=105,},
                    new AllStarPoint {AllStarPointID=3,  AllStarPointName = AllStarPointName.RoundOf, Value=6,},
                    new AllStarPoint {AllStarPointID=4,  AllStarPointName = AllStarPointName.HighPoints, Value=160,}
                    }
                },

                 new Person {FirstName="TJ", LastName="Berger", PersonID=2,
                    Roles =new List<Role> {Role.Captain, Role.Player, },
                    AllStarPoints = new List<AllStarPoint>
                    {
                    new AllStarPoint {AllStarPointID=1,  AllStarPointName = AllStarPointName.Corks, Value=5,},
                    new AllStarPoint {AllStarPointID=2,  AllStarPointName = AllStarPointName.HighOn, Value=105,},
                    new AllStarPoint {AllStarPointID=3,  AllStarPointName = AllStarPointName.RoundOf, Value=6,},
                    new AllStarPoint {AllStarPointID=4,  AllStarPointName = AllStarPointName.HighPoints, Value=160,}
                    }
                }
            };

            var allstarpoints = new List<AllStarPoint>
            {
                new AllStarPoint {AllStarPointID=1,  AllStarPointName = AllStarPointName.Corks, Value=5,},
                new AllStarPoint {AllStarPointID=2,  AllStarPointName = AllStarPointName.HighOn, Value=105,},
                new AllStarPoint {AllStarPointID=3,  AllStarPointName = AllStarPointName.RoundOf, Value=6,},
                new AllStarPoint {AllStarPointID=4,  AllStarPointName = AllStarPointName.HighPoints, Value=160,}

        };
            var teams = new List<Team>
            {
                new Team {TeamName="Twisted Tavern",TeamID=1, Players=Twisted, },
                new Team {TeamName="Barracks", TeamID=2, }

            };
            p.AllStarPoints = allstarpoints;
            p.Teams = teams;

            foreach(Team team in teams)
            {
                Console.WriteLine(team.TeamName);
                if (team.Players != null) { 
                foreach(Person player in team.Players) {
                    Console.WriteLine(player.FirstName + " " + player.LastName);
                    foreach(AllStarPoint ap in player.AllStarPoints)
                    {
                        Console.WriteLine(ap.AllStarPointID.ToString());
                        Console.WriteLine(ap.AllStarPointName.ToString());
                        Console.WriteLine(ap.Value.ToString());
                        Console.WriteLine(ap.PointTotal.ToString());
                        Console.WriteLine("--------------------");
                    }
                }
                }
            }
   
            
            foreach(AllStarPoint pt in p.AllStarPoints)
            {
                Console.WriteLine(pt.AllStarPointID.ToString());
                Console.WriteLine(pt.AllStarPointName.ToString());
                Console.WriteLine(pt.Value.ToString());
                Console.WriteLine(pt.PointTotal.ToString());
                Console.WriteLine("--------------------");

            }




            Console.ReadLine();
            
        }
    }
}
