namespace ProjectManagerDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tasktablechange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tasks", "TaskStatus", c => c.String(nullable: false, maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tasks", "TaskStatus", c => c.String(maxLength: 8000, unicode: false));
        }
    }
}
