namespace TwistedDarts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserEmailtoPeople : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "UserEmail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "UserEmail");
        }
    }
}
