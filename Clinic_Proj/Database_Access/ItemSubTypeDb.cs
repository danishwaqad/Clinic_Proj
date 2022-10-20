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
    public class ItemSubTypeDb
    {
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();
        public void Add_record(ItemSubTypModel rs)
        {
            help.ExecuteParameterizedProcedure("UD_ItemSubType_Setup", "@ID,@SubTypName,@TypeName,@Status,@DivisionID,@SiteID,@LoginID", rs.SubTypeID, rs.SubTypeName,rs.TypeName, rs.Status, rs.DivisionID, rs.SiteID, rs.LoginID);
        }

        //===========Display All Item Sub Type Data by lookup=============
        public DataSet get_record()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnDataSetProcedure("Sp_SubItemType_get");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========Display All Item Type Data by lookup=============
        public DataSet get_Typrecord()
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
        //===============Item Sub Data Update=============
        public void update_record(ItemSubTypModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_ItemSubType_Setup", "@ID,@SubTypName,@TypeName,@Status,@DivisionID,@SiteID,@LoginID", rs.SubTypeID, rs.SubTypeName, rs.TypeName, rs.Status, rs.DivisionID, rs.SiteID, rs.LoginID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Item Sub Type Get Data By ID=================
        public string get_recordbyid(string id)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("Sp_SubItemType_byid", "@ID", id);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Item Type Get Data By ID=================
        public string get_Typrecordbyid(string id)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("Sp_ItemType_byNam", "@ID", id);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //============Delete Item Sub Type===============
        public void deletedata(int id)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Delete_ItemSubType", "@Code", id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===============Get Item Sub Type ID==============
        public DataSet Generate_ItemType_ID()
        {
            try
            {
                ds = help.Return_DataSet_Query("select ItemSubTypeID from VW_Generate_ItemSubType_ID");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}