namespace LuggaGo.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class przekopMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CreditCards", "User_ID", "dbo.Users");
            DropIndex("dbo.CreditCards", new[] { "User_ID" });
            DropTable("dbo.CreditCards");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.CreditCards", "User_ID");
            AddForeignKey("dbo.CreditCards", "User_ID", "dbo.Users", "ID");
        }
    }
}
