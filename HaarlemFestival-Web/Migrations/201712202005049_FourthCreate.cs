namespace HaarlemFestival_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FourthCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subjects", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subjects", "ImagePath");
        }
    }
}
