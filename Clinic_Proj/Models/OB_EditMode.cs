﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Clinic_Proj.Database_Access;

namespace Clinic_Proj.Models
{
    public class OB_EditMode
    {
        [Required]
        public string DocNo { get; set; }
        [Required]
        public DateTime DocDate { get; set; }
        [Required]
        public string RsNote { get; set; }
        [Required]
        public double Quantity { get; set; }
        [Required]
        public double Opening { get; set; }
        [Required]
        public string Remarks { get; set; }
        [Required]
        public string TypeID { get; set; }
        [Required]
        public string LineRemarks { get; set; }
        [Required]
        public double Total { get; set; }
        [Required]
        public double TotalAmount { get; set; }
        [Required]
        public string StaffShift { get; set; }
        [Required]
        public int id { get; set; }
        [Required]
        public string LoginID { get; set; }
        public string DivisionID { get; set; }
        public string SiteID { get; set; }
        public OB_EditMode()
        {
            DocNo = string.Empty;
            DocDate = new DateTime();
            //DivisionID = "MUl";
            //SiteID = "JM";
            //LoginID = "Admin";
            DivisionID = SystemHelper.Get_DivisionID_Session(); //SystemHelper.DivisionID;
            SiteID = SystemHelper.Get_SiteID_Session(); //SystemHelper.SiteID;
            LoginID = SystemHelper.Get_User_Session(); //SystemHelper.Username;
            id = new int();
            TypeID = string.Empty;
            RsNote = string.Empty;
            TotalAmount = new double();
            StaffShift = string.Empty;
            Quantity = 0;
            Opening = 0;
            Remarks = string.Empty;
            Total = 0;
        }
    }
}