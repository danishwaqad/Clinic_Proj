using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Clinic_Proj.Database_Access;


namespace Clinic_Proj.Models
{
    public class ReceivingModel
    {
        [Required]
        public string DocNo { get; set; }
        [Required]
        public string VendorNo { get; set; }
        [Required]
        public string id { get; set; }
        [Required]
        public string ProductCode { get; set; }
        [Required]
        public double PaidQty { get; set; }
        [Required]
        public double BonusQty { get; set; }
        [Required]
        public double PRate { get; set; }
        [Required]
        public double SRate { get; set; }
        [Required]
        public double TotalAmount { get; set; }
        [Required]
        public double SubTotal { get; set; }
        [Required]
        public double Tax { get; set; }
        [Required]
        public double Discount { get; set; }
        [Required]
        public double TotalQty { get; set; }
        [Required]
        public string Remarks { get; set; }
        [Required]
        public string BatchNo { get; set; }
        [Required]
        public string ItemCode { get; set; }
        [Required]
        public DateTime DocDate { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }
        [Required]
        public string LoginID { get; set; }
        public string DivisionID { get; set; }
        public string SiteID { get; set; }
        public ReceivingModel()
        {
            DocNo = string.Empty;
            id = string.Empty;
            DocDate = new DateTime();
            VendorNo= string.Empty;
            ProductCode = string.Empty;
            ItemCode = string.Empty;
            PaidQty = new double();
            BonusQty= new double();
            PRate= new double();
            SRate= new double();
            TotalAmount= new double();
            SubTotal= new double();
            Tax= new double();
            Discount= new double();
            TotalQty= new double();
            Remarks = string.Empty;
            BatchNo = string.Empty;
            ExpiryDate = new DateTime(1900, 01, 01);
            DivisionID = SystemHelper.Get_DivisionID_Session(); //SystemHelper.DivisionID;
            SiteID = SystemHelper.Get_SiteID_Session(); //SystemHelper.SiteID;
            LoginID = SystemHelper.Get_User_Session(); //SystemHelper.Username;
        }
    }
}