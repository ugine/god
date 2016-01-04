using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TherapyBuddy.Models
{
    public class Therapist
    {
        [Key]
        public int TherapistID { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}