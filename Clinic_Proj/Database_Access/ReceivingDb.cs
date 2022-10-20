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
    public class ReceivingDb
    {
        string RtnJS;
        string Query;
        DataTable dt = new DataTable();
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();
        //===========Create Doc No=================
        public string get_DocNo(ReceivingModel rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("UD_Generate_GRN_No", "@DivisionID,@SiteID", rs.DivisionID,rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        //=============View Product By ID=================
        public string get_Prodrecordbyid(ReceivingModel rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("Sp_Prod_byid", "@ID,@DivisionID,@SiteID",rs.DocNo,rs.DivisionID,rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Get_Expiry_Days()
        {
            try
            {
                Query = @"SELECT * FROM Business";
                dt = new DataTable();
                dt = help.Return_DataTable_Query(Query);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============View Total Amount By Doc=================
        public string get_Amountbyid(ReceivingModel rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("UD_Total_ReceivingAmount", "@DocNumbr,@DivisionID,@SiteID", rs.DocNo,rs.DivisionID,rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========Display Auto Batch============
        public string getAbatchrecord(ReceivingModel rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("UD_Generate_Item_Auto_Batch", "@ItemCode,@DocDate,@DivisionID,@SiteID", rs.ItemCode,rs.DocDate,rs.DivisionID,rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========View Doc No=================
        //public string get_Docrecord()
        //{
        //    try
        //    {
        //        Query = "SELECT Top 1 * from View_Docnumer order by DocNo Desc";
        //        dt = new DataTable();
        //        dt = help.Return_DataTable_Query(Query);
        //        RtnJS = JsonConvert.SerializeObject(dt);
        //        return RtnJS;
        //        //return dt;
        //    }
        //    catch (Exception EX)
        //    {
        //        throw EX;
        //    }
        //}
        //===========Document Lookup Data============
        public string getDocrecord(ReceivingModel rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("Sp_Doc_lookup", "@DivisionID,@SiteID", rs.DivisionID, rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=========Save Document Number==============
        public void Add_Doc_Num(ReceivingModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Generate_New_Doc", "@DocNo,@DocDate,@SiteID,@Division,@LoginID", rs.DocNo, rs.DocDate,rs.SiteID, rs.DivisionID, rs.LoginID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=========Save Cart==============
        public void Add_Cart(ReceivingModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_GRN_Cart", "@DocNo,@DocDate,@ItemCode,@PQty,@BQty,@PRate,@SRate,@ExpiryDate,@BatchNo,@SiteID,@DivisionID,@LoginID", rs.DocNo, rs.DocDate,rs.ProductCode,rs.PaidQty,rs.BonusQty,rs.PRate,rs.SRate,rs.ExpiryDate,rs.BatchNo,rs.SiteID, rs.DivisionID, rs.LoginID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=========Save Complete Document Number=============
        public void Sav_CompDoc(ReceivingModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_GRN_Header_UnPost", "@DocNo,@DocDate,@SubTotal,@Tax,@Discount,@Remarks,@SiteID,@DivisionID,@LoginID", rs.DocNo, rs.DocDate, rs.SubTotal, rs.Tax, rs.Discount, rs.Remarks,rs.SiteID, rs.DivisionID, rs.LoginID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===================Post Document Number===============
        public void Post_DocNum(ReceivingModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Post_GRN", "@DocNo,@DocDate,@SiteID,@DivisionID,@LoginID", rs.DocNo, rs.DocDate,rs.SiteID, rs.DivisionID, rs.LoginID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //============Delete Product===============
        public void deletedata(ReceivingModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Delete_Product", "@Code,@DivisionID,@LoginID",rs.id,rs.DivisionID,rs.SiteID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}