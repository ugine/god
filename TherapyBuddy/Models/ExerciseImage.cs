using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TherapyBuddy.Models
{
    public class ExerciseImage
    {
        [Key]
        public int ExerciseImageID { get; set; }
        public string ImageURL { get; set; }
        public int ExerciseID { get; set; }
        public virtual Exercise Exercise { get; set; }
        public virtual ICollection<AssignedImage> AssignedImages { get; set; }
    }
}