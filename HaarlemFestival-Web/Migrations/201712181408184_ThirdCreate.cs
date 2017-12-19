namespace HaarlemFestival_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jazz", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jazz", "ImagePath");
        }
    }
}
