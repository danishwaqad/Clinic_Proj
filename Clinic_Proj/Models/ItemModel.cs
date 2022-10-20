using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Clinic_Proj.Database_Access;
namespace Clinic_Proj.Models
{
    public class ItemModel 
    {
        [Required]
        public string DivisionID { get; set; }
        [Required]
        public string id { get; set; }
        [Required]
        public string SiteID { get; set; }
        [Required]
        public string LoginID { get; set; }
        [Required]
        public string TypeName { get; set; }
        [Required]
        public string ItemCode { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public int ROLevelValue { get; set; }
        [Required]
        public int OrderQty { get; set; }
        [Required]
        public int UnitsInPack { get; set; }
        [Required]
        public string SubTypeName { get; set; }
        [Required]
        public string UOM { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Remarks { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public bool IsExpiry { get; set; }
        [Required]
        public bool IsAutoBack { get; set; }
    public ItemModel()
        {
            ROLevelValue = new int();
            OrderQty = new int();
            UnitsInPack = new int();
            DivisionID = SystemHelper.Get_DivisionID_Session(); //SystemHelper.DivisionID;
            SiteID = SystemHelper.Get_SiteID_Session(); //SystemHelper.SiteID;
            LoginID = SystemHelper.Get_User_Session(); //SystemHelper.Username;
            TypeName = string.Empty;
            ItemCode = string.Empty;
            ItemName = string.Empty;
            UOM = string.Empty;
            id = string.Empty;
            Manufacturer = string.Empty;
            Description = string.Empty;
            Remarks = string.Empty;
            SubTypeName = string.Empty;
        }
    }
}