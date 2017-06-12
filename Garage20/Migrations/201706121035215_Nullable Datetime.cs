namespace Garage20.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableDatetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ParkedVehicles", "CheckInTime", c => c.DateTime());
            AlterColumn("dbo.ParkedVehicles", "CheckOutTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ParkedVehicles", "CheckOutTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ParkedVehicles", "CheckInTime", c => c.DateTime(nullable: false));
        }
    }
}
