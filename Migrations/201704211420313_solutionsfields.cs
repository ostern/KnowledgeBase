namespace KnowledgeBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class solutionsfields : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Solutions", new[] { "IssueId" });
            CreateIndex("dbo.Solutions", "IssueID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Solutions", new[] { "IssueID" });
            CreateIndex("dbo.Solutions", "IssueId");
        }
    }
}
