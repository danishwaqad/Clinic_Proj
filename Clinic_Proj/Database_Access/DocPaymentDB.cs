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
    public class DocPaymentDB
    {
        DataTable dt = new DataTable();
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();
        public void Generate_DcNum(DocPaymentMode DM)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Generate_PMT_No", "@SiteID,@LoginID", DM.SiteID, DM.LoginID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Display Doctor DocNumber===================
        public string get_DocDocNumrecord(DocPaymentMode rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("UD_DocNuumber_Top", "@SiteID", rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Display Doctor Look up Data===================
        public string get_Doctrecord(DocPaymentMode rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("UD_DoctorPayment_Lookup", "@LoginID", rs.LoginID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Doctor Data Get By ID=========================
        public string get_recordbyid(DocPaymentMode rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Sp_Dr_byid", "@ID,@DivisionID,@SiteID", rs.DoctorID, rs.DivisionID, rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Display Doctor Data Get By ID================
        public string get_DoctrecordByid(DocPaymentMode rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("UD_Add_DPR2", "@DocNo,@DocDate,@DoctorID,@SiteID,@LoginID", rs.DocNo,rs.DocDate,rs.DoctorID,rs.SiteID,rs.LoginID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Add Doctors Payment Data================
        public void Add_DCrecord(DocPaymentMode DM)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_DPR1", "@DocNo,@DocDate,@SiteID,@DoctorID,@Total,@Paid,@Remarks,@LoginID", DM.DocNo, DM.DocDate, DM.SiteID, DM.DoctorID, DM.LineTotal, DM.LinePaid, DM.Remarks,DM.LoginID);
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
    }
}