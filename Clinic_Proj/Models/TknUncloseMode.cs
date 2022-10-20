using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Clinic_Proj.Database_Access;

namespace Clinic_Proj.Models
{
    public class TknUncloseMode
    {
        [Required]
        public string TokenNo { get; set; }
        [Required]
        public string Site { get; set; }
        [Required]
        public string LoginID { get; set; }
        public string DivisionID { get; set; }
        public string SiteID { get; set; }
        public TknUncloseMode()
        {
            DivisionID = SystemHelper.Get_DivisionID_Session(); //SystemHelper.DivisionID;
            SiteID = SystemHelper.Get_SiteID_Session(); //SystemHelper.SiteID;
            LoginID = SystemHelper.Get_User_Session(); //SystemHelper.Username;
            TokenNo = string.Empty;
            Site = string.Empty;
        }
    }
}