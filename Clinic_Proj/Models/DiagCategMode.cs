using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Clinic_Proj.Database_Access;

namespace Clinic_Proj.Models
{
    public class DiagCategMode
    {
            [Required]
            public string DiseaseName { get; set; }
            [Required]
            public string ID { get; set; }
            [Required]
            public string HeaderName { get; set; }
            [Required]
            public string Description { get; set; }
            [Required]
            public string LoginID { get; set; }
            [Required]
            public string DivisionID { get; set; }
            [Required]
            public string SiteID { get; set; }
            [Required]
            public string HeaderID { get; set; }
            [Required]
            public string DiseaseID { get; set; }
            [Required]
            public bool InActive { get; set; }
            [Required]
            public bool InActive2 { get; set; }

            public DiagCategMode()
            {
                DivisionID = SystemHelper.Get_DivisionID_Session();
                SiteID = SystemHelper.Get_SiteID_Session();
                LoginID = SystemHelper.Get_User_Session();
                DiseaseName = string.Empty;
                HeaderName = string.Empty;
                Description = string.Empty;
                ID = string.Empty;
                HeaderID = string.Empty;
                DiseaseID = string.Empty;
                InActive = new bool();
                InActive2 = new bool();
            }
        }
}