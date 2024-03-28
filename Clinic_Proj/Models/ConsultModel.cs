using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Clinic_Proj.Database_Access;

namespace Clinic_Proj.Models
{
    public class ConsultModel
    {
        //[Required]
        //public string ServiceType { get; set; }
        [Required]
        public string VitalValue { get; set; }
        [Required]
        public int id { get; set; }
        [Required]
        public DateTime DateFrom { get; set; }
        [Required]
        public DateTime DateTo { get; set; }
        [Required]
        public double NoOfDays { get; set; }
        [Required]
        public double NoOfSession { get; set; }
        [Required]
        public double DosageQty { get; set; }
        [Required]
        public string SessionRemarks { get; set; }
        [Required]
        public string SessionActivity { get; set; }
        [Required]
        public string SessionActRemarks { get; set; }
        [Required]
        public string GenericName { get; set; }
        [Required]
        public string Frequency { get; set; }
        [Required]
        public string LabRemarks { get; set; }
        [Required]
        public string TrtRemarks { get; set; }
        [Required]
        public string MediRemarks { get; set; }
        [Required]
        public string DiagRemarks { get; set; }
        [Required]
        public string HeaderID { get; set; }
        [Required]
        public string DiseaseID { get; set; }
        [Required]
        public string Remarks { get; set; }
        //[Required]
        //public string ServiceDesc { get; set; }
        [Required]
        public string VitalName { get; set; }
        [Required]
        public string LongName { get; set; }
        [Required]
        public string ShortName { get; set; }
        [Required]
        public string TokenNo { get; set; }
        [Required]
        public string PatName { get; set; }
        [Required]
        public double Fee { get; set; }
        [Required]
        public string LoginID { get; set; }
        [Required]
        public string DisagnoseSName { get; set; }
        [Required]
        public string DivisionID { get; set; }
        [Required]
        public string SiteID { get; set; }
        [Required]
        public string LabTest { get; set; }
        [Required]
        public string FollowupDate { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string SubType { get; set; }
        [Required]
        public string UrduText { get; set; }
        [Required]
        public string ServiceName { get; set; }
        public bool IsNight { get; set; }
        public bool IsEvening { get; set; }
        public bool IsMorning { get; set; }
        [Required]
        public string SubTypeID { get; set; }
        [Required]
        public string TypeID { get; set; }
        public string DoctorID { get; set; }
        public int CCPL_ROW_ID { get; set; }

        public ConsultModel()
        {
            //DivisionID = "MUL";
            //SiteID = "JM";
            //LoginID = "Admin";
            DivisionID = SystemHelper.Get_DivisionID_Session(); //SystemHelper.DivisionID;
            SiteID = SystemHelper.Get_SiteID_Session(); //SystemHelper.SiteID;
            LoginID = SystemHelper.Get_User_Session(); //SystemHelper.Username;
            //DivisionID = SystemHelper.DivisionID;
            //SiteID = SystemHelper.SiteID;
            DoctorID = SystemHelper.Get_DoctorID_Session();
            DiseaseID = string.Empty;
            HeaderID = string.Empty;
            //LoginID = SystemHelper.Username;
            DosageQty = new double();
            NoOfDays = new double();
            IsMorning = new bool();
            IsEvening = new bool();
            IsNight = new bool();
            NoOfSession = new double();
            DateFrom = new DateTime();
            DateTo = new DateTime();
            SessionRemarks = string.Empty;
            SessionActivity = string.Empty;
            SessionActRemarks = string.Empty;
            TokenNo = string.Empty;
            LongName = string.Empty;
            ShortName = string.Empty;
            PatName = string.Empty;
            id = new int();
            GenericName = string.Empty;
            TypeID = string.Empty;
            SubTypeID = string.Empty;
            VitalName = string.Empty;
            VitalValue = string.Empty;
            LabTest = string.Empty;
            DisagnoseSName = string.Empty;
            ServiceName = string.Empty;
            Fee = new double();
            DisagnoseSName = string.Empty;
            Remarks = string.Empty;
            Type = string.Empty;
            DiagRemarks = string.Empty;
            TrtRemarks = string.Empty;
            MediRemarks = string.Empty;
            LabRemarks = string.Empty;
            SubType = string.Empty;
            CCPL_ROW_ID = new int();
        }
    }
}