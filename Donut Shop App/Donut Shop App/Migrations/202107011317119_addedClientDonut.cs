namespace Donut_Shop_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedClientDonut : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DonutClients",
                c => new
                    {
                        Donut_Id = c.Int(nullable: false),
                        Client_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Donut_Id, t.Client_Id })
                .ForeignKey("dbo.Donuts", t => t.Donut_Id, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.Client_Id, cascadeDelete: true)
                .Index(t => t.Donut_Id)
                .Index(t => t.Client_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DonutClients", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.DonutClients", "Donut_Id", "dbo.Donuts");
            DropIndex("dbo.DonutClients", new[] { "Client_Id" });
            DropIndex("dbo.DonutClients", new[] { "Donut_Id" });
            DropTable("dbo.DonutClients");
        }
    }
}
