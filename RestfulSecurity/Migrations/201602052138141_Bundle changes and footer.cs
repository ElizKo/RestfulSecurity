namespace RestfulSecurity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Bundlechangesandfooter : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Files", "FileName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Patients", "Title", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Patients", "FirstName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Patients", "LastName", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "LastName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Patients", "FirstName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Patients", "Title", c => c.String(maxLength: 50));
            AlterColumn("dbo.Files", "FileName", c => c.String(maxLength: 200));
        }
    }
}
