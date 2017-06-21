namespace Garage20.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNbr = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(nullable: false),
                        VehicleTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleTypes", t => t.VehicleTypeId, cascadeDelete: true)
                .Index(t => t.MemberId)
                .Index(t => t.VehicleTypeId);
            
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VehicleTypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ParkedVehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Verification = c.String(),
                        RegNr = c.String(nullable: false),
                        Color = c.String(nullable: false),
                        Brand = c.String(nullable: false),
                        Model = c.String(nullable: false),
                        WheelsAmount = c.Int(nullable: false),
                        CheckInTime = c.DateTime(),
                        CheckOutTime = c.DateTime(),
                        AmountFee = c.Int(nullable: false),
                        VehicleType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VehicleTypes", t => t.VehicleType_Id)
                .Index(t => t.VehicleType_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ParkedVehicles", "VehicleType_Id", "dbo.VehicleTypes");
            DropForeignKey("dbo.Vehicles", "VehicleTypeId", "dbo.VehicleTypes");
            DropForeignKey("dbo.Vehicles", "MemberId", "dbo.Members");
            DropIndex("dbo.ParkedVehicles", new[] { "VehicleType_Id" });
            DropIndex("dbo.Vehicles", new[] { "VehicleTypeId" });
            DropIndex("dbo.Vehicles", new[] { "MemberId" });
            DropTable("dbo.ParkedVehicles");
            DropTable("dbo.VehicleTypes");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Members");
        }
    }
}
