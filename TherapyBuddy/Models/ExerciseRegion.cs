using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TherapyBuddy.Models
{
    public class ExerciseRegion
    {
        [Key]
        public int ExerciseRegionID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Exercise> Exercise { get; set; }
    }
}