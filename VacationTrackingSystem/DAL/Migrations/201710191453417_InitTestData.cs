namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitTestData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InfoAboutVacations", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.InfoAboutVacations", "DateModified", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InfoAboutVacations", "DateModified");
            DropColumn("dbo.InfoAboutVacations", "DateCreated");
        }
    }
}
