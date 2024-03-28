using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Clinic_Proj.Database_Access;

namespace Clinic_Proj.Models
{
    public class DocMediMode
    {
        [Required]
        public string GroupName { get; set; }
        [Required]
        public string GroupID { get; set; }
        [Required]
        public string DoctorID { get; set; }
        [Required]
        public string DoctorName { get; set; }
        [Required]
        public string Remarks { get; set; }
        //=========Consultancy============
        [Required]
        public string GenericName { get; set; }
        [Required]
        public string SubTypeID { get; set; }
        [Required]
        public string TypeID { get; set; }
        public bool IsNight { get; set; }
        public bool IsEvening { get; set; }
        public bool IsMorning { get; set; }
        [Required]
        public double NoOfDays { get; set; }
        [Required]
        public double DosageQty { get; set; }
        [Required]
        public string UrduText { get; set; }
        [Required]
        public string MediRemarks { get; set; }
        [Required]
        public string RefGroupID { get; set; }
        [Required]
        public string RefGroupName { get; set; }
        [Required]
        public int id { get; set; }
        //==========Consultancy End========
        [Required]
        public string LoginID { get; set; }
        [Required]
        public string DivisionID { get; set; }
        [Required]
        public string SiteID { get; set; }
        [Required]
        public bool InActive { get; set; }

        public DocMediMode()
        {
            DivisionID = SystemHelper.Get_DivisionID_Session();
            SiteID = SystemHelper.Get_SiteID_Session();
            LoginID = SystemHelper.Get_User_Session();
            GroupName = string.Empty;
            GroupID = string.Empty;
            DoctorID = string.Empty;
            DoctorName = string.Empty;
            Remarks = string.Empty;
            InActive = new bool();

            GenericName = string.Empty;
            SubTypeID = string.Empty;
            TypeID = string.Empty;
            NoOfDays = new double();
            IsMorning = new bool();
            IsEvening = new bool();
            IsNight = new bool();
            DosageQty = new double();
            UrduText = string.Empty;
            MediRemarks = string.Empty;
            RefGroupID = string.Empty;
            RefGroupName = string.Empty;
        }
    }
}