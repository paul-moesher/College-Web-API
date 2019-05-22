using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Students.Data.Models
{
    public class Scores
    {
        public int ID { get; set; }
        public int ScoreTypesID { get; set; }
        public virtual ScoreTypes ScoreTypes { get; set; }
        public int StudentClassesID { get; set; }
        public virtual StudentClasses StudentClasses { get; set; }
        public string Description { get; set; }
        public DateTime DateAssigned { get; set; }
        public DateTime DateDue { get; set; }
        public DateTime DateSubmitted { get; set; }
        public int PointsEarned { get; set; }
        public int PointsPossible { get; set; }
    }
}