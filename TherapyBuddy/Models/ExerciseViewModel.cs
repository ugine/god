using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TherapyBuddy.Models
{
    public class ExerciseViewModel
    {
        public int ExerciseViewModelID { get; set; }
        public int ExerciseRegionID { get; set; }
        public int ExerciseTypeID { get; set; }
        public string Exercise { get; set; }
        public int ExerciseID { get; set; }
        public string ExerciseDescription { get; set; }
        public string VideoURL { get; set; }
        public string ImageURL { get; set; }
        //public string ArticleURL { get; set; }
        public virtual ExerciseRegion ExerciseRegion { get; set; }
        public virtual ExerciseType ExerciseType { get; set; }
    }
}