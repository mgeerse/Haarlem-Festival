namespace HaarlemFestival_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestaurantInLocation : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Locations", name: "Restaurant_Id", newName: "RestaurantId_Id");
            RenameIndex(table: "dbo.Locations", name: "IX_Restaurant_Id", newName: "IX_RestaurantId_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Locations", name: "IX_RestaurantId_Id", newName: "IX_Restaurant_Id");
            RenameColumn(table: "dbo.Locations", name: "RestaurantId_Id", newName: "Restaurant_Id");
        }
    }
}
