using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProjectManagerDAL
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [StringLength(30)]
        [Required]
        [Column(TypeName = "varchar")]
        public string EmployeeName { get; set; }
        [StringLength(30)]
        [Required]
        [Column(TypeName = "varchar")]
        public string EmployeeDesignation { get; set; }
    }
}