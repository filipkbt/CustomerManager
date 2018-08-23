namespace Customer_manager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddressModels",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Country = c.String(nullable: false),
                        City = c.String(nullable: false),
                        PostalCode = c.String(nullable: false),
                        Street = c.String(nullable: false),
                        HouseNumber = c.String(nullable: false),
                        FlatNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerModels", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CustomerModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        TelephoneNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AddressModels", "Id", "dbo.CustomerModels");
            DropIndex("dbo.AddressModels", new[] { "Id" });
            DropTable("dbo.CustomerModels");
            DropTable("dbo.AddressModels");
        }
    }
}
