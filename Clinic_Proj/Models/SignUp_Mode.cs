using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Clinic_Proj.Database_Access;

namespace Clinic_Proj.Models
{
    public class SignUp_Mode
    {
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool InActive { get; set; }
        public string LoginID { get; set; }
        public string EmailID { get; set; }
        public string UserType { get; set; }
        public string Department { get; set; }
        public string Section { get; set; }
        public string ContactNo { get; set; }
        public bool IsFixIP { get; set; }
        public string DivisionID { get; set; }
        public string SiteID { get; set; }
        public string MenuID { get; set; }
        public bool IsAllow { get; set; }
        public bool IsPrint { get; set; }
        public int id { get; set; }

        public SignUp_Mode()
        {
            Name = string.Empty;
            Designation = string.Empty;
            id = new int();
            Username = string.Empty;
            Password = string.Empty;
            InActive = new bool();

            EmailID = string.Empty;
            UserType = string.Empty;
            Department = string.Empty;
            Section = string.Empty;
            ContactNo = string.Empty;
            IsFixIP = new bool();
            DivisionID = string.Empty;
            SiteID = string.Empty;

            MenuID = string.Empty;
            IsAllow = new bool();
            IsPrint = new bool();
            DivisionID = SystemHelper.Get_DivisionID_Session(); //SystemHelper.DivisionID;
            SiteID = SystemHelper.Get_SiteID_Session(); //SystemHelper.SiteID;
            LoginID = SystemHelper.Get_User_Session(); //SystemHelper.Username;
            //LoginID = SystemHelper.Username;
        }
    }
}