using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Clinic_Proj.Database_Access;

namespace Clinic_Proj.Models
{
    public class FAPayModel
    {
        [Required]
        public string PaymentMeth { get; set; }
        [Required]
        public string Bank { get; set; }
        [Required]
        public string Mode { get; set; }
        [Required]
        public string RegNo { get; set; }
        [Required]
        public string Age { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public double TotalAmount { get; set; }
        [Required]
        public double Fee { get; set; }
        [Required]
        public double PaidFee { get; set; }
        [Required]
        public double Balance { get; set; }
        [Required]
        public string Remarks { get; set; }
        [Required]
        public string DoctorName { get; set; }
        [Required]
        public string ServiceName { get; set; }
        [Required]
        public string TokenNo { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string LoginID { get; set; }
        [Required]
        public string DivisionID { get; set; }
        [Required]
        public string SiteID { get; set; }
        public int CCPL_ROW_ID { get; set; }

        public FAPayModel()
        {
            //DivisionID = "MUL";
            //SiteID = "JM";
            //LoginID = "Admin";
            DivisionID = SystemHelper.Get_DivisionID_Session(); //SystemHelper.DivisionID;
            SiteID = SystemHelper.Get_SiteID_Session(); //SystemHelper.SiteID;
            LoginID = SystemHelper.Get_User_Session(); //SystemHelper.Username;
            DoctorName = string.Empty;
            TokenNo = string.Empty;
            PaymentMeth = string.Empty;
            Bank = string.Empty;
            RegNo = string.Empty;
            FullName = string.Empty;
            ServiceName = string.Empty;
            Mode = string.Empty;
            Fee = new double();
            PaidFee = new double();
            TotalAmount = new double();
            Balance = new double();
            Remarks = string.Empty;
            CCPL_ROW_ID = new int();
        }
    }
}