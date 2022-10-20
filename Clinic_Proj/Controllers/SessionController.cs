using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using Clinic_Proj.Models;
using Newtonsoft.Json;
using Clinic_Proj.Database_Access;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace Clinic_Proj.Controllers
{
    [Authorize]
    public class SessionController : Controller
    {
        DataTable dt = new DataTable();
        // GET: Session
        Clinic_Proj.Database_Access.SessionDb dblayer = new Clinic_Proj.Database_Access.SessionDb();
        string Result;
        string res = string.Empty;
        public ActionResult PatientSession()
        {
            return View();
        }
        //===============Display Session Tokens=====================
        [HttpPost]
        public JsonResult Get_data(SessionMode rs)
        {
            try
            {
                Result = dblayer.get_SessionRecord(rs);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "Session Token Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //===================Display Session All Data===================
        [HttpPost]
        public JsonResult Get_Sessiondata(SessionMode rs)
        {
            try
            {
                return Json(dblayer.get_SessionViewrecord(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===================Display ToDate View Data==================
        [HttpPost]
        public JsonResult Get_SessionVWTodate(SessionMode rs)
        {
            try
            {
                return Json(dblayer.get_SessionViewToDate(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public ActionResult Print_Session_Rpt(string TokenNo)
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
                    string FileName = "SessionDetail";
                    //ReportDocument cryRpt = new ReportDocument();

                    //cryRpt.Load(@"C:\Users\Usman Khalid\Desktop\Barcode Testing\rpt.rpt");
                    //cryRpt.SetParameterValue("Title", em.DocNo);
                    string ReportPath = Path + @"\rpt_Session_Detail.rpt";
                    cryRpt.Load(ReportPath);

                    cryRpt.SetParameterValue("@TokenNo", TokenNo);
                    cryRpt.SetParameterValue("@SiteID", SystemHelper.Get_SiteID_Session());
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
        //===============Display Session Fee=====================
        //[HttpPost]
        //public JsonResult Get_SessionFeedata(SessionMode rs)
        //{
        //    try
        //    {
        //        Result = dblayer.get_SessionFeeRecord(rs);
        //        return Json(Result, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        Result = "Session Fee Failed.." + ex.Message;
        //        return Json(Result, JsonRequestBehavior.AllowGet);
        //    }
        //}
        //===============Session Token Insert======================
        [HttpPost]
        public JsonResult TrsTknData(string TokenSession, SessionMode DM)
        {
            try
            {

                dblayer.Update_SesStatus(DM);
                Session["TokenNo"] = TokenSession;
                Session["TokenType"] = "Session";
                Result = "Done";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        //==================Get Active Tokens List For Session=======================
        [HttpPost]
        public JsonResult SessiontknList(SessionMode rs)
        {
            try
            {
                return Json(dblayer.Get_SessionTkn_List(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==================Get Tokens List For Session Extend=======================
        [HttpPost]
        public JsonResult SessionExtList(SessionMode rs)
        {
            try
            {
                return Json(dblayer.Get_SessionExtTkn_List(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //================Final Save Doc Records====================
        [HttpPost]
        public JsonResult Add_PatSesrecord(SessionMode DM)
        {
            string res = string.Empty;
            try
            {
                dblayer.Add_Saverecord(DM);
                res = "Inserted";
            }

            catch (Exception)
            {
                res = "failed";
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //================Extra Session Insert====================
        [HttpPost]
        public JsonResult Add_ExtSesrecord(SessionMode DM)
        {
            string res = string.Empty;
            try
            {
                dblayer.Add_ExtSesionrecord(DM);
                res = "Inserted";
            }

            catch (Exception)
            {
                res = "failed";
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //==================Save FullPayment Extension Session===============
        [HttpPost]
        public JsonResult Add_FullPaySesrecord(SessionMode DM)
        {
            string res = string.Empty;
            try
            {
                dblayer.Add_FullSesionrecord(DM);
                res = "Inserted";
            }

            catch (Exception)
            {
                res = "failed";
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //================Extra Session Full Package Insert====================
        [HttpPost]
        public JsonResult Add_ExtPackage(SessionMode DM)
        {
            string res = string.Empty;
            try
            {
                dblayer.Add_ExtPackagerecord(DM);
                res = "Inserted";
            }

            catch (Exception)
            {
                res = "failed";
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //================Save Extended Session====================
        [HttpPost]
        public JsonResult SaveSessionData(SessionMode DM)
        {
            string res = string.Empty;
            try
            {
                dblayer.Add_Saverecord(DM);
                res = "Inserted";
            }

            catch (Exception)
            {
                res = "failed";
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //==================Single Paid Amount Insert=======================
        [HttpPost]
        public JsonResult Single_PatSavrecord(SessionMode DM)
        {
            string res = string.Empty;
            try
            {
                dblayer.AddSingle_Sesrecord(DM);
                res = "Inserted";
            }

            catch (Exception)
            {
                res = "failed";
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //==================Extra Session Inserted=======================
        [HttpPost]
        public JsonResult Extra_SessionSav(SessionMode DM)
        {
            string res = string.Empty;
            try
            {
                dblayer.Extra_Sesrecord(DM);
                res = "Inserted";
            }

            catch (Exception)
            {
                res = "failed";
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //================Update Session Record====================
        //[HttpPost]
        //public JsonResult Add_Sessionrecord(SessionMode DM)
        //{
        //    string res = string.Empty;
        //    try
        //    {
        //        dblayer.Add_DetailRecord(DM);
        //        res = "Inserted";
        //    }

        //    catch (Exception)
        //    {
        //        res = "failed";
        //    }
        //    return Json(res, JsonRequestBehavior.AllowGet);
        //}
        //=============Patient Session Data Get By ID==========================
        [HttpPost]
        public JsonResult Get_databyid(SessionMode rs)
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
    }
}