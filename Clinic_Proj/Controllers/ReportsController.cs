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

namespace Clinic_Proj.Controllers
{
    [Authorize]
    public class ReportsController : Controller
    {
        Clinic_Proj.Database_Access.ReportsDb dblayer = new Clinic_Proj.Database_Access.ReportsDb();
        string Result = null;
        DataTable dt = new DataTable();
        // GET: Reports
        public ActionResult Reports()
        {
            return View();
        }
        //Display Clinic all View data
        [HttpPost]
        public JsonResult Get_ClinicViewdata(ReportsModel rs)
        {
            try
            {
                Result = dblayer.ViewClinicData(rs);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        //Display Session all View data
        [HttpPost]
        public JsonResult Get_SessionViewdata(ReportsModel rs)
        {
            try
            {
                Result = dblayer.ViewSessionData(rs);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        [HttpGet]
        public ActionResult Print_FirstAid_Rpt(DateTime DateFrom, DateTime DateTo, string SiteFrom, string SiteTo, string DoctorNam,string loginID)
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
                    string FileName = "ManagementFARpt";
                    loginID = SystemHelper.Get_User_Session();
                    //ReportDocument cryRpt = new ReportDocument();

                    //cryRpt.Load(@"C:\Users\Usman Khalid\Desktop\Barcode Testing\rpt.rpt");
                    //cryRpt.SetParameterValue("Title", em.DocNo);
                    string ReportPath = Path + @"\Managemnt_Report_FirstAid.rpt";
                    cryRpt.Load(ReportPath);

                    cryRpt.SetParameterValue("@DateFrom", DateFrom);
                    cryRpt.SetParameterValue("@DateTo", DateTo);
                    cryRpt.SetParameterValue("@SiteFrom", SiteFrom);
                    cryRpt.SetParameterValue("@SiteTo", SiteTo);
                    cryRpt.SetParameterValue("@Doctor", DoctorNam);
                    cryRpt.SetParameterValue("@LoginID", loginID);
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
        [HttpGet]
        public ActionResult Print_Summary_Test(DateTime DateFrom, DateTime DateTo, string SiteFrom, string SiteTo/*, string DoctorNam*/)
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
                    string FileName = "ManagementSummaryRpt";
                    //ReportDocument cryRpt = new ReportDocument();

                    //cryRpt.Load(@"C:\Users\Usman Khalid\Desktop\Barcode Testing\rpt.rpt");
                    //cryRpt.SetParameterValue("Title", em.DocNo);
                    string ReportPath = Path + @"\rpt_Clinic_Performance_Report_DateWise.rpt";
                    cryRpt.Load(ReportPath);

                    cryRpt.SetParameterValue("@DateFrom", DateFrom);
                    cryRpt.SetParameterValue("@DateTo", DateTo);
                    cryRpt.SetParameterValue("@SiteFrom", SiteFrom);
                    cryRpt.SetParameterValue("@SiteTo", SiteTo);
                    //cryRpt.SetParameterValue("@Doctor", DoctorNam);
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
       [HttpGet]
        public ActionResult Print_Clinic_Rpt(DateTime DateFrom, DateTime DateTo,string SiteFrom,string SiteTo,string DoctorNam,string loginID)
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
                    string FileName = "ManagementRpt";
                    loginID = SystemHelper.Get_User_Session();
                    //ReportDocument cryRpt = new ReportDocument();

                    //cryRpt.Load(@"C:\Users\Usman Khalid\Desktop\Barcode Testing\rpt.rpt");
                    //cryRpt.SetParameterValue("Title", em.DocNo);
                    string ReportPath = Path + @"\ManagemntClinic_Report.rpt";
                    cryRpt.Load(ReportPath);
   
                    cryRpt.SetParameterValue("@DateFrom", DateFrom);
                    cryRpt.SetParameterValue("@DateTo", DateTo);
                    cryRpt.SetParameterValue("@SiteFrom", SiteFrom);
                    cryRpt.SetParameterValue("@SiteTo", SiteTo);
                    cryRpt.SetParameterValue("@Doctor", DoctorNam);
                    cryRpt.SetParameterValue("@LoginID", loginID);
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
        [HttpGet]
        public ActionResult Print_Session_Rpt(DateTime DateFrom, DateTime DateTo, string SiteFrom, string SiteTo, string DoctorNam, string loginID)
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
                    string FileName = "ManagementSessionRpt";
                    loginID = SystemHelper.Get_User_Session();
                    //ReportDocument cryRpt = new ReportDocument();

                    //cryRpt.Load(@"C:\Users\Usman Khalid\Desktop\Barcode Testing\rpt.rpt");
                    //cryRpt.SetParameterValue("Title", em.DocNo);
                    string ReportPath = Path + @"\Management_Session_Report.rpt";
                    cryRpt.Load(ReportPath);

                    cryRpt.SetParameterValue("@DateFrom", DateFrom);
                    cryRpt.SetParameterValue("@DateTo", DateTo);
                    cryRpt.SetParameterValue("@SiteFrom", SiteFrom);
                    cryRpt.SetParameterValue("@SiteTo", SiteTo);
                    cryRpt.SetParameterValue("@Doctor", DoctorNam);
                    cryRpt.SetParameterValue("@LoginID", loginID);
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
        //Display First Aid all View data
        [HttpPost]
        public JsonResult Get_FirstAidViewdata(ReportsModel rs)
        {
            try
            {
                Result = dblayer.ViewFirstAidData(rs);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        //=============Get Total For CLinic=========
        [HttpPost]
        public JsonResult Get_Clinic_Total(ReportsModel rs)
        {
            try
            {
                Result = dblayer.get_ChargesClinic(rs);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        //=============Get Total For Session=========
        [HttpPost]
        public JsonResult Get_Session_Total(ReportsModel rs)
        {
            try
            {
                Result = dblayer.get_ChargesSession(rs);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        //=============Get Total For First Aid=========
        [HttpPost]
        public JsonResult Get_FirstAid_Total(ReportsModel rs)
        {
            try
            {
                Result = dblayer.get_ChargesFirstAid(rs);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}