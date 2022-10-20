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
    public class PatVitalDb
    {
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        string Query;
        string RtnJS;

        //=============Insert Vital Data=======================
        public void Add_record(PatientVitalMode rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Patient_Vital", "@TokenNo,@VitalName,@VitalVal,@LoginID,@DivisionID,@SiteID", rs.TokenNo, rs.VitalName, rs.VitalValue,rs.LoginID, rs.DivisionID,rs.SiteID);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        //===============Display All Data By Token Lookup=====================
        public string get_record(PatientVitalMode rs)
        {
            try
            {
                Query = "Select * from VW_Patient_Vital_get where SiteID= '" + rs.SiteID + "' and DivisionID='" + rs.DivisionID + "' ORDER BY  CCPL_ROW_ID desc";
                dt = help.Return_DataTable_Query(Query);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=================Display View All Vital Data===================
        public string get_Viewrecord(PatientVitalMode rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Sp_Patient_View_Vital_get", "@TokenNo,@DivisionID,@SiteID", rs.TokenNo, rs.DivisionID, rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===============Update Vital Data==========================
        public void update_record(PatientVitalMode rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Patient_Vital", "@TokenNo,@VitalName,@VitalVal,@LoginID,@DivisionID,@SiteID", rs.TokenNo, rs.VitalName, rs.VitalValue, rs.LoginID, rs.DivisionID, rs.SiteID);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        //=============Patient Data Get By ID==========================
        public string get_recordbyid(PatientVitalMode rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Sp_Patient_Vital_byTken", "@ID,@DivisionID,@SiteID", rs.TokenNo,rs.DivisionID,rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===================View Vital Data Get By ID==========================
        public string get_Viewrecordbyid(PatientVitalMode rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Sp_ViewPatient_Vital_byTken", "@ID,@DivisionID,@SiteID", rs.id,rs.DivisionID,rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //==================Delete Vital Name And Value===============
        public void deletedata(PatientVitalMode rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Delete_Patient_Vital", "@Code,@VitalName,@DivisionID,@SiteID", rs.TokenNo, rs.VitalName, rs.DivisionID, rs.SiteID);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        //=======================Get Vital List===============
        public DataSet get_PatVital()
        {
            try
            {
                ds = help.ReturnDataSetProcedure("UD_patiVital_Name");
                return ds;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}