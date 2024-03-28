﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Clinic_Proj.Database_Access;

namespace Clinic_Proj.Models
{
        public class TokenGenerateMode
        {
            [Required]
            public string TokenNo { get; set; }
            [Required]
            public string TokenDel_Remarks { get; set; }
            [Required]
            public string SearchCnic { get; set; }
            [Required]
            public string RegNo { get; set; }
            [Required]
            public string CNIC { get; set; }
            [Required]
            public DateTime RegDate { get; set; }
            [Required]
            public DateTime DOB { get; set; }
            [Required]
            public string Gender { get; set; }
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
            public string Guardian { get; set; }
            [Required]
            public DateTime CNICIssue { get; set; }
            [Required]
            public DateTime CNICExp { get; set; }
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
            public TokenGenerateMode()
            {
                TokenNo = string.Empty;
                TokenDel_Remarks = string.Empty;
                SearchCnic = string.Empty;
                Guardian = string.Empty;
                EmailID = string.Empty;
                Remarks = string.Empty;
                ReferBy = string.Empty;
                RegNo = string.Empty;
                RegDate = new DateTime();
                Gender = string.Empty;
                FirstName = string.Empty;
                MidName = string.Empty;
                LastName = string.Empty;
                Title = string.Empty;
                DOB = new DateTime();
                CNIC = string.Empty;
                CNICIssue = new DateTime();
                CNICExp = new DateTime();
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
                DivisionID = SystemHelper.Get_DivisionID_Session(); 
                SiteID = SystemHelper.Get_SiteID_Session(); 
                LoginID = SystemHelper.Get_User_Session(); 
            }
        }
}