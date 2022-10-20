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
    public class AddVitalDb
    {
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();

        public void Add_record(AddVital rs)
        {
            help.ExecuteParameterizedProcedure("UD_Add_Vital_Setup", "@ID,@Name,@MinVal,@MaxVal,@DivisionID,@SiteID,@LoginID", rs.VitalID, rs.VitalName, rs.MinValue, rs.MaxValue, rs.DivisionID,rs.SiteID, rs.LoginID);
        }

        //===========Display All patient Data by lookup=============
        public DataSet get_record()
        {
            try
            {
                ds = help.ReturnDataSetProcedure("Sp_Vital_get");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //===============Vital Data Update=============
        public void update_record(AddVital rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Vital_Setup", "@ID,@Name,@MinVal,@MaxVal,@DivisionID,@SiteID,@LoginID", rs.VitalID, rs.VitalName, rs.MinValue, rs.MaxValue, rs.DivisionID, rs.SiteID, rs.LoginID);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        //=============Patient Get Data By ID=================
        public string get_recordbyid(AddVital rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("Sp_Vital_byid", "@ID", rs.id);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //============Delete Vitals===============
        public void deletedata(AddVital rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Delete_Vital", "@Code", rs.id);
            }
           catch(Exception ex)
            {
                throw ex;
            }
        }
        //===============Get Vital ID==============
        public DataSet Generate_Vital_ID()
        {
            try
            {
                ds = help.Return_DataSet_Query("SELECT VitalID FROM VW_Generate_Vital_ID");
                return ds;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}