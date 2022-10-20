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
    public class SessionDb
    {
        string RtnJS;
        string Query;
        DataTable dt = new DataTable();
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();


        //===============Display Session Tokens By Lookup=====================
        public string get_SessionRecord(SessionMode rs)
        {
            try
            {
                Query = "Select * from VW_Patient_Sessiontkn_getSession1 where SiteID= '" + rs.SiteID + "' and DivisionID='" + rs.DivisionID + "'";
                dt = help.Return_DataTable_Query(Query);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===================Display Session View All Data===================
        public string get_SessionViewrecord(SessionMode rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("VW_ViewPrevious_Session", "@TokenNo,@DivisionID,@SiteID", rs.TokenNo, rs.DivisionID, rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===================Display Session ToDate View Data===================
        public string get_SessionViewToDate(SessionMode rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("VW_ViewTodate_Session", "@TokenNo,@DivisionID,@SiteID", rs.TokenNo, rs.DivisionID, rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===============Display Session Fee=====================
        //public string get_SessionFeeRecord(SessionMode rs)
        //{
        //    try
        //    {
        //        Query = "Select * from VW_Patient_SessionFee_get where SiteID= '" + rs.SiteID + "' and DivisionID='" + rs.DivisionID + "' and DrName ='" + rs.DoctorName + "'";
        //        dt = help.Return_DataTable_Query(Query);
        //        RtnJS = JsonConvert.SerializeObject(dt);
        //        return RtnJS;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //=============Patient Session Data Get By ID==========================
        public string get_recordbyid(SessionMode rs)
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
        public void Add_Saverecord(SessionMode DM)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_SessionFullPkg_Detail", "@TokenSession,@TotalFee,@Status,@DivisionID,@SiteID,@LoginID", DM.TokenNo, DM.TotalFee, DM.Status, DM.DivisionID, DM.SiteID, DM.LoginID);
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public void Add_ExtSesionrecord(SessionMode DM)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Ext_Session_byTken", "@ID,@NoOfSession,@SessionRemarks,@FromDate,@ToDate,@Remarks,@DivisionID,@SiteID,@LoginID", DM.TokenNo, DM.NoOfSessions, DM.SessionRemarks, DM.FromDate, DM.ToDate, DM.Remarks, DM.DivisionID, DM.SiteID, DM.LoginID);
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        //==================Save FullPayment Extension Session===============
        public void Add_FullSesionrecord(SessionMode DM)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Pkg_ExtFull_byTken", "@TokenNo,@DivisionID,@SiteID,@LoginID", DM.TokenNo, DM.DivisionID, DM.SiteID, DM.LoginID);
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public void Add_ExtPackagerecord(SessionMode DM)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_FullPkg_ExtSession_byTken", "@ID,@DivisionID,@SiteID,@LoginID", DM.TokenNo, DM.DivisionID, DM.SiteID, DM.LoginID);
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public void Update_SesStatus(SessionMode DM)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Update_Session_Status_Ssession2", "@TokenNo,@DivisionID,@SiteID,@LoginID", DM.TokenNo, DM.DivisionID, DM.SiteID, DM.LoginID);
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public void AddSingle_Sesrecord(SessionMode DM)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_SinglePayment_Session_Detail", "@TokenSession,@TotalFee,@Status,@DivisionID,@SiteID,@LoginID", DM.TokenNo, DM.TotalFee, DM.Status, DM.DivisionID, DM.SiteID, DM.LoginID);
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public void Extra_Sesrecord(SessionMode DM)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Extra_Sessionworking_Insert", "@TokenNo,@DivisionID,@SiteID,@LoginID", DM.TokenNo, DM.DivisionID, DM.SiteID, DM.LoginID);
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        //==================Get Active Tokens List For Session=======================
        public string Get_SessionTkn_List(SessionMode rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("UD_Patient_SessiontknList_get_All", "@TokenNo,@DivisionID,@SiteID", rs.TokenNo, rs.DivisionID, rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==================Get Tokens List For Session Extend=======================
        public string Get_SessionExtTkn_List(SessionMode rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("UD_Sessiontkn_ExtList_All", "@TokenNo,@DivisionID,@SiteID", rs.TokenNo, rs.DivisionID, rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Patient Sessions Detail==========================
        //public void Add_DetailRecord(SessionMode DM)
        //{
        //    try
        //    {
        //        help.ExecuteParameterizedProcedure("UD_Add_OB_Detail", "@DocNo,@DocDate,@RsNote,@Qty,@Total,@Opening,@DivisionID,@SiteID,@LoginID,@Remarks", DM.DocNo, DM.DocDate, DM.RsNote, DM.Quantity, DM.Total, DM.Opening, DM.DivisionID, DM.SiteID, DM.LoginID, DM.Remarks);
        //    }
        //    catch (Exception EX)
        //    {
        //        throw EX;
        //    }
        //}
    }
}