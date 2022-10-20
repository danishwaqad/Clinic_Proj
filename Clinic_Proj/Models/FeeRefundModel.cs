using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Clinic_Proj.Database_Access;

namespace Clinic_Proj.Models
{
    public class FeeRefundModel
    {
        [Required]
        public string TokenDate { get; set; }
        [Required]
        public string TokenNo { get; set; }
        [Required]
        public string PatName { get; set; }
        [Required]
        public string RefundType { get; set; }
        [Required]
        public string RefundFee { get; set; }
        [Required]
        public string Balance { get; set; }
        [Required]
        public string PaidFee { get; set; }
        [Required]
        public string TotalFee { get; set; }
        [Required]
        public string Remarks { get; set; }
        [Required]
        public string RefundApproval { get; set; }
        [Required]
        public string LoginID { get; set; }
        [Required]
        public string DivisionID { get; set; }
        [Required]
        public string SiteID { get; set; }
        [Required]
        public string Discount { get; set; }
        public int CCPL_RowId { get; set; }

        public int id { get; set; }

        public FeeRefundModel()
        {
            DivisionID = SystemHelper.Get_DivisionID_Session(); //SystemHelper.DivisionID;
            SiteID = SystemHelper.Get_SiteID_Session(); //SystemHelper.SiteID;
            LoginID = SystemHelper.Get_User_Session(); //SystemHelper.Username;
            TokenNo = string.Empty;
            PatName = string.Empty;
            TokenDate = string.Empty;
            RefundType = string.Empty;
            RefundFee = string.Empty;
            Balance = string.Empty;
            Discount = string.Empty;
            PaidFee = string.Empty;
            TotalFee = string.Empty;
            Remarks = string.Empty;
            id = new int();
            CCPL_RowId = new int();
            RefundApproval = string.Empty;
        }

    }
}