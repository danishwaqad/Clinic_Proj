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
    public class DiagCategDb
    {
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        string RtnJS;
        //=============Header Data Insert=================
        public void Add_Headerecord(DiagCategMode rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Header_Setup", "@HeadID,@HeaderName,@InActive,@LoginID,@DivisionID,@SiteID", rs.HeaderID, rs.HeaderName, rs.InActive, rs.LoginID, rs.DivisionID, rs.SiteID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Header Data Insert=================
        public void Add_Diagrecord(DiagCategMode rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Disease2_Setup", "@HeadID,@DiagnoseID,@DiagnoseName,@Description,@InActive,@LoginID,@DivisionID,@SiteID", rs.HeaderID, rs.DiseaseID, rs.DiseaseName,rs.Description,rs.InActive2,rs.LoginID, rs.DivisionID, rs.SiteID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=======Display Header All Data By lookup=================
        public DataSet getHead_record()
        {
            try
            {
                ds = help.ReturnDataSetProcedure("Vw_Header_get");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=======Display Diagnose All Data By lookup=================
        public string getDis_record(DiagCategMode rs)
        {
            try
            {
                String Query = "Select * from Vw_Disease2_get Where HeaderID = '" + rs.ID + "'";
                dt = help.Return_DataTable_Query(Query);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Get Header ID================
        public DataSet Header_ID()
        {
            try
            {
                ds = help.ReturnDataSetProcedure("UD_Generate_Header_ID");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        
        //=============Get Diagnose ID================
        public DataSet Diagnose_ID()
        {
            try
            {
                ds = help.ReturnDataSetProcedure("UD_Generate_Disease_ID");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //============Header Data Get By ID============
        public string get_Headbyid(DiagCategMode rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Ud_Header_byId", "@ID", rs.ID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //============Diagnose Data Get By ID============
        public string get_Disbyid(DiagCategMode rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Ud_Disease_byId", "@ID", rs.ID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========Delete Header=============
        public void deleteHeaddata(DiagCategMode rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Delete_HeaderID", "@Code", rs.ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========Delete Diagnose=============
        public void deleteDisdata(DiagCategMode rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Delete_DiseaseID", "@Code", rs.ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetDiagnose2()
        {
            try
            {
                dt = help.Return_DataTable_Query("SELECT HeaderID, HeaderName FROM VW_Diagnose1_Data");
                string Rtn = JsonConvert.SerializeObject(dt);
                return Rtn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetDiagnose2Byid(DiagCategMode rs)
        {
            try
            {
                String Query = "SELECT DiseaseID, DiseaseName, Description, HeaderID, HeaderName FROM VW_Diagnose2_Data Where HeaderID = '" + rs.HeaderID + "'";
                dt = help.Return_DataTable_Query(Query);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}