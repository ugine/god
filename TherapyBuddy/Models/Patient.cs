using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TherapyBuddy.Models
{
    public class Patient
    {
        [Key]
        public int PatientID { get; set; }
        public string Patient_Email { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        //[NotMapped]
        //[DataType(DataType.Password)]
        //[Display(Name = "Confirm password")]
        //[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        //public string ConfirmPassword { get; set; }
        public int Phone_Number { get; set; }
        public string Gender { get; set; }
        [DataType(DataType.Date)]
        public string Date_Of_Birth { get; set; }
        public Boolean Feedback_Allowed { get; set; }
        public int Total_Points { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}