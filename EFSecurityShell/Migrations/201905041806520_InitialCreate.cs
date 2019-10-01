namespace EFSecurityShell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applicants",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        MiddleName = c.String(maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        CreateTime = c.DateTime(nullable: false),
                        SocialSecurityNo = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        HomePhone = c.String(nullable: false),
                        CellPhone = c.String(nullable: false),
                        Street = c.String(nullable: false, maxLength: 50),
                        City = c.String(nullable: false, maxLength: 45),
                        State = c.String(nullable: false, maxLength: 12),
                        Zip = c.String(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        Gender = c.String(nullable: false),
                        SchoolName = c.String(nullable: false),
                        SchoolCity = c.String(nullable: false),
                        GraduationDate = c.DateTime(nullable: false),
                        GPA = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MathScore = c.Int(nullable: false),
                        VerbalScore = c.Int(nullable: false),
                        TotalScore = c.Int(nullable: false),
                        PAOfInterest = c.Int(nullable: false),
                        EnrollmentSemester = c.Int(nullable: false),
                        EnrollmentYear = c.Int(nullable: false),
                        EnrollmentDecision = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Applicants");
        }
    }
}
