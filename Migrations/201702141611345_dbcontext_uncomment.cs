namespace KnowledgeBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbcontext_uncomment : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Issues", "ProductId");
            CreateIndex("dbo.Solutions", "IssueId");
            AddForeignKey("dbo.Issues", "ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
            AddForeignKey("dbo.Solutions", "IssueId", "dbo.Issues", "IssueID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Solutions", "IssueId", "dbo.Issues");
            DropForeignKey("dbo.Issues", "ProductId", "dbo.Products");
            DropIndex("dbo.Solutions", new[] { "IssueId" });
            DropIndex("dbo.Issues", new[] { "ProductId" });
        }
    }
}
