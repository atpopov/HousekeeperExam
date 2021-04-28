namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBudget : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "Budget", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tasks", "Budget");
        }
    }
}
