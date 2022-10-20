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
    public class Sitedb
    {
        string RtnJS;
        string Query;
        DataTable dt = new DataTable();
        DB_Helper help = new DB_Helper();

        //===========Insert Site Data============== 
        public void Add_record(SiteModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Site", "@ID,@Name,@Address,@Tel,@Mobile1,@Mobile2,@City,@Country,@Remarks,@Status,@LoginID,@DivisionID", rs.SiteCode, rs.SiteName, rs.Address, rs.Tel, rs.Mobile1, rs.Mobile2, rs.City, rs.Country, rs.Remarks, rs.InActive, rs.LoginID, rs.DivisionCode);
            }
            catch(Exception ex)
            {
                throw ex;
            }   
        }
        //=====================
        public string User_Access_List(string User)
        {
            try
            {
                dt = help.ReturnParameterizedDataTableProcedure("UD_Get_Site_Access", "@Username", User);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Login_Site_Detail(string ID)
        {
            try
            {
                Query = "SELECT * FROM VW_Login_Site_Detail WHERE SiteID = '" + ID + "' ORDER BY SiteName ASC";
                dt = help.Return_DataTable_Query(Query);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=================Display Dt Site Record===================   
        public DataSet get_record()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnDataSetProcedure("Sp_Site_get");
                return ds;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        //=================Update Site Record==================
        public void update_record(SiteModel rs)
        {
            try
            { 
            help.ExecuteParameterizedProcedure("UD_Add_Site", "@ID,@Name,@Address,@Tel,@Mobile1,@Mobile2,@City,@Country,@Remarks,@Status,@LoginID,@DivisionID", rs.SiteCode, rs.SiteName, rs.Address, rs.Tel, rs.Mobile1, rs.Mobile2, rs.City, rs.Country, rs.Remarks, rs.InActive, rs.LoginID, rs.DivisionCode);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        //=============Site Record get by Id=================
        public string get_recordbyid(SiteModel rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("Sp_Site_byid", "@ID", rs.SiteCode);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //==================Delete Site record================
        public void deletedata(SiteModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Delete_Site", "@Code", rs.SiteCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}