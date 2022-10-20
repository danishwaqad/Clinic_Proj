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
    public class DoctorsPaymentController : Controller
    {
        // GET: DoctorsPayment
        string Result = null;
        DataTable dt = new DataTable();
        Clinic_Proj.Database_Access.DocPaymentDB dblayer = new Clinic_Proj.Database_Access.DocPaymentDB();
        public ActionResult DoctorPayment()
        {
            return View();
        }
        //========New Doc Number======
        [HttpPost]
        public JsonResult Generate_DocNum(DocPaymentMode DM)
        {
            string res = string.Empty;
            try
            {
                dblayer.Generate_DcNum(DM);
                res = "Inserted";
            }
            catch (Exception)
            {
                res = "Failed";
                throw;
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //==============Display Doctor DocNumber===================
        [HttpPost]
        public JsonResult Get_Docupdata(DocPaymentMode rs)
        {
            try
            {
                return Json(dblayer.get_DocDocNumrecord(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult Print_Doctors_Payment(string DocNumber)
        {
            try
            {
                //=============Print=========
                dt = SystemHelper.Business_Setting();
                if (dt.Rows.Count > 0)
                {
                    //===============Generate and Save QR Code Image===========
                    string p = dt.Rows[0]["QRCodePath"].ToString().Trim();

                    string QRPath = p + @"\Clinic_" + DocNumber + ".bmp";

                    //string QRPath = @"\\192.168.201.69\CCPL Documents\QRCode\Clinic_" + DocNumber + ".bmp";
                    QRCodeGenerator.ECCLevel eccLevel = QRCodeGenerator.ECCLevel.L;
                    using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                    using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(DocNumber, eccLevel))

                    using (QRCode qrCode = new QRCode(qrCodeData))
                    {

                        int Pixel = 20;
                        var PrimaryColor = System.Drawing.Color.Black;
                        var BackgrounColor = System.Drawing.Color.White;
                        Bitmap bitmap = qrCode.GetGraphic(Pixel, PrimaryColor, BackgrounColor, null, 0);
                        bitmap.Save(QRPath, ImageFormat.Bmp);
                    }
                    //===============Generate Report===========
                    string Path = dt.Rows[0]["ReportPath"].ToString().Trim();
                    string dbID = dt.Rows[0]["dbID"].ToString().Trim();
                    string dbPass = dt.Rows[0]["dbPass"].ToString().Trim();
                    ReportDocument cryRpt = new ReportDocument();

                    string ReportFormat = "pdf";
                    string FileName = DocNumber;
                    string ReportPath = Path + @"\rpt_Doctor_Payment_Voucher.rpt";
                    cryRpt.Load(ReportPath);

                    cryRpt.SetParameterValue("@DocNo", DocNumber);
                    cryRpt.SetParameterValue("@SiteID", SystemHelper.Get_SiteID_Session());
                    cryRpt.SetParameterValue("@PicPath", QRPath);
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
                        stream = cryRpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                        stream.Seek(0, SeekOrigin.Begin);
                        if (string.IsNullOrEmpty(FileName))
                        {
                            if (System.IO.File.Exists(QRPath))
                            {
                                System.IO.File.Delete(QRPath);
                            }
                            return File(stream, "application/pdf");
                        }
                        else
                        {
                            if (System.IO.File.Exists(QRPath))
                            {
                                System.IO.File.Delete(QRPath);
                            }
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
        //==============Display Doctors Look up Data===================
        [HttpPost]
        public JsonResult Get_DoLokupdata(DocPaymentMode rs)
        {
            try
            {
                return Json(dblayer.get_Doctrecord(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Doctor Data Get By ID=========================
        [HttpPost]
        public JsonResult Get_Paydatabyid(DocPaymentMode rs)
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
        //=============Display Doctor Data Get By ID================
        [HttpPost]
        public JsonResult Get_Doctrdataid(DocPaymentMode rs)
        {
            try
            {
                return Json(dblayer.get_DoctrecordByid(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==================Add Doctors Payment=======================
        [HttpPost]
        public JsonResult Add_Docrecord(DocPaymentMode DM)
        {
            string res = string.Empty;
            try
            {
                dblayer.Add_DCrecord(DM);
                res = "Inserted";
            }

            catch (Exception)
            {
                res = "failed";
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}