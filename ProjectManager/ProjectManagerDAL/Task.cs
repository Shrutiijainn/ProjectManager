using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProjectManagerDAL
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }
        [StringLength(100)]
        [Required]
        [Column(TypeName = "varchar")]
        public string TaskName { get; set; }
        [StringLength(300)]
        [Column(TypeName = "varchar")]
        public string TaskDescription { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime TaskStartDate { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime TaskEndDate { get; set; }
        [RegularExpression("^[1 - 5]{1}$")]
        public int TaskPriority { get; set; }
        [Column(TypeName = "varchar")]
        public string TaskStatus { get; set; }
        [ForeignKey("P")]
        public int ProjectId { get; set; }
        [ForeignKey("Emp")]
        public int EmployeeId { get; set; }
        public virtual Project P { get; set; }
        public virtual Employee Emp { get; set; }

    }
}