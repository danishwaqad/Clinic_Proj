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
    public class PatientRegdb
    {
        string Query;
        string RtnJS;
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        //===============Patient Insert======================
        public void Add_record(PatientModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Register_Patient", "@RegNo,@TokenNo,@Title,@FName,@MName,@LName,@CNIC,@Guardian,@Tel1,@Tel2,@Gender,@EmailID,@Address,@City,@Country,@DOB,@ReferBy,@Remarks,@Relation,@DivisionID,@SiteID,@LoginID,@PatType", rs.RegNo, rs.TokenNo, rs.Title, rs.FirstName, rs.MidName, rs.LastName, rs.CNIC, rs.Guardian, rs.Tel1, rs.Tel2, rs.Gender, rs.EmailID, rs.Address, rs.City, rs.Country, rs.DOB, rs.ReferBy, rs.Remarks, rs.Relation, rs.DivisionID, rs.SiteID, rs.LoginID, rs.PatType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===============Fee Data Insert=========================
        public void Add_Fee_record(PatientModel rs)
        {
            try
            {
                string FullName = rs.Title + " " + rs.FirstName + " " + rs.MidName + " " + rs.LastName;
                help.ExecuteParameterizedProcedure("UD_Add_Patient_Fee", "@RegNo,@TokenNo,@PatName,@CNIC,@DrID,@DrName,@TotalFee,@Discount,@PaidFee,@Balance,@Remarks,@DiscountBy,@DivisionID,@SiteID,@CompID,@CompName,@LoginID,@DisType,@PayMethod,@Bank", rs.RegNo, rs.TokenNo, FullName, rs.CNIC,rs.DrID,rs.DrName,rs.TotalFee, rs.Discount, rs.PaidFee, rs.Balance, rs.Remarks, rs.DisAprov, rs.DivisionID, rs.SiteID,rs.CompanyID,rs.CompanyName,rs.LoginID, rs.DiscountType,rs.PaymentMeth,rs.Bank);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===============Register CNIC Transfer to New Patient Form======================
        public string get_PatientRecord(PatientModel rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("Sp_CNICPatient_byCNIC", "@ID", rs.CNIC);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===============Get Secound Token In One Relation======================
        //public string get_TokenSecound(PatientModel rs)
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();
        //        ds = help.ReturnParameterizedDataSetProcedure("UD_Generate_SecounToken_OneRelation", "@CNIC,@Relation,@ID", rs.CNIC,rs.Relation,rs.SecoundTkn);
        //        return (JsonConvert.SerializeObject(ds.Tables[0]));
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //===============Register Session Token Transfer to New Patient Form======================
        public string get_SessionPatientRecord(PatientModel rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("SpNew_TokenPatient_Session", "@ID", rs.TokenNo);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===============Register Panal CNIC Transfer to New Patient Form======================
        public string get_PanalPatientRecord(PatientModel rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("SpPanal_byCNIC", "@ID", rs.CNIC);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========get CNIC=============
        public string get_CNRecord(string CNIC)
        {
            try
            {
                CNIC = SystemHelper.Get_CNIC_Session();
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("Sp_byCNIC", "@ID", CNIC);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========get Session CNIC=============
        public string getSession_CNRecord(string TokenNo)
        {
            try
            {
                TokenNo = SystemHelper.Get_Token_Session();
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("SpNew_bySessionTkn", "@ID", TokenNo);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========get Panal CNIC=============
        public string get_PanalCNRecord(string CNIC)
        {
            try
            {
                CNIC = SystemHelper.Get_CNIC_Session();
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("SpPanal_byCNIC", "@ID", CNIC);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==========Display All Patient Related lookup Data================
        public string get_record(PatientModel rs)
        {
            try
            {
                dt = new DataTable();
                Query = " SELECT * FROM VW_Patient_Register_Lookup where SiteID= '" + rs.SiteID + "' and DivisionID='" + rs.DivisionID + "' ";
                dt = help.Return_DataTable_Query(Query);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==================Patient Related Data Get For Pharmacy===================
        public string get_Pharmacyrecord()
        {
            string Query, RtnJS;
            try
            {
                Query = @"SELECT * FROM VW_Patient_Detail_ForPharmacy";
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
        ////========================Patient Update===============
        //public void update_record(PatientModel rs)
        //{
        //    try
        //    {
        //        help.ExecuteParameterizedProcedure("UD_Register_Patient", "@RegNo,@TokenNo,@Title,@FName,@MName,@LName,@CNIC,@Guardian,@Tel1,@Tel2,@Gender,@EmailID,@Address,@City,@Country,@DOB,@ReferBy,@Remarks,@Relation,@DivisionID,@SiteID,@LoginID,@PatType", rs.RegNo, rs.TokenNo, rs.Title, rs.FirstName, rs.MidName, rs.LastName, rs.CNIC, rs.Guardian, rs.Tel1, rs.Tel2, rs.Gender, rs.EmailID, rs.Address, rs.City, rs.Country, rs.DOB, rs.ReferBy, rs.Remarks, rs.Relation, rs.DivisionID, rs.SiteID, rs.LoginID, rs.PatType);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public void update_Fee_record(PatientModel rs)
        //{
        //    try
        //    {
        //        string FullName = rs.Title + " " + rs.FirstName + " " + rs.MidName + " " + rs.LastName;
        //        help.ExecuteParameterizedProcedure("UD_Add_Patient_Fee", "@RegNo,@TokenNo,@PatName,@CNIC,@DrID,@DrName,@TotalFee,@Discount,@PaidFee,@Balance,@Remarks,@DiscountBy,@CompID,@CompName,@DivisionID,@SiteID,@LoginID,@DisType", rs.RegNo, rs.TokenNo, FullName, rs.CNIC,rs.DrID,rs.DrName, rs.TotalFee, rs.Discount, rs.PaidFee, rs.Balance, rs.Remarks, rs.DisAprov,rs.CompanyID,rs.CompanyName,rs.DivisionID, rs.SiteID, rs.LoginID, rs.DiscountType);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public string get_recordbyid(PatientModel rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Sp_Patient_byid", "@ID,@SiteID,@DivisionID", rs.TokenNo,rs.SiteID,rs.DivisionID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Create New Token============
        public string get_NewTokenbyid(PatientModel rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("UD_Generate_Token_New", "@CNIC,@Relation", rs.CNIC, rs.Relation);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Patient Detail if Patient is already Register Get By ID AND Token============
        public string get_Exirecordbyid(PatientModel rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("UD_Check_Ex_Patient_Detail", "@CNIC,@Relation,@CCPL_ID", rs.CNIC, rs.Relation,rs.CCPL_RowID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========Get Patient Data By CNIC And Relation IF Already Available
        public string getExist_recordbyid(PatientModel rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("UD_Ex_Patient_Detail", "@CNIC,@Relation", rs.CNIC, rs.Relation);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // Dr Name
        public string get_DocName(PatientModel rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("UD_DrName_Relation", "@SiteID,@DivisionID", rs.SiteID,rs.DivisionID);
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
        //=============Get Patient Relation related All Data=================
        public DataSet get_PatRelation()
        {
            try
            {
                ds = help.ReturnDataSetProcedure("UD_pati_Relation");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=================Get Patient Type By lookup====================
        public DataSet get_PatType()
        {
            try
            {
                ds = help.ReturnDataSetProcedure("UD_pati_Type");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========Get Patient Data By CNIC IF Already Available===========
        public string get_PatAvail(PatientModel rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("UD_Check_Ex_Patient_List", "@CNIC", rs.CNIC);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========Dummy New Token Create=================
        public string get_PatToken(string SiteID, string LoginID)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("UD_Add_Token", "@SiteID,@LoginID", SiteID, LoginID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==================Delete Patient=============================
        public void deletedata(string id)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Delete_Patient", "@Code", id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}