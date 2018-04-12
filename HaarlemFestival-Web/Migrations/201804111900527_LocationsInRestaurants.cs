namespace HaarlemFestival_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocationsInRestaurants : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "Restaurant_Id", c => c.Int());
            CreateIndex("dbo.Locations", "Restaurant_Id");
            AddForeignKey("dbo.Locations", "Restaurant_Id", "dbo.Restaurants", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locations", "Restaurant_Id", "dbo.Restaurants");
            DropIndex("dbo.Locations", new[] { "Restaurant_Id" });
            DropColumn("dbo.Locations", "Restaurant_Id");
        }
    }
}
