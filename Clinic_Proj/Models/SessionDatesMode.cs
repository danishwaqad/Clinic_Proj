using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Clinic_Proj.Database_Access;

namespace Clinic_Proj.Models
{
    public class SessionDatesMode
    {
        [Required]
        public string TokenNo { get; set; }
        [Required]
        public DateTime ToDate { get; set; }
        [Required]
        public string Remarks { get; set; }
        [Required]
        public string LoginID { get; set; }
        public string DivisionID { get; set; }
        public string SiteID { get; set; }
        public SessionDatesMode()
        {
            TokenNo = string.Empty;
            ToDate = new DateTime();
            DivisionID = SystemHelper.Get_DivisionID_Session();
            SiteID = SystemHelper.Get_SiteID_Session();
            LoginID = SystemHelper.Get_User_Session();
            Remarks = string.Empty;
        }
    }
}