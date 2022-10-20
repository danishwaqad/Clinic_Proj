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
    public class GraphDb
    {
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        //===================View Graph==========================
        public string get_Graphrecord(GraphMode rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("UD_Get_Site_Sale_ForGraph", "@SiteID", rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Display Class Data By LookUp=================
        public void get_Closedrecord(GraphMode rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Patient_AutoClose_Token", "@SiteID",rs.SiteID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}