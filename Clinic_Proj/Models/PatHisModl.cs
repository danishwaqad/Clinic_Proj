using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Clinic_Proj.Database_Access;

namespace Clinic_Proj.Models
{
    public class PatHisModl
    {
        [Required]
        public string Type { get; set; }
        [Required]
        public string CNICFrom { get; set; }
        [Required]
        public string CNICTo { get; set; }
        [Required]
        public string SiteFrom { get; set; }
        [Required]
        public string SiteTo { get; set; }
        [Required]
        public string TokenNo { get; set; }
        [Required]
        public string SiteID { get; set; }
        [Required]
        public string DoctorName { get; set; }
        [Required]
        public string LoginID { get; set; }
        [Required]
        public string DivisionID { get; set; }
        [Required]
        public DateTime DateFrom { get; set; }
        [Required]
        public DateTime DateTo { get; set; }
        public PatHisModl()
        {
            TokenNo = string.Empty;
            CNICFrom = string.Empty;
            CNICTo = string.Empty;
            DoctorName = string.Empty;
            SiteFrom = string.Empty;
            SiteTo = string.Empty;
            DateFrom = new DateTime();
            Type = string.Empty;
            DateTo = new DateTime();
            DivisionID = SystemHelper.Get_DivisionID_Session(); //SystemHelper.DivisionID;
            SiteID = SystemHelper.Get_SiteID_Session(); //SystemHelper.SiteID;
            LoginID = SystemHelper.Get_User_Session(); //SystemHelper.Username;
        }

    }
}