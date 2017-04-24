namespace KnowledgeBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedDisplayName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Issues", "DateIssueCreation", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Issues", "DateIssueCreation", c => c.DateTime(nullable: false));
        }
    }
}
