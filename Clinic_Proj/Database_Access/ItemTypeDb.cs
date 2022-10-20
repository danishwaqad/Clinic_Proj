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
    public class ItemTypeDb
    {
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();

        public void Add_record(ItemTypeModel rs)
        {
            help.ExecuteParameterizedProcedure("UD_ItemType_Setup", "@ID,@Name,@Status,@DivisionID,@SiteID,@LoginID", rs.TypeID, rs.TypeName, rs.Status, rs.DivisionID, rs.SiteID, rs.LoginID);
        }

        //===========Display All Item Type Data by lookup=============
        public DataSet get_record()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnDataSetProcedure("Sp_ItemType_get");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //===============Item Data Update=============
        public void update_record(ItemTypeModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_ItemType_Setup", "@ID,@Name,@Status,@DivisionID,@SiteID,@LoginID",rs.TypeID,rs.TypeName, rs.Status, rs.DivisionID, rs.SiteID, rs.LoginID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Item Type Get Data By ID=================
        public string get_recordbyid(string id)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("Sp_ItemType_byid", "@ID", id);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //============Delete Item Type===============
        public void deletedata(int id)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Delete_ItemType", "@Code", id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===============Get Item Type ID==============
        public DataSet Generate_ItemType_ID()
        {
            try
            {
                ds = help.Return_DataSet_Query("select ItemTypeID from VW_Generate_ItemType_ID");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}