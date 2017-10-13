namespace TwistedDarts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonIDtoLogin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        MiddleInitial = c.String(maxLength: 1),
                        RegistrationDate = c.DateTime(),
                        ContactNumber = c.String(),
                        AltNumber = c.String(),
                        EmailAddress = c.String(),
                        Gender = c.Int(),
                        DOB = c.DateTime(),
                        IsApproved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PersonID);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressID = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        PostalCode = c.String(),
                        County = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.AddressID);
            
            CreateTable(
                "dbo.AddressPersons",
                c => new
                    {
                        Address_AddressID = c.Int(nullable: false),
                        Person_PersonID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Address_AddressID, t.Person_PersonID })
                .ForeignKey("dbo.Addresses", t => t.Address_AddressID, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.Person_PersonID, cascadeDelete: true)
                .Index(t => t.Address_AddressID)
                .Index(t => t.Person_PersonID);
            
            AddColumn("dbo.AspNetUsers", "Person_PersonID", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Person_PersonID");
            AddForeignKey("dbo.AspNetUsers", "Person_PersonID", "dbo.People", "PersonID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Person_PersonID", "dbo.People");
            DropForeignKey("dbo.AddressPersons", "Person_PersonID", "dbo.People");
            DropForeignKey("dbo.AddressPersons", "Address_AddressID", "dbo.Addresses");
            DropIndex("dbo.AddressPersons", new[] { "Person_PersonID" });
            DropIndex("dbo.AddressPersons", new[] { "Address_AddressID" });
            DropIndex("dbo.AspNetUsers", new[] { "Person_PersonID" });
            DropColumn("dbo.AspNetUsers", "Person_PersonID");
            DropTable("dbo.AddressPersons");
            DropTable("dbo.Addresses");
            DropTable("dbo.People");
        }
    }
}
