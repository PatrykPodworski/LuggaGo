namespace LuggaGo.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                        Street = c.String(),
                        PostalCode = c.String(),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Airports",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortName = c.String(),
                        Address_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Addresses", t => t.Address_ID)
                .Index(t => t.Address_ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FlightNumber = c.String(),
                        LuggageWeight = c.Int(nullable: false),
                        LuggageDimensions_Width = c.Int(nullable: false),
                        LuggageDimensions_Height = c.Int(nullable: false),
                        LuggageDimensions_Depth = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Paths",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FromAddress_ID = c.Int(),
                        ToAddress_ID = c.Int(),
                        Order_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Addresses", t => t.FromAddress_ID)
                .ForeignKey("dbo.Addresses", t => t.ToAddress_ID)
                .ForeignKey("dbo.Orders", t => t.Order_ID)
                .Index(t => t.FromAddress_ID)
                .Index(t => t.ToAddress_ID)
                .Index(t => t.Order_ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Addresses", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Paths", "Order_ID", "dbo.Orders");
            DropForeignKey("dbo.Paths", "ToAddress_ID", "dbo.Addresses");
            DropForeignKey("dbo.Paths", "FromAddress_ID", "dbo.Addresses");
            DropForeignKey("dbo.Airports", "Address_ID", "dbo.Addresses");
            DropIndex("dbo.Paths", new[] { "Order_ID" });
            DropIndex("dbo.Paths", new[] { "ToAddress_ID" });
            DropIndex("dbo.Paths", new[] { "FromAddress_ID" });
            DropIndex("dbo.Orders", new[] { "User_ID" });
            DropIndex("dbo.Airports", new[] { "Address_ID" });
            DropIndex("dbo.Addresses", new[] { "User_ID" });
            DropTable("dbo.Users");
            DropTable("dbo.Paths");
            DropTable("dbo.Orders");
            DropTable("dbo.Airports");
            DropTable("dbo.Addresses");
        }
    }
}
