namespace Garage20.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVehicleType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ParkedVehicles", "VehicleType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ParkedVehicles", "VehicleType");
        }
    }
}
