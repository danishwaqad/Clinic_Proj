using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Clinic_Proj.Database_Access;

namespace Clinic_Proj.Models
{
    public class DocPaymentMode
    {
        [Required]
        public string DocNo { get; set; }
        [Required]
        public DateTime DocDate { get; set; }
        [Required]
        public string DoctorID { get; set; }
        [Required]
        public double LineTotal { get; set; }
        [Required]
        public double LinePaid { get; set; }
        [Required]
        public string Remarks { get; set; }
        [Required]
        public string LoginID { get; set; }
        public string DivisionID { get; set; }
        public string SiteID { get; set; }
        public DocPaymentMode()
        {
            DocNo = string.Empty;
            DocDate = new DateTime();
            DivisionID = SystemHelper.Get_DivisionID_Session(); 
            SiteID = SystemHelper.Get_SiteID_Session(); 
            LoginID = SystemHelper.Get_User_Session(); 
            DoctorID = string.Empty;
            Remarks = string.Empty;
            LinePaid = new double();
            LineTotal = new double();
        }
    }
}