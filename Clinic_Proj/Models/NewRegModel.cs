using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Clinic_Proj.Database_Access;

namespace Clinic_Proj.Models
{
    public class NewRegModel
    {
        [Required]
        public int DrID { get; set; }
        [Required]
        public string PaymentMeth { get; set; }
        [Required]
        public string Bank { get; set; }
        [Required]
        public string PatType { get; set; }
        [Required]
        public string DrName { get; set; }
        [Required]
        public int TotalFee { get; set; }
        [Required]
        public string DiscountType { get; set; }
        [Required]
        public int Discount { get; set; }
        [Required]
        public int PaidFee { get; set; }
        [Required]
        public int Balance { get; set; }
        [Required]
        public string DisAprov { get; set; }
        [Required]
        public string Relation { get; set; }
        [Required]
        public string TokenNo { get; set; }
        [Required]
        public string RegNo { get; set; }
        [Required]
        public DateTime RegDate { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string ReferBy { get; set; }
        [Required]
        public string Remarks { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MidName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string CNIC { get; set; }
        [Required]
        public string CNIC1 { get; set; }
        [Required]
        public string DOB { get; set; }
        [Required]
        public string CNICIssue { get; set; }
        [Required]
        public string CNICExp { get; set; }
        [Required]
        public string FamilyNo { get; set; }
        [Required]
        public string CNICIdentity { get; set; }
        //==========Address==========================
        [Required]
        public string AddressTyp { get; set; }
        [Required]
        public string HouseNo { get; set; }
        [Required]
        public string Town { get; set; }
        [Required]
        public string StreetNo { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Zip { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string RemarksA { get; set; }
        //==================Address End================
        //==================Contact================
        [Required]
        public string ContactType { get; set; }
        [Required]
        public string TeleNo { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string EmailID { get; set; }
        [Required]
        public string Guardian { get; set; }
        [Required]
        public string Tel1 { get; set; }
        [Required]
        public string Tel2 { get; set; }
        [Required]
        public string RemarksC { get; set; }
        //===========Contact End===================
        [Required]
        public string DivisionID { get; set; }
        [Required]
        public string SiteID { get; set; }
        [Required]
        public string LoginID { get; set; }
        [Required]
        public int ID { get; set; }
        public NewRegModel()
        {
            DrID = new int();
            Guardian = string.Empty;
            DrName = string.Empty;
            TotalFee = 0;
            DiscountType = string.Empty;
            Discount = 0;

            PaidFee = 0;
            EmailID = string.Empty;
            PaymentMeth = string.Empty;
            Bank = string.Empty;
            Remarks = string.Empty;
            ReferBy = string.Empty;
            Tel1 = string.Empty;
            Tel2 = string.Empty;
            Balance = 0;
            DisAprov = string.Empty;
            PatType = string.Empty;
            Relation = string.Empty;
            TokenNo = string.Empty;
            RegNo = string.Empty;
            RegDate = new DateTime();
            gender = string.Empty;
            FirstName = string.Empty;
            MidName = string.Empty;
            LastName = string.Empty;
            Title = string.Empty;
            DOB = string.Empty;
            CNIC = string.Empty;
            CNICIssue = string.Empty;
            CNICExp = string.Empty;
            FamilyNo = string.Empty;
            CNICIdentity = string.Empty;
            //==========Address===============
            AddressTyp = string.Empty;
            HouseNo = string.Empty;
            Town = string.Empty;
            StreetNo = string.Empty;
            City = string.Empty;
            State = string.Empty;
            Country = string.Empty;
            Zip = string.Empty;
            Address = string.Empty;
            RemarksA = string.Empty;
            //==========Contact=================
            ContactType = string.Empty;
            TeleNo = string.Empty;
            Email = string.Empty;
            RemarksC = string.Empty;
            ID = new int();
            //==================================
            //DivisionID = "MUL";
            //SiteID = "JM";
            //LoginID = "Admin";
            DivisionID = SystemHelper.Get_DivisionID_Session(); //SystemHelper.DivisionID;
            SiteID = SystemHelper.Get_SiteID_Session(); //SystemHelper.SiteID;
            LoginID = SystemHelper.Get_User_Session(); //SystemHelper.Username;
        }

    }
}