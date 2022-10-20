using Clinic_Proj.Database_Access;
using Clinic_Proj.Models;
using CrystalDecisions.CrystalReports.Engine;
//using CrystalDecisions.CrystalReports.Engine;
using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;
using System.Web.Mvc;

namespace Clinic_Proj.Controllers
{
    [Authorize]
    public class PatientRegController : Controller
    {
        Clinic_Proj.Database_Access.PatientRegdb dblayer = new Clinic_Proj.Database_Access.PatientRegdb();
        // GET: PatientReg
        string res = string.Empty;
        DataTable dt = new DataTable();
        string Result;
        public ActionResult PatientReg()
        {
            return View();
        }
        //===============Print And Save================
        //public JsonResult Print_Rpt(PatientModel rs)
        //{
        //    try
        //    {
                
        //        //dblayer.Add_record(rs);
        //        res = "Print";
        //        ReportDocument cryRpt = new ReportDocument();

        //        //cryRpt.Load(@"C:\Users\Usman Khalid\Desktop\Barcode Testing\rpt.rpt");
        //        //cryRpt.SetParameterValue("Title", em.DocNo);
        //        cryRpt.Load(@"D:\Project\Clinic Reports\rpt_Token_Slip.rpt");
        //        cryRpt.SetParameterValue("@TokenNo", rs.TokenNo);
        //        cryRpt.SetParameterValue("@SiteID", rs.SiteID);
        //        cryRpt.SetDatabaseLogon("sa", "ccpl@jm2021");


        //        cryRpt.PrintToPrinter(1, true, 0, 0);

        //        return Json(res, JsonRequestBehavior.AllowGet);

        //    }
        //    catch (Exception ex)
        //    {
        //        res = "QT Header Failed.." + ex.Message;
        //        return Json(res, JsonRequestBehavior.AllowGet);
        //    }
        //}

        //===============Patient Insert======================
        [HttpPost]
        public JsonResult Add_record(PatientModel rs)
        {
            string res = string.Empty;
            try
            {
                dblayer.Add_record(rs);
                res = "Inserted";
            }
            catch (Exception)
            {
                res = "Failed";
                throw;
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //===============Check Type=====================
        [HttpPost]
        public JsonResult CheckTyp_record(PatientModel rs)
        {
            try
            {
                Result = SystemHelper.Get_TokenTyp_Session();
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Token Print========
        public ActionResult Token_Print(string TokenNo)
        {
            try
            {
                //=============Print=========
                dt = SystemHelper.Business_Setting();
                if (dt.Rows.Count > 0)
                {
                    string Path = dt.Rows[0]["ReportPath"].ToString().Trim();
                    string dbID = dt.Rows[0]["dbID"].ToString().Trim();
                    string dbPass = dt.Rows[0]["dbPass"].ToString().Trim();
                    ReportDocument cryRpt = new ReportDocument();

                    string ReportFormat = "pdf";
                    string FileName = "ClinicTokenRpt";
                    //ReportDocument cryRpt = new ReportDocument();

                    //cryRpt.Load(@"C:\Users\Usman Khalid\Desktop\Barcode Testing\rpt.rpt");
                    //cryRpt.SetParameterValue("Title", em.DocNo);
                    string ReportPath = Path + @"\rpt_Token_Slip.rpt";
                    cryRpt.Load(ReportPath);
                    string abc = SystemHelper.Get_SiteID_Session();
                    cryRpt.SetParameterValue("@SiteID", SystemHelper.Get_SiteID_Session());
                    cryRpt.SetParameterValue("@TokenNo", TokenNo);
                    //cryRpt.SetParameterValue("@DocDate", DateTime.Now);
                    //cryRpt.SetDatabaseLogon("sa", "ccpl@jm2021");
                    cryRpt.SetDatabaseLogon(dbID, dbPass, "HMS_CCPL", "CCPL_HMS");

                    Response.Buffer = false;
                    Response.ClearContent();
                    Response.ClearHeaders();

                    Stream stream = null;

                    if (ReportFormat == "Excel")
                    {
                        stream = cryRpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.ExcelRecord);
                        stream.Seek(0, SeekOrigin.Begin);
                        return File(stream, "application/xml", FileName + ".xls");

                    }
                    else
                    {
                        //stream = cryRpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                        //stream.Seek(0, SeekOrigin.Begin);
                        //return File(stream, "application/pdf");
                        stream = cryRpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                        stream.Seek(0, SeekOrigin.Begin);
                        if (string.IsNullOrEmpty(FileName))
                        {
                            return File(stream, "application/pdf");
                        }
                        else
                        {
                            //return File(stream, "application/pdf", FileName + ".pdf");
                            return File(stream, "application/pdf");
                        }
                    }
                }
                else
                {
                    return File("", "application/pdf");
                }

            }
            catch (Exception ex)
            {
                Result = "PDR Doc Print Error.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //===============Fee Data Insert=========================
        [HttpPost]
        public JsonResult Add_Feerecord(PatientModel rs)
        {
            string res = string.Empty;
            try
            {
                dblayer.Add_Fee_record(rs);
                res = "Inserted";
            }
            catch (Exception ex)
            {
                res = "Failed";
                throw ex;
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //==========Display All Patient Related lookup Data================
        [HttpPost]
        public JsonResult Get_data(PatientModel rs)
        {
            try
            {
                Result = dblayer.get_record(rs);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "List Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //==================Patient Related Data Get For Pharmacy===================
        [HttpGet]
        public JsonResult Get_PharmacyMed()
        {
            string Result = null;
            try
            {
                Result = dblayer.get_Pharmacyrecord();
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "Lookup Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //==============Patient data Get By id=================
        [HttpPost]
        public JsonResult Get_databyid(PatientModel rs)
        {
            try
            {
                return Json(dblayer.get_recordbyid(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Create New Token============
        [HttpPost]
        public JsonResult Get_NewTknbyid(PatientModel rs)
        {
            try
            {
                if (rs.Relation.Equals(null) || rs.Relation.Equals(""))
                {
                    rs.Relation = "Self";
                }
                else
                {

                }
                return Json(dblayer.get_NewTokenbyid(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Patient Detail if Patient is already Register Get By ID AND Token============
        [HttpPost]
        public JsonResult Get_PatExibyid(PatientModel rs)
        {
            try
            {
                return Json(dblayer.get_Exirecordbyid(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========Get Patient Data By CNIC And Relation IF Already Available
        [HttpPost]
        public JsonResult GetPat_Available(PatientModel rs)
        {
            try
            {
                return Json(dblayer.getExist_recordbyid(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        //===========Dummy New Token Create=================
        public JsonResult get_Pat_Token()
        {
            try
            {
                return Json(dblayer.get_PatToken(SystemHelper.SiteID, SystemHelper.Username), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Get Patient Relation related All Data=================
        [HttpPost]
        public JsonResult Get_PatdataRelation()
        {
            try
            {
                DataSet ds = dblayer.get_PatRelation();
                string RtnJS = JsonConvert.SerializeObject(ds.Tables[0]);
                return Json(RtnJS, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Get Doctor Name======================
        [HttpPost]
        public JsonResult Get_DoctorName(PatientModel rs)
        {
            try
            {
                return Json(dblayer.get_DocName(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Get Bank Name======================
        [HttpPost]
        public JsonResult Get_BankName()
        {
            try
            {
                DataSet ds = dblayer.get_BankName();
                string RtnJS = JsonConvert.SerializeObject(ds.Tables[0]);
                return Json(RtnJS, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Get Payment Method======================
        [HttpPost]
        public JsonResult Get_PayMethod()
        {
            try
            {
                DataSet ds = dblayer.get_PaymntMeth();
                string RtnJS = JsonConvert.SerializeObject(ds.Tables[0]);
                return Json(RtnJS, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========Get Patient Data By CNIC IF Already Available===========
        [HttpPost]
        public JsonResult Get_PatAvailable(PatientModel rs)
        {
            try
            {
                return Json(dblayer.get_PatAvail(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=================Get Patient Type By lookup====================
        [HttpPost]
        public JsonResult Get_PatdataType()
        {
            try
            {
                DataSet ds = dblayer.get_PatType();
                string RtnJS = JsonConvert.SerializeObject(ds.Tables[0]);
                return Json(RtnJS, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //========================Patient Update===============
        //[HttpPost]
        //public JsonResult update_record(PatientModel rs)
        //{
        //    string res = string.Empty;
        //    try
        //    {
        //        dblayer.update_record(rs);
        //        res = "Updated";
        //    }
        //    catch (Exception)
        //    {
        //        res = "failed";
        //    }
        //    return Json(res, JsonRequestBehavior.AllowGet);
        //}
        ////======================Fee Update===================
        //[HttpPost]
        //public JsonResult update_Feerecord(PatientModel rs)
        //{
        //    string res = string.Empty;
        //    try
        //    {
        //        dblayer.update_Fee_record(rs);
        //        res = "Updated";
        //    }
        //    catch (Exception)
        //    {
        //        res = "failed";
        //    }
        //    return Json(res, JsonRequestBehavior.AllowGet);
        //}
        //==================Delete Patient=============================
        [HttpPost]
        public JsonResult OnDelete(string ID)
        {
            string res = string.Empty;
            if (ID != null && ID != "")
            {
                dblayer.deletedata(ID);
                res = "Delete";
            }
            else
            {
                res = "failed";
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        //===========get CNIC=============
        [HttpPost]
        public JsonResult Get_CNIC()
        {
            try
            {
                return Json(dblayer.get_CNRecord(SystemHelper.Get_CNIC_Session()), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========get Session TokenNo=============
        [HttpPost]
        public JsonResult Get_SessionCNIC()
        {
            try
            {
                return Json(dblayer.getSession_CNRecord(SystemHelper.Get_Token_Session()), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========get Panal CNIC=============
        [HttpPost]
        public JsonResult GetPanal_CNIC()
        {
            try
            {
                return Json(dblayer.get_PanalCNRecord(SystemHelper.Get_CNIC_Session()), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===============Register CNIC Transfer to New Patient Form======================
        [HttpPost]
        public JsonResult Register_CNIC(PatientModel rs)
        {
            try
            {
                return Json(dblayer.get_PatientRecord(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===============Get Secound Token In One Relation======================
        //[HttpPost]
        //public JsonResult Secound_TokenRelation(PatientModel rs)
        //{
        //    try
        //    {
        //        return Json(dblayer.get_TokenSecound(rs), JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //===============Register Session Token Transfer to New Patient Form======================
        [HttpPost]
        public JsonResult RegisterSession_Token(PatientModel rs)
        {
            try
            {
                return Json(dblayer.get_SessionPatientRecord(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===============Register Panal CNIC Transfer to New Patient Form======================
        [HttpPost]
        public JsonResult PanalRegister_CNIC(PatientModel rs)
        {
            try
            {
                return Json(dblayer.get_PanalPatientRecord(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
