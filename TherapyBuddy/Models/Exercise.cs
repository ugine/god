using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TherapyBuddy.Models
{
    public class Exercise
    {
        [Key]
        public int ExerciseID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ExerciseRegionID { get; set; }
        public int ExerciseTypeID { get; set; }
        public virtual ExerciseType ExerciseType{ get; set;}
        //public virtual ICollection<ExerciseImage> ExerciseImages { get; set; }
        public virtual ExerciseRegion Region { get; set; }


    }
}