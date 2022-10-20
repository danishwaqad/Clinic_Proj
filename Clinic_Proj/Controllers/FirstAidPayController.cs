using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using Clinic_Proj.Models;
using Clinic_Proj.Controllers;
using Newtonsoft.Json;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using Clinic_Proj.Database_Access;
using System.Net;
using System.Web.Security;


namespace Clinic_Proj.Controllers
{
    [Authorize]
    public class FirstAidPayController : Controller
    {
        DataTable dt = new DataTable();
        Clinic_Proj.Database_Access.FAPayDb dblayer = new Clinic_Proj.Database_Access.FAPayDb();
        // GET: FirstAidPay
        public ActionResult FAPay()
        {
            return View();
        }
        //==============Display Patient Look up Data===================
        [HttpPost]
        public JsonResult Get_data(FAPayModel rs)
        {
            try
            {
                return Json(dblayer.get_record(rs), JsonRequestBehavior.AllowGet);
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
        //=============First Aid Print================
        public ActionResult FAPrint(string TokenNo)
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
        //==================Check Payment Record=======================
        [HttpPost]
        public JsonResult FA_CheckPayment(FAPayModel rs)
        {
            try
            {
                return Json(dblayer.get_FAPaymentbyid(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Display Patient Data Get By ID================
        [HttpPost]
        public JsonResult Get_databyid(FAPayModel rs)
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
        //Update records
       [HttpPost]
        public JsonResult Save_record(FAPayModel rs)
        {
            string res = string.Empty;
            try
            {
                dblayer.save_record(rs);
                res = "Inserted";
            }
            catch (Exception ex)
            {
                res = "failed";
                throw ex;
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}