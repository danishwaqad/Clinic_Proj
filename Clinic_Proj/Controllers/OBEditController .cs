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
    public class OBEditController : Controller
    {
        string Result = null;
        DataTable dt = new DataTable();
        Clinic_Proj.Database_Access.ObEditDB dblayer = new Clinic_Proj.Database_Access.ObEditDB();


        // GET: Accounting
        public ActionResult NewOB()
        {
            return View();
        }
        public ActionResult Print_Slip_Test(string DocNumber)
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
                        //bitmap.Save(Server.MapPath("~/Uploads/") + "Test.bmp", System.Drawing.Imaging.ImageFormat.Bmp);

                        //bitmap.Save(QRPath, System.Drawing.Imaging.ImageFormat.Bmp);
                    }
                    //===============Generate Report===========
                    string Path = dt.Rows[0]["ReportPath"].ToString().Trim();
                    string dbID = dt.Rows[0]["dbID"].ToString().Trim();
                    string dbPass = dt.Rows[0]["dbPass"].ToString().Trim();
                    ReportDocument cryRpt = new ReportDocument();

                    string ReportFormat = "pdf";
                    string FileName = DocNumber;
                    //ReportDocument cryRpt = new ReportDocument();

                    //cryRpt.Load(@"C:\Users\Usman Khalid\Desktop\Barcode Testing\rpt.rpt");
                    //cryRpt.SetParameterValue("Title", em.DocNo);
                    string ReportPath = Path + @"\Closing_Report_Duplicate.rpt";
                    cryRpt.Load(ReportPath);

                    cryRpt.SetParameterValue("@DocNo", DocNumber);
                    cryRpt.SetParameterValue("@SiteID", SystemHelper.Get_SiteID_Session());
                    cryRpt.SetParameterValue("@DivisionID", SystemHelper.Get_DivisionID_Session());
                    cryRpt.SetParameterValue("@PicPath", QRPath);
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
                            if (System.IO.File.Exists(QRPath))
                            {
                                System.IO.File.Delete(QRPath);
                            }
                            return File(stream, "application/pdf");
                        }
                        else
                        {
                            //return File(stream, "application/pdf", FileName + ".pdf");
                            //File.Delete(QRPath);
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
        //==============Display Doc Look up Data===================
        [HttpPost]
        public JsonResult Get_DoLokupdata(OB_EditMode rs)
        {
            try
            {
                return Json(dblayer.get_DocrecordLokup(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Get Consultancy and First Aid Data=============
        [HttpPost]
        public JsonResult Get_CF(OB_EditMode DM)
        {
            try
            {
                Result = dblayer.get_CF(DM);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "List Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }

        //=============Display Doc Data Get By ID================
        [HttpPost]
        public JsonResult Get_dataid(OB_EditMode rs)
        {
            try
            {
                return Json(dblayer.get_recordid(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Display Document Data Get By ID If Consultancy Fa Session Or DocPayment Not Available================
        [HttpPost]
        public JsonResult Get_dataNaById(OB_EditMode rs)
        {
            try
            {
                return Json(dblayer.get_Narecordid(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Display Rs Note Data Get By ID================
        [HttpPost]
        public JsonResult Get_RsNotdataid(OB_EditMode rs)
        {
            try
            {
                return Json(dblayer.get_RsNoterecordid(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //========Get Rs Note=============
        [HttpPost]
        public JsonResult NoteList()
        {
            try
            {
                Result = dblayer.Get_RsNote_List();
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "RsNote List Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult OBEditView()
        {
            return View();
        }
        //================Final Save Doc Records====================
        [HttpPost]
        public JsonResult AddF_Docrecord(OB_EditMode DM)
        {
            string res = string.Empty;
            try
            {
                dblayer.Add_DCrecord(DM);
                res = "Updated";
            }

            catch (Exception)
            {
                res = "failed";
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //================Ob Close Next Record Enter===================
        [HttpPost]
        public JsonResult AddOb_Closerecord(OB_EditMode DM)
        {
            string res = string.Empty;
            try
            {
                dblayer.Add_Closerecord(DM);
                res = "Inserted";
            }

            catch (Exception)
            {
                res = "failed";
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //==================For Closing Report OB Insert=======================
        [HttpPost]
        public JsonResult RptAddF_Docrecord(OB_EditMode DM)
        {
            string res = string.Empty;
            try
            {
                dblayer.RptAdd_DCrecord(DM);
                res = "Updated";
            }

            catch (Exception)
            {
                res = "failed";
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //============Delete Record==================
        [HttpPost]
        public JsonResult OnDelete(OB_EditMode DM)
        {
            string res = string.Empty;
            if (DM.DocNo != "")
            {
                dblayer.deletedata(DM);
                res = "Delete";
            }
            else
            {
                res = "failed";
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}