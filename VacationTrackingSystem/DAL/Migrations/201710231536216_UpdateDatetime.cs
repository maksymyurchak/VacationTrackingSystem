namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Holidays", "Date", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Holidays", "DateCreated", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Holidays", "DateModified", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.InfoAboutVacations", "DateCreated", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.InfoAboutVacations", "DateModified", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Users", "DateCreated", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Users", "DateModified", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Roles", "DateCreated", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Roles", "DateModified", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.VacationRequests", "StartDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.VacationRequests", "EndDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.VacationRequests", "DateCreated", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.VacationRequests", "DateModified", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Policies", "DateCreated", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Policies", "DateModified", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Policies", "DateModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Policies", "DateCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.VacationRequests", "DateModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.VacationRequests", "DateCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.VacationRequests", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.VacationRequests", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Roles", "DateModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Roles", "DateCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "DateModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "DateCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.InfoAboutVacations", "DateModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.InfoAboutVacations", "DateCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Holidays", "DateModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Holidays", "DateCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Holidays", "Date", c => c.DateTime(nullable: false));
        }
    }
}
