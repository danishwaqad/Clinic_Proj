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
    public class TokenGenerateDb
    {
        string RtnJS;
        string Query;
        DataTable dt = new DataTable();
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();
        //Update Record
        //==========Display All Today Token Patient Related lookup Data================
        public string get_TodyTknrecord(TokenGenerateMode rs)
        {
            try
            {
                dt = new DataTable();
                Query = "SELECT * FROM VW_Today_Token_Lookup where SiteID = '" + rs.SiteID + "'";
                dt = help.Return_DataTable_Query(Query);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Today Token Data Get Data By id=================
        public string get_Tknrecordbyid(TokenGenerateMode rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("UD_Today_Token_byid", "@Token", rs.TokenNo);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //================Delete Today Token Data=============================
        public void deletedata_Todaytkn(TokenGenerateMode rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("Ud_TokenDelete_AndBackup", "@TokenNo,@Upd_Remarks,@SiteID", rs.TokenNo, rs.TokenDel_Remarks, rs.SiteID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //================Delete Today Token Get Back Data=============================
        public void deletedata_TodaytknBack(TokenGenerateMode rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("Ud_TokenDelete_AndBackup2", "@TokenNo,@Upd_Remarks,@SiteID", rs.TokenNo, rs.TokenDel_Remarks, rs.SiteID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===============Update CNIC Register======================
        public void Update_Record(TokenGenerateMode rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Update_Cnic_Register", "@RegNo,@CNIC,@RegDate,@DOB,@Title,@FName,@MName,@LName,@Guardian,@CNICIssue,@CNICExp,@Gender,@ReferBy,@Remarks,@CNICIdentity,@FamilyNo,@AddressTyp,@HouseNo,@Town,@StreetNo,@City,@State,@Country,@Zip,@RemarksA,@ContactType,@TeleNo,@Email,@RemarksC,@DivisionID,@SiteID,@LoginID", rs.RegNo, rs.CNIC, rs.RegDate, rs.DOB, rs.Title, rs.FirstName, rs.MidName, rs.LastName, rs.Guardian, rs.CNICIssue, rs.CNICExp, rs.Gender, rs.ReferBy, rs.Remarks, rs.CNICIdentity, rs.FamilyNo, rs.AddressTyp, rs.HouseNo, rs.Town, rs.StreetNo, rs.City, rs.State, rs.Country, rs.Zip, rs.RemarksA, rs.ContactType, rs.TeleNo, rs.Email, rs.RemarksC, rs.DivisionID, rs.SiteID, rs.LoginID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========Get Patient Data By CNIC IF Already Available===========
        public string get_PatAvail(TokenGenerateMode rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("UD_Check_Upd_Patient_List", "@CNIC", rs.CNIC);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}