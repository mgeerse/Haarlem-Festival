namespace HaarlemFestival_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Registration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "Password", c => c.String(nullable: false));
            DropColumn("dbo.Subjects", "ImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subjects", "ImagePath", c => c.String());
            AlterColumn("dbo.Accounts", "Password", c => c.String());
            AlterColumn("dbo.Accounts", "Username", c => c.String());
            AlterColumn("dbo.Accounts", "Name", c => c.String());
        }
    }
}
