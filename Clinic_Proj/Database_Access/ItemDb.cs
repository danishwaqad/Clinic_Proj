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
    public class ItemDb
    {
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();
        string RtnJS;
        DataTable dt = new DataTable();
        //===========Display All Item Data by lookup=============
        public string get_Itemrecord(ItemModel rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("Sp_Item_get", "@SiteID,@Division",rs.SiteID,rs.DivisionID) ;
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Item Get Data By ID=================
        public string get_Itemrecordbyid(ItemModel rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("Sp_Item_byid", "@ID,@SiteID,@Division", rs.id,rs.SiteID, rs.DivisionID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===============Get Item Code==============
        public string Generate_Item_Code(ItemModel rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("UD_Generate_Item_Code", "@SiteID,@Division",rs.SiteID, rs.DivisionID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Get_RO(string id)
        {
            try
            {
                dt = help.ReturnParameterizedDataTableProcedure("UD_RO_Detail_By_Item", "@ItemCode", id.Trim());
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=========Generate Ro By Code==============
        public string Get_ROByid(string ItemCode)
        {
            try
            {
                dt = help.ReturnParameterizedDataTableProcedure("UD_Item_ROByID", "@ItemCode", ItemCode.Trim());
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Add_RO_Config(ItemModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_RO_Config", "@ItemCode,@ROLevelVal,@OrderQty,@SiteID,@Division,@LoginID", rs.ItemCode, rs.ROLevelValue, rs.OrderQty, rs.SiteID,rs.DivisionID,rs.LoginID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //========Add Product==========
        public void Add_Product(ItemModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Item", "@ItemCode,@ItemName,@TypeID,@SubTypeID,@IsExpiry,@IsBack,@UOM,@Manufacturer,@UnitsInPack,@Description,@InActive,@Remarks,@LoginID,@DivisionID,@SiteID", rs.ItemCode,rs.ItemName,rs.TypeName,rs.SubTypeName,rs.IsExpiry,rs.IsAutoBack,rs.UOM,rs.Manufacturer,rs.UnitsInPack,rs.Description,rs.Status,rs.Remarks,rs.LoginID,rs.DivisionID,rs.SiteID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //========Update Product==========
        public void Update_Product(ItemModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Item", "@ItemCode,@ItemName,@TypeID,@SubTypeID,@IsExpiry,@IsBack,@UOM,@Manufacturer,@UnitsInPack,@Description,@InActive,@Remarks,@LoginID,@DivisionID,@SiteID", rs.ItemCode, rs.ItemName, rs.TypeName, rs.SubTypeName, rs.IsExpiry,rs.IsAutoBack, rs.UOM, rs.Manufacturer, rs.UnitsInPack, rs.Description, rs.Status, rs.Remarks, rs.LoginID, rs.DivisionID, rs.SiteID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //============Delete Item===============
        public void deletedata(ItemModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Delete_Item", "@Code,@DivisionID,@SiteID", rs.ItemCode,rs.DivisionID, rs.SiteID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}