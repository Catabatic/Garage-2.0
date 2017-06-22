namespace Garage20.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "PhoneNbr", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "PhoneNbr", c => c.String());
            AlterColumn("dbo.Members", "LastName", c => c.String());
            AlterColumn("dbo.Members", "FirstName", c => c.String());
        }
    }
}
