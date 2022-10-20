using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Clinic_Proj.Database_Access;

namespace Clinic_Proj.Models
{
    public class PatientVitalMode
    {
        [Required]
        public string PatCNIC { get; set; }
        [Required]
        public int id { get; set; }
        [Required]
        public string TokenDate { get; set; }
        [Required]
        public string PatName { get; set; }
        [Required]
        public string TokenNo { get; set; }
        [Required]
        public string VitalName { get; set; }
        [Required]
        public string VitalValue { get; set; }
        [Required]
        public string LoginID { get; set; }
        [Required]
        public string DivisionID { get; set; }
        [Required]
        public string SiteID { get; set; }
        public int CCPL_rowId { get; set; }

        public PatientVitalMode()
        {
            DivisionID = SystemHelper.Get_DivisionID_Session(); //SystemHelper.DivisionID;
            SiteID = SystemHelper.Get_SiteID_Session(); //SystemHelper.SiteID;
            LoginID = SystemHelper.Get_User_Session(); //SystemHelper.Username;
            TokenNo = string.Empty;
            PatCNIC = string.Empty;
            PatName = string.Empty;
            VitalName = string.Empty;
            VitalValue = string.Empty;
            id = new int();
            TokenDate = string.Empty;
        }
    }
}