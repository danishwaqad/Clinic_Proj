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
    public class DocMediDb
    {
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        //=============Get Diagnose ID================
        public DataSet Diagnose_ID()
        {
            try
            {
                ds = help.ReturnDataSetProcedure("UD_Generate_DocGroup1_ID");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Header Data Insert=================
        public void Add_DiagRecord(DocMediMode rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Group1_Setup", "@GroupID,@GroupName,@DoctorID,@DoctorName,@Remarks,@InActive,@LoginID", rs.GroupID, rs.GroupName, rs.DoctorID, rs.DoctorName, rs.Remarks,rs.InActive, rs.LoginID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Display Diagnose Data By Lookup===================
        public string getDiage_record(DocMediMode rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("UD_Diagnose_By_Doctor", "@DivisionID,@SiteID,@LoginID", rs.DivisionID, rs.SiteID,rs.LoginID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Display Group 1 Data By Lookup===================
        public string getGroup1_record(DocMediMode rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("UD_Group1_By_DoctorLogin", "@LoginID",rs.LoginID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //============Delete Group 1 Data================
        public void dele_Group1_data(DocMediMode rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Delete_Group1_ByID", "@Code,@LoginID", rs.GroupID, rs.LoginID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Get Group 1 Data By ID============
        public string get_Group1_byid(DocMediMode rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("UD_Group1_By_Doctor", "@GroupID,@LoginID", rs.GroupID, rs.LoginID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========get ID and Name By User=============
        public string get_ID_ByUser_Record(string User)
        {
            try
            {
                User = SystemHelper.Get_User_Session();
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("UD_Get_ID_byUser", "@ID", User);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==========================Consultancy Start==============
        //================Insert Medication==============
        public void Add_Medicate(DocMediMode rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Group2_Medication", "@ItemName,@RefGroupID,@RefGroupName,@TypeID,@SubTypeID,@IsMorning," +
                "@IsEvening,@IsNight,@Dosage,@Days, @UrduText, @Remarks, @LoginID",rs.GenericName, rs.RefGroupID,rs.RefGroupName,rs.TypeID, rs.SubTypeID, rs.IsMorning, rs.IsEvening, rs.IsNight, rs.DosageQty,rs.NoOfDays, rs.UrduText, rs.MediRemarks,rs.LoginID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //============Display Medication View All Data==============
        public string getmed_Viewrecord(DocMediMode rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Sp_ViewGroup2_Medi_ByDiagid", "@DiagNoseID,@DiagnoseName,@loginID", rs.RefGroupID, rs.RefGroupName, rs.LoginID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============For Delete Medication==================
        public void deleteMeddata(DocMediMode rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Delete_Medication_FromGroup2", "@Code,@LoginID", rs.id, rs.LoginID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==========================Consultancy End================
    }
}