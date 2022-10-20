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
    public class CbDB
    {
        string RtnJS;
        string Query;
        DataTable dt = new DataTable();
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();
        public string Generate_DcNum()
        {
            try
            {
                Query = "SELECT * FROM Generate_CB_No";
                dt = new DataTable();
                dt = help.Return_DataTable_Query(Query);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
                //return dt;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public void Add_DocNum(CB_Mode DM)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_CB_Header", "@DocNo,@DocDate,@OB,@DivisionID,@SiteID,@LoginID,@Remarks", DM.DocNo, DM.DocDate, DM.Opening, DM.DivisionID, DM.SiteID, DM.LoginID, DM.Remarks);
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public void update_DCrecord(CB_Mode DM)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Update_CB_Header", "@DocNo,@DocDate,@OB,@DivisionID,@SiteID,@LoginID,@Remarks", DM.DocNo, DM.DocDate, DM.Opening, DM.DivisionID, DM.SiteID, DM.LoginID, DM.Remarks);
            }
            catch (Exception EX)
            {
                throw EX;
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
        public void Add_AllDetail(CB_Mode DM)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_CB_Detail", "@DocNo,@DocDate,@RsNote,@Qty,@Total,@LoginID,@Remarks,@DivisionID,@SiteID", DM.DocNo, DM.DocDate, DM.RsNote, DM.Quantity, DM.Total, DM.LoginID, DM.Remarks, DM.DivisionID, DM.SiteID);
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        //==========View All Data================
        public string get_Viewrecord(string id)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("Sp_CBDetailView_byid", "@ID", id);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==========View All Data================
        public string get_CBrecord(string id)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("UD_CB_Calclulate", "@DocNo", id);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //============Delete record==================
        public void deletedata(int id)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Delete_CBDetail", "@Code", id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}