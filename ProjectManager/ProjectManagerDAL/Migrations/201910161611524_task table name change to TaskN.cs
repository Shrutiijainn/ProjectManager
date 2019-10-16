namespace ProjectManagerDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tasktablenamechangetoTaskN : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Tasks", newName: "TaskNs");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.TaskNs", newName: "Tasks");
        }
    }
}
