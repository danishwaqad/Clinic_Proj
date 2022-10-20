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
    public class FollowHistDb
    {
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        string Query;
        string RtnJS;
        //Display Follow History Record record
        public string get_Folowrecord(FollowUpModel rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("UD_FollowUp_History_SiteWise", "@SiteID", rs.Site);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Display New Follow History Record record
        public string get_NewFolowrecord(FollowUpModel rs)
        {
            try
            {
                dt = new DataTable();
                Query = "select * from VW_FollowUp_History where SiteID= '" + rs.Site + "' and DivisionID='" + rs.DivisionID + "' ORDER BY TokenDate";
                dt = help.Return_DataTable_Query(Query);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //======Contact Via By ID=======
        public string get_Conttactbyid(string Contctid)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Sp_ContctVia_byid", "@ID", Contctid);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //================Save Follow Up Record in History Table====================
        public void Add_Folowrecord(FollowUpModel DM)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_FollowHistory_Detail", "@RegNo,@TokenDate,@TokenNo,@CNIC,@PatName,@DoctorID,@DrName,@FollowupDate,@LoginID,@Remarks,@Status,@NextFollowDate,@ContactVia,@DivisionID,@SiteID", DM.RegNo, DM.TokenDate, DM.TokenNo, DM.CNIC, DM.PatName, DM.DoctorID, DM.DrName, DM.FollowupDate, DM.LoginID, DM.Remarks, DM.Status, DM.NextFollowUpDate, DM.ContactVia, DM.DivisionID, DM.Site);
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        //================Save New Follow Up Record====================
        public void Add_NewFolowrecord(FollowUpModel DM)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Update_FollowHistory_Detail", "@RegNo,@TokenNo,@LoginID,@Status,@NextFollowDate,@ContactVia,@DivisionID,@SiteID", DM.RegNo,DM.TokenNo,DM.LoginID,DM.Status,DM.NextFollowUpDate, DM.ContactVia, DM.DivisionID, DM.Site);
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        //==============Get All Data By id and insert to Follow Up History=================
        public string get_Databyid(FollowUpModel rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Sp_GetToken_byid_ForFolow", "@ID,@SiteID,@DivisionID",rs.TokenNo,rs.Site,rs.DivisionID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Get View Data Follow Up History=================
        public string get_ViewDataid(FollowUpModel rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Sp_ViewData_Folow", "@ID,@SiteID,@DivisionID",rs.TokenNo,rs.Site,rs.DivisionID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=====Get Contact Via======
        public DataSet get_CntctVia()
        {
            try
            {
                ds = help.ReturnDataSetProcedure("UD_ContactVia");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}