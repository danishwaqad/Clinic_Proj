using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Clinic_Proj.Database_Access;

namespace Clinic_Proj.Models
{
    public class CnicMode
    {
        [Required]
        public string SiteID { get; set; }
        [Required]
        public string SearchCnic { get; set; }
        public CnicMode()
        {
            SiteID = SystemHelper.Get_SiteID_Session();
            SearchCnic = string.Empty;
        }
    }
}