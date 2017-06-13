namespace Garage20.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class merge2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ParkedVehicles", "CheckOutTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ParkedVehicles", "CheckOutTime", c => c.DateTime(nullable: false));
        }
    }
}
