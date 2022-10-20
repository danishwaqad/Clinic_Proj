using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Clinic_Proj.Database_Access;

namespace Clinic_Proj.Models
{
    public class ViewTokensModel
    {
        [Required]
        public string Search { get; set; }
        public ViewTokensModel()
        {
            Search = string.Empty;
        }
    }
}