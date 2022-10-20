using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Clinic_Proj.Database_Access;

namespace Clinic_Proj.Models
{
    public class MedStatus
    {
        public int Code { get; set; }
        public string Msg { get; set; }
        public List<MedicationSinc> data { get; set; }
    }
    public class MedicationSinc
    {
        public string BrandName { get; set; }
        public string GenericName { get; set; }
        public string SubTypeID { get; set; }
        public string PotencyWithUOM { get; set; }
        public string StockUnitQty { get; set; }
        public string ItemCode { get; set; }
        public string SKU { get; set; }
        public double SKUValue { get; set; }
        public string PackSize { get; set; }
        public string Potency { get; set; }
        public string PotencyUOM { get; set; }
        public double StockPackQty { get; set; }
        public string DivisionID { get; set; }
        public string SiteID { get; set; }
        public string LoginID { get; set; }
    }
}