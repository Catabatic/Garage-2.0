namespace Garage20.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vehiclesmembers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehiclesMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Member_Id = c.Int(),
                        Vehicle_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.Member_Id)
                .ForeignKey("dbo.Vehicles", t => t.Vehicle_Id)
                .Index(t => t.Member_Id)
                .Index(t => t.Vehicle_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehiclesMembers", "Vehicle_Id", "dbo.Vehicles");
            DropForeignKey("dbo.VehiclesMembers", "Member_Id", "dbo.Members");
            DropIndex("dbo.VehiclesMembers", new[] { "Vehicle_Id" });
            DropIndex("dbo.VehiclesMembers", new[] { "Member_Id" });
            DropTable("dbo.VehiclesMembers");
        }
    }
}
