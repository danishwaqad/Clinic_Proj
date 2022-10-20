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
    public class SignIn_Qry
    {
            DataTable dt = new DataTable();
            DB_Helper help = new DB_Helper();
            string Query;
            public DataTable Login(string Username, string Password)
            {
                try
                {
                    dt = help.ReturnParameterizedDataTableProcedure("UD_Login_Authenticate", "@Username,@Pass", Username, Password);
                    return dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            public void ChangePass(string Usr, string Pass)
            {
                try
                {
                    help.ExecuteParameterizedProcedure("UD_Update_Login_Pass", "@Username,@Pass", Usr, Pass);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            public DataTable Get_Site_Name(string SiteID)
            {
                try
                {
                    Query = "SELECT SiteName FROM Site WHERE SiteCode = '" + SiteID + "'";
                    dt = help.Return_DataTable_Query(Query);
                    return dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
    }
}