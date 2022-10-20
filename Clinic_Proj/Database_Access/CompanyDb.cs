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
    public class CompanyDb
    {
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();
        //==================Insert Company Data=======================
        public void Add_record(CompanyMode rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Company", "@CompanyID,@CompanyName,@ContactPerson,@CNIC,@Mobile1,@Mobile2,@NTN,@Address,@City,@Country,@STRN,@Remarks,@BusinessType,@Tel,@InActive,@ClassID,@ClassName,@LoginID", rs.CompanyID, rs.CompanyName, rs.ContactPerson, rs.CNIC, rs.Mobile1, rs.Mobile2, rs.NTN, rs.Address, rs.City,rs.Country, rs.STRN, rs.Remarks,rs.BusinessType,rs.Tel, rs.Status,rs.ClassID,rs.ClassName,rs.LoginID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //=============Display Company Data By LookUp=================
        public DataSet get_record()
        {
            try
            {
                ds = help.ReturnDataSetProcedure("UD_Company_get");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Display Class Data By LookUp=================
        public DataSet get_Classrecord()
        {
            try
            {
                ds = help.ReturnDataSetProcedure("UD_Class_get");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //================Update Dr Data==============================
        public void update_record(CompanyMode rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Company", "@CompanyID,@CompanyName,@ContactPerson,@CNIC,@Mobile1,@Mobile2,@NTN,@Address,@City,@Country,@STRN,@Remarks,@BusinessType,@Tel,@InActive,@ClassID,@ClassName,@LoginID", rs.CompanyID, rs.CompanyName, rs.ContactPerson, rs.CNIC, rs.Mobile1, rs.Mobile2, rs.NTN, rs.Address, rs.City, rs.Country, rs.STRN, rs.Remarks,rs.BusinessType,rs.Tel, rs.Status, rs.ClassID, rs.ClassName, rs.LoginID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Company Data Get By ID=========================
        public string get_recordbyid(CompanyMode rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Ud_Company_byid", "@ID", rs.CompanyID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //================Delete Company=============================
        public void deletedata(CompanyMode rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Delete_Company", "@Code", rs.CompanyID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===================Auto Get Company ID============================
        public DataSet Generate_Company_ID()
        {
            try
            {
                ds = help.ReturnDataSetProcedure("UD_Generate_Company_ID");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}