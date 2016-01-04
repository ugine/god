using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TherapyBuddy.Models
{
    public class AssignExercisesViewModel
    {
        public int AssignExercisesViewModelID { get; set; }
        public int ExerciseRegionID { get; set; }
        public int ExerciseTypeID { get; set; }
        public int ExerciseID { get; set; }
        public int ExerciseVideoID { get; set; }   
        
        //Exercise Instructions   
        public int Number_Of_Reps { get; set; }
        public int Frequency_Per_Day { get; set; }
        public int Reps_Completed { get; set; }
        public string Remark { get; set; }
    }
}