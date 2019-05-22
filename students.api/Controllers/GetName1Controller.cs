using CollegeDBEF.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;



namespace Students.API_.Controllers
{
    public class GetName1Controller : ApiController
    {
        public string GetName1(int id)
        {
            string fullName = "";

            using (schoolContext name = new schoolContext())
            {
                CollegeEFDB.Models.Students1 NAME = name.Students.FirstOrDefault(a => a.ID == id);
                if (NAME == null)
                {
                    return "not found";
                }
                fullName = NAME.FName + " " + NAME.LName;
            }

            return fullName;
        }




   
    }
}