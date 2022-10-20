using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Clinic_Proj.Database_Access;

namespace Clinic_Proj.Models
{
    public class SiteModel
    {
        [Required]
        public string SiteCode { get; set; }
        [Required]
        public string DivisionCode { get; set; }
        [Required]
        public string SiteName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Tel { get; set; }
        [Required]
        public string Mobile1 { get; set; }
        [Required]
        public string Mobile2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Remarks { get; set; }
        [Required]
        public bool InActive { get; set; }
        [Required]
        public string LoginID { get; set; }
        public SiteModel()
        {
            SiteName = string.Empty;
            DivisionCode = string.Empty;
            SiteCode = string.Empty;
            Address = string.Empty;
            //Username = SystemHelper.Username;
            Tel = string.Empty;
            Mobile1 = string.Empty;
            Mobile2 = string.Empty;
            City = string.Empty;
            Country = string.Empty;
            Remarks = string.Empty;
            InActive = true;
            DivisionCode = SystemHelper.Get_DivisionID_Session(); //SystemHelper.DivisionID;
            //SiteID = SystemHelper.Get_SiteID_Session(); //SystemHelper.SiteID;
            LoginID = SystemHelper.Get_User_Session(); //SystemHelper.Username;
        }
    }
}