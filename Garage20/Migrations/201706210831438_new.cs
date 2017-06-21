namespace Garage20.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "Verification", c => c.String());
            AddColumn("dbo.Vehicles", "RegNr", c => c.String(nullable: false));
            AddColumn("dbo.Vehicles", "Color", c => c.String(nullable: false));
            AddColumn("dbo.Vehicles", "Brand", c => c.String(nullable: false));
            AddColumn("dbo.Vehicles", "Model", c => c.String(nullable: false));
            AddColumn("dbo.Vehicles", "WheelsAmount", c => c.Int(nullable: false));
            AddColumn("dbo.Vehicles", "CheckInTime", c => c.DateTime());
            AddColumn("dbo.Vehicles", "CheckOutTime", c => c.DateTime());
            AddColumn("dbo.Vehicles", "AmountFee", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "AmountFee");
            DropColumn("dbo.Vehicles", "CheckOutTime");
            DropColumn("dbo.Vehicles", "CheckInTime");
            DropColumn("dbo.Vehicles", "WheelsAmount");
            DropColumn("dbo.Vehicles", "Model");
            DropColumn("dbo.Vehicles", "Brand");
            DropColumn("dbo.Vehicles", "Color");
            DropColumn("dbo.Vehicles", "RegNr");
            DropColumn("dbo.Vehicles", "Verification");
        }
    }
}
