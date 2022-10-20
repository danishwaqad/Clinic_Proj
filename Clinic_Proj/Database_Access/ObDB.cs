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
    public class ObDB
    {
        string RtnJS;
        string Query;
        DataTable dt = new DataTable();
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();

        public string Get_RsNote_List()
        {
            try
            {
                Query = "SELECT * FROM VW_RSNo_OB_Detail";
                dt = help.Return_DataTable_Query(Query);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        //=============Get Consultancy and First Aid Data=============
        public string get_CF(OB_Mode DM)
        {
            try
            {
                dt = new DataTable();
                Query = "Select * From VW_TodayDayClosing_Balance where SiteID= '" + DM.SiteID + "' and DivisionID='" + DM.DivisionID + "' ";
                dt = help.Return_DataTable_Query(Query);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Generate_DcNum(OB_Mode DM)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("UD_Generate_OB_No", "@DivisionID,@SiteID", DM.DivisionID,DM.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Add_DocNum(OB_Mode DM)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_OB_Header", "@DocNo,@DocDate,@OB,@DivisionID,@SiteID,@LoginID,@Remarks", DM.DocNo, DM.DocDate,DM.Opening,DM.DivisionID, DM.SiteID,DM.LoginID, DM.Remarks);
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public void update_DCrecord(OB_Mode DM)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Update_OB_Header", "@DocNo,@DocDate,@OB,@DivisionID,@SiteID,@LoginID,@Remarks", DM.DocNo, DM.DocDate, DM.Opening, DM.DivisionID, DM.SiteID, DM.LoginID, DM.Remarks);
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public void Add_DCrecord(OB_Mode DM)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_OB_Detail", "@DocNo,@DocDate,@RsNote,@Qty,@Total,@Opening,@DivisionID,@SiteID,@LoginID,@Remarks", DM.DocNo, DM.DocDate, DM.RsNote, DM.Quantity, DM.Total,DM.Opening, DM.DivisionID, DM.SiteID, DM.LoginID, DM.Remarks);
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public void RptAdd_DCrecord(OB_Mode DM)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_OB_Close", "@DocNo,@DocDate,@RsNote,@Qty,@Total,@Consultancy,@FirstAid,@Session,@LoginID,@DivisionID,@SiteID,@Remarks", DM.DocNo, DM.DocDate, DM.RsNote, DM.Quantity, DM.Total, DM.Consultancy, DM.FirstAid,DM.Session,DM.LoginID,DM.DivisionID,DM.SiteID,DM.Remarks);
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        //==========Display Document Number lookup Data================
        public string get_record(OB_Mode DM)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("UD_OB_Lookup", "@DivisionID,@SiteID", DM.DivisionID,DM.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string get_recordbyid(OB_Mode DM)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Sp_OBDetail_byid", "@ID,@DivisionID,@SiteID", DM.DocNo,DM.DivisionID,DM.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===============Display dropdown Rupees Data================
        public DataSet get_RupeesAll()
        {
            try
            {
                ds = help.ReturnDataSetProcedure("Ud_Get_Rupees");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Add_AllDetail(OB_Mode DM)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_OB_Detail", "@DocNo,@DocDate,@RsNote,@Qty,@Total,@LoginID,@Remarks,@DivisionID,@SiteID", DM.DocNo, DM.DocDate, DM.RsNote, DM.Quantity, DM.Total, DM.LoginID, DM.Remarks, DM.DivisionID, DM.SiteID);
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        //==========View All Data================
        public string get_Viewrecord(OB_Mode DM)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("Sp_OBDetailView_byid", "@ID,@DivisionID,@SiteID", DM.DocNo,DM.DivisionID,DM.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==========View All Data================
        public string get_OBrecord(OB_Mode DM)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("UD_OB_Calclulate", "@DocNo,@DivisionID,@SiteID",DM.DocNo,DM.DivisionID,DM.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //============Delete record==================
        public void deletedata(OB_Mode DM)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Delete_OBDetail", "@Code,@DivisionID,@SiteID", DM.id,DM.DivisionID,DM.SiteID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}