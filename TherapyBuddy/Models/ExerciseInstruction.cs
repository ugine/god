using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TherapyBuddy.Models
{
    public class ExerciseInstruction
    {
        [Key]
        public int ExerciseInstructionID { get; set; }
        public int Number_Of_Reps { get; set; }
        public int Frequency_Per_Day { get; set; }
        public int Reps_Completed { get; set; }
        public string Remark { get; set; }
        public int AssignmentID { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual Assignment Assignment { get; set; }
        public virtual ICollection<AssignedVideo> AssignedVideos { get; set; }

        public virtual ICollection<AssignedImage> AssignedImages { get; set; }

    }
}