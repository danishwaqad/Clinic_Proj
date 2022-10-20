using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Clinic_Proj.Database_Access;

namespace Clinic_Proj.Models
{
    public class CB_Mode
    {
        [Required]
        public string DocNo { get; set; }
        [Required]
        public string DocDate { get; set; }
        [Required]
        public string RsNote { get; set; }
        [Required]
        public double Quantity { get; set; }
        [Required]
        public double Opening { get; set; }
        [Required]
        public string Remarks { get; set; }
        [Required]
        public double Total { get; set; }
        [Required]
        public string LoginID { get; set; }
        public string DivisionID { get; set; }
        public string SiteID { get; set; }
        public CB_Mode()
        {
            DocNo = string.Empty;
            DocDate = string.Empty;
            DivisionID = SystemHelper.Get_DivisionID_Session(); //SystemHelper.DivisionID;
            SiteID = SystemHelper.Get_SiteID_Session(); //SystemHelper.SiteID;
            LoginID = SystemHelper.Get_User_Session(); //SystemHelper.Username;
            RsNote = string.Empty;
            Quantity = 0;
            Opening = 0;
            Remarks = string.Empty;
            Total = 0;
        }
    }
}