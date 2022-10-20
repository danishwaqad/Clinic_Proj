using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Clinic_Proj.Database_Access;

namespace Clinic_Proj.Models
{
    public class EmployeeRegMode
    {
        [Required]
        public string EmpID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MidName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string EmpCNIC { get; set; }
        [Required]
        public string ReferBy { get; set; }
        [Required]
        public string Guardian { get; set; }
        [Required]
        public DateTime CNICIssue { get; set; }
        [Required]
        public DateTime CNICExp { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string FamilyNo { get; set; }
        [Required]
        public string CNICIdentity { get; set; }
        [Required]
        public string EmpTel1 { get; set; }
        [Required]
        public string EmpTel2 { get; set; }
        [Required]
        public string EmpAddress { get; set; }
        [Required]
        public string EmpCity { get; set; }
        [Required]
        public string EmpCountry { get; set; }
        [Required]
        public string EmpRemarks { get; set; }
        [Required]
        public string CompanyID { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string EmpCompanyID { get; set; }
        [Required]
        public string EmpDepartment { get; set; }
        [Required]
        public string EmpDesignation { get; set; }
        [Required]
        public string EmpPayroll { get; set; }
        [Required]
        public string EmpType { get; set; }
        [Required]
        public bool InActive { get; set; }
        [Required]
        public string Remarks { get; set; }
        [Required]
        public string SearchEmployee { get; set; }
        [Required]
        public string LoginID { get; set; }
        public EmployeeRegMode()
        {
            CompanyID = string.Empty;
            SearchEmployee = string.Empty;
            LoginID = SystemHelper.Get_User_Session();
            CompanyName = string.Empty;
            EmpID = string.Empty;
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
            EmpAddress = string.Empty;
            Gender = string.Empty;
            EmpCity = string.Empty;
            EmpCNIC = string.Empty;
            EmpCompanyID = string.Empty;
            EmpCountry = string.Empty;
            EmpDepartment = string.Empty;
            EmpDesignation = string.Empty;
            EmpPayroll = string.Empty;
            EmpRemarks = string.Empty;
            EmpTel1 = string.Empty;
            EmpTel2 = string.Empty;
            EmpType = string.Empty;
            DOB = new DateTime();
            Remarks = string.Empty;
            InActive = new bool();
        }
    }
}