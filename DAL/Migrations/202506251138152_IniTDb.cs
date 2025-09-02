namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IniTDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        DoctorId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Specialization = c.String(nullable: false),
                        Qualifications = c.String(),
                        ExperienceYears = c.Int(),
                        ClinicRoom = c.String(),
                    })
                .PrimaryKey(t => t.DoctorId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Role = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Gender = c.String(),
                        EmergencyContact = c.String(),
                        MedicalHistory = c.String(),
                        DateOfBirth = c.DateTime(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.PatientId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "UserId", "dbo.Users");
            DropForeignKey("dbo.Doctors", "UserId", "dbo.Users");
            DropIndex("dbo.Patients", new[] { "UserId" });
            DropIndex("dbo.Doctors", new[] { "UserId" });
            DropTable("dbo.Patients");
            DropTable("dbo.Users");
            DropTable("dbo.Doctors");
        }
    }
}
