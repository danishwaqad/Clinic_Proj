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
    public class TokenMediDb
    {
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        //========Display Medication By token  View API All Data=================
        public string get_PharmaMeditknecord(TokenMediMode rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("UD_Get_Token_Medicine_List_ForPharmacy", "@TokenNo,@DivisionID,@SiteID", rs.TokenNo, rs.DivisionID, rs.SiteID);
                string RtnJS = JsonConvert.SerializeObject(ds.Tables[0]);
                return RtnJS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}