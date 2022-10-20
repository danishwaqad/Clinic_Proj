using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Clinic_Proj.Database_Access;

namespace Clinic_Proj.Models
{
    public class CmpToEmpMode
    {
        [Required]
        public string CompanyID { get; set; }
        [Required]
        public string EmployeeID { get; set; }
        public CmpToEmpMode()
        {
            CompanyID = string.Empty;
            EmployeeID = string.Empty;
        }
    }
}