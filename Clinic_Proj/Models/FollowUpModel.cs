using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Clinic_Proj.Database_Access;

namespace Clinic_Proj.Models
{
    public class FollowUpModel
    {
        [Required]
        public string RegNo { get; set; }
        [Required]
        public string TokenNo { get; set; }
        [Required]
        public string Site { get; set; }
        [Required]
        public DateTime TokenDate { get; set; }
        [Required]
        public string CNIC { get; set; }
        [Required]
        public string DoctorID { get; set; }
        [Required]
        public string ContactVia { get; set; }
        [Required]
        public DateTime NextFollowUpDate { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string PatName { get; set; }
        [Required]
        public string DrName { get; set; }
        [Required]
        public DateTime FollowupDate { get; set; }
        [Required]
        public string Remarks { get; set; }
        [Required]
        public string LoginID { get; set; }
        public string DivisionID { get; set; }
        public string SiteID { get; set; }
        public FollowUpModel()
        {
            RegNo = string.Empty;
            TokenDate = new DateTime();
            DivisionID = SystemHelper.Get_DivisionID_Session(); //SystemHelper.DivisionID;
            SiteID = SystemHelper.Get_SiteID_Session(); //SystemHelper.SiteID;
            LoginID = SystemHelper.Get_User_Session(); //SystemHelper.Username;
            TokenNo = string.Empty;
            Site = string.Empty;
            CNIC = string.Empty;
            PatName = string.Empty;
            ContactVia = string.Empty;
            NextFollowUpDate = new DateTime();
            Status = string.Empty;
            DoctorID = string.Empty;
            DrName = string.Empty;
            FollowupDate = new DateTime();
            Remarks = string.Empty;
        }
    }
}