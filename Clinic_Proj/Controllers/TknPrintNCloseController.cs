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
    public class TknPrintNCloseController : Controller
    {
        Clinic_Proj.Database_Access.TknUncloseDB dblayer = new Clinic_Proj.Database_Access.TknUncloseDB();
        DataTable dt = new DataTable();
        string Result;
        // GET: TknPrintNClose
        public ActionResult TknPrintAndUnclose()
        {
            return View();
        }
        //=======Get Patient View Data=========
        [HttpPost]
        public JsonResult Get_ViewData(TknUncloseMode rs)
        {
            try
            {
                return Json(dblayer.get_ViewDataid(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=======Token Unclosed=========
        //[HttpPost]
        //public JsonResult Get_UncloseData(TknUncloseMode rs)
        //{
        //    try
        //    {
        //        return Json(dblayer.get_UncloseTknid(rs), JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //=======Token Unclosed=========
        [HttpPost]
        public JsonResult Get_UncloseData(TknUncloseMode rs)
        {
            string res = string.Empty;
            if (rs.TokenNo != "")
            {
                dblayer.get_UncloseTknid(rs);
                res = "Token Unclosed";
            }
            else
            {
                res = "failed";
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //==============Token Print========
        public ActionResult Token_Print(string TokenNo,string SiteID)
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
                    //string abc = SystemHelper.Get_SiteID_Session();
                    cryRpt.SetParameterValue("@SiteID", SiteID);
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
        //=============First Aid Print================
        public ActionResult FAPrint(string TokenNo,string SiteID)
        {
            string Result;
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
                    string FileName = "FirstAidRpt";
                    //ReportDocument cryRpt = new ReportDocument();

                    //cryRpt.Load(@"C:\Users\Usman Khalid\Desktop\Barcode Testing\rpt.rpt");
                    //cryRpt.SetParameterValue("Title", em.DocNo);
                    string ReportPath = Path + @"\rpt_FAServices_Bill_Slip.rpt";
                    cryRpt.Load(ReportPath);
                    string abc = SystemHelper.Get_SiteID_Session();
                    cryRpt.SetParameterValue("@SiteID", SiteID);
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
    }
}