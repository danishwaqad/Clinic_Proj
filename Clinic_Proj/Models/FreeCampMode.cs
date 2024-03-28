using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Clinic_Proj.Database_Access;

namespace Clinic_Proj.Models
{
    public class FreeCampMode
    {
        [Required]
        public string DoctorID { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public string DrName { get; set; }
        [Required]
        public string SiteCode { get; set; }
        [Required]
        public string DisType { get; set; }
        [Required]
        public double Discount { get; set; }
        [Required]
        public string DisAprov { get; set; }
        [Required]
        public double ID { get; set; }
        [Required]
        public string DivisionID { get; set; }
        [Required]
        public string SiteID { get; set; }
        [Required]
        public string LoginID { get; set; }
        public FreeCampMode()
        {
            DoctorID = string.Empty;
            ID = new double();
            Status = new bool();
            DivisionID = SystemHelper.Get_DivisionID_Session(); 
            SiteID = SystemHelper.Get_SiteID_Session(); 
            LoginID = SystemHelper.Get_User_Session(); 
            DrName = string.Empty;
            SiteCode = string.Empty;
            DisType = string.Empty;
            DisAprov = string.Empty;
            Discount = new double();
        }
    }
}