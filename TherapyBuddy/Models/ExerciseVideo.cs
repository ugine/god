using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TherapyBuddy.Models
{
    public class ExerciseVideo
    {
        [Key]
        public int ExerciseVideoID { get; set; }
        public string VideoURL { get; set; }
        public int ExerciseID { get; set; }
        public virtual Exercise Exercise { get; set; }
        public virtual ICollection<AssignedVideo> AssignedVideos { get; set; }
    }
}