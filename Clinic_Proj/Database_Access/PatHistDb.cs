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
    public class PatHistDb
    {
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        string Query;
        string RtnJS;

        //patient token
        public string get_Tokenrecord(PatHisModl rs)
        {
            DataSet ds = new DataSet();
            ds = help.ReturnParameterizedDataSetProcedure("Sp_Pat_Tken", "@TokenNo", rs.TokenNo);
            return (JsonConvert.SerializeObject(ds.Tables[0]));
        }
        //Display Selected Record
        public string get_Selectrecord(PatHisModl rs)
        {
            DataSet ds = new DataSet();
            ds = help.ReturnParameterizedDataSetProcedure("UD_Selected_Data", "@TokenNo,@Type", rs.TokenNo,rs.Type);
            return (JsonConvert.SerializeObject(ds.Tables[0]));

        }
        //===================Display Session View All Data===================
        public string get_SessionViewrecord(PatHisModl rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Sp_ViewHisPat_Session", "@TokenNo", rs.TokenNo);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===================Display Session Activity View All Data===================
        public string get_SessionActrecord(PatHisModl rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Sp_ViewHisPat_SessionAct", "@TokenNo", rs.TokenNo);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Display Cnic From and To record
        public string get_CNICFTrecord(PatHisModl rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("UD_CNIC_All_Tken", "@LoginID", rs.LoginID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Display Type Data From Lookup
        public string get_Typrecord()
        {
            try
            {
                dt = new DataTable();
                Query = "select * from Vw_patient_Type where InActive = 0";
                dt = help.Return_DataTable_Query(Query);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Display Doctor From Lookup
        public string get_Docrecord(PatHisModl rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("UD_Doctor_Lookup", "@LoginID", rs.LoginID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Display Site From and To record
        public string get_SiteFTrecord(PatHisModl rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("UD_Get_AllSite", "@LoginID", rs.LoginID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Display Site From and To record
        //public DataSet ViewData(PatHisModl rs)

        //{
        //    try
        //    {
        //    DataSet ds = new DataSet();
        //    ds = help.ReturnParameterizedDataSetProcedure("UD_Patient_History_Header", "@CNICFrom,@CNICTo,@SiteFrom,@SiteTo,@DateFrom,@DateTo", rs.CNICFrom, rs.CNICTo, rs.SiteFrom, rs.SiteTo, rs.DateFrom, rs.DateTo);
        //    return ds;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public string ViewData(PatHisModl rs)
        {
            try
            {
                    string RtnJS;
                    DataTable dt = new DataTable();
                    dt = help.ReturnParameterizedDataTableProcedure("UD_Closing_Balance", "@CNICFrom,@SiteFrom,@DivisionID,@DateFrom,@DateTo,@Type,@DocNam,@LoginID", rs.CNICFrom, rs.SiteFrom, rs.DivisionID, rs.DateFrom, rs.DateTo, rs.Type,rs.DoctorName,rs.LoginID);
                    RtnJS = JsonConvert.SerializeObject(dt);
                    return RtnJS;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        //==============Get Charges Total By ID============
        public string get_ChargesByID(PatHisModl rs)
        {
            try
            {
                string RtnJS;
                DataTable dt = new DataTable();
                dt = help.ReturnParameterizedDataTableProcedure("UD_History_Total_Balance_SUM", "@CNICFrom,@SiteFrom,@DivisionID,@DocNam,@DateFrom,@DateTo,@Type,@LoginID", rs.CNICFrom, rs.SiteFrom,rs.DivisionID,rs.DoctorName,rs.DateFrom, rs.DateTo,rs.Type,rs.LoginID);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        //patient Diagnose view Muneeb change
        public string get_DiagViewrecord(PatHisModl rs)

        {
            DataSet ds = new DataSet();
            ds = help.ReturnParameterizedDataSetProcedure("Sp_ViewPat_Diag_Tken", "@TokenNo", rs.TokenNo);
            return (JsonConvert.SerializeObject(ds.Tables[0]));

        }
        //patient Vital view
        public string get_Viewrecord(PatHisModl rs)

        {
            DataSet ds = new DataSet();
            ds = help.ReturnParameterizedDataSetProcedure("Sp_ViewVital_Conslt_Tken", "@TokenNo", rs.TokenNo);
            return (JsonConvert.SerializeObject(ds.Tables[0]));
        }
        //Get Token
        public string get_Tknrecord(PatHisModl rs)

        {
            DataSet ds = new DataSet();
            ds = help.ReturnParameterizedDataSetProcedure("Sp_ViewVital_Conslt_Tken", "@TokenNo", rs.TokenNo);
            return (JsonConvert.SerializeObject(ds.Tables[0]));
        }
        //patient Lab Test view
        public string get_LabViewrecord(PatHisModl rs)

        {
            DataSet ds = new DataSet();
            ds = help.ReturnParameterizedDataSetProcedure("Sp_ViewPat_Lab_Tken", "@TokenNo", rs.TokenNo);
            return (JsonConvert.SerializeObject(ds.Tables[0]));

        }
        //patient Follow up view
        public string get_FolowViewrecord(PatHisModl rs)

        {
            DataSet ds = new DataSet();
            ds = help.ReturnParameterizedDataSetProcedure("Sp_ViewPat_Folow_Tken", "@TokenNo", rs.TokenNo);
            return (JsonConvert.SerializeObject(ds.Tables[0]));
        }
        //patient Follow up view
        public string get_FAViewrecord(PatHisModl rs)

        {
            DataSet ds = new DataSet();
            ds = help.ReturnParameterizedDataSetProcedure("UD_Fa_Services", "@TokenNo", rs.TokenNo);
            return (JsonConvert.SerializeObject(ds.Tables[0]));
        }
        //patient Medication view
        public string getmed_Viewrecord(PatHisModl rs)

        {
            DataSet ds = new DataSet();
            ds = help.ReturnParameterizedDataSetProcedure("Sp_ViewPat_Medi_Tken", "@TokenNo", rs.TokenNo);
            return (JsonConvert.SerializeObject(ds.Tables[0]));
        }
        //patient Service view
        public string getSer_View(PatHisModl rs)
        {
            DataSet ds = new DataSet();
            ds = help.ReturnParameterizedDataSetProcedure("Sp_ViewTreatmnt_bySamTken", "@TokenNo", rs.TokenNo);
            return (JsonConvert.SerializeObject(ds.Tables[0]));
        }
    }
}