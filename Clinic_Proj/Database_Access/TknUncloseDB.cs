using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Clinic_Proj.Models;
using Newtonsoft.Json;

namespace Clinic_Proj.Database_Access
{
    public class TknUncloseDB
    {
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable(); 
        //==============Get Patient View Data=================
        public string get_ViewDataid(TknUncloseMode rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Ud_Patient_ViewData", "@SiteID,@DivisionID",rs.Site, rs.DivisionID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //========Token Unclosed===========
        public void get_UncloseTknid(TknUncloseMode rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("Ud_Patient_UncloseData", "@TokenNo,@SiteID,@DivisionID", rs.TokenNo, rs.Site, rs.DivisionID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}