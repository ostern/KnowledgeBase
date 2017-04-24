namespace KnowledgeBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbcontext2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Issues", "Solution_SolutionID", "dbo.Solutions");
            DropIndex("dbo.Issues", new[] { "Solution_SolutionID" });
            DropColumn("dbo.Issues", "Solution_SolutionID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Issues", "Solution_SolutionID", c => c.Int());
            CreateIndex("dbo.Issues", "Solution_SolutionID");
            AddForeignKey("dbo.Issues", "Solution_SolutionID", "dbo.Solutions", "SolutionID");
        }
    }
}
