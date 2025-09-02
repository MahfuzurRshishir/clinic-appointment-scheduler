namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMorTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        AppointmentId = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        AppointmentDate = c.DateTime(nullable: false),
                        Status = c.String(nullable: false),
                        Reason = c.String(),
                        Notes = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AppointmentId)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: false)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: false)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        EmailLogId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        EmailAddress = c.String(),
                        Subject = c.String(),
                        Body = c.String(),
                        SentAt = c.DateTime(nullable: false),
                        IsSuccess = c.Boolean(nullable: false),
                        ErrorMessage = c.String(),
                    })
                .PrimaryKey(t => t.EmailLogId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.FileRecords",
                c => new
                    {
                        FileRecordId = c.Int(nullable: false, identity: true),
                        AppointmentId = c.Int(),
                        PatientId = c.Int(),
                        FileName = c.String(),
                        FilePath = c.String(),
                        FileType = c.String(),
                        UploadedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FileRecordId)
                .ForeignKey("dbo.Appointments", t => t.AppointmentId)
                .ForeignKey("dbo.Patients", t => t.PatientId)
                .Index(t => t.AppointmentId)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotificationId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Message = c.String(),
                        IsRead = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.NotificationId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "UserId", "dbo.Users");
            DropForeignKey("dbo.FileRecords", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.FileRecords", "AppointmentId", "dbo.Appointments");
            DropForeignKey("dbo.Emails", "UserId", "dbo.Users");
            DropForeignKey("dbo.Appointments", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Notifications", new[] { "UserId" });
            DropIndex("dbo.FileRecords", new[] { "PatientId" });
            DropIndex("dbo.FileRecords", new[] { "AppointmentId" });
            DropIndex("dbo.Emails", new[] { "UserId" });
            DropIndex("dbo.Appointments", new[] { "DoctorId" });
            DropIndex("dbo.Appointments", new[] { "PatientId" });
            DropTable("dbo.Notifications");
            DropTable("dbo.FileRecords");
            DropTable("dbo.Emails");
            DropTable("dbo.Appointments");
        }
    }
}
