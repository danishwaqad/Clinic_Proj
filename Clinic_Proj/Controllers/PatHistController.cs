using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using Clinic_Proj.Models;
using Newtonsoft.Json;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using Clinic_Proj.Database_Access;
using QRCoder;
using Microsoft.Win32;
using System.Drawing.Imaging;
using System.Drawing;
using System.Net;
using System.Configuration;

namespace Clinic_Proj.Controllers
{
    [Authorize]
    public class PatHistController : Controller
    {
        string Result;
        Clinic_Proj.Database_Access.PatHistDb dblayer = new Clinic_Proj.Database_Access.PatHistDb();
        DataTable dt = new DataTable();
        // GET: PatRefundFee
        public ActionResult patientHistView()
        {
            return View();
        }
        //Display Token data
        [HttpPost]
        public JsonResult Get_Tokendata(PatHisModl rs)
        {
            try
            {
                return Json(dblayer.get_Tokenrecord(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public ActionResult Print_Perscription_Rpt(string Token,string SiteID)
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
                    string FileName = "Duplicate_Prescription_Rpt";
                    //SiteID = SystemHelper.Get_SiteID_Session();
                    //ReportDocument cryRpt = new ReportDocument();

                    //cryRpt.Load(@"C:\Users\Usman Khalid\Desktop\Barcode Testing\rpt.rpt");
                    //cryRpt.SetParameterValue("Title", em.DocNo);
                    string ReportPath = Path + @"\rpt_Prescription_History.rpt";
                    cryRpt.Load(ReportPath);

                    cryRpt.SetParameterValue("@TokenNo", Token);
                    cryRpt.SetParameterValue("@SiteID", SiteID);
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
        //================Report Download Code================
        public ActionResult Download_Perscription_Slip(string Token, string SiteID)
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
                    string FileName = "";// dm.DocNo;
                    dt = new DataTable();
                    //FileName = Token + "-" + Name + "-" + SiteID + "[" + Cnic + "]";
                    string MyString = Token.Replace('/', '-');
                    FileName = MyString + "-" + SiteID;
                    //ReportDocument cryRpt = new ReportDocument();

                    //cryRpt.Load(@"C:\Users\Usman Khalid\Desktop\Barcode Testing\rpt.rpt");
                    //cryRpt.SetParameterValue("Title", em.DocNo);
                    string ReportPath = Path + @"\rpt_Prescription_History.rpt";
                    cryRpt.Load(ReportPath);

                    cryRpt.SetParameterValue("@TokenNo", Token);
                    cryRpt.SetParameterValue("@SiteID", SiteID);
                    //cryRpt.SetDatabaseLogon("sa", "ccpl@jm2021");
                    cryRpt.SetDatabaseLogon(dbID, dbPass, "HMS_CCPL", "CCPL_HMS");

                    Response.Buffer = false;
                    Response.ClearContent();
                    Response.ClearHeaders();

                    Stream stream = null;
                    //cryRpt.FileName = dm.DocNo;
                    if (ReportFormat == "Excel")
                    {
                        stream = cryRpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.ExcelRecord);
                        stream.Seek(0, SeekOrigin.Begin);
                        return File(stream, "application/xml", FileName + ".xls");

                    }
                    else
                    {
                        stream = cryRpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                        stream.Seek(0, SeekOrigin.Begin);
                        if (string.IsNullOrEmpty(FileName))
                        {
                            return File(stream, "application/pdf");
                        }
                        else
                        {
                            //============To Download PDF File===========
                            return File(stream, "application/pdf", FileName + ".pdf");

                            //============To Preview PDF on runtime without downloading===========
                            //return File(stream, "application/pdf");
                        }

                        //stream = cryRpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                        //stream.Seek(0, SeekOrigin.Begin);
                        ////return File(stream, "application/pdf");
                        //return File(stream, "application/pdf", FileName + ".pdf");
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

        //Display Selected data
        [HttpPost]
        public JsonResult Get_Selectdata(PatHisModl rs)
        {
            try
            {
                return Json(dblayer.get_Selectrecord(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===================Display Session All Data===================
        [HttpPost]
        public JsonResult Get_Sessiondata(PatHisModl rs)
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
        //===================Display Activity Session All Data===================
        [HttpPost]
        public JsonResult Get_SessionActdata(PatHisModl rs)
        {
            try
            {
                return Json(dblayer.get_SessionActrecord(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Display cnic from data
        [HttpPost]
        public JsonResult Get_CNICFTdata(PatHisModl rs)
        {
            try
            {
                //return Json(dblayer.get_CNICFTrecord(rs), JsonRequestBehavior.AllowGet);
                string Rtn = dblayer.get_CNICFTrecord(rs);
                var T = Json(Rtn, JsonRequestBehavior.AllowGet);
                T.MaxJsonLength = int.MaxValue;
                return T;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Display Type From lookup
        [HttpPost]
        public JsonResult Get_Typdata()
        {
            try
            {
                Result = dblayer.get_Typrecord();
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "List Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //Display Doctor From lookup
        [HttpPost]
        public JsonResult Get_Docdata(PatHisModl rs)
        {
            try
            {
                return Json(dblayer.get_Docrecord(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Get Total=========
        [HttpPost]
        public JsonResult Get_Charges_Total(PatHisModl rs)
        {
            try
            {
                string Result = null;
                Result = dblayer.get_ChargesByID(rs);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        //Display Site from data
        [HttpPost]
        public JsonResult Get_SiteFTdata(PatHisModl rs)
        {
            try
            {
                return Json(dblayer.get_SiteFTrecord(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Display all View data
        [HttpPost]
        public JsonResult Get_Viewdata(PatHisModl rs)
        {
            try
            {   
                string Result = null;
                Result = dblayer.ViewData(rs);
                var T = Json(Result, JsonRequestBehavior.AllowGet);
                T.MaxJsonLength = int.MaxValue;
                return T;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        //Display all Diagnose View data Muneeb Changing With code
        [HttpPost]
        public JsonResult Get_ViewDiagdata(PatHisModl rs)
        {
            try
            {
                return Json(dblayer.get_DiagViewrecord(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public JsonResult Get_VitalViewdata(PatHisModl rs)
        {
            try
            {
                return Json(dblayer.get_Viewrecord(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Get TOken
        [HttpPost]
        public JsonResult Get_TKndata(PatHisModl rs)
        {
            try
            {
                return Json(dblayer.get_Tknrecord(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Display all Lab View data
        [HttpPost]
        public JsonResult Get_ViewLabdata(PatHisModl rs)
        {
            try
            {
                return Json(dblayer.get_LabViewrecord(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Display all Follow View data
        [HttpPost]
        public JsonResult Get_ViewFolowdata(PatHisModl rs)
        {
            try
            {
                return Json(dblayer.get_FolowViewrecord(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Display First Aid View All Data
        [HttpPost]
        public JsonResult Get_ViewFAData(PatHisModl rs)
        {
            try
            {
                return Json(dblayer.get_FAViewrecord(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Display Medi View all data
        [HttpPost]
        public JsonResult GetMed_Viewdata(PatHisModl rs)
        {
            try
            {
                return Json(dblayer.getmed_Viewrecord(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Display Service View all data
        [HttpPost]
        public JsonResult GetServ_data(PatHisModl rs)
        {
            try
            {
                return Json(dblayer.getSer_View(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}