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
    public class FAPayDb
    {
        DataTable dt = new DataTable();
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();
        //Update Record
        public void save_record(FAPayModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Patient_FA_Header1", "@TokenNo,@TotalAmount,@BalanceAmount,@PaidAmount,@Remarks,@LoginID,@DivisionID,@SiteID,@PaymentMethod,@BankName", rs.TokenNo, rs.TotalAmount, rs.Balance, rs.PaidFee, rs.Remarks, rs.LoginID, rs.DivisionID, rs.SiteID, rs.PaymentMeth, rs.Bank);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Display Patient Look up Data===================
        public string get_record(FAPayModel rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("UD_Patient_FA_Pay_get", "@DivisionID,@SiteID",rs.DivisionID,rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // Bank Name
        public DataSet get_BankName()
        {
            try
            {
                ds = help.ReturnDataSetProcedure("UD_BankName");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // Payment Method
        public DataSet get_PaymntMeth()
        {
            try
            {
                ds = help.ReturnDataSetProcedure("UD_PaymentMethod");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==================Check Payment Record=======================
        public string get_FAPaymentbyid(FAPayModel rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("FAChekPayment_byID", "@ID,@DivisionID,@SiteID", rs.TokenNo, rs.DivisionID, rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Display Patient Data Get By ID================
        public string get_recordbyid(FAPayModel rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("Sp_Patient_PayData_byID", "@ID,@DivisionID,@SiteID", rs.TokenNo,rs.DivisionID,rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}