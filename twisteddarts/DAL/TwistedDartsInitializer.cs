using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TwistedDarts.Models;

namespace TwistedDarts.DAL
{
    public class TwistedDartsInitializer : DropCreateDatabaseIfModelChanges<TwistedDartsContext>

    {
        protected override void Seed(TwistedDartsContext context)
        {
            var establishments = new List<Establishment>
            {
                new Establishment {EstablishmentName="Twisted Tavern",
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

            var people = new List<Person>
            {
                new Person {FirstName="Bryan", LastName="Cabrera", Gender=Gender.Male, RegistrationDate=DateTime.Now, EmailAddress="bryan@twisteddarts.com"},
                new Person {FirstName="TJ", LastName="Berger", Gender=Gender.Male, RegistrationDate=DateTime.Now, EmailAddress="tj@twisteddarts.com" },
                new Person {FirstName="Chris", LastName="Mulhall", Gender=Gender.Male, RegistrationDate=DateTime.Now, EmailAddress="chris@twisteddarts.com" },
                new Person {FirstName="Carl", LastName="Bernardis", Gender=Gender.Male, RegistrationDate=DateTime.Now, EmailAddress="carl@twisteddarts.com" },
                new Person {FirstName="Michael", LastName="Scandale", Gender=Gender.Male, RegistrationDate=DateTime.Now, EmailAddress="migues@twisteddarts.com" },
             };
            people.ForEach(p => context.People.Add(p));
            context.SaveChanges();

            var teams = new List<Team>
            {
                new Team {Name="Twisted Tavern Dart Team", JoinDate=DateTime.Now, PlayDay=DayOfWeek.Wednesday, },
                new Team {Name="Barracks", JoinDate=DateTime.Now, PlayDay=DayOfWeek.Wednesday },
                new Team {Name="Watsons", JoinDate=DateTime.Now, PlayDay=DayOfWeek.Wednesday },
                new Team {Name="Gator Blue", JoinDate=DateTime.Now, PlayDay=DayOfWeek.Wednesday },
            };
            teams.ForEach(t => context.Teams.Add(t));
            context.SaveChanges();
        }

    }
}