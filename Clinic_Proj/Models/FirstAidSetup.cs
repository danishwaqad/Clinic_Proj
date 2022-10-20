using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Clinic_Proj.Database_Access;

namespace Clinic_Proj.Models
{
    public class FirstAidSetup
    {
        //[Required]
        //public string Description { get; set; }
        [Required]
        public string Charges { get; set; }
        [Required]
        public string ServiceType { get; set; }
        [Required]
        public string ChargeType { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
        //[Required]
        public string ServiceName { get; set; }
        [Required]
        public string ServiceDesc { get; set; }
        [Required]
        public string LoginID { get; set; }
        [Required]
        public string DivisionID { get; set; }
        [Required]
        public string SiteID { get; set; }
        public int CCPL_ROW_ID { get; set; }

        public int id { get; set; }
        public FirstAidSetup()
        {
            //DivisionID = "MUL";
            //SiteID = "JM";
            //LoginID = "Admin";
            DivisionID = SystemHelper.Get_DivisionID_Session(); //SystemHelper.DivisionID;
            SiteID = SystemHelper.Get_SiteID_Session(); //SystemHelper.SiteID;
            LoginID = SystemHelper.Get_User_Session(); //SystemHelper.Username;

            ServiceName = string.Empty;
            ServiceDesc = string.Empty;
            //Description = string.Empty;
            Charges = string.Empty;
            ServiceType = string.Empty;
            ChargeType = string.Empty;
            id = new int();
            TimeFrom = new DateTime();
            TimeTo = new DateTime();
            //DiffMinutes = string.Empty;
            //TypeID = string.Empty;
        }
    }
}