using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Clinic_Proj.Models
{
    public class CurrentModel
    {
        [Required]
        public string SiteFrom { get; set; }
        public CurrentModel()
        {
            SiteFrom = string.Empty;
        }
    }
}