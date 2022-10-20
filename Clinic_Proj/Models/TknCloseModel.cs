using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Clinic_Proj.Database_Access;
namespace Clinic_Proj.Models
{
    public class TknCloseModel
    {
        [Required]
        public string TokenDate { get; set; }
        [Required]
        public string TokenNo { get; set; }
        [Required]
        public double NewBal { get; set; }
        [Required]
        public double NewPaid { get; set; }
        [Required]
        public string PatName { get; set; }
        [Required]
        public string TypeID { get; set; }
        [Required]
        public double RefundAmount { get; set; }
        [Required]
        public double PayableAmount { get; set; }
        [Required]
        public double PaidAmount { get; set; }
        [Required]
        public double TotalAmount { get; set; }
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
        public double DiscountAmount { get; set; }
        public int CCPL_RowId { get; set; }
        public double NetPaidAmount { get; set; }
        public TknCloseModel()
        {
            NetPaidAmount = new double();
            DivisionID = SystemHelper.Get_DivisionID_Session(); //SystemHelper.DivisionID;
            SiteID = SystemHelper.Get_SiteID_Session(); //SystemHelper.SiteID;
            LoginID = SystemHelper.Get_User_Session(); //SystemHelper.Username;
            TokenNo = string.Empty;
            PatName = string.Empty;
            TokenDate = string.Empty;
            TypeID = string.Empty;
            //RefundFee = string.Empty;
            //Balance = string.Empty;
            //Discount = string.Empty;
            //PaidFee = string.Empty;
            //TotalFee = string.Empty;
            Remarks = string.Empty;
            RefundApproval = string.Empty;
        }

    }
}