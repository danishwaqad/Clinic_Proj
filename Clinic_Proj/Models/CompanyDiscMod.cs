using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Clinic_Proj.Database_Access;

namespace Clinic_Proj.Models
{
    public class CompanyDiscMod
    {
        [Required]
        public double CompanyID { get; set; }
        [Required]
        public double Discount3 { get; set; }
        [Required]
        public double Discount4 { get; set; }
        [Required]
        public bool IsAllow { get; set; }
        [Required]
        public string LoginID { get; set; }
        public CompanyDiscMod()
        {
            CompanyID = new double();
            LoginID = SystemHelper.Get_User_Session(); 
            IsAllow = new bool();
            Discount3 = new double();
            Discount4 = new double();
        }
    }
}