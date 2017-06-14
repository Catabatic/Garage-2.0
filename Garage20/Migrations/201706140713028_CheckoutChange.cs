namespace Garage20.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckoutChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ParkedVehicles", "AmountFee", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ParkedVehicles", "AmountFee");
        }
    }
}
