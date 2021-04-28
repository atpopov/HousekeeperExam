namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKey : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Tasks", "LocationId");
            AddForeignKey("dbo.Tasks", "LocationId", "dbo.Locations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "LocationId", "dbo.Locations");
            DropIndex("dbo.Tasks", new[] { "LocationId" });
            AlterColumn("dbo.Tasks", "LocationId", c => c.Int(nullable:false));
        }
    }
}
