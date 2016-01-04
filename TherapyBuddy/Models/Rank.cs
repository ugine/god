using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TherapyBuddy.Models
{
    public class Rank
    {
        [Key]
        public int RankID { get; set; }
        public string Rank_Name { get; set; }
        public int Min_Point { get; set; }
        public int Max_Point { get; set; }
    }
}