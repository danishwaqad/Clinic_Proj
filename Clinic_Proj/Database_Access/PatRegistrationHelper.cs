using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinic_Proj.Database_Access
{
    public class PatRegistrationHelper
    {
        public static string RegNo { get; set; }
        public static string TokenNo { get; set; }
        public static string Title { get; set; }
        public static string FirstName { get; set; }
        public static string MidName { get; set; }
        public static string LastName { get; set; }
        public static string DoctorName { get; set; }
        public static string CNIC { get; set; }
        public static string Guardian { get; set; }
        public static string Tel1 { get; set; }
        public static string Tel2 { get; set; }
        public static string Gender { get; set; }
        public static string EmailID { get; set; }
        public static string Address { get; set; }
        public static string City { get; set; }
        public static string Country { get; set; }
        public static string DOB { get; set; }
        public static string ReferBy { get; set; }
        public static string Remarks { get; set; }
        public static string MiddleName { get; internal set; }
        public static string Relation { get; internal set; }
        public static string PatType { get; internal set; }
        public static string DrName { get; internal set; }
    }
}