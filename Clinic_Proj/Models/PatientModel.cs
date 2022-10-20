using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Clinic_Proj.Database_Access;
namespace Clinic_Proj.Models
{
    public class PatientModel
    {
        [Required]
        public int DrID { get; set; }
        [Required]
        public string PaymentMeth { get; set; }
        [Required]
        public string SecoundTkn { get; set; }
        [Required]
        public string Bank { get; set; }
        [Required]
        public string RegNo { get; set; }
        [Required]
        public string TokenNo { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MidName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string DoctorName { get; set; }
        [Required]
        public int Charges { get; set; }
        [Required]
        public string CNIC { get; set; }

        [Required]
        public string Guardian { get; set; }

        [Required]
        public string Tel1 { get; set; }
        [Required]
        public string Tel2 { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string EmailID { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string DOB { get; set; }
        [Required]
        public string ReferBy { get; set; }
        [Required]
        public string Remarks { get; set; }
        [Required]
        public int TotalFee { get; set; }
        [Required]
        public int Discount { get; set; }
        [Required]
        public int Balance { get; set; }
        [Required]
        public string DisAprov { get; set; }
        [Required]
        public int PaidFee { get; set; }
        [Required]
        public string DrName { get; set; }
        [Required]
        public string Relation { get; set; }
        [Required]
        public string DivisionID { get; set; }
        [Required]
        public string SiteID { get; set; }
        [Required]
        public string LoginID { get; set; }
        [Required]
        public string PatType { get; set; }
        [Required]
        public string DiscountType { get; set; }
        [Required]
        public DateTime TokenDate { get; set; }
        [Required]
        public string InActive { get; set; }
        [Required]
        public string CompanyID { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string CCPL_RowID { get; set; }
        [Required]
        public string Age { get; set; }
        public PatientModel()
        {
            SecoundTkn = string.Empty;
            CompanyName = string.Empty;
            CompanyID = string.Empty;
            CCPL_RowID = string.Empty;
            DrID = new int();
            RegNo = string.Empty;
            TokenNo = string.Empty;
            FirstName = string.Empty;
            MidName = string.Empty;
            LastName = string.Empty;
            Title = string.Empty;
            DoctorName = string.Empty;
            Charges = 0;
            CNIC = string.Empty;
            Guardian = string.Empty;
            Tel1 = string.Empty;
            Tel2 = string.Empty;
            Gender = string.Empty;
            EmailID = string.Empty;
            Address = string.Empty;
            City = string.Empty;
            Country = string.Empty;
            DOB = string.Empty;
            ReferBy = string.Empty;
            Remarks = string.Empty;
            PaymentMeth = string.Empty;
            Bank = string.Empty;
            TotalFee = 0;
            Discount = 0;
            Balance = 0;
            DisAprov = string.Empty;
            PaidFee = 0;
            DrName = string.Empty;
            Relation = string.Empty;

            DivisionID = SystemHelper.Get_DivisionID_Session(); //SystemHelper.DivisionID;
            SiteID = SystemHelper.Get_SiteID_Session(); //SystemHelper.SiteID;
            LoginID = SystemHelper.Get_User_Session(); //SystemHelper.Username;


            TokenDate = new DateTime();

            PatType = "Consultancy";
            DiscountType = string.Empty;
            InActive = string.Empty;
            Age = string.Empty;
        }
    }
}