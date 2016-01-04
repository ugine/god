using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TherapyBuddy.Models
{
    public class Assignment
    {
        [Key]
        public int AssignmentID { get; set; }
        public DateTime Date_Assigned { get; set; }
        public int PatientID { get; set; }
        public int TherapistID { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Therapist Therapist { get; set; }
        public virtual ICollection<ExerciseInstruction> ExerciseInstructions { get; set; }


    }
}