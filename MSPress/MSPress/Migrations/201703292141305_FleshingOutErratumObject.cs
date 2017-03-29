namespace MSPress.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FleshingOutErratumObject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Errata", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Errata", "PageNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Errata", "DescriptionOfError", c => c.String());
            AddColumn("dbo.Errata", "Reporter_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Errata", "Reporter_Id");
            AddForeignKey("dbo.Errata", "Reporter_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Errata", "Reporter_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Errata", new[] { "Reporter_Id" });
            DropColumn("dbo.Errata", "Reporter_Id");
            DropColumn("dbo.Errata", "DescriptionOfError");
            DropColumn("dbo.Errata", "PageNumber");
            DropColumn("dbo.Errata", "Status");
        }
    }
}
