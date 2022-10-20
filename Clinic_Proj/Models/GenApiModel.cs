using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinic_Proj.Models
{
    public class RequestStatus
    {
        public int Code { get; set; }
        public string Msg { get; set; }
        public List<GenericMod> data { get; set; }
    }
    public class GenericMod
    {
        public string BrandName { get; set; }
        public string TypeID { get; set; }
        public string SubTypeID { get; set; }
        public string Potency { get; set; }
        public string PotencyUOM { get; set; }
        public string FullItemName { get; set; }
        public string GenericName { get; set; }

    }

}