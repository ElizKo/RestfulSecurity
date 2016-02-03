namespace RestfulSecurity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 200),
                        PatientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientID, cascadeDelete: true)
                .Index(t => t.PatientID);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        FirstName = c.String(maxLength: 100),
                        LastName = c.String(maxLength: 100),
                        Age = c.Int(nullable: false),
                        NumberOfEmbryos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Files", "PatientID", "dbo.Patients");
            DropIndex("dbo.Files", new[] { "PatientID" });
            DropTable("dbo.Patients");
            DropTable("dbo.Files");
        }
    }
}
