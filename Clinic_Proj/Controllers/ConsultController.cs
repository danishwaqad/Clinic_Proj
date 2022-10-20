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
    public class ConsultController : Controller
    {
        Clinic_Proj.Database_Access.ConsultDb dblayer = new Clinic_Proj.Database_Access.ConsultDb();
        // GET: FirstAdd
        string Result = "";
        DataTable dt = new DataTable();
        //APIdb Obj = new APIdb();
        public ActionResult Consultancy()
        {
            return View();
        }
        //Display Diagnose 2 
        [HttpPost]
        public JsonResult Get_DiagnoseViewdata()
        {
            try
            {
                string Rtn = dblayer.GetDiagnose2();
                return Json(Rtn, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "List Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //Display Diagnose 2 Data By ID 
        [HttpPost]
        public JsonResult Get_DiagnoseViewdataByid(ConsultModel rs)
        {
            try
            {
                Result = dblayer.GetDiagnose2Byid(rs);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "List Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //==============Display Patient Token All Data===================
        [HttpPost]
        public JsonResult Get_data(ConsultModel rs)
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
        //===============Print PDR Report for History==================
        //[HttpPost]
        //public ActionResult Print_Slip(ConsultModel dm)
        //{
        //    try
        //    {
        //        //=============Print=========
        //        dt = SystemHelper.Business_Setting();
        //        if (dt.Rows.Count > 0)
        //        {
        //            string Path = dt.Rows[0]["ReportPath"].ToString().Trim();
        //            string dbID = dt.Rows[0]["dbID"].ToString().Trim();
        //            string dbPass = dt.Rows[0]["dbPass"].ToString().Trim();
        //            ReportDocument cryRpt = new ReportDocument();

        //            string ReportFormat = "pdf";
        //            string FileName = dm.TokenNo;
        //            //ReportDocument cryRpt = new ReportDocument();

        //            //cryRpt.Load(@"C:\Users\Usman Khalid\Desktop\Barcode Testing\rpt.rpt");
        //            //cryRpt.SetParameterValue("Title", em.DocNo);
        //            string ReportPath = Path + @"\rpt_Prescription.rpt";
        //            cryRpt.Load(ReportPath);

        //            cryRpt.SetParameterValue("@TokenNo", dm.TokenNo);
        //            cryRpt.SetParameterValue("@SiteID", dm.SiteID);
        //            //cryRpt.SetDatabaseLogon("sa", "ccpl@jm2021");
        //            cryRpt.SetDatabaseLogon(dbID, dbPass, "HMS_CCPL", "CCPL_HMS");

        //            Response.Buffer = false;
        //            Response.ClearContent();
        //            Response.ClearHeaders();

        //            Stream stream = null;

        //            if (ReportFormat == "Excel")
        //            {
        //                stream = cryRpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.ExcelRecord);
        //                stream.Seek(0, SeekOrigin.Begin);
        //                return File(stream, "application/xml", FileName + ".xls");

        //            }
        //            else
        //            {
        //                //stream = cryRpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        //                //stream.Seek(0, SeekOrigin.Begin);
        //                //return File(stream, "application/pdf");
        //                stream = cryRpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        //                stream.Seek(0, SeekOrigin.Begin);
        //                if (string.IsNullOrEmpty(FileName))
        //                {
        //                    return File(stream, "application/pdf");
        //                }
        //                else
        //                {
        //                    return File(stream, "application/pdf", FileName + ".pdf");
        //                }
        //            }
        //        }
        //        else
        //        {
        //            return File("", "application/pdf");
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Result = "PDR Doc Print Error.." + ex.Message;
        //        return Json(Result, JsonRequestBehavior.AllowGet);
        //    }
        //}
        //========================Session Working==================
        //===================Display Session All Data===================
        [HttpPost]
        public JsonResult Get_Sessiondata(ConsultModel rs)
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
        //===================Display Session History All Data===================
        [HttpPost]
        public JsonResult Get_SessiondataHist(ConsultModel rs)
        {
            try
            {
                return Json(dblayer.get_SessionHistViewrecord(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===================Display Activity Session All Data===================
        [HttpPost]
        public JsonResult Get_SessionActdata(ConsultModel rs)
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
        //==============Display Session Activity Lookup===================
        [HttpPost]
        public JsonResult GetSesionAct_data(ConsultModel rs)
        {
            try
            {
                return Json(dblayer.getSA_record(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Display Medication Enable and Disbale Button Data===================
        [HttpPost]
        public JsonResult GetEnable_Data(ConsultModel rs)
        {
            try
            {
                string Rtn = dblayer.GetEnable_record(rs);
                return Json(Rtn, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "List Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //==================Session Data Insert==================
        [HttpPost]
        public JsonResult Add_SessionRecrd(ConsultModel rs)
        {
            string res = string.Empty;
            try
            {
                dblayer.Add_Sessionrecord(rs);
                res = "Inserted";
            }
            catch (Exception)
            {
                res = "Failed";
                throw;
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //==================Session Activity Data Insert==================
        [HttpPost]
        public JsonResult Add_SessionActRecrd(ConsultModel rs)
        {
            string res = string.Empty;
            try
            {
                dblayer.Add_ActSessionrecord(rs);
                res = "Inserted";
            }
            catch (Exception ex)
            {
                res = "Failed";
                throw ex;
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //==============Session Data Delete============== 
        [HttpPost]
        public JsonResult OnSessionDelete(ConsultModel rs)
        {
            try
            {
                string res = string.Empty;
                if (rs.TokenNo != "")
                {
                    dblayer.deleteSessiondata(rs);
                    res = "Delete";
                }
                else
                {
                    res = "failed";
                }
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Session Act Data Delete============== 
        [HttpPost]
        public JsonResult OnSessionActDelete(ConsultModel rs)
        {
            try
            {
                string res = string.Empty;
                if (rs.TokenNo != "")
                {
                    dblayer.deleteSessionActdata(rs);
                    res = "Delete";
                }
                else
                {
                    res = "failed";
                }
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=========================================================
        public ActionResult Print_Slip_Test(string TokenNo)
        {
            try
            {
                //=============Print=========
                dt = SystemHelper.Business_Setting();
                if (dt.Rows.Count > 0)
                {
                    //===============Generate and Save QR Code Image===========
                    Random rd = new Random();
                    int num = rd.Next();
                    string NewName = num.ToString();
                    string p = dt.Rows[0]["QRCodePath"].ToString().Trim();
                    //string QRPath = @"\\192.168.203.69\CCPL Documents\QRCode\Clinic_" + NewName + ".bmp";
                    string QRPath = p + @"\Clinic_" + NewName + ".bmp";
                    QRCodeGenerator.ECCLevel eccLevel = QRCodeGenerator.ECCLevel.L;
                    using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                    using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(TokenNo, eccLevel))

                    using (QRCode qrCode = new QRCode(qrCodeData))
                    {

                        int Pixel = 20;
                        var PrimaryColor = System.Drawing.Color.Black;
                        var BackgrounColor = System.Drawing.Color.White;
                        Bitmap bitmap = qrCode.GetGraphic(Pixel, PrimaryColor, BackgrounColor, null, 0);
                        //bitmap.Save(path, ImageFormat.Bmp);
                        //bitmap.Save(Server.MapPath("~/Uploads/") + "Test.bmp", System.Drawing.Imaging.ImageFormat.Bmp);

                        bitmap.Save(QRPath, System.Drawing.Imaging.ImageFormat.Bmp);
                    }
                    //===============Generate Report===========
                    string Path = dt.Rows[0]["ReportPath"].ToString().Trim();
                    string dbID = dt.Rows[0]["dbID"].ToString().Trim();
                    string dbPass = dt.Rows[0]["dbPass"].ToString().Trim();
                    ReportDocument cryRpt = new ReportDocument();

                    string ReportFormat = "pdf";
                    string FileName = TokenNo;
                    //ReportDocument cryRpt = new ReportDocument();

                    //cryRpt.Load(@"C:\Users\Usman Khalid\Desktop\Barcode Testing\rpt.rpt");
                    //cryRpt.SetParameterValue("Title", em.DocNo);
                    string ReportPath = Path + @"\rpt_Prescription.rpt";
                    cryRpt.Load(ReportPath);
                    cryRpt.SetParameterValue("@PicPath", QRPath);
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
        //Witout QR Code Print
        //public ActionResult Print_Slip_Test(string TokenNo)
        //{
        //    try
        //    {
        //        //=============Print=========
        //        dt = SystemHelper.Business_Setting();
        //        if (dt.Rows.Count > 0)
        //        {
        //            string Path = dt.Rows[0]["ReportPath"].ToString().Trim();
        //            string dbID = dt.Rows[0]["dbID"].ToString().Trim();
        //            string dbPass = dt.Rows[0]["dbPass"].ToString().Trim();
        //            ReportDocument cryRpt = new ReportDocument();

        //            string ReportFormat = "pdf";
        //            string FileName = TokenNo;
        //            //ReportDocument cryRpt = new ReportDocument();

        //            //cryRpt.Load(@"C:\Users\Usman Khalid\Desktop\Barcode Testing\rpt.rpt");
        //            //cryRpt.SetParameterValue("Title", em.DocNo);
        //            string ReportPath = Path + @"\rpt_Prescription.rpt";
        //            cryRpt.Load(ReportPath);

        //            cryRpt.SetParameterValue("@TokenNo", TokenNo);
        //            cryRpt.SetParameterValue("@SiteID", SystemHelper.Get_SiteID_Session());
        //            //cryRpt.SetParameterValue("@DocDate", DateTime.Now);
        //            //cryRpt.SetDatabaseLogon("sa", "ccpl@jm2021");
        //            cryRpt.SetDatabaseLogon(dbID, dbPass, "HMS_CCPL", "CCPL_HMS");

        //            Response.Buffer = false;
        //            Response.ClearContent();
        //            Response.ClearHeaders();

        //            Stream stream = null;

        //            if (ReportFormat == "Excel")
        //            {
        //                stream = cryRpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.ExcelRecord);
        //                stream.Seek(0, SeekOrigin.Begin);
        //                return File(stream, "application/xml", FileName + ".xls");

        //            }
        //            else
        //            {
        //                //stream = cryRpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        //                //stream.Seek(0, SeekOrigin.Begin);
        //                //return File(stream, "application/pdf");
        //                stream = cryRpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        //                stream.Seek(0, SeekOrigin.Begin);
        //                if (string.IsNullOrEmpty(FileName))
        //                {
        //                    return File(stream, "application/pdf");
        //                }
        //                else
        //                {
        //                    //return File(stream, "application/pdf", FileName + ".pdf");
        //                    return File(stream, "application/pdf");
        //                }
        //            }
        //        }
        //        else
        //        {
        //            return File("", "application/pdf");
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Result = "PDR Doc Print Error.." + ex.Message;
        //        return Json(Result, JsonRequestBehavior.AllowGet);
        //    }
        //}
        //============Get Patient Data By Token==================
        [HttpPost]
        public JsonResult Get_databyid(ConsultModel rs)
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
        //==============Display Patient Token All Data===================
        [HttpPost]
        public JsonResult Get_Penddata(ConsultModel rs)
        {
            try
            {
                Result = dblayer.get_pendrecord(rs);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "List Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //============Get Patient Data By Token==================
        [HttpPost]
        public JsonResult Get_Penddatabyid(ConsultModel rs)
        {
            try
            {
                return Json(dblayer.get_penrecordbyid(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //================Display Vital View All Data===============
        [HttpPost]
        public JsonResult Get_Viewdata(ConsultModel rs)
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
        //================Display Patient History On Cosultancy===============
        [HttpPost]
        public JsonResult Get_ViewHistdata(ConsultModel rs)
        {
            try
            {
                return Json(dblayer.get_ViewHistrecord(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //================Diagnose Data Insert=========================
        [HttpPost]
        public JsonResult Add_Recrd(ConsultModel rs)
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
        //==============Display Diagnose Data By Lookup===================
        [HttpPost]
        public JsonResult GetDiag_data(ConsultModel rs)
        {
            try
            {
                return Json(dblayer.getDiage_record(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========Diagnose Data Delete====================
        [HttpPost]
        public JsonResult OnDelete(ConsultModel rs)
        {
            try
            {
                string res = string.Empty;
                if (rs.id != 0)
                {
                    dblayer.deletedata(rs);
                    res = "Delete";
                }
                else
                {
                    res = "failed";
                }
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //============Display Diagnose View All Data===================
        [HttpPost]
        public JsonResult Get_ViewDiagdata(ConsultModel rs)
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
        //==============Display Lab Data By Lookup ===================
        [HttpPost]
        public JsonResult GetLab_data(ConsultModel rs)
        {
            try
            {
                return Json(dblayer.getLab_record(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Lab Data Delete============== 
        [HttpPost]
        public JsonResult OnLabDelete(ConsultModel rs)
        {
            try
            {
                string res = string.Empty;
                if (rs.id != 0)
                {
                    dblayer.deleteLabdata(rs);
                    res = "Delete";
                }
                else
                {
                    res = "failed";
                }
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===================Display Lab View All Data===================
        [HttpPost]
        public JsonResult Get_ViewLabdata(ConsultModel rs)
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
        //==================Lab Data Insert==================
        [HttpPost]
        public JsonResult Add_LabRecrd(ConsultModel rs)
        {
            string res = string.Empty;
            try
            {
                dblayer.Add_Lbrecord(rs);
                res = "Inserted";
            }
            catch (Exception)
            {
                res = "Failed";
                throw;
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //======Display Treatment or Service View All Data===============
        [HttpPost]
        public JsonResult GetServ_Viewdata(ConsultModel rs)
        {
            try
            {
                return Json(dblayer.getSer_Viewrecord(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===============Insert Treatment============
        [HttpPost]
        public JsonResult AddSer_Recrd(ConsultModel rs)
        {
            string res = string.Empty;
            try
            {
                dblayer.AddServ_record(rs);
                res = "Inserted";
            }
            catch (Exception)
            {
                res = "Failed";
                throw;
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //==================Treatment or Service Data Delete=============
        [HttpPost]
        public JsonResult OntrtDelete(ConsultModel rs)
        {
            try
            {
                string res = string.Empty;
                if (rs.id != 0)
                {
                    dblayer.deletetrtdata(rs);
                    res = "Delete";
                }
                else
                {
                    res = "failed";
                }
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //===============Display Genric Related Data in Medication With API==============
        //[HttpPost]
        //public JsonResult GetAPI()
        //{
        //    try
        //    {
        //        //Refresh();
        //        DataTable dt = dblayer.GetPath();
        //        WebClient web = new WebClient();
        //        string Server = dt.Rows[0]["ServerName"].ToString();
        //        string APIPath = dt.Rows[0]["APIPath"].ToString();

        //        Result = web.DownloadString(APIPath);

        //        //var Response = await client.GetStringAsync(APIPath);
        //        //client.get

        //        //TEst();
        //        string T = Result.Replace(@"\", string.Empty);
        //        //string qw = "\"";
        //        string W = T.Replace("\"[{", "[{");

        //        string WW = W.Replace(@"}]" + "\"", "}]");

        //        return Json(WW, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        Result = "List Failed.." + ex.Message;
        //        return Json(Result, JsonRequestBehavior.AllowGet);
        //    }
        //}
        [HttpPost]
        public JsonResult GetAPI()
        {
            try
            {
                DataTable dt = dblayer.GetPath();
                string APIPath = dt.Rows[0]["APIPath"].ToString();
                var Result = "";
                string URL = APIPath;
                WebClient webClient = new WebClient();
                webClient.BaseAddress = URL;
                Result = webClient.DownloadString(URL);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "List Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult GetStockAPI()
        {
            try
            {
                string SiteID = "?SiteID=" + SystemHelper.Get_SiteID_Session();
                DataTable dt = dblayer.GetStockPath();
                string APIPath = dt.Rows[0]["APIPath"].ToString();
                var Result = "";
                string URL = APIPath + SiteID;
                WebClient webClient = new WebClient();
                webClient.BaseAddress = URL;

                Result = webClient.DownloadString(URL);
                //Result.max
                //Result = "Test";
                var T = Json(Result, JsonRequestBehavior.AllowGet);
                T.MaxJsonLength = int.MaxValue;
                return T;
                //return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "List Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //========Display Medication By token  View API All Data=================
        [HttpGet]
        public JsonResult Get_PharmacyMedTkn(ConsultModel rs)
        {
            try
            {

                Result = dblayer.get_PharmaMeditknecord(rs);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "Lookup Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //================Insert Medication==============
        [HttpPost]
        public JsonResult Add_Medication(ConsultModel rs)
        {
            string res = string.Empty;
            try
            {
                dblayer.Add_Medicate(rs);
                res = "Inserted";
            }
            catch (Exception ex)
            {
                res = "Failed";
                throw ex;
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //============Display Medication View All Data==============
        [HttpPost]
        public JsonResult GetMed_Viewdata(ConsultModel rs)
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
        //=============For Delete Medication==================
        [HttpPost]
        public JsonResult OnMediDelete(ConsultModel rs)
        {
            try
            {
                string res = string.Empty;
                if (rs.id != 0)
                {
                    dblayer.deleteMeddata(rs);
                    res = "Delete";
                }
                else
                {
                    res = "failed";
                }
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===============For Follow Up Delete================== 
        [HttpPost]
        public JsonResult OnFolowDelete(ConsultModel rs)
        {
            try
            {
                string res = string.Empty;
                if (rs.id != 0)
                {
                    dblayer.deleteFolowdata(rs);
                    res = "Delete";
                }
                else
                {
                    res = "failed";
                }
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //====================Display Follow View All Data===============
        [HttpPost]
        public JsonResult Get_ViewFolowdata(ConsultModel rs)
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
        //=================Follow Up Data Insert=================
        [HttpPost]
        public JsonResult Add_FolowRecrd(ConsultModel rs)
        {
            string res = string.Empty;
            try
            {
                dblayer.Add_FolRecrd(rs);
                res = "Inserted";
            }
            catch (Exception)
            {
                res = "Failed";
                throw;
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //===========Display All Services By lookup=============
        [HttpPost]
        public JsonResult Get_Servicedata()
        {
            try
            {
                DataSet rs = dblayer.get_Servrecord();
                string RtnJS = JsonConvert.SerializeObject(rs.Tables[0]);
                return Json(RtnJS, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        ////==========Display All Service Name Or Treatement==============
        //[HttpPost]
        //public JsonResult Get_Servicedata(ConsultModel rs)
        //{
        //    try
        //    {
        //        return Json(dblayer.get_Servrecord(rs), JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //=========Display Medicine Type Related Data================= 
        [HttpPost]
        public JsonResult Get_TypeMed()
        {
            try
            {
                DataSet ds = dblayer.get_MediTyprecord();
                string RtnJS = JsonConvert.SerializeObject(ds.Tables[0]);
                return Json(RtnJS, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //============Display Medicine Sub Type Related Data=============== 
        [HttpPost]
        public JsonResult Get_SubTypMed(string TypeID)
        {
            try
            {
                return Json(dblayer.get_MediSbTyprecord(TypeID), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //============Get SubType For Enable Disable TextBoxes=============== 
        [HttpPost]
        public JsonResult Get_EnableText(ConsultModel rs)
        {
            try
            {

                Result = dblayer.get_MediSbTypEnbRecord(rs);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "Lookup Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //============Get SubType For Enable Disable Urdu Text=============== 
        [HttpPost]
        public JsonResult Get_EnableUrduText(ConsultModel rs)
        {
            try
            {

                Result = dblayer.get_MediSbUrduEnbRecord(rs);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "Lookup Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //=====================After Enter Days then its count days In Urdu text=================
        [HttpPost]
        public JsonResult Get_DosageID(double urducnt)
        {
            try
            {
                return Json(dblayer.get_Dsogerecord(urducnt), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //============Display Service Name By Lookup===============
        [HttpPost]
        public JsonResult Get_Servdatabyid(ConsultModel rs)
        {
            try
            {
                return Json(dblayer.get_Servrecordbyid(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==================Next Token===================
        [HttpPost]
        public JsonResult Add_Nxt_tkn_Recrd(ConsultModel rs)
        {
            string res = string.Empty;
            try
            {
                dblayer.Add_Queue_record(rs);
                res = "Inserted";
            }
            catch (Exception)
            {
                res = "Failed";
                throw;
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        //==================Check Doctor===================
        [HttpPost]
        public JsonResult Check(ConsultModel rs)
        {
            string res = string.Empty;
            try
            {
                string LoginType = SystemHelper.LoginType;
                if (LoginType.Contains("Doctor"))
                {
                    res = "Done";
                    dblayer.Get_Dr_ID(rs);
                }
                else
                {
                    res = "Failed";
                }
            }
            catch (Exception)
            {
                res = "Failed";
                throw;
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        //Display All Shifts
        //[HttpPost]
        //public JsonResult Get_ShiftMEN()
        //{

        //    DataSet ds = dblayer.get_Shifts();

        //    List<ConsultModel> listrs = new List<ConsultModel>();

        //    foreach (DataRow dr in ds.Tables[0].Rows)
        //    {
        //        listrs.Add(new ConsultModel
        //        {
        //            Frequency = dr["Frequency"].ToString()
        //        });
        //    }
        //    return Json(listrs, JsonRequestBehavior.AllowGet);
        //}
        //Display all Genric Related data USman code direct to database
        //[HttpPost]
        //public JsonResult Get_GenricMed()
        //{
        //    try
        //    {
        //        DataSet ds = dblayer.get_GenricTyprecord();
        //        string RtnJS = JsonConvert.SerializeObject(ds.Tables[0]);
        //        //string Result = RtnJS;
        //        return Json(RtnJS, JsonRequestBehavior.AllowGet);
        //        //return

        //        //List<ConsultModel> listrs = new List<ConsultModel>();

        //        //foreach (DataRow dr in ds.Tables[0].Rows)
        //        //{
        //        //    listrs.Add(new ConsultModel
        //        //    {
        //        //        GenricNam = dr["GenericName"].ToString()
        //        //    });
        //        //}
        //        //return Json(listrs, JsonRequestBehavior.AllowGet);
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    } 
        //}
        //Display all Service data
        //[HttpPost]
        //public JsonResult Get_Servicedata()
        //{

        //    DataSet ds = dblayer.get_Servrecord();

        //    List<FirstAddModal> listrs = new List<FirstAddModal>();

        //    foreach (DataRow dr in ds.Tables[0].Rows)
        //    {
        //        listrs.Add(new FirstAddModal
        //        {
        //            ServiceName = dr["ServiceName"].ToString(),
        //            //ServiceDesc = dr["ServiceDesc"].ToString(),
        //            //ServiceType = dr["ServiceType"].ToString()
        //        });
        //    }
        //    return Json(listrs, JsonRequestBehavior.AllowGet);
        //}

        // Display View records by id
        //[HttpPost]
        //public JsonResult Get_Viewdatabyid(string id)
        //{
        //    DataSet dS = dblayer.get_Viewrecordbyid(id);
        //    DataTable dt = dS.Tables[0];
        //    string Result = JsonConvert.SerializeObject(dt);
        //    return Json(Result, JsonRequestBehavior.AllowGet);
        //}
        // Update records
        //[HttpPost]
        //public JsonResult update_record(FeeRefundModel rs)
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
    }
}