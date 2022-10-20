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
    public class NewRegdb
    {
        string RtnJS;
        string Query;
        DataTable dt = new DataTable();
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();
        //===============Patient Insert======================
        public void Add_record(NewRegModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Registeration", "@RegNo,@CNIC,@RegDate,@Title,@FirstName,@MidName,@LastName,@FatherName,@DOB,@CNICIssueDate,@CNICExpiryDate,@FamilyNumber,@CNICIdentity,@Gender,@ReferBy,@Remarks,@DivisionID,@SiteID,@LoginID", rs.RegNo, rs.CNIC, rs.RegDate, rs.Title, rs.FirstName, rs.MidName, rs.LastName, rs.Guardian, rs.DOB, rs.CNICIssue, rs.CNICExp, rs.FamilyNo, rs.CNICIdentity, rs.gender, rs.ReferBy, rs.Remarks, rs.DivisionID, rs.SiteID, rs.LoginID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===============Patient Panal Insert======================
        public void Add_Panalrecord(NewRegModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Registeration", "@RegNo,@CNIC,@RegDate,@Title,@FirstName,@MidName,@LastName,@FatherName,@DOB,@CNICIssueDate,@CNICExpiryDate,@FamilyNumber,@CNICIdentity,@Gender,@ReferBy,@Remarks,@DivisionID,@SiteID,@LoginID", rs.RegNo, rs.CNIC, rs.RegDate, rs.Title, rs.FirstName, rs.MidName, rs.LastName, rs.Guardian, rs.DOB, rs.CNICIssue, rs.CNICExp, rs.FamilyNo, rs.CNICIdentity, rs.gender, rs.ReferBy, rs.Remarks, rs.DivisionID, rs.SiteID, rs.LoginID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========If Patient Cannot Provide CNIC=================
        public string get_PatCNIC()
        {
            try
            {
                Query = "SELECT * FROM Generate_CNIC_No";
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
        //===================Button Clicking=================
        //=============Create New Token============
        public string get_NewTokenbyid(string CNIC, string Relation)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("UD_Generate_Token_New", "@CNIC,@Relation", CNIC, Relation);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=================Info Transfer to Self Button==============
        public string get_InfoTrnsfrbyid(NewRegModel rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("UD_GetInfo_ForSelf", "@CNIC",rs.CNIC);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
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
        // Dr Name
        public string get_DocName(NewRegModel rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("UD_DrName_Relation", "@DivisionID,@SiteID", rs.DivisionID, rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string get_recordbyid(NewRegModel rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Sp_Drget_ForNewreg_byid", "@ID",rs.DrID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Get Doctor Names
        public string get_recordDrnam(NewRegModel rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Sp_ForNewNam_byid", "@ID", rs.DrID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Bank By ID
        public string get_bankbyid(string Bankid)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Sp_Bankget_ForNewreg_byid", "@ID", Bankid);
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
        //Payment Method By ID
        public string get_Paybyid(string Payid)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Sp_Paymentget_ForNewreg_byid", "@ID", Payid);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
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
        //===============Fee Data Insert=========================
        public void Add_Fee_record(NewRegModel rs)
        {
            try
            {
                string FullName = rs.Title + " " + rs.FirstName + " " + rs.MidName + " " + rs.LastName;
                help.ExecuteParameterizedProcedure("UD_Add_ForSelf_Patient_Fee", "@RegNo,@TokenNo,@PatName,@CNIC,@DrID,@TotalFee,@Discount,@PaidFee,@Balance,@Remarks,@DiscountBy,@DivisionID,@SiteID,@LoginID,@DisType,,@PayMethod,@Bank", rs.RegNo, rs.TokenNo, FullName, rs.CNIC,rs.DrID,rs.TotalFee, rs.Discount, rs.PaidFee, rs.Balance, rs.Remarks, rs.DisAprov, rs.DivisionID, rs.SiteID, rs.LoginID, rs.DiscountType,rs.PaymentMeth,rs.Bank);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==========Display All Patient Related lookup Data================
        public string get_CNICLrecord(NewRegModel rs)
        {
            try
            {
                dt = new DataTable();
                Query = " SELECT * FROM VW_Registration_Lookup where SiteID= '" + rs.SiteID + "' and DivisionID='" + rs.DivisionID + "' ";
                dt = help.Return_DataTable_Query(Query);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Patient Lookup CNIC Get Data By id=================
        public string get_CNrecordbyid(NewRegModel rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Sp_CNICPatient_byid", "@ID,@DivisionID,@SiteID", rs.RegNo,rs.DivisionID,rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===============Patient Insert======================
        public void Add_Selfrecord(NewRegModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Register_Patient", "@RegNo,@TokenNo,@Title,@FName,@MName,@LName,@Guardian,@CNIC,@Tel1,@Tel2,@Gender,@EmailID,@Address,@City,@Country,@DOB,@ReferBy,@Remarks,@Relation,@DivisionID,@SiteID,@LoginID,@PatType", rs.RegNo, rs.TokenNo, rs.Title, rs.FirstName, rs.MidName, rs.LastName, rs.Guardian, rs.CNIC, rs.Tel1, rs.Tel2, rs.gender, rs.EmailID, rs.Address, rs.City, rs.Country, rs.DOB,rs.ReferBy, rs.Remarks, rs.Relation, rs.DivisionID, rs.SiteID, rs.LoginID, rs.PatType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===============Patient Update======================
        public void Update_Selfrecord(NewRegModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Register_Patient", "@RegNo,@TokenNo,@Title,@FName,@MName,@LName,@Guardian,@CNIC,@Tel1,@Tel2,@Gender,@EmailID,@Address,@City,@Country,@DOB,@ReferBy,@Remarks,@Relation,@DivisionID,@SiteID,@LoginID,@PatType", rs.RegNo, rs.TokenNo, rs.Title, rs.FirstName, rs.MidName, rs.LastName, rs.Guardian, rs.CNIC, rs.Tel1, rs.Tel2, rs.gender, rs.EmailID, rs.Address, rs.City, rs.Country, rs.DOB, rs.ReferBy, rs.Remarks, rs.Relation, rs.DivisionID, rs.SiteID, rs.LoginID, rs.PatType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //========================End============================= 
        //===========Get Patient Data By CNIC IF Already Available===========
        public string get_PatAvail(NewRegModel rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("UD_Check_Ex_CNIC_Register", "@CNIC", rs.CNIC);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========Get Panal Patient Data By CNIC IF Already Available==========
        public string get_PanlPatAvail(NewRegModel rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("UD_Panal_Patients", "@CNIC", rs.CNIC);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========Get Whats App Avail===========
        //public string get_WhatsAppAvail(NewRegModel rs)
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();
        //        ds = help.ReturnParameterizedDataSetProcedure("Ud_Proc_Check_WhatsApp", "@CNIC",rs.CNIC);
        //        return (JsonConvert.SerializeObject(ds.Tables[0]));
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //==========View Address Data================
        public string get_AViewrecord(NewRegModel rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("Sp_AddressData_byid", "@ID,@SiteID,@DivisionID", rs.RegNo,rs.SiteID,rs.DivisionID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==================Address Data Delete=============
        public void deleteAdddata(NewRegModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Delete_Address", "@Code,@SiteID,@DivisionID",rs.ID,rs.SiteID,rs.DivisionID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==================Address Data Delete=============
        public void deleteContdata(NewRegModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Delete_Contact", "@Code,@SiteID,@DivisionID", rs.ID,rs.SiteID,rs.DivisionID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==========View Contact Data================
        public string get_CViewrecord(NewRegModel rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("Sp_ContactData_byid", "@ID,@SiteID,@DivisionID", rs.RegNo,rs.SiteID,rs.DivisionID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==========View CNIC Data================
        public string get_CNICViewrecord(NewRegModel rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("Sp_CNICData_byid", "@ID,@SiteID,@DivisionID", rs.RegNo, rs.SiteID, rs.DivisionID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==========View Contact Data================
        public string get_Viewrecord(NewRegModel rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("Sp_Data_byid", "@ID,@SiteID,@DivisionID", rs.RegNo,rs.SiteID,rs.DivisionID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        //==========View Address Data By ID================
        //public string get_Arecordbyid(string id)
        //{
        //    try
        //    {
        //        ds = help.ReturnParameterizedDataSetProcedure("Sp_AddressData_byid", "@ID", id);
        //        return (JsonConvert.SerializeObject(ds.Tables[0]));
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //===============Patient Address Insert======================
        public void Add_Addressrecord(NewRegModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Reg_Address", "@RegNo,@CNIC,@RegDate,@TypeID,@HouseNo,@StreetNo,@Town,@ZipCode,@City,@State,@Country,@Remarks,@DivisionID,@SiteID,@LoginID", rs.RegNo, rs.CNIC, rs.RegDate, rs.AddressTyp, rs.HouseNo, rs.StreetNo, rs.Town, rs.Zip, rs.City, rs.State, rs.Country, rs.RemarksA, rs.DivisionID, rs.SiteID, rs.LoginID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===============Patient Contact Insert======================
        public void Add_Contactrecord(NewRegModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Reg_Contact", "@RegNo,@CNIC,@RegDate,@TypeID,@Tel,@EmailID,@Remarks,@DivisionID,@SiteID,@LoginID", rs.RegNo, rs.CNIC, rs.RegDate, rs.ContactType, rs.TeleNo, rs.Email, rs.RemarksC, rs.DivisionID, rs.SiteID, rs.LoginID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===============Patient Contact Insert======================
        public void Add_WContactrecord(NewRegModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Reg_Contact", "@RegNo,@CNIC,@RegDate,@TypeID,@Tel,@EmailID,@Remarks,@DivisionID,@SiteID,@LoginID", rs.RegNo, rs.CNIC, rs.RegDate, rs.ContactType, rs.TeleNo, rs.Email, rs.RemarksC, rs.DivisionID, rs.SiteID, rs.LoginID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===============Patient CNIC Insert======================
        public void Add_CNICDetail(NewRegModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_CNIC_Detail", "@CNIC,@CNICIsue,@CNICExp,@CNICIdent,@FamilyNo,@DivisionID,@SiteID,@LoginID", rs.CNIC, rs.CNICIssue, rs.CNICExp, rs.CNICIdentity, rs.FamilyNo, rs.DivisionID, rs.SiteID, rs.LoginID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========Display Address Type Data by Dropdown=============
        public DataSet get_Addressrecord()
            {
            try
            {
                ds = help.ReturnDataSetProcedure("Ud_Get_AddressType");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========Display Contact Type Data by Dropdown=============
        public DataSet get_Contactrecord()
        {
            try
            {
                ds = help.ReturnDataSetProcedure("Ud_Get_ContactType");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}