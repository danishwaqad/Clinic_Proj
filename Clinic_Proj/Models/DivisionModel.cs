using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using Clinic_Proj.Database_Access;

namespace Clinic_Proj.Models
{
    public class register
    {
        [Required]
        public string DivisionCode { get; set; }

        [Required]
        public string DivisionName { get; set; }

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
        public string LoginID { get; set; }
        [Required]
        public bool InActive { get; set; }
        public register()
        {
            Address = string.Empty;
            Tel = string.Empty;
            Mobile1 = string.Empty;
            Mobile2 = string.Empty;
            City = string.Empty;
            Country = string.Empty;
            Remarks = string.Empty;
            LoginID = SystemHelper.Get_User_Session(); //SystemHelper.Username;
        }
    }

}