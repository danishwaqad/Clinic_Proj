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
    public class CurrentStockDb
    {
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();
        //Display Current Sotck View data
        public string ViewCurrentData(ReportsModel rs)
        {
            try
            {
                string RtnJS;
                DataTable dt = new DataTable();
                dt = help.ReturnParameterizedDataTableProcedure("UD_Current_Stock", "@SiteFrom", rs.SiteFrom);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        //==============Get Total For Clinic============
        public string get_CurrentTotal(ReportsModel rs)
        {
            try
            {
                string RtnJS;
                DataTable dt = new DataTable();
                dt = help.ReturnParameterizedDataTableProcedure("UD_CurrentStock_SUM", "@SiteFrom", rs.SiteFrom);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
    }
}