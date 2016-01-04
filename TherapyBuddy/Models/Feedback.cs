using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace TherapyBuddy.Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackID { get; set; }
        public string Recipient { get; set; }
        public string Sender { get; set; }
        public string Date_Sent { get; set; }
        public bool HasReplied { get; set; }
        [NotMapped]
        public HttpPostedFileBase VideoFile { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        public string Description { get; set; }
    }
}