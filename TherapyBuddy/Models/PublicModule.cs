using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TherapyBuddy.Models
{
    public class PublicModule
    {
        [Key]
       
        public int PublicModuleID { get; set; }
        public String VideoURL { get; set; }
        public String ExerciseRegion { get; set; }
        public String ExerciseType { get; set; }
        [DisplayName("hello")]
        public String ExerciseName { get; set; }
    }
}