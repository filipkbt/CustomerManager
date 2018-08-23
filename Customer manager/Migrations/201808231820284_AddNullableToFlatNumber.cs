namespace Customer_manager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNullableToFlatNumber : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AddressModels", "FlatNumber", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AddressModels", "FlatNumber", c => c.Int(nullable: false));
        }
    }
}
