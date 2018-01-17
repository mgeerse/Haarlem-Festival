namespace HaarlemFestival_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        Number = c.Int(nullable: false),
                        Postalcode = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cuisine",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TourGuides",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Language = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Walking", t => t.Walking_Id)
                .Index(t => t.Walking_Id);
            
            CreateTable(
                "dbo.Jazz",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Artist = c.String(),
                        Hall = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Activities", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Dining",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Cuisine_Id = c.Int(),
                        AmountOfSessions = c.Int(nullable: false),
                        SessionLength = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Activities", t => t.Id)
                .ForeignKey("dbo.Cuisine", t => t.Cuisine_Id)
                .Index(t => t.Id)
                .Index(t => t.Cuisine_Id);
            
            CreateTable(
                "dbo.Talking",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        SpeakerOne = c.String(),
                        SpeakerTwo = c.String(),
                        SpeakerOneDescription = c.String(),
                        SpeakerTwoDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Activities", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Walking",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        TourGuideId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Activities", t => t.Id)
                .ForeignKey("dbo.TourGuides", t => t.TourGuideId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.TourGuideId);
            
            AddColumn("dbo.Activities", "LocationId", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "SoldAt", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Activities", "LocationId");
            AddForeignKey("dbo.Activities", "LocationId", "dbo.Locations", "Id", cascadeDelete: true);
            DropColumn("dbo.Activities", "Location");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Activities", "Location", c => c.String());
            DropForeignKey("dbo.Walking", "TourGuideId", "dbo.TourGuides");
            DropForeignKey("dbo.Walking", "Id", "dbo.Activities");
            DropForeignKey("dbo.Talking", "Id", "dbo.Activities");
            DropForeignKey("dbo.Dining", "Cuisine_Id", "dbo.Cuisine");
            DropForeignKey("dbo.Dining", "Id", "dbo.Activities");
            DropForeignKey("dbo.Jazz", "Id", "dbo.Activities");
            DropForeignKey("dbo.TourLocations", "Walking_Id", "dbo.Walking");
            DropForeignKey("dbo.Activities", "LocationId", "dbo.Locations");
            DropIndex("dbo.Walking", new[] { "TourGuideId" });
            DropIndex("dbo.Walking", new[] { "Id" });
            DropIndex("dbo.Talking", new[] { "Id" });
            DropIndex("dbo.Dining", new[] { "Cuisine_Id" });
            DropIndex("dbo.Dining", new[] { "Id" });
            DropIndex("dbo.Jazz", new[] { "Id" });
            DropIndex("dbo.TourLocations", new[] { "Walking_Id" });
            DropIndex("dbo.Activities", new[] { "LocationId" });
            DropColumn("dbo.Tickets", "SoldAt");
            DropColumn("dbo.Activities", "LocationId");
            DropTable("dbo.Walking");
            DropTable("dbo.Talking");
            DropTable("dbo.Dining");
            DropTable("dbo.Jazz");
            DropTable("dbo.TourLocations");
            DropTable("dbo.TourGuides");
            DropTable("dbo.Cuisine");
            DropTable("dbo.Locations");
        }
    }
}
