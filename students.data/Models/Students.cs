using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Students.Data.Models
{
    public class Students
    {
        public int ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public int SNN { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public int Phone { get; set; }
    }
}