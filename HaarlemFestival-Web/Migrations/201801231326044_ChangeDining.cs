namespace HaarlemFestival_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDining : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Dining", "AmountOfSessions");
            DropColumn("dbo.Dining", "SessionLength");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dining", "SessionLength", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.Dining", "AmountOfSessions", c => c.Int(nullable: false));
        }
    }
}
