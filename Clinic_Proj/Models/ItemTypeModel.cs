using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Clinic_Proj.Database_Access;

namespace Clinic_Proj.Models
{
    public class ItemTypeModel
    {
        [Required]
        public int TypeID { get; set; }
        [Required]
        public string DivisionID { get; set; }
        [Required]
        public string SiteID { get; set; }
        [Required]
        public string LoginID { get; set; }
        [Required]
        public string TypeName { get; set; }
        [Required]
        public bool Status { get; set; }
        public ItemTypeModel()
        {
            TypeID = new int();
            DivisionID = SystemHelper.Get_DivisionID_Session(); //SystemHelper.DivisionID;
            SiteID = SystemHelper.Get_SiteID_Session(); //SystemHelper.SiteID;
            LoginID = SystemHelper.Get_User_Session(); //SystemHelper.Username;
            TypeName = string.Empty;
        }
    }
}