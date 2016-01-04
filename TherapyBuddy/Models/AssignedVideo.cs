using System.ComponentModel.DataAnnotations;

namespace TherapyBuddy.Models
{
    public class AssignedVideo
    {
        [Key]
        public int AssignedVideoID { get; set; }
        public int ExerciseInstructionID { get; set; }
        public int ExerciseVideoID { get; set; }
        public virtual ExerciseInstruction ExerciseInstruction { get; set; }
        public virtual ExerciseVideo ExerciseVideo { get; set; }
    }
}