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
    public class DiagnosesDb
    {
    DB_Helper help = new DB_Helper();
    DataSet ds = new DataSet();
        DataTable dt = new DataTable();
    //=============Diagnose Data Insert=================
    public void Add_record(DiagnosesModel rs)
    {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Diagnoses_Setup", "@RowID,@ShortName,@LongName,@LoginID,@DivisionID,@SiteID", rs.ID, rs.ShortName, rs.LongName, rs.LoginID, rs.DivisionID, rs.SiteID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    //=======Display Diagnose All Data By lookup=================
    public DataSet get_record()
    {
            try
            {
                ds = help.ReturnDataSetProcedure("Sp_Diagnoses_get");
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
                ds = help.ReturnDataSetProcedure("UD_Generate_Diagnose_ID");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==========Diagnose Update===========
        public void update_record(DiagnosesModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Diagnoses_Setup", "@RowID,@ShortName,@LongName,@LoginID,@DivisionID,@SiteID", rs.ID, rs.ShortName, rs.LongName, rs.LoginID, rs.DivisionID, rs.SiteID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //============Diagnose Data Get By ID============
        public string get_recordbyid(DiagnosesModel rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Sp_DiagnosesbyId", "@ID", rs.ID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========Delete Diagnose=============
        public void deletedata(DiagnosesModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Delete_Diagnoses", "@Code", rs.ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=======================Diagnose Level=======================
        //===================Auto Get Node ID============================
        public string Generate_Node_ID()
        {
            try
            {
                dt = help.Return_DataTable_Query("SELECT NodeID FROM VW_Get_New_NodeID_DiseaseLevel");
                string Rtn = JsonConvert.SerializeObject(dt);
                return Rtn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===================Auto Get Node ID============================
        public string Get_Parent_List()
        {
            try
            {
                dt = help.Return_DataTable_Query("SELECT * FROM VW_Disease_Parent_List");
                string Rtn = JsonConvert.SerializeObject(dt);

                return Rtn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===================Auto Get Child ID============================
        public string Get_Child_List(DiagnosesModel rs)
        {
            try
            {
                dt = help.Return_DataTable_Query("SELECT * FROM VW_Disease_Child_List where ParentID = " + rs.ParentID + "");
                string Rtn = JsonConvert.SerializeObject(dt);

                return Rtn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //============Diagnose Disease Data Get By ID============
        public string get_Diseaserecordbyid(DiagnosesModel rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("UD_Inputto_TextBoxes", "@NodeID", rs.NodeID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Diagnose Level Data Insert=================
        public void AddNode_record(DiagnosesModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_DiseaseLevel", "@NodeID,@ParentID,@Title,@Description,@InActive,@LoginID", rs.NodeID, rs.ParentID, rs.ICDCode, rs.ICDName, rs.InActive, rs.LoginID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========Delete Node=============
        public void delete_Nodedata(DiagnosesModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Delete_DiseaseNode", "@Code", rs.NodeID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}