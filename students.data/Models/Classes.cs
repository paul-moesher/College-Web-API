using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Students.Data.Models
{
    public class Classes
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Number { get; set; }
        public int DepartmentTypesID { get; set; }
        public virtual DepartmentTypes DepartmentTypes { get; set; }
        public string instructor { get; set; }
    }
}