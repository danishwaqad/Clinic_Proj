using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Clinic_Proj.Database_Access;

namespace Clinic_Proj.Models
{
    public class DiagnosesModel
    {   
    [Required]
    public string LongName { get; set; }
    public int ID { get; set; }
    [Required]
    public string ShortName { get; set; }
    [Required]
    public string LoginID { get; set; }
    [Required]
    public string DivisionID { get; set; }
    [Required]
    public string SiteID { get; set; }
    [Required]
    public double NodeID { get; set; }
    [Required]
    public double ParentID { get; set; }
    [Required]
    public bool InActive { get; set; }
    [Required]
    public string ICDCode { get; set; }
    [Required]
    public string ParentName { get; set; }
    [Required]
    public string ICDName { get; set; }

        public DiagnosesModel()
    {
            DivisionID = SystemHelper.Get_DivisionID_Session(); 
            SiteID = SystemHelper.Get_SiteID_Session(); 
            LoginID = SystemHelper.Get_User_Session(); 
            LongName = string.Empty;
            ShortName = string.Empty;
            ID = new int();
            NodeID = new double();
            ParentID = new double();
            InActive = new bool();
            ICDCode = string.Empty;
            ParentName = string.Empty;
            ICDName = string.Empty;
        }
}
}