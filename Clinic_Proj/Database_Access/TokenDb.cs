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
    public class TokenDb
    {
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        string RtnJS;
        string Query;
        ////Patient Token
        //public string get_Tokenrecord(string Token)

        //{
        //    DataSet ds = new DataSet();
        //    ds = help.ReturnParameterizedDataSetProcedure("Sp_ViewPat_Tken", "@TokenNo", Token);
        //    return (JsonConvert.SerializeObject(ds.Tables[0]));

        //}
        //Display Token No
        public string get_Tokenrecord(TokenModel rs)
        {
            try
            {
                Query = "Select * from VW_Pending_Token_InQueue where SiteID= '" + rs.SiteID + "' and DivisionID='" + rs.DivisionID + "' order by SerialNo";
                dt = help.Return_DataTable_Query(Query);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=================Display Pending TOkens===================   
        public string get_PendingTkn(TokenModel rs)
        {
            try
            {
                Query = "Select * from VW_PendingTokens_Queue where SiteID= '" + rs.SiteID + "' and DivisionID='" + rs.DivisionID + "' order by CCPL_ROW_ID ";
                dt = help.Return_DataTable_Query(Query);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetAllDr(TokenModel rs)
        {
            try
            {
            string Query = "SELECT DrID, DrName FROM VW_Pending_Token_InQueue where SiteID= '" + rs.SiteID + "' and DivisionID='" + rs.DivisionID + "' GROUP BY DrID, DrName ";
            DataSet dataSet = help.Return_DataSet_Query(Query);
            DataTable dt = new DataTable();
            dt = dataSet.Tables[0];
            return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetAllPatientByDr(string DrID,string SiteID,string DivisionID)
        {
            string Query = "SELECT Top 3 * FROM VW_Pending_Token_InQueue WHERE DrID = '" + DrID + "' and SiteID='" + SiteID + "' and DivisionID='" + DivisionID + "' order by SerialNo asc ";
            DataSet dataSet = help.Return_DataSet_Query(Query);
            DataTable dt = new DataTable();
            dt = dataSet.Tables[0];
            return dt;

        }
    }
}