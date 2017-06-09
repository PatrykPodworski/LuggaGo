namespace LuggaGo.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCreditCards : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CreditCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CardNumber = c.String(),
                        ExpirationDate = c.String(),
                        OwnerName = c.String(),
                        CVVCode = c.String(),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.User_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CreditCards", "User_ID", "dbo.Users");
            DropIndex("dbo.CreditCards", new[] { "User_ID" });
            DropTable("dbo.CreditCards");
        }
    }
}
