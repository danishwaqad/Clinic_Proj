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
    public class PatRefundFeedb
    {
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();
        string Query;
        string RtnJS;
        DataTable dt = new DataTable();
        public void Add_record(FeeRefundModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Patient_Refund", "@TokenNo,@TypeID,@Total,@PaidFee,@Refund,@Balance,@Remarks,@Approval,@Discount,@LoginID,@DivisionID,@SiteID", rs.TokenNo, rs.RefundType, rs.TotalFee, rs.PaidFee, rs.RefundFee, rs.Balance, rs.Remarks, rs.RefundApproval, rs.Discount, rs.LoginID, rs.DivisionID, rs.SiteID);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
        //==========Display Patient Data By Lookup===========
        public string get_record(FeeRefundModel rs)
        {
            try
            {
                Query = "Select * from VW_Patient_PatRef_get where SiteID= '" + rs.SiteID + "' and DivisionID='" + rs.DivisionID + "'";
                dt = help.Return_DataTable_Query(Query);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Update Refund Data=================
        public void update_record(FeeRefundModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Patient_Refund", "@TokenNo,@TypeID,@Total,@PaidFee,@Refund,@Balance,@Remarks,@Approval,@Discount,@LoginID,@DivisionID,@SiteID", rs.TokenNo, rs.RefundType, rs.TotalFee, rs.PaidFee, rs.RefundFee, rs.Balance, rs.Remarks,rs.RefundApproval, rs.Discount,rs.LoginID, rs.DivisionID, rs.SiteID);
            }
            catch (Exception ex)
            {
                throw ex;
            }    
        }
        //=========Get Patient Data By ID=================
        public string get_recordbyid(FeeRefundModel rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Sp_Patient_Refund_byTken", "@ID,@SiteID,@DivisionID", rs.TokenNo,rs.SiteID,rs.DivisionID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Patient Refund Delete=================
        public void deletedata(FeeRefundModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Delete_Patient_Refund", "@Code,@TokenNo,@RefundType,@SiteID,@DivisionID", rs.id,rs.TokenNo,rs.RefundType, rs.SiteID,rs.DivisionID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //============Get Patient Refund Type============
        public DataSet get_PatRefundType()
        {
            try
            {
                ds = help.ReturnDataSetProcedure("UD_Refund_Type");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========Get Refund By Type===============
        public string get_RefundByType(FeeRefundModel rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("UD_Get_Refund_Type_Detail", "@TokenNo,@RefundType,@SiteID,@DivisionID",rs.TokenNo,rs.RefundType, rs.SiteID,rs.DivisionID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //============Display Refund View All Data===============
        public string get_Viewrecord(FeeRefundModel rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Sp_PatientViewRef_get", "@TokenNo,@SiteID,@DivisionID",rs.TokenNo,rs.SiteID,rs.DivisionID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============View Refund Data Get By ID==============
        public string get_Viewrecordbyid(FeeRefundModel rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Sp_ViewPatient_Refund_byTken", "@ID,@SiteID,@DivisionID", rs.id,rs.SiteID,rs.DivisionID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}