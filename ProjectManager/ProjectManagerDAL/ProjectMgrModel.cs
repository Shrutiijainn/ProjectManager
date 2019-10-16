namespace ProjectManagerDAL
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    internal class ProjectMgrModel : DbContext
    {
        public ProjectMgrModel()
            : base("name=ProjectMgrModel")
        {
        }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<TaskN> Tasks { get; set; }

    }
}