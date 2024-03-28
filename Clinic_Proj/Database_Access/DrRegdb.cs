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
    public class DrRegdb
    {
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();
        //==================Insert Dr Data=======================
        public void Add_record(DoctorRegisterModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Doctor", "@DoctorID,@Type,@Name,@FName,@CNIC,@Tel1,@Tel2,@EmailID,@Address,@City,@Country,@Gender,@DOB,@Desc,@Remarks,@Designation,@DivisionID,@SiteID,@Status,@LoginID,@Shift,@Fee,@UserName,@Pass,@Sharepercent,@Home_Consultancy,@Education", rs.DoctorID, rs.DoctorType, rs.DoctorName, rs.DrFName, rs.CNIC, rs.Tel1, rs.Tel2, rs.EmailID, rs.Address, rs.City, rs.Country, rs.Gender, rs.DOB, rs.Description, rs.Remarks, rs.ReferBy, rs.DivisionID, rs.SiteID, rs.Status, rs.LoginID, rs.DrShift, rs.Charges, rs.UserName, rs.Pass, rs.SharePercent, rs.HomeStatus,rs.Education);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=================Display View All Doctor Share Data===================
        public string get_ShareViewrecord(DoctorRegisterModel rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Sp_View_DoctorShare_get", "@DoctorID,@SiteID", rs.DoctorID,rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===================View Share Doctor Data Get By ID==========================
        public string get_ViewShareRecrdbyid(DoctorRegisterModel rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Sp_View_DoctorShareByID_get", "@DoctorID,@ShareType,@SiteID", rs.DoctorID,rs.ShareType,rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========Delete Doctor Share==============
        public void OnShareDelete(DoctorRegisterModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Delete_DoctorShare", "@DoctorID,@ShareType,@SiteID", rs.DoctorID, rs.ShareType, rs.SiteID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==================Insert Dr Share=======================
        public void Add_shareRecord(DoctorRegisterModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_DoctorShare", "@DoctorID,@DoctorType,@Name,@Sharepercent,@ShareType,@InActive,@SiteID,@LoginID",rs.DoctorID,rs.DoctorType,rs.DoctorName,rs.SharePercent,rs.ShareType,rs.InActive,rs.SiteID,rs.LoginID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Display Doctor Data By LookUp=================
        public string get_record(DoctorRegisterModel rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Sp_Dr_get", "@DivisionID,@SiteID", rs.DivisionID, rs.SiteCode);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //================Update Dr Data==============================
        public void update_record(DoctorRegisterModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Doctor", "@DoctorID,@Type,@Name,@FName,@CNIC,@Tel1,@Tel2,@EmailID,@Address,@City,@Country,@Gender,@DOB,@Desc,@Remarks,@Designation,@DivisionID,@SiteID,@LoginID,@Status,@Shift,@Fee,@UserName,@Pass,@Sharepercent,@Home_Consultancy,@Education", rs.DoctorID, rs.DoctorType, rs.DoctorName, rs.DrFName, rs.CNIC, rs.Tel1, rs.Tel2, rs.EmailID, rs.Address, rs.City, rs.Country, rs.Gender, rs.DOB, rs.Description, rs.Remarks, rs.ReferBy, rs.DivisionID, rs.SiteID, rs.LoginID, rs.Status, rs.DrShift, rs.Charges, rs.UserName, rs.Pass, rs.SharePercent, rs.HomeStatus,rs.Education);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Doctor Data Get By ID=========================
        public string get_recordbyid(DoctorRegisterModel rs)
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
        //===============Get Dr shift LookUp Data=====================
        public DataSet get_DrShift()
        {
            try
            {
                ds = help.ReturnDataSetProcedure("Sp_Dr_Shift");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===============Get Dr Share LookUp Data=====================
        public DataSet get_DrShare()
        {
            try
            {
                ds = help.ReturnDataSetProcedure("Sp_Dr_Share");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==================Display Dr Type Data By lookup==================
        public DataSet get_DrType()
        {
            try
            {
                ds = help.ReturnDataSetProcedure("Sp_Dr_Type");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //================Delete Doctor=============================
        public void deletedata(DoctorRegisterModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Delete_Dr", "@Code,@DivisionID,@SiteID", rs.DoctorID, rs.DivisionID, rs.SiteID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===================Auto Get Dr ID============================
        public DataSet Generate_Doctor_ID()
        {
            try
            {
                ds = help.ReturnDataSetProcedure("UD_Generate_Doctor_ID");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}