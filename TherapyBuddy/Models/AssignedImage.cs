using System.ComponentModel.DataAnnotations;

namespace TherapyBuddy.Models
{
    public class AssignedImage
    {
        [Key]
        public int AssignedImageID { get; set; }
        public int ExerciseInstructionID { get; set; }
        public int ExerciseImageID { get; set; }
        public virtual ExerciseImage ExerciseImage { get; set; }
        public virtual ExerciseInstruction ExerciseInstruction { get; set; }
    }
}