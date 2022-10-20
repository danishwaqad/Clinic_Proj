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
    public class ViewTokensDb
    {
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        //==============Get View Data Follow Up History=================
        public string get_ViewDataid(ViewTokensModel rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("UD_ViewTokens_History", "@SearchField", rs.Search);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}