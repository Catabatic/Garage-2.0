namespace Garage20.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mergetest : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ParkedVehicles", "RegNr", c => c.String(nullable: false));
            AlterColumn("dbo.ParkedVehicles", "Color", c => c.String(nullable: false));
            AlterColumn("dbo.ParkedVehicles", "Brand", c => c.String(nullable: false));
            AlterColumn("dbo.ParkedVehicles", "Model", c => c.String(nullable: false));
            AlterColumn("dbo.ParkedVehicles", "CheckOutTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ParkedVehicles", "CheckOutTime", c => c.DateTime());
            AlterColumn("dbo.ParkedVehicles", "Model", c => c.String());
            AlterColumn("dbo.ParkedVehicles", "Brand", c => c.String());
            AlterColumn("dbo.ParkedVehicles", "Color", c => c.String());
            AlterColumn("dbo.ParkedVehicles", "RegNr", c => c.String());
        }
    }
}
