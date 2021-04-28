namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Locations", "UserId");
            AddForeignKey("dbo.Locations", "UserId", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Locations"," UserId");
            DropForeignKey("dbo.Locations", "UserId", "dbo.Users");
            DropIndex("dbo.Locations", new[] { "UserId" });
            AlterColumn("dbo.Locations", "UserId", c => c.Int(nullable: false));
        }
    }
}
