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
    public class FirstAddDb
    {
        string Query;
        string RtnJS;
        DataTable dt = new DataTable();
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();

        //=============Insert Service Data=================
        public void Add_record(FirstAddModal rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Patient_FA_Service", "@TokenNo,@Mode,@Service,@Fee,@Paid,@Balance,@Remarks,@DivisionID,@SiteID,@LoginID", rs.TokenNo, rs.Mode, rs.ServiceName, rs.Fee, rs.Paid, rs.Balance, rs.Remarks, rs.DivisionID, rs.SiteID, rs.LoginID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========Insert Data For In And Out=================
        public void AddInOutRecrd(FirstAddModal rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Patient_FA_Check", "@TokenNo,@Mode,@Remarks,@LoginID,@DivisionID,@SiteID", rs.TokenNo, rs.Mode, rs.Remarks, rs.LoginID, rs.DivisionID, rs.SiteID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========Insert Data For Service Header=================
        //public void AddFaHeadRecrd(FirstAddModal rs)
        //{
        //    try
        //    {
        //        help.ExecuteParameterizedProcedure("UD_Add_Patient_FA_Header", "@TokenNo,@TotalAmount,@Remarks,@DivisionID,@SiteID,@LoginID", rs.TokenNo, rs.TotalAmount, rs.Remarks, rs.DivisionID, rs.SiteID, rs.LoginID);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //========Display Recomendation View All Data==============
        public string getRec_Viewrecord(FirstAddModal rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("Sp_RecViewTreatmnt", "@TokenNo,@DivisionID,@SiteID", rs.TokenNo, rs.DivisionID,rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //============Recomendation Delete=====================
        public void deleRecdata(FirstAddModal rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Delete_Treatmnt", "@Code,@DivisionID,@SiteID", rs.id,rs.DivisionID,rs.SiteID);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        //==========View Service All Data==============
        public string get_Viewrecord(FirstAddModal rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("Sp_ViewFrstAid_bySamTken", "@TokenNo,@DivisionID,@SiteID",rs.TokenNo,rs.DivisionID,rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Display Patient Look up Data===================
        public string get_record(FirstAddModal rs)
        {
            try
            {
                dt = new DataTable();
                Query = "Select * from VW_Patient_FirstAId_get where SiteID= '" + rs.SiteID + "' and DivisionID='" + rs.DivisionID + "' ORDER BY CCPL_ROW_ID desc";
                dt = help.Return_DataTable_Query(Query);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========Display All Services By lookup============
        public DataSet get_Servrecord()
        {
            try
            {
                ds = help.ReturnDataSetProcedure("Sp_First_Aid_Services");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Get Service Name By ID============
        public string get_Servrecordbyid(FirstAddModal rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Sp_First_AidSet_byID", "@ID", rs.id);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Get FA Check List============
        public string get_FArecordbyid(FirstAddModal rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("FAList_byID", "@ID,@DivisionID,@SiteID", rs.TokenNo, rs.DivisionID, rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==================Check Service Before Out Command=======================
        public string get_FACheckBefOut(FirstAddModal rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("UD_FAList_byID", "@ID,@DivisionID,@SiteID", rs.TokenNo, rs.DivisionID, rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Get Charges Total By ID============
        public string get_ChargesByID(FirstAddModal rs)
        {
            try
            {
                dt = new DataTable();
                Query = "select * from VW_TotalFirstAid_Services where TokenNo = '" + rs.TokenNo + "' and SiteID = '"+ rs.SiteID + "' and DivisionID = '" + rs.DivisionID + "' ORDER BY TokenNo";
                dt = help.Return_DataTable_Query(Query);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Update Record
        //public void update_record(FirstAddModal rs)

        //{
        //    help.ExecuteParameterizedProcedure("UD_Add_Patient_FA_Service", "@TokenNo,@Mode,@Service,@Fee,@Paid,@Balance,@Remarks,@LoginID,@DivisionID,@SiteID", rs.TokenNo, rs.Mode, rs.Service, rs.Fee, rs.Paid, rs.Balance, rs.Remarks, rs.LoginID, rs.DivisionID, rs.SiteID);
        //}
        //=============Display Patient Data Get By ID================
        public string get_recordbyid(FirstAddModal rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("Sp_Patient_Data_byTken", "@ID,@DivisionID,@SiteID", rs.TokenNo,rs.DivisionID,rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Mode Data Get By ID==========
        public string get_Modebyid(FirstAddModal rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("Ud_Check_Mode", "@ID,@DivisionID,@SiteID",rs.TokenNo,rs.DivisionID,rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //===============Delete First Aid Services==============
        public void deletedata(FirstAddModal rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Delete_first_Aid", "@Code,@Token,@DivisionID,@SiteID",rs.id,rs.TokenNo,rs.DivisionID,rs.SiteID);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}