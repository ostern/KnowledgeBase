namespace KnowledgeBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbcontext_correctdb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Issues", "ProductVersion", c => c.String());
            DropColumn("dbo.Products", "ProductVersion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ProductVersion", c => c.String());
            DropColumn("dbo.Issues", "ProductVersion");
        }
    }
}
