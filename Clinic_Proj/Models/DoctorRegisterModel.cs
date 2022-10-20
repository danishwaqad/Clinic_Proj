using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Clinic_Proj.Database_Access;

namespace Clinic_Proj.Models
{
    public class DoctorRegisterModel
    {
        public int DoctorID { get; set; }
        [Required]
        public string DoctorType { get; set; }
        [Required]
        public string ShareType { get; set; }
        [Required]
        public double SharePercent { get; set; }
        [Required]
        public string DoctorName { get; set; }

        [Required]
        public string DrFName { get; set; }

        [Required]
        public string CNIC { get; set; }
        [Required]
        public string Tel1 { get; set; }
        [Required]
        public string HomeStatus { get; set; }
        [Required]
        public string Tel2 { get; set; }
        [Required]
        public string EmailID { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string DOB { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Remarks { get; set; }
        [Required]
        public string ReferBy { get; set; }
        [Required]
        public string DivisionID { get; set; }
        [Required]
        public string SiteID { get; set; }
        [Required]
        public string SiteCode { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string LoginID { get; set; }
        [Required]
        public string DrShift { get; set; }
        [Required]
        public string Charges { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Pass { get; set; }
        public string InActive { get; set; }

        public DoctorRegisterModel()
        {
            DoctorID = new int();
            ReferBy = string.Empty;
            EmailID = string.Empty;
            Remarks = string.Empty;
            Description = string.Empty;
            SharePercent = new double();
            DoctorType = string.Empty;
            DrFName = string.Empty;
            Tel1 = string.Empty;
            Tel2 = string.Empty;
            Address = string.Empty;
            City = string.Empty;
            Country = string.Empty;
            Gender = string.Empty;
            DOB = string.Empty;
            CNIC = string.Empty;
            Status = string.Empty;
            DrShift = string.Empty;
            UserName = string.Empty;
            ShareType = string.Empty;
            Pass = string.Empty;
            Charges = "0";
            HomeStatus = string.Empty;
            InActive = string.Empty;
            //LoginID = "Admin";
            //DivisionID = "MUL";
            //SiteID = "JM";
            DivisionID = SystemHelper.Get_DivisionID_Session(); //SystemHelper.DivisionID;
            SiteCode = SystemHelper.Get_SiteID_Session();
            SiteID = string.Empty;
            LoginID = SystemHelper.Get_User_Session(); //SystemHelper.Username;

        }
    }
}