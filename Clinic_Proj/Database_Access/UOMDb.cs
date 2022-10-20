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
    public class UOMDb
    {
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();

        public void Add_record(UOMModel rs)
        {
            help.ExecuteParameterizedProcedure("UD_UOM_Insert", "@ID,@Name,@Short_val,@Status,@DivisionID,@SiteID,@LoginID", rs.UOM_ID, rs.UOM,rs.Shor_Val, rs.Status, rs.DivisionID, rs.SiteID, rs.LoginID);
        }

        //===========Display All Item UOM Data by lookup=============
        public DataSet get_record()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnDataSetProcedure("Sp_UOM_get");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //===============UOM Update=============
        public void update_record(UOMModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_UOM_Insert", "@ID,@Name,@Short_val,@Status,@DivisionID,@SiteID,@LoginID", rs.UOM_ID, rs.UOM, rs.Shor_Val, rs.Status, rs.DivisionID, rs.SiteID, rs.LoginID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============UOM Get Data By ID=================
        public string get_recordbyid(string id)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("Sp_UOM_byid", "@ID", id);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //============Delete UOM===============
        public void deletedata(int id)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Delete_UOM", "@Code", id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===============Get UOM ID==============
        public DataSet Generate_UOM_ID()
        {
            try
            {
                ds = help.Return_DataSet_Query("select UOM_ID from VW_Generate_UOM_ID");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}