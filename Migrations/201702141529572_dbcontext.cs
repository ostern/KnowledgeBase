namespace KnowledgeBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbcontext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Issues",
                c => new
                    {
                        IssueID = c.Int(nullable: false, identity: true),
                        ErrorCode = c.String(),
                        IssueText = c.String(),
                        Username = c.String(),
                        DateIssueCreation = c.DateTime(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Solution_SolutionID = c.Int(),
                    })
                .PrimaryKey(t => t.IssueID)
                .ForeignKey("dbo.Solutions", t => t.Solution_SolutionID)
                .Index(t => t.Solution_SolutionID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductVersion = c.String(),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.Solutions",
                c => new
                    {
                        SolutionID = c.Int(nullable: false, identity: true),
                        SolutionText = c.String(),
                        Username = c.String(),
                        DateSolutionCreation = c.DateTime(nullable: false),
                        IssueId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SolutionID);
            
            CreateTable(
                "dbo.ProductIssues",
                c => new
                    {
                        Product_ProductId = c.Int(nullable: false),
                        Issue_IssueID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_ProductId, t.Issue_IssueID })
                .ForeignKey("dbo.Products", t => t.Product_ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Issues", t => t.Issue_IssueID, cascadeDelete: true)
                .Index(t => t.Product_ProductId)
                .Index(t => t.Issue_IssueID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Issues", "Solution_SolutionID", "dbo.Solutions");
            DropForeignKey("dbo.ProductIssues", "Issue_IssueID", "dbo.Issues");
            DropForeignKey("dbo.ProductIssues", "Product_ProductId", "dbo.Products");
            DropIndex("dbo.ProductIssues", new[] { "Issue_IssueID" });
            DropIndex("dbo.ProductIssues", new[] { "Product_ProductId" });
            DropIndex("dbo.Issues", new[] { "Solution_SolutionID" });
            DropTable("dbo.ProductIssues");
            DropTable("dbo.Solutions");
            DropTable("dbo.Products");
            DropTable("dbo.Issues");
        }
    }
}
