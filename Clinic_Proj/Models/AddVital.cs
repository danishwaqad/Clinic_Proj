using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Clinic_Proj.Database_Access;

namespace Clinic_Proj.Models
{
    public class AddVital
    {
        [Required]
        public int VitalID { get; set; }
        //public int CCPL_ROW_ID { get; set; }
        [Required]
        public string DivisionID { get; set; }
        [Required]
        public string SiteID { get; set; }
        [Required]
        public int id { get; set; }
        [Required]
        public string LoginID { get; set; }
        [Required]
        public string VitalName { get; set; }
        [Required]
        public string MinValue { get; set; }

        [Required]
        public string MaxValue { get; set; }
        public AddVital()
        {
            VitalID = new int();
            DivisionID = SystemHelper.Get_DivisionID_Session(); //SystemHelper.DivisionID;
            SiteID = SystemHelper.Get_SiteID_Session(); //SystemHelper.SiteID;
            LoginID = SystemHelper.Get_User_Session(); //SystemHelper.Username;
            //DivisionID = "MUL";
            //SiteID = "JM";
            //LoginID = "Admin";
            VitalName = string.Empty;
            id = new int();
            MinValue = string.Empty;
            MaxValue = string.Empty;
        }
    }
}
