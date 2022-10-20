using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Clinic_Proj.Database_Access;


namespace Clinic_Proj.Models
{
    public class EmpDependMode
    {
        [Required]
        public string EmployeeID { get; set; }
        [Required]
        public double ID { get; set; }
        [Required]
        public string EmpName { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MidName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string ReferBy { get; set; }
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
        [Required]
        public string Gender { get; set; }
        [Required]
        public string CNIC { get; set; }
        [Required]
        public string Tel1 { get; set; }
        [Required]
        public string Tel2 { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string Relation { get; set; }
        [Required]
        public bool InActive { get; set; }
        [Required]
        public string Remarks { get; set; }
        [Required]
        public string LoginID { get; set; }
        public EmpDependMode()
        {
            EmployeeID = string.Empty;
            LoginID = SystemHelper.Get_User_Session();
            EmpName = string.Empty;
            FirstName = string.Empty;
            MidName = string.Empty;
            LastName = string.Empty;
            Guardian = string.Empty;
            ReferBy = string.Empty;
            CNICExp = new DateTime();
            CNICIssue = new DateTime();
            Title = string.Empty;
            FamilyNo = string.Empty;
            CNICIdentity = string.Empty;
            Gender = string.Empty;
            CNIC = string.Empty;
            Tel1 = string.Empty;
            Tel2 = string.Empty;
            Address = string.Empty;
            City = string.Empty;
            Country = string.Empty;
            DOB = new DateTime();
            Relation = string.Empty;
            InActive = new bool();
            Remarks = string.Empty;
            ID = new double();
        }
    }
}