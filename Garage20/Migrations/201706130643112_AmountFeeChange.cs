namespace Garage20.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AmountFeeChange : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ParkedVehicles", "AmountFee");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ParkedVehicles", "AmountFee", c => c.Int(nullable: false));
        }
    }
}
