using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TherapyBuddy.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public virtual ICollection<Therapist> Therapists { get; set; }
    }
}