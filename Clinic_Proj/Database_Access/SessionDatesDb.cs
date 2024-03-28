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
    public class SessionDatesDb
    {
        string RtnJS;
        string Query;
        DataTable dt = new DataTable();
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();


        //===============Display Session Tokens By Lookup=====================
        public string get_SessionRecord(SessionDatesMode rs)
        {
            try
            {
                Query = "Select * from VW_Patient_Sessiontkn_getSessionDates where SiteID= '" + rs.SiteID + "' and DivisionID='" + rs.DivisionID + "'";
                dt = help.Return_DataTable_Query(Query);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Patient Session Data Get By ID==========================
        public string get_recordbyid(SessionDatesMode rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("UD_AddPatient_Session_byTken", "@ID,@DivisionID,@SiteID,@LogindID", rs.TokenNo, rs.DivisionID, rs.SiteID, rs.LoginID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==================Save Change Date Session===============
        public void Add_DateChangeRecord(SessionDatesMode DM)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_ChangeSessionDates_byTken", "@TokenNo,@DivisionID,@SiteID,@ToDate,@Remarks,@LoginID", DM.TokenNo, DM.DivisionID, DM.SiteID,DM.ToDate,DM.Remarks,DM.LoginID);
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
    }
}