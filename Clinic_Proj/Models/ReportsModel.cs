using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Clinic_Proj.Database_Access;

namespace Clinic_Proj.Models
{
    public class ReportsModel
    {
        [Required]
        public string SiteFrom { get; set; }
        [Required]
        public string SiteTo { get; set; }
        [Required]
        public string DoctorNam { get; set; }
        [Required]
        public DateTime DateFrom { get; set; }
        [Required]
        public DateTime DateTo { get; set; }
        [Required]
        public string LoginID { get; set; }
        public ReportsModel()
        {
            SiteFrom = string.Empty;
            DoctorNam = string.Empty;
            SiteTo = string.Empty;
            DateFrom = new DateTime();
            DateTo = new DateTime();
            LoginID = SystemHelper.Get_User_Session();
        }
    }
}