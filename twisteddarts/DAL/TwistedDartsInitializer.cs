using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TwistedDarts.Models;
using System.Diagnostics;

namespace TwistedDarts.DAL
{
    public class TwistedDartsInitializer : DropCreateDatabaseAlways<TwistedDartsContext>

    {
        protected override void Seed(TwistedDartsContext context)
        {
            Season season = new Season { SeasonName = "Spring2017", StartDate = new DateTime(2017, 4, 13), EndDate = new DateTime(2017, 6, 14) };
            Schedule schedule = new Schedule { DayOfWeek = DayOfWeek.Wednesday, Season = season, ScheduleName = "SpringWed2017" };
            var scheddates = new List<ScheduleDate>();

            for (int i = 1; i <= 15; i++)
            {
                scheddates.Add(new ScheduleDate { GameDate = new DateTime(2017, 9, 6).AddDays(i * 7), Schedule = schedule });
            }

            scheddates.ForEach(s => context.ScheduleDate.Add(s));


            //context.TeamRoster.Add(
            //   new TeamRoster()
            //   {
            //       Team = new Team()
            //       {
            //           Name = "Lions Den",
            //           JoinDate = DateTime.Now,
            //           PlayDay = DayOfWeek.Wednesday,
            //           IsActive = true,
            //           Establishment = new Establishment()
            //           {
            //               EstablishmentName = "Lions Den",
            //               Address = new Address()
            //               { Street = "148 Johnson Ave", City = "Bohemia", State = "NY", PostalCode = "11730", County = "Suffolk" },

            //           }
            //       },
            //       EnrollmentDate = DateTime.Now,
            //       Season = season

            //   });

            //context.SaveChanges();



            var establishments = new List<Establishment>
            {
                new Establishment {EstablishmentName="Station Pub",
                Address = new Address {Street="4777 Sunrise Hwy", City="Bohemia", State="NY", PostalCode="11716", County="Suffolk" },
                },
                new Establishment {EstablishmentName="Barracks",
                Address = new Address {Street="1132 Smithtown Ave", City="Bohemia", State="NY", PostalCode="11716", County="Suffolk" }
                },
                new Establishment {EstablishmentName="Watsons",
                Address = new Address {Street="876 Church St", City="Bohemia", State="NY", PostalCode="11716", County="Suffolk" }
                },
                new Establishment {EstablishmentName="Gator Blue",
                Address = new Address {Street="148 Carleton Ave", City="East Islip", State="NY", PostalCode="11730", County="Suffolk" }
                },

            };

            establishments.ForEach(e => context.Establishments.Add(e));
            context.SaveChanges();
            var stationPub = new Team { Name = "Station Pub", EstablishmentID = 1, JoinDate = DateTime.Now, PlayDay = DayOfWeek.Wednesday, };
            var barracks = new Team { Name = "Barracks", EstablishmentID = 2, JoinDate = DateTime.Now, PlayDay = DayOfWeek.Wednesday };
            var watsons = new Team { Name = "Watsons", EstablishmentID = 3, JoinDate = DateTime.Now, PlayDay = DayOfWeek.Wednesday };
            var gatorBlue = new Team { Name = "Gator Blue", EstablishmentID = 4, JoinDate = DateTime.Now, PlayDay = DayOfWeek.Wednesday };


            var teams = new List<Team>
        {

            stationPub, barracks, watsons, gatorBlue    
            //new Team {Name="Station Pub",EstablishmentID = 1, JoinDate=DateTime.Now, PlayDay=DayOfWeek.Wednesday },
            //new Team {Name="Barracks",EstablishmentID = 2, JoinDate=DateTime.Now, PlayDay=DayOfWeek.Wednesday },
            //new Team {Name="Watsons",EstablishmentID = 3, JoinDate=DateTime.Now, PlayDay=DayOfWeek.Wednesday },
            //new Team {Name="Gator Blue",EstablishmentID = 4, JoinDate=DateTime.Now, PlayDay=DayOfWeek.Wednesday },
        };
            teams.ForEach(t => context.Teams.Add(t));
            context.SaveChanges();

            var FallSeason =
               new Season { SeasonName = "Fall2017", StartDate = new DateTime(2017, 9, 13), EndDate = new DateTime(2018, 2, 14) };
            var StationPubRoster = new List<Person>
            {
                new Person {FirstName="Bryan", LastName="Cabrera", Gender=Gender.Male, RegistrationDate=DateTime.Now, EmailAddress="bryan@twisteddarts.com"},
                new Person {FirstName="TJ", LastName="Berger", Gender=Gender.Male, RegistrationDate=DateTime.Now, EmailAddress="tj@twisteddarts.com" },
                new Person {FirstName="Chris", LastName="Mulhall", Gender=Gender.Male, RegistrationDate=DateTime.Now, EmailAddress="chris@twisteddarts.com" },
                new Person {FirstName="Carl", LastName="Bernardis", Gender=Gender.Male, RegistrationDate=DateTime.Now, EmailAddress="carl@twisteddarts.com" },
                new Person {FirstName="Michael", LastName="Scandale", Gender=Gender.Male, RegistrationDate=DateTime.Now, EmailAddress="migues@twisteddarts.com" },
             };
            var GatorBlueRoster = new List<Person>
            {
                new Person {FirstName="Gary", LastName="Smith", Gender=Gender.Male, RegistrationDate=DateTime.Now, EmailAddress="gs@twisteddarts.com"},
                new Person {FirstName="Tom", LastName="Smith", Gender=Gender.Male, RegistrationDate=DateTime.Now, EmailAddress="tom@twisteddarts.com" },
                new Person {FirstName="Dave", LastName="Stanzione", Gender=Gender.Male, RegistrationDate=DateTime.Now, EmailAddress="daves@twisteddarts.com" },
                new Person {FirstName="Tim", LastName="Smith", Gender=Gender.Male, RegistrationDate=DateTime.Now, EmailAddress="tim@twisteddarts.com" },
             };
            //people.ForEach(p => context.People.Add(p));
            foreach (Person p in StationPubRoster)
            {
                Role r = Role.Player;
                if (p.EmailAddress == "tj@twisteddarts.com")
                {
                    r = Role.Captain;
                }
                context.PlayerPhase.Add(new PlayerPhase { Person = p, Role = r, TeamID = 1, Season = FallSeason, StartDate = DateTime.Now });
            }

            foreach (Person p in GatorBlueRoster)
            {
                Role r = Role.Player;

                if (p.EmailAddress == "daves@twisteddarts.com")
                {
                    r = Role.Captain;
                }

                context.PlayerPhase.Add(new PlayerPhase { Person = p, Role = r, TeamID = 2, Season = FallSeason, StartDate = DateTime.Now });
            }


            context.SaveChanges();

            var Match = new Match
            {
                HomeTeam = stationPub,
                AwayTeam = barracks,
                MatchName = "Barracks VS Station Pub",
                ScheduleDateID = 1,
                ActualDateTime = DateTime.Now,
                EstablishmentID = 1,
                IsForfeit = false,
                Season = season,
                Type = MatchType.Regular,

            };

            context.Matches.Add(Match);

            context.SaveChanges();

            var set1 = new List<Game>
            {
                new Game{GameName = GameName.Four01, GameSequence = 1, GameFormat = GameFormat.Singles},
                new Game{GameName = GameName.Four01, GameSequence = 2, GameFormat = GameFormat.Singles},
                new Game{GameName = GameName.Cricket, GameSequence = 3, GameFormat = GameFormat.Singles},
            };

            var set2 = new List<Game>
            {
                new Game{GameName = GameName.Five01, GameSequence = 1, GameFormat = GameFormat.Doubles},
                new Game{GameName = GameName.Five01, GameSequence = 2, GameFormat = GameFormat.Doubles},
            };

            var set3 = new List<Game>
            {
                new Game{GameName = GameName.Cricket, GameSequence = 1, GameFormat = GameFormat.Singles},
                new Game{GameName = GameName.Cricket, GameSequence = 2, GameFormat = GameFormat.Singles},
                new Game{GameName = GameName.Cricket, GameSequence = 2, GameFormat = GameFormat.Doubles},
            };
            var matchSet = new MatchSet { SetSequence = 1, Games = set1, MatchID = 1, HomeTeamTotal = 10, AwayTeamTotal = 9 };
            var matchSet2 = new MatchSet { SetSequence = 2, Games = set2, MatchID = 1, HomeTeamTotal = 3, AwayTeamTotal = 16 };
            var matchSet3 = new MatchSet { SetSequence = 2, Games = set3, MatchID = 1, HomeTeamTotal = 1, AwayTeamTotal = 18 };

            context.MatchSets.Add(matchSet);
            context.MatchSets.Add(matchSet2);
            context.MatchSets.Add(matchSet3);
            context.SaveChanges();
            

            var GameResult = new GameResult
            {
                GameID = 1,
                Result = Result.win,
                IsForfeit = false,
                SubmissionTeamID = 1,
                PlayerPhase = new PlayerPhase
                {
                    Person = new Person { FirstName = "Gary", LastName = "Smith", Gender = Gender.Male, RegistrationDate = DateTime.Now }
                ,
                    Role = Role.Player,
                    TeamID = 2,
                    Season = FallSeason,
                    StartDate = DateTime.Now
                },
            };

            var ASP = new AllStarPoint
            {
                AllStarPointName = AllStarPointName.HighPoints,
                Value = 100,
                GameResult = GameResult,
                PlayerPhase = GameResult.PlayerPhase,


            };

            context.AllStarPoints.Add(ASP);
            context.SaveChanges();

        }

    }
}