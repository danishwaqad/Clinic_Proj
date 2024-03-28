using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Clinic_Proj.Database_Access;

namespace Clinic_Proj.Models
{
    public class DocPaymentRptMode
    {
        public string LoginID { get; set; }
        public string DivisionID { get; set; }
        public string SiteID { get; set; }
        public DocPaymentRptMode()
        {
            DivisionID = SystemHelper.Get_DivisionID_Session(); 
            SiteID = SystemHelper.Get_SiteID_Session(); 
            LoginID = SystemHelper.Get_User_Session();
        }
    }
}