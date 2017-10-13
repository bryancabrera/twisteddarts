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






            var establishments = new List<Establishment>
            {

new Establishment{EstablishmentName="Holbrooks Backporch",Address=new Address {Street="1260 Grundy Ave",City="Holbrook,",State="NY", PostalCode="11741",County="Suffolk"}},
new Establishment{EstablishmentName="Barrack's",Address=new Address {Street="1132 Smithtown Ave",City="Bohemia,",State="NY", PostalCode="11716",County="Suffolk"}},
new Establishment{EstablishmentName="Gator Blue",Address=new Address {Street="148 Carleton Ave",City="East Islip,",State="NY", PostalCode="11730",County="Suffolk"}},
new Establishment{EstablishmentName="Watson's",Address=new Address {Street="876 Church St",City="Bohemia,",State="NY", PostalCode="11716",County="Suffolk"}},
new Establishment{EstablishmentName="Irish Exit",Address=new Address {Street="220 N Main St",City="Sayville,",State="NY", PostalCode="11782",County="Suffolk"}},
new Establishment{EstablishmentName="Village Idiot Pub",Address=new Address {Street="8 E Main St",City="Patchogue,",State="NY", PostalCode="11772",County="Suffolk"}},
new Establishment{EstablishmentName="Twisted Tavern",Address=new Address {Street="4777 Sunrise Hwy",City="Bohemia,",State="NY", PostalCode="11716",County="Suffolk"}},
new Establishment{EstablishmentName="Fulton's Gate",Address=new Address {Street="124 E. Main Street",City="Patchogue,",State="NY", PostalCode="11772",County="Suffolk"}},
new Establishment{EstablishmentName="Station Pub",Address=new Address {Street="3 Lakeland Ave.",City="Sayville,",State="NY", PostalCode="11782",County="Suffolk"}},
new Establishment{EstablishmentName="Lions Den",Address=new Address {Street="191 Higbie Lane",City="West Islip,",State="NY", PostalCode="11795",County="Suffolk"}},
new Establishment{EstablishmentName="Vanderbilt Wharf Marina",Address=new Address {Street=" 445 Vanderbilt Blvd",City="Oakdale,",State="NY", PostalCode="11769",County="Suffolk"}},
new Establishment{EstablishmentName="Connolly Station",Address=new Address {Street="227 4th Ave",City="Bay Shore,",State="NY", PostalCode="11706",County="Suffolk"}},
new Establishment{EstablishmentName="Rudi's",Address=new Address {Street="Rte. 112",City="Patchogue,",State="NY", PostalCode="11772",County="Suffolk"}},
            };

            establishments.ForEach(e => context.Establishments.Add(e));
            //context.SaveChanges();

            var backporch = new Team { TeamName = "Backporch", EstablishmentID = 1, JoinDate = DateTime.Now, PlayDay = DayOfWeek.Wednesday };
            var barracks = new Team { TeamName = "Barrack's", EstablishmentID = 2, JoinDate = DateTime.Now, PlayDay = DayOfWeek.Wednesday };
            var gatorbluei = new Team { TeamName = "Gator Blue I", EstablishmentID = 3, JoinDate = DateTime.Now, PlayDay = DayOfWeek.Wednesday };
            var gatorblueii = new Team { TeamName = "Gator Blue II", EstablishmentID = 4, JoinDate = DateTime.Now, PlayDay = DayOfWeek.Wednesday };
            var watsonsi = new Team { TeamName = "Watson's I", EstablishmentID = 5, JoinDate = DateTime.Now, PlayDay = DayOfWeek.Wednesday };
            var watsonsii = new Team { TeamName = "Watson's II", EstablishmentID = 6, JoinDate = DateTime.Now, PlayDay = DayOfWeek.Wednesday };
            var stationpubii = new Team { TeamName = "Station Pub II", EstablishmentID = 7, JoinDate = DateTime.Now, PlayDay = DayOfWeek.Wednesday };
            var connollystation = new Team { TeamName = "Connolly Station", EstablishmentID = 8, JoinDate = DateTime.Now, PlayDay = DayOfWeek.Wednesday };


            var teams = new List<Team>
        {

            backporch,barracks,gatorbluei,gatorblueii,watsonsi,watsonsii,stationpubii,connollystation
        };
            teams.ForEach(t => context.Teams.Add(t));
            context.SaveChanges();
            Season season = new Season
            {
                SeasonName = "Spring2017"
                ,
                StartDate = new DateTime(2017, 4, 13)
                ,
                EndDate = new DateTime(2017, 6, 14)
            ,
                RegistrationStartDate = new DateTime(2017, 6, 1)
            ,
                RegistrationCloseDate = new DateTime(2017, 1, 1)
            };
            Schedule schedule = new Schedule { DayOfWeek = DayOfWeek.Wednesday, Season = season, ScheduleName = "SpringWed2017" };
            var scheddates = new List<ScheduleDate>
            {
                new ScheduleDate { GameDate  = DateTime.Parse("9/13/2017"), Sequence  = 1,Schedule= schedule},
                new ScheduleDate { GameDate  = DateTime.Parse("9/20/2017"), Sequence  = 2,Schedule= schedule},
                new ScheduleDate { GameDate  = DateTime.Parse("9/27/2017"), Sequence  = 3,Schedule= schedule},
                new ScheduleDate { GameDate  = DateTime.Parse("10/4/2017"), Sequence  = 4,Schedule= schedule},
                new ScheduleDate { GameDate  = DateTime.Parse("10/11/2017"), Sequence  = 5,Schedule= schedule},
                new ScheduleDate { GameDate  = DateTime.Parse("10/18/2017"), Sequence  = 6,Schedule= schedule},
                new ScheduleDate { GameDate  = DateTime.Parse("10/25/2017"), Sequence  = 7,Schedule= schedule},
                new ScheduleDate { GameDate  = DateTime.Parse("11/1/2017"), Sequence  = 8,Schedule= schedule},
                new ScheduleDate { GameDate  = DateTime.Parse("11/8/2017"), Sequence  = 9,Schedule= schedule},
                new ScheduleDate { GameDate  = DateTime.Parse("11/15/2017"), Sequence  = 10,Schedule= schedule},
                new ScheduleDate { GameDate  = DateTime.Parse("11/29/2017"), Sequence  = 11,Schedule= schedule},
                new ScheduleDate { GameDate  = DateTime.Parse("12/6/2017"), Sequence  = 12,Schedule= schedule},
                new ScheduleDate { GameDate  = DateTime.Parse("12/13/2017"), Sequence  = 13,Schedule= schedule},
                new ScheduleDate { GameDate  = DateTime.Parse("12/20/2017"), Sequence  = 14,Schedule= schedule},

            };
            scheddates.ForEach(s => context.ScheduleDate.Add(s));
            context.SaveChanges();

            //for (int i = 1; i <= 15; i++)
            //{
            //    scheddates.Add(new ScheduleDate { GameDate = new DateTime(2017, 9, 6).AddDays(i * 7), Schedule = schedule });

            //}
            var matchups = new List<MatchUp>
            {
                new MatchUp{ ScheduleDateID = 1,HomeTeamID = 1,AwayTeamID=2},
                new MatchUp{ ScheduleDateID = 1,HomeTeamID = 5,AwayTeamID=6},
                new MatchUp{ ScheduleDateID = 1,HomeTeamID = 3,AwayTeamID=8},
                new MatchUp{ ScheduleDateID = 1,HomeTeamID = 4,AwayTeamID=7},
                new MatchUp{ ScheduleDateID = 2,HomeTeamID = 2,AwayTeamID=3},
                new MatchUp{ ScheduleDateID = 2,HomeTeamID = 8,AwayTeamID=1},
                new MatchUp{ ScheduleDateID = 2,HomeTeamID = 7,AwayTeamID=6},
                new MatchUp{ ScheduleDateID = 2,HomeTeamID = 4,AwayTeamID=5},
                new MatchUp{ ScheduleDateID = 3,HomeTeamID = 1,AwayTeamID=7},
                new MatchUp{ ScheduleDateID = 3,HomeTeamID = 6,AwayTeamID=2},
                new MatchUp{ ScheduleDateID = 3,HomeTeamID = 3,AwayTeamID=4},
                new MatchUp{ ScheduleDateID = 3,HomeTeamID = 5,AwayTeamID=8},
                new MatchUp{ ScheduleDateID = 4,HomeTeamID = 4,AwayTeamID=1},
                new MatchUp{ ScheduleDateID = 4,HomeTeamID = 2,AwayTeamID=5},
                new MatchUp{ ScheduleDateID = 4,HomeTeamID = 3,AwayTeamID=7},
                new MatchUp{ ScheduleDateID = 4,HomeTeamID = 6,AwayTeamID=8},
                new MatchUp{ ScheduleDateID = 5,HomeTeamID = 1,AwayTeamID=3},
                new MatchUp{ ScheduleDateID = 5,HomeTeamID = 8,AwayTeamID=2},
                new MatchUp{ ScheduleDateID = 5,HomeTeamID = 7,AwayTeamID=5},
                new MatchUp{ ScheduleDateID = 5,HomeTeamID = 4,AwayTeamID=6},
                new MatchUp{ ScheduleDateID = 6,HomeTeamID = 5,AwayTeamID=1},
                new MatchUp{ ScheduleDateID = 6,HomeTeamID = 2,AwayTeamID=7},
                new MatchUp{ ScheduleDateID = 6,HomeTeamID = 6,AwayTeamID=3},
                new MatchUp{ ScheduleDateID = 6,HomeTeamID = 8,AwayTeamID=4},
                new MatchUp{ ScheduleDateID = 7,HomeTeamID = 6,AwayTeamID=1},
                new MatchUp{ ScheduleDateID = 7,HomeTeamID = 2,AwayTeamID=4},
                new MatchUp{ ScheduleDateID = 7,HomeTeamID = 3,AwayTeamID=5},
                new MatchUp{ ScheduleDateID = 7,HomeTeamID = 7,AwayTeamID=8},
                new MatchUp{ ScheduleDateID = 8,HomeTeamID = 2,AwayTeamID=1},
                new MatchUp{ ScheduleDateID = 8,HomeTeamID = 6,AwayTeamID=5},
                new MatchUp{ ScheduleDateID = 8,HomeTeamID = 8,AwayTeamID=3},
                new MatchUp{ ScheduleDateID = 8,HomeTeamID = 7,AwayTeamID=4},
                new MatchUp{ ScheduleDateID = 9,HomeTeamID = 3,AwayTeamID=2},
                new MatchUp{ ScheduleDateID = 9,HomeTeamID = 1,AwayTeamID=8},
                new MatchUp{ ScheduleDateID = 9,HomeTeamID = 6,AwayTeamID=7},
                new MatchUp{ ScheduleDateID = 9,HomeTeamID = 5,AwayTeamID=4},
                new MatchUp{ ScheduleDateID = 10,HomeTeamID = 7,AwayTeamID=1},
                new MatchUp{ ScheduleDateID = 10,HomeTeamID = 2,AwayTeamID=6},
                new MatchUp{ ScheduleDateID = 10,HomeTeamID = 4,AwayTeamID=3},
                new MatchUp{ ScheduleDateID = 10,HomeTeamID = 8,AwayTeamID=5},
                new MatchUp{ ScheduleDateID = 11,HomeTeamID = 1,AwayTeamID=4},
                new MatchUp{ ScheduleDateID = 11,HomeTeamID = 5,AwayTeamID=2},
                new MatchUp{ ScheduleDateID = 11,HomeTeamID = 7,AwayTeamID=3},
                new MatchUp{ ScheduleDateID = 11,HomeTeamID = 8,AwayTeamID=6},
                new MatchUp{ ScheduleDateID = 12,HomeTeamID = 3,AwayTeamID=1},
                new MatchUp{ ScheduleDateID = 12,HomeTeamID = 2,AwayTeamID=8},
                new MatchUp{ ScheduleDateID = 12,HomeTeamID = 5,AwayTeamID=7},
                new MatchUp{ ScheduleDateID = 12,HomeTeamID = 6,AwayTeamID=4},
                new MatchUp{ ScheduleDateID = 13,HomeTeamID = 1,AwayTeamID=5},
                new MatchUp{ ScheduleDateID = 13,HomeTeamID = 7,AwayTeamID=2},
                new MatchUp{ ScheduleDateID = 13,HomeTeamID = 3,AwayTeamID=6},
                new MatchUp{ ScheduleDateID = 13,HomeTeamID = 4,AwayTeamID=8},
                new MatchUp{ ScheduleDateID = 14,HomeTeamID = 1,AwayTeamID=6},
                new MatchUp{ ScheduleDateID = 14,HomeTeamID = 4,AwayTeamID=2},
                new MatchUp{ ScheduleDateID = 14,HomeTeamID = 5,AwayTeamID=3},
                new MatchUp{ ScheduleDateID = 14,HomeTeamID = 8,AwayTeamID=7},

            };
            foreach (var mu in matchups)
            {
                context.Matchups.Add(mu);
            };
            context.SaveChanges();


            var FallSeason =
               new Season
               {
                   SeasonName = "Fall2017"
               ,
                   StartDate = new DateTime(2017, 9, 13)
               ,
                   EndDate = new DateTime(2018, 2, 14)
               ,
                   RegistrationStartDate = new DateTime(2017, 1, 1)
               ,
                   RegistrationCloseDate = new DateTime(2017, 5, 1)
               };
            var StationPubRoster = new List<Person>
            {
                new Person {FirstName="Bryan", LastName="Cabrera", Gender=Gender.Male, RegistrationDate=DateTime.Now, EmailAddress="bryan@twisteddarts.com"},
                new Person {FirstName="TJ", LastName="Berger", Gender=Gender.Male, RegistrationDate=DateTime.Now, EmailAddress="tj@twisteddarts.com" },
                new Person {FirstName="Kevin", LastName="Carey", Gender=Gender.Male, RegistrationDate=DateTime.Now, EmailAddress="Kevin@twisteddarts.com" },
                new Person {FirstName="Will", LastName="Knauth", Gender=Gender.Male, RegistrationDate=DateTime.Now, EmailAddress="will@twisteddarts.com" },
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
                context.PlayerPhase.Add(new PlayerPhase { Person = p, Role = r, TeamID = 7, Season = FallSeason, StartDate = DateTime.Now });
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
                HomeTeam = stationpubii,
                AwayTeam = barracks,
                MatchName = "Gator VS Station Pub II",
                ScheduleDateID = 1,
                ActualDateTime = DateTime.Now,
                EstablishmentID = 6,
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

            var playerResult = new List<PlayerResult>
            {
              new PlayerResult{GameID=1, PlayerPhaseID = 1, SubmittingTeamID =1, Result=Result.win, SubmissionDateTime = DateTime.Now },
              new PlayerResult{GameID=1, PlayerPhaseID = 2, SubmittingTeamID =1, Result=Result.win, SubmissionDateTime = DateTime.Now },
              new PlayerResult{GameID=1, PlayerPhaseID = 6, SubmittingTeamID =1, Result=Result.loss, SubmissionDateTime = DateTime.Now },
              new PlayerResult{GameID=1, PlayerPhaseID = 7, SubmittingTeamID =1, Result=Result.loss, SubmissionDateTime = DateTime.Now },


        };
            foreach (PlayerResult p in playerResult)
            { context.PlayerResult.Add(p); }
            context.SaveChanges();


            //var GameResult = new GameResult
            //{
            //    GameID = 1,
            //    Result = Result.win,
            //    IsForfeit = false,
            //    SubmissionTeamID = 1,
            //    PlayerPhase = new PlayerPhase
            //    {
            //        Person = new Person { FirstName = "Gary", LastName = "Smith", Gender = Gender.Male, RegistrationDate = DateTime.Now }
            //    ,
            //        Role = Role.Player,
            //        TeamID = 2,
            //        Season = FallSeason,
            //        StartDate = DateTime.Now
            //    },
            //};

            //var ASP = new AllStarPoint
            //{
            //    AllStarPointName = AllStarPointName.HighPoints,
            //    Value = 100,
            //    GameResult = GameResult,
            //    PlayerPhase = GameResult.PlayerPhase,


            //};

            //context.AllStarPoints.Add(ASP);
            //context.SaveChanges();

        }

    }
}