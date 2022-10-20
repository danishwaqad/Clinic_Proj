using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Clinic_Proj.Database_Access;

namespace Clinic_Proj.Models
{
    public class CalenderMode
    {
        
        public string title { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string allDay { get; set; }
        public string className { get; set; }

    }
}