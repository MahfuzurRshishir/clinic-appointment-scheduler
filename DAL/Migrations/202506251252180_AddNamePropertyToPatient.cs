namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNamePropertyToPatient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "Name");
        }
    }
}
