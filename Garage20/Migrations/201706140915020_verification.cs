namespace Garage20.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class verification : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ParkedVehicles", "Verification", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ParkedVehicles", "Verification");
        }
    }
}
