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
    public class TokenModel
    {
        public string DrID { get; set; }
        public string DrName { get; set; }

        public List<temp_DrPatientDetails> DrPatientDetails { get; set; }

        [Required]
        public string TokenNo { get; set; }
        [Required]
        public string PatName { get; set; }
        [Required]
        public string LoginID { get; set; }
        [Required]
        public string DivisionID { get; set; }
        [Required]
        public string SiteID { get; set; }
        public TokenModel()
        {
            DivisionID = SystemHelper.Get_DivisionID_Session();
            SiteID = SystemHelper.Get_SiteID_Session();
            LoginID = SystemHelper.Get_User_Session(); 
            TokenNo = string.Empty;
            PatName = string.Empty;
        }
    }
}