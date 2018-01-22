namespace HaarlemFestival_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeijeCreate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "Name", c => c.String());
            AlterColumn("dbo.Accounts", "Username", c => c.String());
            AlterColumn("dbo.Accounts", "Password", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Accounts", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "Name", c => c.String(nullable: false));
        }
    }
}
