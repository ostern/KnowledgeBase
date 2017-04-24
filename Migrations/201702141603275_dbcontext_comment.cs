namespace KnowledgeBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbcontext_comment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductIssues", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductIssues", "Issue_IssueID", "dbo.Issues");
            DropIndex("dbo.ProductIssues", new[] { "Product_ProductId" });
            DropIndex("dbo.ProductIssues", new[] { "Issue_IssueID" });
            DropTable("dbo.ProductIssues");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductIssues",
                c => new
                    {
                        Product_ProductId = c.Int(nullable: false),
                        Issue_IssueID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_ProductId, t.Issue_IssueID });
            
            CreateIndex("dbo.ProductIssues", "Issue_IssueID");
            CreateIndex("dbo.ProductIssues", "Product_ProductId");
            AddForeignKey("dbo.ProductIssues", "Issue_IssueID", "dbo.Issues", "IssueID", cascadeDelete: true);
            AddForeignKey("dbo.ProductIssues", "Product_ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
        }
    }
}
