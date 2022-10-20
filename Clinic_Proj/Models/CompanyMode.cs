using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Clinic_Proj.Database_Access;

namespace Clinic_Proj.Models
{
    public class CompanyMode
    {
        [Required]
        public string BusinessType { get; set; }
        [Required]
        public string CompanyID { get; set; }
        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string ContactPerson { get; set; }

        [Required]
        public string CNIC { get; set; }

        [Required]
        public string NTN { get; set; }

        [Required]
        public string STRN { get; set; }
        [Required]
        public string Mobile1 { get; set; }
        [Required]
        public string Mobile2 { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string ClassID { get; set; }
        [Required]
        public string ClassName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Tel { get; set; }
        [Required]
        public string Remarks { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public string LoginID { get; set; }
        public CompanyMode()
        {
            BusinessType = string.Empty;
            CompanyID = string.Empty;
            CompanyName = string.Empty;
            ContactPerson = string.Empty;
            ClassID = string.Empty;
            ClassName = string.Empty;
            CNIC = string.Empty;
            NTN = string.Empty;
            STRN = string.Empty;
            Mobile1 = string.Empty;
            Mobile2 = string.Empty;
            Tel = string.Empty;
            Address = string.Empty;
            City = string.Empty;
            Country = string.Empty;
            Remarks = string.Empty;
            Status = new bool();
            LoginID = SystemHelper.Get_User_Session();
        }
    }
}