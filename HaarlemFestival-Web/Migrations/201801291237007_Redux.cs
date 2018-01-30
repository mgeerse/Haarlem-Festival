namespace HaarlemFestival_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Redux : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Dining", "Cuisine_Id", "dbo.Cuisine");
            DropIndex("dbo.TourLocations", new[] { "Walking_Id" });
            DropIndex("dbo.Dining", new[] { "Cuisine_Id" });
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Interviewees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Activities", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Dining", "Restaurant_Id", c => c.Int());
            AddColumn("dbo.Talking", "SpeakerOne_Id", c => c.Int());
            AddColumn("dbo.Talking", "SpeakerTwo_Id", c => c.Int());
            AddColumn("dbo.Locations", "Walking_Id", c => c.Int());
            AddColumn("dbo.Cuisine", "Restaurant_Id", c => c.Int());
            CreateIndex("dbo.Locations", "Walking_Id");
            CreateIndex("dbo.Cuisine", "Restaurant_Id");
            CreateIndex("dbo.Dining", "Restaurant_Id");
            CreateIndex("dbo.Talking", "SpeakerOne_Id");
            CreateIndex("dbo.Talking", "SpeakerTwo_Id");
            AddForeignKey("dbo.Cuisine", "Restaurant_Id", "dbo.Restaurants", "Id");
            AddForeignKey("dbo.Dining", "Restaurant_Id", "dbo.Restaurants", "Id");
            AddForeignKey("dbo.Talking", "SpeakerOne_Id", "dbo.Interviewees", "Id");
            AddForeignKey("dbo.Talking", "SpeakerTwo_Id", "dbo.Interviewees", "Id");
            DropColumn("dbo.Dining", "Cuisine_Id");
            DropColumn("dbo.Talking", "SpeakerOne");
            DropColumn("dbo.Talking", "SpeakerTwo");
            DropColumn("dbo.Talking", "SpeakerOneDescription");
            DropColumn("dbo.Talking", "SpeakerTwoDescription");
            DropColumn("dbo.Locations", "Number");
            DropTable("dbo.TourLocations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TourLocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        Number = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Walking_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Locations", "Number", c => c.Int(nullable: false));
            AddColumn("dbo.Talking", "SpeakerTwoDescription", c => c.String());
            AddColumn("dbo.Talking", "SpeakerOneDescription", c => c.String());
            AddColumn("dbo.Talking", "SpeakerTwo", c => c.String());
            AddColumn("dbo.Talking", "SpeakerOne", c => c.String());
            AddColumn("dbo.Dining", "Cuisine_Id", c => c.Int());
            DropForeignKey("dbo.Talking", "SpeakerTwo_Id", "dbo.Interviewees");
            DropForeignKey("dbo.Talking", "SpeakerOne_Id", "dbo.Interviewees");
            DropForeignKey("dbo.Dining", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.Cuisine", "Restaurant_Id", "dbo.Restaurants");
            DropIndex("dbo.Talking", new[] { "SpeakerTwo_Id" });
            DropIndex("dbo.Talking", new[] { "SpeakerOne_Id" });
            DropIndex("dbo.Dining", new[] { "Restaurant_Id" });
            DropIndex("dbo.Cuisine", new[] { "Restaurant_Id" });
            DropIndex("dbo.Locations", new[] { "Walking_Id" });
            DropColumn("dbo.Cuisine", "Restaurant_Id");
            DropColumn("dbo.Locations", "Walking_Id");
            DropColumn("dbo.Talking", "SpeakerTwo_Id");
            DropColumn("dbo.Talking", "SpeakerOne_Id");
            DropColumn("dbo.Dining", "Restaurant_Id");
            DropColumn("dbo.Activities", "Price");
            DropTable("dbo.Interviewees");
            DropTable("dbo.Restaurants");
            CreateIndex("dbo.Dining", "Cuisine_Id");
            CreateIndex("dbo.TourLocations", "Walking_Id");
            AddForeignKey("dbo.Dining", "Cuisine_Id", "dbo.Cuisine", "Id");
        }
    }
}
