using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Students.Data.Models
{
    public class StudentClasses
    {
        public int ID { get; set; }
        public int ClassesID { get; set; }
        public virtual Classes Classes { get; set; }
        public int StudentsID { get; set; }
        public virtual Students student { get; set; }
    }
}