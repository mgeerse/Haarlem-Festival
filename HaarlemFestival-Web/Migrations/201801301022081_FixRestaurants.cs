namespace HaarlemFestival_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixRestaurants : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cuisine", "Restaurant_Id", "dbo.Restaurants");
            DropIndex("dbo.Cuisine", new[] { "Restaurant_Id" });
            CreateTable(
                "dbo.CuisineRestaurants",
                c => new
                    {
                        Cuisine_Id = c.Int(nullable: false),
                        Restaurant_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Cuisine_Id, t.Restaurant_Id })
                .ForeignKey("dbo.Cuisine", t => t.Cuisine_Id, cascadeDelete: true)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_Id, cascadeDelete: true)
                .Index(t => t.Cuisine_Id)
                .Index(t => t.Restaurant_Id);
            
            DropColumn("dbo.Cuisine", "Restaurant_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cuisine", "Restaurant_Id", c => c.Int());
            DropForeignKey("dbo.CuisineRestaurants", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.CuisineRestaurants", "Cuisine_Id", "dbo.Cuisine");
            DropIndex("dbo.CuisineRestaurants", new[] { "Restaurant_Id" });
            DropIndex("dbo.CuisineRestaurants", new[] { "Cuisine_Id" });
            DropTable("dbo.CuisineRestaurants");
            CreateIndex("dbo.Cuisine", "Restaurant_Id");
            AddForeignKey("dbo.Cuisine", "Restaurant_Id", "dbo.Restaurants", "Id");
        }
    }
}
