using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProjectManagerDAL
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        [StringLength(50)]
        [Required]
        [Column(TypeName = "varchar")]
        public string ProjectTitle { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime ProjectStartDate { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime ProjectEndDate { get; set; }
        [ForeignKey("Emp")]
        public int EmployeeId { get; set; }

        public virtual ICollection<TaskN> Tasks { get; set; }
        public virtual Employee Emp { get; set; }
    }
}