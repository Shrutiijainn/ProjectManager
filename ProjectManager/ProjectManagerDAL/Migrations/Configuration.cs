namespace ProjectManagerDAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjectManagerDAL.ProjectMgrModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProjectManagerDAL.ProjectMgrModel context)
        {
            context.Employees.AddOrUpdate(p => p.EmployeeName,
                new Employee() { EmployeeName = "Shruti Jain", EmployeeDesignation = "ProjectManager" },
                new Employee() { EmployeeName = "Vaishnavi Awasthi", EmployeeDesignation = "ProjectManager" },
                new Employee() { EmployeeName = "Pranav Dixit", EmployeeDesignation = "ProjectManager" },
                new Employee() { EmployeeName = "Harshitha", EmployeeDesignation = "Developer" },
                new Employee() { EmployeeName = "Sampada Kalyani", EmployeeDesignation = "Developer" }
            );
        }
    }
}
