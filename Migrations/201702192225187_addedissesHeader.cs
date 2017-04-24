namespace KnowledgeBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedissesHeader : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Issues", "IssueHeader", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Issues", "IssueHeader");
        }
    }
}
