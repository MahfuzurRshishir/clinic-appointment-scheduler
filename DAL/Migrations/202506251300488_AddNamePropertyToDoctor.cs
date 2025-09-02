namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNamePropertyToDoctor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "Name");
        }
    }
}
