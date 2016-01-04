using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TherapyBuddy.Models
{
    public class ExerciseType
    {
        [Key]
        public int ExerciseTypeID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Exercise> Exercise { get; set; }
    }
}