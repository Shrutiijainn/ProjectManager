namespace ProjectManagerDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class entitiesadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(nullable: false, maxLength: 30, unicode: false),
                        EmployeeDesignation = c.String(nullable: false, maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ProjectTitle = c.String(nullable: false, maxLength: 50, unicode: false),
                        ProjectStartDate = c.DateTime(nullable: false, storeType: "date"),
                        ProjectEndDate = c.DateTime(nullable: false, storeType: "date"),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: false)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        TaskName = c.String(nullable: false, maxLength: 100, unicode: false),
                        TaskDescription = c.String(maxLength: 300, unicode: false),
                        TaskStartDate = c.DateTime(nullable: false, storeType: "date"),
                        TaskEndDate = c.DateTime(nullable: false, storeType: "date"),
                        TaskPriority = c.Int(nullable: false),
                        TaskStatus = c.String(maxLength: 8000, unicode: false),
                        ProjectId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: false)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: false)
                .Index(t => t.ProjectId)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Tasks", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Projects", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Tasks", new[] { "EmployeeId" });
            DropIndex("dbo.Tasks", new[] { "ProjectId" });
            DropIndex("dbo.Projects", new[] { "EmployeeId" });
            DropTable("dbo.Tasks");
            DropTable("dbo.Projects");
            DropTable("dbo.Employees");
        }
    }
}
