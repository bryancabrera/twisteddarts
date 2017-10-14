namespace TwistedDarts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
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
                "dbo.AllStarPoints",
                c => new
                    {
                        AllStarPointID = c.Int(nullable: false, identity: true),
                        AllStarPointName = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                        GameResultID = c.Int(nullable: false),
                        PlayerPhaseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AllStarPointID)
                .ForeignKey("dbo.PlayerPhases", t => t.PlayerPhaseID, cascadeDelete: true)
                .ForeignKey("dbo.GameResults", t => t.GameResultID, cascadeDelete: true)
                .Index(t => t.GameResultID)
                .Index(t => t.PlayerPhaseID);
            
            CreateTable(
                "dbo.GameResults",
                c => new
                    {
                        GameResultID = c.Int(nullable: false, identity: true),
                        Result = c.Int(nullable: false),
                        WinningTeamID = c.Int(nullable: false),
                        IsForfeit = c.Boolean(nullable: false),
                        SubmissionTeamID = c.Int(nullable: false),
                        GameID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GameResultID)
                .ForeignKey("dbo.Games", t => t.GameID, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.SubmissionTeamID)
                .ForeignKey("dbo.Teams", t => t.WinningTeamID, cascadeDelete: true)
                .Index(t => t.WinningTeamID)
                .Index(t => t.SubmissionTeamID)
                .Index(t => t.GameID);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        GameID = c.Int(nullable: false, identity: true),
                        GameName = c.Int(nullable: false),
                        GameFormat = c.Short(nullable: false),
                        GameSequence = c.Short(nullable: false),
                        MatchSetID = c.Int(nullable: false),
                        WinningTeamID = c.Int(),
                    })
                .PrimaryKey(t => t.GameID)
                .ForeignKey("dbo.MatchSets", t => t.MatchSetID, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.WinningTeamID)
                .Index(t => t.MatchSetID)
                .Index(t => t.WinningTeamID);
            
            CreateTable(
                "dbo.MatchSets",
                c => new
                    {
                        MatchSetID = c.Int(nullable: false, identity: true),
                        SetSequence = c.Short(nullable: false),
                        HomeTeamTotal = c.Short(nullable: false),
                        AwayTeamTotal = c.Short(nullable: false),
                        MatchID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MatchSetID)
                .ForeignKey("dbo.Matches", t => t.MatchID)
                .Index(t => t.MatchID);
            
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        MatchID = c.Int(nullable: false, identity: true),
                        MatchName = c.String(),
                        ScheduleDateID = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        AltDateTime = c.DateTime(),
                        ActualDateTime = c.DateTime(),
                        PointTotal = c.Short(nullable: false),
                        EstablishmentID = c.Int(nullable: false),
                        HomeTeamID = c.Int(nullable: false),
                        AwayTeamID = c.Int(nullable: false),
                        SeasonID = c.Int(nullable: false),
                        IsForfeit = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MatchID)
                .ForeignKey("dbo.Teams", t => t.AwayTeamID)
                .ForeignKey("dbo.Establishments", t => t.EstablishmentID)
                .ForeignKey("dbo.Teams", t => t.HomeTeamID)
                .ForeignKey("dbo.ScheduleDates", t => t.ScheduleDateID, cascadeDelete: true)
                .ForeignKey("dbo.Seasons", t => t.SeasonID, cascadeDelete: true)
                .Index(t => t.ScheduleDateID)
                .Index(t => t.EstablishmentID)
                .Index(t => t.HomeTeamID)
                .Index(t => t.AwayTeamID)
                .Index(t => t.SeasonID);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamID = c.Int(nullable: false, identity: true),
                        TeamName = c.String(),
                        JoinDate = c.DateTime(nullable: false),
                        PlayDay = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        EstablishmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeamID)
                .ForeignKey("dbo.Establishments", t => t.EstablishmentID, cascadeDelete: true)
                .Index(t => t.EstablishmentID);
            
            CreateTable(
                "dbo.Establishments",
                c => new
                    {
                        EstablishmentID = c.Int(nullable: false, identity: true),
                        EstablishmentName = c.String(),
                        AddressID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EstablishmentID)
                .ForeignKey("dbo.Addresses", t => t.AddressID, cascadeDelete: true)
                .Index(t => t.AddressID);
            
            CreateTable(
                "dbo.PlayerPhases",
                c => new
                    {
                        PlayerPhaseID = c.Int(nullable: false, identity: true),
                        Role = c.Int(nullable: false),
                        SkillLevel = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        TeamID = c.Int(nullable: false),
                        PersonID = c.Int(nullable: false),
                        SeasonID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerPhaseID)
                .ForeignKey("dbo.People", t => t.PersonID, cascadeDelete: true)
                .ForeignKey("dbo.Seasons", t => t.SeasonID)
                .ForeignKey("dbo.Teams", t => t.TeamID)
                .Index(t => new { t.PersonID, t.SeasonID, t.TeamID }, unique: true, name: "IX_UniquePersonTeamSeason");
            
            CreateTable(
                "dbo.Seasons",
                c => new
                    {
                        SeasonID = c.Int(nullable: false, identity: true),
                        SeasonName = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        RegistrationStartDate = c.DateTime(nullable: false),
                        RegistrationCloseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SeasonID);
            
            CreateTable(
                "dbo.ScheduleDates",
                c => new
                    {
                        ScheduleDateID = c.Int(nullable: false, identity: true),
                        GameDate = c.DateTime(nullable: false),
                        Sequence = c.Short(nullable: false),
                        ScheduleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ScheduleDateID)
                .ForeignKey("dbo.Schedules", t => t.ScheduleID)
                .Index(t => t.ScheduleID);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ScheduleID = c.Int(nullable: false, identity: true),
                        ScheduleName = c.String(),
                        DayOfWeek = c.Int(nullable: false),
                        ScheduleType = c.Int(nullable: false),
                        SeasonID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ScheduleID)
                .ForeignKey("dbo.Seasons", t => t.SeasonID)
                .Index(t => t.SeasonID);
            
            CreateTable(
                "dbo.PlayerResults",
                c => new
                    {
                        PlayerResultID = c.Int(nullable: false, identity: true),
                        PlayerPhaseID = c.Int(nullable: false),
                        PlayerSequence = c.Short(nullable: false),
                        Result = c.Int(nullable: false),
                        GameID = c.Int(nullable: false),
                        SubmittingTeamID = c.Int(nullable: false),
                        SubmissionDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerResultID)
                .ForeignKey("dbo.Games", t => t.GameID, cascadeDelete: true)
                .ForeignKey("dbo.PlayerPhases", t => t.PlayerPhaseID, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.SubmittingTeamID, cascadeDelete: true)
                .Index(t => t.PlayerPhaseID)
                .Index(t => t.GameID)
                .Index(t => t.SubmittingTeamID);
            
            CreateTable(
                "dbo.EventResults",
                c => new
                    {
                        EventResultID = c.Int(nullable: false, identity: true),
                        ParentID = c.Int(),
                        SubmissionDate = c.DateTime(nullable: false),
                        LastRevisionDate = c.DateTime(),
                        IsFinal = c.Boolean(nullable: false),
                        MatchesOpponent = c.Boolean(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                        HomeTeamScore = c.Short(nullable: false),
                        AwayTeamScore = c.Short(nullable: false),
                        Sequence = c.Short(nullable: false),
                        WinningTeamID = c.Int(nullable: false),
                        SubmittingTeamID = c.Int(nullable: false),
                        GameFormat = c.Short(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.EventResultID)
                .ForeignKey("dbo.EventResults", t => t.ParentID)
                .ForeignKey("dbo.Teams", t => t.SubmittingTeamID, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.WinningTeamID)
                .Index(t => t.ParentID)
                .Index(t => t.WinningTeamID)
                .Index(t => t.SubmittingTeamID);
            
            CreateTable(
                "dbo.MatchUps",
                c => new
                    {
                        MatchUpID = c.Int(nullable: false, identity: true),
                        HomeTeamID = c.Int(nullable: false),
                        AwayTeamID = c.Int(nullable: false),
                        ScheduleDateID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MatchUpID)
                .ForeignKey("dbo.Teams", t => t.AwayTeamID)
                .ForeignKey("dbo.Teams", t => t.HomeTeamID)
                .Index(t => t.HomeTeamID)
                .Index(t => t.AwayTeamID);
            
            CreateTable(
                "dbo.PersonAddresses",
                c => new
                    {
                        PersonID = c.Int(nullable: false),
                        Addresses = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PersonID, t.Addresses })
                .ForeignKey("dbo.People", t => t.PersonID, cascadeDelete: true)
                .ForeignKey("dbo.Addresses", t => t.Addresses, cascadeDelete: true)
                .Index(t => t.PersonID)
                .Index(t => t.Addresses);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MatchUps", "HomeTeamID", "dbo.Teams");
            DropForeignKey("dbo.MatchUps", "AwayTeamID", "dbo.Teams");
            DropForeignKey("dbo.EventResults", "WinningTeamID", "dbo.Teams");
            DropForeignKey("dbo.EventResults", "SubmittingTeamID", "dbo.Teams");
            DropForeignKey("dbo.EventResults", "ParentID", "dbo.EventResults");
            DropForeignKey("dbo.AllStarPoints", "GameResultID", "dbo.GameResults");
            DropForeignKey("dbo.GameResults", "WinningTeamID", "dbo.Teams");
            DropForeignKey("dbo.GameResults", "SubmissionTeamID", "dbo.Teams");
            DropForeignKey("dbo.GameResults", "GameID", "dbo.Games");
            DropForeignKey("dbo.Games", "WinningTeamID", "dbo.Teams");
            DropForeignKey("dbo.PlayerResults", "SubmittingTeamID", "dbo.Teams");
            DropForeignKey("dbo.PlayerResults", "PlayerPhaseID", "dbo.PlayerPhases");
            DropForeignKey("dbo.PlayerResults", "GameID", "dbo.Games");
            DropForeignKey("dbo.MatchSets", "MatchID", "dbo.Matches");
            DropForeignKey("dbo.Matches", "SeasonID", "dbo.Seasons");
            DropForeignKey("dbo.Matches", "ScheduleDateID", "dbo.ScheduleDates");
            DropForeignKey("dbo.Schedules", "SeasonID", "dbo.Seasons");
            DropForeignKey("dbo.ScheduleDates", "ScheduleID", "dbo.Schedules");
            DropForeignKey("dbo.Matches", "HomeTeamID", "dbo.Teams");
            DropForeignKey("dbo.Matches", "EstablishmentID", "dbo.Establishments");
            DropForeignKey("dbo.Matches", "AwayTeamID", "dbo.Teams");
            DropForeignKey("dbo.PlayerPhases", "TeamID", "dbo.Teams");
            DropForeignKey("dbo.PlayerPhases", "SeasonID", "dbo.Seasons");
            DropForeignKey("dbo.PlayerPhases", "PersonID", "dbo.People");
            DropForeignKey("dbo.AllStarPoints", "PlayerPhaseID", "dbo.PlayerPhases");
            DropForeignKey("dbo.Teams", "EstablishmentID", "dbo.Establishments");
            DropForeignKey("dbo.Establishments", "AddressID", "dbo.Addresses");
            DropForeignKey("dbo.Games", "MatchSetID", "dbo.MatchSets");
            DropForeignKey("dbo.PersonAddresses", "Addresses", "dbo.Addresses");
            DropForeignKey("dbo.PersonAddresses", "PersonID", "dbo.People");
            DropIndex("dbo.PersonAddresses", new[] { "Addresses" });
            DropIndex("dbo.PersonAddresses", new[] { "PersonID" });
            DropIndex("dbo.MatchUps", new[] { "AwayTeamID" });
            DropIndex("dbo.MatchUps", new[] { "HomeTeamID" });
            DropIndex("dbo.EventResults", new[] { "SubmittingTeamID" });
            DropIndex("dbo.EventResults", new[] { "WinningTeamID" });
            DropIndex("dbo.EventResults", new[] { "ParentID" });
            DropIndex("dbo.PlayerResults", new[] { "SubmittingTeamID" });
            DropIndex("dbo.PlayerResults", new[] { "GameID" });
            DropIndex("dbo.PlayerResults", new[] { "PlayerPhaseID" });
            DropIndex("dbo.Schedules", new[] { "SeasonID" });
            DropIndex("dbo.ScheduleDates", new[] { "ScheduleID" });
            DropIndex("dbo.PlayerPhases", "IX_UniquePersonTeamSeason");
            DropIndex("dbo.Establishments", new[] { "AddressID" });
            DropIndex("dbo.Teams", new[] { "EstablishmentID" });
            DropIndex("dbo.Matches", new[] { "SeasonID" });
            DropIndex("dbo.Matches", new[] { "AwayTeamID" });
            DropIndex("dbo.Matches", new[] { "HomeTeamID" });
            DropIndex("dbo.Matches", new[] { "EstablishmentID" });
            DropIndex("dbo.Matches", new[] { "ScheduleDateID" });
            DropIndex("dbo.MatchSets", new[] { "MatchID" });
            DropIndex("dbo.Games", new[] { "WinningTeamID" });
            DropIndex("dbo.Games", new[] { "MatchSetID" });
            DropIndex("dbo.GameResults", new[] { "GameID" });
            DropIndex("dbo.GameResults", new[] { "SubmissionTeamID" });
            DropIndex("dbo.GameResults", new[] { "WinningTeamID" });
            DropIndex("dbo.AllStarPoints", new[] { "PlayerPhaseID" });
            DropIndex("dbo.AllStarPoints", new[] { "GameResultID" });
            DropTable("dbo.PersonAddresses");
            DropTable("dbo.MatchUps");
            DropTable("dbo.EventResults");
            DropTable("dbo.PlayerResults");
            DropTable("dbo.Schedules");
            DropTable("dbo.ScheduleDates");
            DropTable("dbo.Seasons");
            DropTable("dbo.PlayerPhases");
            DropTable("dbo.Establishments");
            DropTable("dbo.Teams");
            DropTable("dbo.Matches");
            DropTable("dbo.MatchSets");
            DropTable("dbo.Games");
            DropTable("dbo.GameResults");
            DropTable("dbo.AllStarPoints");
            DropTable("dbo.People");
            DropTable("dbo.Addresses");
        }
    }
}
