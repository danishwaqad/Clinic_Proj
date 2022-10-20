using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Clinic_Proj.Database_Access;

namespace Clinic_Proj.Models
{
    public class SessionMode
    {
        [Required]
        public string TokenNo { get; set; }
        [Required]
        public string DoctorName { get; set; }
        [Required]
        public DateTime FromDate { get; set; }
        [Required]
        public DateTime ToDate { get; set; }
        [Required]
        public double NoOfSessions { get; set; }
        [Required]
        public double TotalFee { get; set; }
        [Required]
        public double PaidFee { get; set; }
        [Required]
        public double Discount { get; set; }
        [Required]
        public string DisType { get; set; }
        [Required]
        public string DisApproval { get; set; }
        [Required]
        public string PaymentMeth { get; set; }
        [Required]
        public string Bank { get; set; }
        [Required]
        public double BalanceFee { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string Remarks { get; set; }
        [Required]
        public string SessionRemarks { get; set; }
        [Required]
        public double Total { get; set; }
        [Required]
        public string LoginID { get; set; }
        public string DivisionID { get; set; }
        public string SiteID { get; set; }
        public SessionMode()
        {
            TokenNo = string.Empty;
            DoctorName = string.Empty;
            TotalFee = new double();
            PaidFee = new double();
            Discount = new double();
            DisType = string.Empty;
            DisApproval = string.Empty;
            PaymentMeth = string.Empty;
            SessionRemarks = string.Empty;
            Bank = string.Empty;
            BalanceFee = new double();
            ToDate = new DateTime();
            FromDate = new DateTime();
            DivisionID = SystemHelper.Get_DivisionID_Session();
            SiteID = SystemHelper.Get_SiteID_Session();
            LoginID = SystemHelper.Get_User_Session();
            NoOfSessions = new double();
            Remarks = string.Empty;
            Total = 0;
        }
    }
}