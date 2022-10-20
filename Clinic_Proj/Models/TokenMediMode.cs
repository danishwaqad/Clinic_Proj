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
    public class TokenMediMode
    {
        
        public string TokenNo { get; set; }
        
        public string DivisionID { get; set; }
        
        public string SiteID { get; set; }


        public TokenMediMode()
        {
            TokenNo = string.Empty;
            DivisionID = string.Empty;
            SiteID = string.Empty;
        }

    }
}