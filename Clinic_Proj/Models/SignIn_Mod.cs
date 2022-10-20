using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinic_Proj.Models
{
    public class SignIn_Mod
    {
        public int id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public string EmailID { get; set; }
        public bool IsIPFix { get; set; }
        public string Department { get; set; }
        public string Section { get; set; }
    }
}