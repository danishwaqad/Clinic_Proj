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
    public class ConsultDb
    {
        string RtnJS;
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        string Query;

        //============Display Service Name By Lookup===============
        public string get_Servrecordbyid(ConsultModel rs)
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
        public string GetDiagnose2()
        {
            try
            {
                dt = help.Return_DataTable_Query("SELECT HeaderID, HeaderName FROM VW_Diagnose1_Data");
                string Rtn = JsonConvert.SerializeObject(dt);
                return Rtn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Get Enable Disable Medi Button Data===============
        public string GetEnable_record(ConsultModel rs)
        {
            try
            {
                dt = help.Return_DataTable_Query("SELECT * FROM Vw_CheckConsultnBtn_Rights Where Username = '" + rs.LoginID + "'");
                string Rtn = JsonConvert.SerializeObject(dt);
                return Rtn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetDiagnose2Byid(ConsultModel rs)
        {
            try
            {
                String Query = "SELECT DiseaseID, DiseaseName, Description, HeaderID, HeaderName FROM VW_Diagnose2_Data Where HeaderID = '" + rs.HeaderID + "'";
                dt = help.Return_DataTable_Query(Query);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===============Session Working========================
        //===================Display Session View All Data===================
        public string get_SessionViewrecord(ConsultModel rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("VW_ViewPatient_Session", "@TokenNo,@DivisionID,@SiteID", rs.TokenNo, rs.DivisionID, rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===================Display History Session View All Data===================
        public string get_SessionHistViewrecord(ConsultModel rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("VWNew_ViewPatient_Session", "@TokenNo,@DivisionID,@SiteID", rs.TokenNo, rs.DivisionID, rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===================Display Session Activity View All Data===================
        public string get_SessionActrecord(ConsultModel rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Vw_ViewPatient_SessionAct", "@TokenNo,@DivisionID,@SiteID", rs.TokenNo, rs.DivisionID, rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Display Session Activity Lookup===================
        public string getSA_record(ConsultModel rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("SpNew_Session_Pat_All", "@DivisionID,@SiteID", rs.DivisionID, rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==================Session Data Insert==================
        public void Add_Sessionrecord(ConsultModel rs)
        {
            try
            {
                //string Session;
                ////double d1 = (-1 * ((rs.DateFrom - rs.DateTo).TotalDays)) + 1;
                //for (int i = 1, j = 0; i < rs.NoOfSession + 1; i++, j++)
                //{
                //    DateTime AddDate = rs.DateFrom.AddDays(j);
                //    Session = string.Concat(rs.TokenNo, "-S", i);
                help.ExecuteParameterizedProcedure("UD_Add_Patient_Session1", "@TokenNo,@Remarks,@FromDate,@ToDate,@NoOfSession,@LoginID,@DivisionID,@SiteID", rs.TokenNo, rs.SessionRemarks, rs.DateFrom, rs.DateTo, rs.NoOfSession, rs.LoginID, rs.DivisionID, rs.SiteID);
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==================Session Activity Data Insert==================
        public void Add_ActSessionrecord(ConsultModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Patient_SessionActivity", "@TokenNo,@SessionActivity,@SessionRemarks,@LoginID,@DivisionID,@SiteID", rs.TokenNo, rs.SessionActivity, rs.SessionActRemarks, rs.LoginID, rs.DivisionID, rs.SiteID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Session Data Delete============== 
        public void deleteSessiondata(ConsultModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Delete_Session1", "@Code,@DivisionID,@SiteID", rs.TokenNo, rs.DivisionID, rs.SiteID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Session Act Data Delete============== 
        public void deleteSessionActdata(ConsultModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Delete_SessionAct1", "@Code,@DivisionID,@SiteID", rs.TokenNo, rs.DivisionID, rs.SiteID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=================================Session End================================
        //===============Display Genric Related Data in Medication With API==============
        public DataTable GetPath()
        {
            try
            {
                //string Query = @"SELECT * from VW_RootAPI";
                string Query = @"SELECT * from VW_RootAPI";
                DataSet dataSet = help.Return_DataSet_Query(Query);
                dt = dataSet.Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===============Display Stock Related Data in Medication With API==============
        public DataTable GetStockPath()
        {
            try
            {
                //string Query = @"SELECT * from VW_RootAPI";
                string Query = @"SELECT * from VW_Top_1_Active_API";
                DataSet dataSet = help.Return_DataSet_Query(Query);
                dt = dataSet.Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //========Display Medication By token  View API All Data=================
        public string get_PharmaMeditknecord(ConsultModel rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("UD_Get_Token_Medicine_List_ForPharmacy", "@TokenNo,@DivisionID,@SiteID", rs.TokenNo, rs.DivisionID, rs.SiteID);
                string RtnJS = JsonConvert.SerializeObject(ds.Tables[0]);
                return RtnJS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==========Display All Service Name Or Treatement==============
        //public string get_Servrecord(ConsultModel rs)
        //{
        //    try
        //    {
        //        ds = help.ReturnParameterizedDataSetProcedure("Sp_Patient_TRT_get", "@DivisionID,@SiteID", rs.DivisionID, rs.SiteID);
        //        return (JsonConvert.SerializeObject(ds.Tables[0]));
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
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
        //=========Display Medicine Type Related Data================= 
        public DataSet get_MediTyprecord()
        {
            try
            {
                ds = help.ReturnDataSetProcedure("Sp_Patient_MediTyp_get");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=====================After Enter Days then its count days In Urdu text=================
        public string get_Dsogerecord(double urducnt)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("SP_Dosage_Urdu_Number", "@UrduCnt", urducnt);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //============Display Medicine Sub Type Related Data=============== 
        public string get_MediSbTyprecord(string id)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Sp_Patient_MediSubTyp_get", "@TypeID", id);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========Get SubType For Enable Disable TextBoxes============== 
        public string get_MediSbTypEnbRecord(ConsultModel rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Ud_For_Check_Norml_Medi", "@SubTypeID", rs.SubTypeID);
                string RtnJS = JsonConvert.SerializeObject(ds.Tables[0]);
                return RtnJS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========Get SubType For Enable Urdu TextBoxes============== 
        public string get_MediSbUrduEnbRecord(ConsultModel rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Ud_For_Check_Current_Medi", "@SubTypeID", rs.SubTypeID);
                string RtnJS = JsonConvert.SerializeObject(ds.Tables[0]);
                return RtnJS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //======Display Treatment or Service View All Data===============
        public string getSer_Viewrecord(ConsultModel rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Sp_ViewTreatment_bySamTken", "@TokenNo,@DivisionID,@SiteID", rs.TokenNo, rs.DivisionID, rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===============Insert Treatment============
        public void AddServ_record(ConsultModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Patient_Treatment", "@TokenNo,@Service,@Remarks,@LoginID,@DivisionID,@SiteID", rs.TokenNo, rs.ServiceName, rs.TrtRemarks, rs.LoginID, rs.DivisionID, rs.SiteID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //================Diagnose Data Insert=========================
        public void Add_record(ConsultModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Patient_Diagnoses", "@TokenNo,@DiagnoseName,@Remarks,@LoginID,@DivisionID,@SiteID", rs.TokenNo, rs.DisagnoseSName, rs.DiagRemarks, rs.LoginID, rs.DivisionID, rs.SiteID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==================Next Token===================
        public void Add_Queue_record(ConsultModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Token_Queue", "@TokenNo,@LoginID,@DivisionID,@SiteID,@DrId", rs.TokenNo, rs.LoginID, rs.DivisionID, rs.SiteID, rs.DoctorID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //================Insert Medication==============
        public void Add_Medicate(ConsultModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Patient_Medication", "@TokenNo,@GenericName,@TypeID,@SubTypeID,@IsMorning,@IsEvening,@IsNight,@Days,@Dosage,@UrduText,@Remarks,@DivisionID,@SiteID,@LoginID", rs.TokenNo, rs.GenericName, rs.TypeID, rs.SubTypeID, rs.IsMorning, rs.IsEvening, rs.IsNight, rs.NoOfDays, rs.DosageQty, rs.UrduText, rs.MediRemarks, rs.DivisionID, rs.SiteID, rs.LoginID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //============Display Medication View All Data==============
        public string getmed_Viewrecord(ConsultModel rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Sp_ViewPatient_Medi_Tken", "@TokenNo,@DivisionID,@SiteID", rs.TokenNo, rs.DivisionID, rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==================Lab Data Insert==================
        public void Add_Lbrecord(ConsultModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Patient_Lab", "@TokenNo,@TestName,@Remarks,@LoginID,@DivisionID,@SiteID", rs.TokenNo, rs.LabTest, rs.LabRemarks, rs.LoginID, rs.DivisionID, rs.SiteID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=================Follow Up Data Insert=================
        public void Add_FolRecrd(ConsultModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Patient_Followup", "@TokenNo,@FollowupDate,@Remarks,@LoginID,@DivisionID,@SiteID", rs.TokenNo, rs.FollowupDate, rs.Remarks, rs.LoginID, rs.DivisionID, rs.SiteID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //================Display Vital View All Data===============
        public string get_Viewrecord(ConsultModel rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Sp_ViewVital_Consltancy_Tken", "@TokenNo,@DivisionID,@SiteID", rs.TokenNo, rs.DivisionID, rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //================Display Patient History On Cosultancy===============
        public string get_ViewHistrecord(ConsultModel rs)
        {
            try
            {
                dt = help.ReturnParameterizedDataTableProcedure("UD_Get_ToeknList_By_RegNo", "@TokenNo", rs.TokenNo);
                return (JsonConvert.SerializeObject(dt));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //============Display Diagnose View All Data===================
        public string get_DiagViewrecord(ConsultModel rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Sp_ViewPatient_Diag_Tken", "@TokenNo,@DivisionID,@SiteID", rs.TokenNo, rs.DivisionID, rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===================Display Lab View All Data===================
        public string get_LabViewrecord(ConsultModel rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Sp_ViewPatient_Lab_Tken", "@TokenNo,@DivisionID,@SiteID", rs.TokenNo, rs.DivisionID, rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //====================Display Follow View All Data===============
        public string get_FolowViewrecord(ConsultModel rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Sp_ViewPatient_Folow_Tken", "@TokenNo,@DivisionID,@SiteID", rs.TokenNo, rs.DivisionID, rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Display Patient Token All Data===================
        public string get_record(ConsultModel rs)
        {
            try
            {
                String Query = "SELECT TokenNo,FullName FROM Sp_GetPatient_Consult Where DrID = '" + rs.DoctorID + "' and SiteID= '" + rs.SiteID + "' and DivisionID='" + rs.DivisionID + "'";
                dt = help.Return_DataTable_Query(Query);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Display Pending Patient Token All Data===================
        public string get_pendrecord(ConsultModel rs)
        {
            try
            {
                Query = "Select * from VW_PendingProc_Queue Where DoctorID = '" + rs.DoctorID + "' and SiteID= '" + rs.SiteID + "' and DivisionID='" + rs.DivisionID + "' ORDER BY  CCPL_ROW_ID desc";
                dt = help.Return_DataTable_Query(Query);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //============Get Pending Patient Data By Token==================
        public string get_penrecordbyid(ConsultModel rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Sp_Conslt_PendPatient_byTken", "@ID,@DivisionID,@SiteID", rs.TokenNo, rs.DivisionID, rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Display Diagnose Data By Lookup===================
        public string getDiage_record(ConsultModel rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Sp_Diagno_Pat_All", "@DivisionID,@SiteID", rs.DivisionID, rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Display Lab Data By Lookup ===================
        public string getLab_record(ConsultModel rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Sp_Lab_Pat_All", "@DivisionID,@SiteID", rs.DivisionID, rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //============Get Patient Data By Token==================
        public string get_recordbyid(ConsultModel rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Sp_Conslt_Patient_byTken", "@ID,@DivisionID,@SiteID", rs.TokenNo, rs.DivisionID, rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========Diagnose Data Delete====================
        public void deletedata(ConsultModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Delete_Diagnose", "@Code,@DivisionID,@SiteID", rs.id, rs.DivisionID, rs.SiteID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============For Delete Medication==================
        public void deleteMeddata(ConsultModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Delete_Medication", "@Code,@DivisionID,@SiteID", rs.id, rs.DivisionID, rs.SiteID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==================Treatment or Service Data Delete=============
        public void deletetrtdata(ConsultModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Delete_Treatmnt", "@Code,@DivisionID,@SiteID", rs.id, rs.DivisionID, rs.SiteID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Lab Data Delete============== 
        public void deleteLabdata(ConsultModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Delete_Lab", "@Code,@DivisionID,@SiteID", rs.id, rs.DivisionID, rs.SiteID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===============For Follow Up Delete================== 
        public void deleteFolowdata(ConsultModel rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Delete_follow", "@Code,@DivisionID,@SiteID", rs.id, rs.DivisionID, rs.SiteID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //============Get Doctor ID From Login==================
        public string Get_Dr_ID(ConsultModel rs)
        {
            try
            {
                dt = help.Return_DataTable_Query("SELECT DoctorID FROM DoctorHeader Where DoctorID = '" + rs.DoctorID + "' and SiteID= '" + rs.SiteID + "' and DivisionID='" + rs.DivisionID + "'");
                if (dt.Rows.Count > 0)
                {
                    SystemHelper.DoctorID = dt.Rows[0][0].ToString();
                }

                return (JsonConvert.SerializeObject(dt));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Display all service record
        //public DataSet get_Servrecord()
        //{
        //    DataSet ds = new DataSet();
        //    ds = help.ReturnDataSetProcedure("Sp_First_Aid_Setup");
        //    return ds;
        //}
        ////display service by id 
        //public DataSet get_Servrecordbyid(string id)
        //{
        //    DataSet ds = new DataSet();
        //    ds = help.ReturnParameterizedDataSetProcedure("Sp_First_AidSet_byID", "@ID", id);
        //    return ds;
        //}

        //Update Record
        //public void update_record(FirstAddModal rs)

        //{
        //    help.ExecuteParameterizedProcedure("UD_Add_Patient_FA_Service", "@TokenNo,@Mode,@Service,@Fee,@Paid,@Balance,@Remarks,@LoginID,@DivisionID,@SiteID", rs.TokenNo, rs.Mode, rs.Service, rs.Fee, rs.Paid, rs.Balance, rs.Remarks, rs.LoginID, rs.DivisionID, rs.SiteID);
        //}
        //View Record By ID
        //public DataSet get_Viewrecordbyid(string id)

        //{
        //    DataSet ds = new DataSet();
        //    ds = help.ReturnParameterizedDataSetProcedure("Sp_ViewFrstAid_byTken", "@ID", id);

        //    return ds;

        //}
        //Display Shifts Morning Evening Night
        //public DataSet get_Shifts()
        //{
        //    DataSet ds = new DataSet();
        //    ds = help.ReturnDataSetProcedure("Sp_Shifts_get");
        //    return ds;
        //}

        //Display Genric Name
        //public DataSet get_GenricTyprecord()
        //{
        //    DataSet ds = new DataSet();
        //    ds = help.ReturnDataSetProcedure("Sp_Patient_Genric_get");
        //    return ds;
        //}
    }
}