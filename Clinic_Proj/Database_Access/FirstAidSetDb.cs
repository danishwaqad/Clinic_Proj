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
    public class FirstAidSetDb
    {
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();
        //===============Get First Aid ID==============
        public DataSet Generate_FirstAid_ID()
        {
            try
            {
                ds = help.ReturnDataSetProcedure("UD_Generate_FA_ID");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===================First Aid Insert==============
        public void Add_record(FirstAidSetup rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_FirstAid_Setup", "@Name,@Desc,@Fee,@ServiceType,@ChargeType,@TimeFrom,@TimeTo,@LoginID,@DivisionID,@SiteID,@CCPLID", rs.ServiceName, rs.ServiceDesc, rs.Charges, rs.ServiceType, rs.ChargeType, rs.TimeFrom, rs.TimeTo, rs.LoginID, rs.DivisionID,rs.SiteID,rs.CCPL_ROW_ID);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        //===========Display All Service Name By lookUp==============
        public DataSet get_record()
        {
            try
            {
                ds = help.Return_DataSet_Query("Select * from VW_Generate_FirstAid_ID ");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========Display All Service Name By lookUp==============
        public DataSet get_Lookuprecord()
        {
            try
            {
                ds = help.Return_DataSet_Query("Select * from FirstAidSetup");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet get_Serv_record()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnDataSetProcedure("Sp_Service_Typ_Setup");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==========Display Charge Type By Lookup==========
        public DataSet get_Char_record()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnDataSetProcedure("Sp_Charge_Type_Setup");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //============First Aid Update=============
        public void update_record(FirstAidSetup rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_FirstAid_Setup", "@Name,@Desc,@Fee,@ServiceType,@ChargeType,@TimeFrom,@TimeTo,@LoginID,@DivisionID,@SiteID,@CCPLID", rs.ServiceName, rs.ServiceDesc, rs.Charges, rs.ServiceType, rs.ChargeType, rs.TimeFrom, rs.TimeTo, rs.LoginID, rs.DivisionID, rs.SiteID, rs.CCPL_ROW_ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //============Get Service Name By ID===========
        public string get_recordbyid(FirstAidSetup rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("Sp_First_AidSet_byID", "@ID",rs.id);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Get Service Type By ID=============
        public string get_Serbyid(string id)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("Sp_Firs_Ser_byID", "@ID", id);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==========Get Charge Type By ID====================
        public string get_Charbyid(string id)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("Sp_Firs_Char_byID", "@ID", id);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==========First Aid Delete============
        public void deletedata(FirstAidSetup rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Delete_Patient_FirstAddSet", "@Code",rs.id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}