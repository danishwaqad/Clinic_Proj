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
    public class ClosingRptController : Controller
    {
        // GET: ClosingRpt
        DataTable dt = new DataTable();
        public ActionResult ClosingRpt()
        {
            return View();
        }
        string Result;
        Clinic_Proj.Database_Access.ClosingRptDb dblayer = new Clinic_Proj.Database_Access.ClosingRptDb();
        public ActionResult Print_Document_Rpt(string DocNo, string SiteID)
        {
            try
            {
                //=============Print=========
                dt = SystemHelper.Business_Setting();
                if (dt.Rows.Count > 0)
                {
                    //===============Generate and Save QR Code Image===========
                    string p = dt.Rows[0]["QRCodePath"].ToString().Trim();

                    string QRPath = p + @"\Clinic_" + DocNo + ".bmp";

                    //string QRPath = @"\\192.168.201.69\CCPL Documents\QRCode\Clinic_" + DocNumber + ".bmp";
                    QRCodeGenerator.ECCLevel eccLevel = QRCodeGenerator.ECCLevel.L;
                    using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                    using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(DocNo, eccLevel))

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
                    string FileName = DocNo;
                    //ReportDocument cryRpt = new ReportDocument();

                    //cryRpt.Load(@"C:\Users\Usman Khalid\Desktop\Barcode Testing\rpt.rpt");
                    //cryRpt.SetParameterValue("Title", em.DocNo);
                    string ReportPath = Path + @"\Closing_Report_Duplicate.rpt";
                    cryRpt.Load(ReportPath);

                    cryRpt.SetParameterValue("@DocNo", DocNo);
                    cryRpt.SetParameterValue("@SiteID", SiteID);
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
    }
}