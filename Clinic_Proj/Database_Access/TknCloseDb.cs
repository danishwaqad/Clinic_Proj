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
    public class TknCloseDb
    {
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        string Query;
        string RtnJS;
        //==============SAVE For Token Closing=============
        public void Add_record(TknCloseModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Token_Closed", "@TokenNo,@TypeID,@TotalAmount,@PaidAmount,@DiscountAmount,@RefundAmount,@Payable,@ClosedAmount,@PendingAmount,@LoginID,@DivisionID,@SiteID,@NetPaidAmount", rs.TokenNo, rs.TypeID, rs.TotalAmount, rs.PaidAmount, rs.DiscountAmount, rs.RefundAmount, rs.PayableAmount, rs.NewPaid, rs.NewBal, rs.LoginID, rs.DivisionID, rs.SiteID, rs.NetPaidAmount);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        //==============Display Patient Token All Data==============
        public string get_record(TknCloseModel rs)
        {
            try
            {
                Query = "Select * from VW_Clstkn_Lookup where SiteID= '" + rs.SiteID + "' and DivisionID='" + rs.DivisionID + "' ORDER BY TokenNo,TokenDate";
                dt = help.Return_DataTable_Query(Query);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Patient Token Data Get By ID===================
        public string get_recordbyid(TknCloseModel rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("Sp_Patient_Close_byTken", "@ID,@DivisionID,@SiteID", rs.TokenNo, rs.DivisionID, rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //========Display Patient View All Data=====================
        public string get_Viewrecord(TknCloseModel rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("UD_Unclosed_Token_Detail_New1", "@TokenNo,@DivisionID,@SiteID", rs.TokenNo,rs.DivisionID,rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // Update Record
        //public void update_record(TknCloseModel rs)
        //{
        //    try
        //    {
        //        help.ExecuteParameterizedProcedure("UD_Add_Token_Closed", "@TokenNo,@TypeID,@TotalAmount,@PaidAmount,@DiscountAmount,@RefundAmount,@Payable,@ClosedAmount,@PendingAmount,@DivisionID,@SiteID,@LoginID", rs.TokenNo, rs.TypeID, rs.TotalAmount, rs.PaidAmount, rs.DiscountAmount, rs.RefundAmount, rs.PayableAmount, rs.NewPaid, rs.NewBal, rs.LoginID, rs.DivisionID, rs.SiteID);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        // Delete record
        //public void deletedata(int id)
        //{
        //    help.ExecuteParameterizedProcedure("UD_Delete_Patient_Refund", "@Code,", id);
        //}
        //Get View Record By id
        //public DataSet get_Viewrecordbyid(int id)
        //{
        //    DataSet ds = new DataSet();
        //    ds = help.ReturnParameterizedDataSetProcedure("Sp_ViewPatient_Refund_byTken", "@ID", id);
        //    return ds;
        //}
    }
}