using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using Clinic_Proj.Models;
using Newtonsoft.Json;
using CrystalDecisions.CrystalReports.Engine;
using Clinic_Proj.Database_Access;
using QRCoder;
using System.Drawing;
using System.IO;

namespace Clinic_Proj.Controllers
{
    [Authorize]
    public class RegisterationController : Controller
    {
        string Result = null;
        Clinic_Proj.Database_Access.NewRegdb dblayer = new Clinic_Proj.Database_Access.NewRegdb();
        string res = string.Empty;
        DataTable dt = new DataTable();
        // GET: Registeration
        public ActionResult RegNew()
        {
            return View();
        }
        //===========If Patient Cannot Provide CNIC=================
        public JsonResult get_Pat_CNIC()
        {
            try
            {
                Result = dblayer.get_PatCNIC();
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "New Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //==================Button Clicking===============
        //=============Create New Token============
        [HttpPost]
        public JsonResult Get_NewTknbyid(string CNIC, string Relation)
        {
            try
            {
                if (Relation.Equals(null) || Relation.Equals(""))
                {
                    Relation = "Self";
                }
                else
                {

                }
                return Json(dblayer.get_NewTokenbyid(CNIC, Relation), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=================Info Transfer to Self Button==============
        [HttpPost]
        public JsonResult Get_InfoTrasfrid(NewRegModel rs)
        {
            try
            {
                return Json(dblayer.get_InfoTrnsfrbyid(rs), JsonRequestBehavior.AllowGet);
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
        //=============Get Doctor Name======================
        [HttpPost]
        public JsonResult Get_DoctorName(NewRegModel rs)
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
        //==============Doctor data Get By id=================
        [HttpPost]
        public JsonResult Get_databyid(NewRegModel rs)
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
        //==============Doctor Names=================
        [HttpPost]
        public JsonResult Get_dataNames(NewRegModel rs)
        {
            try
            {
                return Json(dblayer.get_recordDrnam(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Get Payyment Method By ID=================
        [HttpPost]
        public JsonResult Get_Paybyid(string Payid)
        {
            try
            {
                return Json(dblayer.get_Paybyid(Payid), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Get Bank By id=================
        [HttpPost]
        public JsonResult Get_Bankbyid(string Bankid)
        {
            try
            {
                return Json(dblayer.get_bankbyid(Bankid), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===============Print And Save================
        public JsonResult Print_Rpt(NewRegModel rs)
        {
            try
            {
                //dblayer.Add_record(rs);
                //res = "Inserted";
                ReportDocument cryRpt = new ReportDocument();

                //cryRpt.Load(@"C:\Users\Usman Khalid\Desktop\Barcode Testing\rpt.rpt");
                //cryRpt.SetParameterValue("Title", em.DocNo);

                cryRpt.Load(@"D:\Project\Clinic Reports\rpt_Token_Slip.rpt");
                cryRpt.SetParameterValue("@TokenNo", rs.TokenNo);
                cryRpt.SetParameterValue("@SiteID", rs.SiteID);
                cryRpt.SetDatabaseLogon("sa", "ccpl@jm2021");

                cryRpt.PrintToPrinter(1, true, 0, 0);

                return Json(res, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                res = "QT Header Failed.." + ex.Message;
                return Json(res, JsonRequestBehavior.AllowGet);
            }
        }
        //==========Display All Patient CNIC Lookup================
        [HttpPost]
        public JsonResult GetCNAll_data(NewRegModel rs)
        {
            try
            {
                Result = dblayer.get_CNICLrecord(rs);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "List Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //==============Patient Lookup CNIC Get Data By id=================
        [HttpPost]
        public JsonResult Get_CNdatabyid(NewRegModel rs)
        {
            try
            {
                return Json(dblayer.get_CNrecordbyid(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===============Patient Insert======================
        [HttpPost]
        public JsonResult AddPSelf_record(NewRegModel rs)
        {
            string res = string.Empty;
            try
            {
                dblayer.Add_Selfrecord(rs);
                res = "Inserted";
            }
            catch (Exception)
            {
                res = "Failed";
                throw;
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //===============Patient Update======================
        [HttpPost]
        public JsonResult UpdateComData(NewRegModel rs)
        {
            string res = string.Empty;
            try
            {
                dblayer.Update_Selfrecord(rs);
                res = "Updated";
            }
            catch (Exception)
            {
                res = "Failed";
                throw;
            }
            return Json(res, JsonRequestBehavior.AllowGet);
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
        //===============Fee Data Insert=========================
        [HttpPost]
        public JsonResult Add_Feerecord(NewRegModel rs)
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
        //=====================END========================
        //===========Get Patient Data By CNIC IF Already Available===========
        [HttpPost]
        public JsonResult Get_PatAvailable(NewRegModel rs)
        {
            try
            {  
                if(string.IsNullOrEmpty(rs.CNIC))
                {
                    rs.CNIC = "";
                }
                return Json(dblayer.get_PatAvail(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========Get Panal Patient Data By CNIC IF Already Available===========
        [HttpPost]
        public JsonResult Get_PanlPatAvailable(NewRegModel rs)
        {
            try
            {
                if (string.IsNullOrEmpty(rs.CNIC))
                {
                    rs.CNIC = "";
                }
                return Json(dblayer.get_PanlPatAvail(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========Get Whats App Avail===========
        //[HttpPost]
        //public JsonResult Get_WhatsAppAvailable(NewRegModel rs)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(rs.CNIC))
        //        {
        //            rs.CNIC = "";
        //        }
        //        return Json(dblayer.get_WhatsAppAvail(rs), JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //==================Address Data Delete=============
        [HttpPost]
        public JsonResult Delete_Address(NewRegModel rs)
        {
            try
            {
                string res = string.Empty;
                if (rs.ID != 0)
                {
                    dblayer.deleteAdddata(rs);
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
        //==================Address Data Delete=============
        [HttpPost]
        public JsonResult Delete_Contact(NewRegModel rs)
        {
            try
            {
                string res = string.Empty;
                if (rs.ID != 0)
                {
                    dblayer.deleteContdata(rs);
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
        //==========View All Address Data================
        [HttpPost]
        public JsonResult GetAView_data(NewRegModel rs)
        {
            try
            {
                return Json(dblayer.get_AViewrecord(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==========View All Contact Data================
        [HttpPost]
        public JsonResult GetCView_data(NewRegModel rs)
        {
            try
            {
                return Json(dblayer.get_CViewrecord(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==========View All CNIC Data================
        [HttpPost]
        public JsonResult GetCNView_data(NewRegModel rs)
        {
            try
            {
                return Json(dblayer.get_CNICViewrecord(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==========View All Data================
        [HttpPost]
        public JsonResult GetView_data(NewRegModel rs)
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
        //==============View Address data Get By id=================
        //[HttpPost]
        //public JsonResult Get_Adatabyid(string id)
        //{
        //    try
        //    {
        //        return Json(dblayer.get_Arecordbyid(id), JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //===============Register CNIC Transfer to New Patient Form======================
        [HttpPost]
        public JsonResult Register_CNIC(NewRegModel rs)
        {
            string res = string.Empty;
            try
            {
                res = "Inserted";
                Session["CNIC"] = rs.CNIC;
                Session["TokenType"] = "Walk-In";
            }
            catch (Exception)
            {
                res = "Failed";
                throw;
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //===============Register Panal CNIC Transfer to New Patient Form======================
        [HttpPost]
        public JsonResult RegisterPanal_CNIC(NewRegModel rs)
        {
            string res = string.Empty;
            try
            {
                res = "Inserted";
                Session["CNIC"] = rs.CNIC;
                Session["TokenType"] = "Panal";
            }
            catch (Exception)
            {
                res = "Failed";
                throw;
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //===============Register Panal CNIC Transfer to New Patient Form======================
        //[HttpPost]
        //public JsonResult Register_Panal_CNIC(NewRegModel rs)
        //{
        //    string res = string.Empty;
        //    try
        //    {
        //        res = "Inserted";
        //        Session["PanalCNIC"] = rs.CNIC1;
        //    }
        //    catch (Exception)
        //    {
        //        res = "Failed";
        //        throw;
        //    }
        //    return Json(res, JsonRequestBehavior.AllowGet);
        //}
        //===============Patient Insert======================
        [HttpPost]
        public JsonResult Add_record(NewRegModel rs)
        {
            string res = string.Empty;
            try
            {
                dblayer.Add_record(rs);
                res = "Inserted";
                Session["CNIC"] = rs.CNIC;
            }
            catch (Exception)
            {
                res = "Failed";
                throw;
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //===============Panal Patient Insert======================
        [HttpPost]
        public JsonResult Add_Panalrecord(NewRegModel rs)
        {
            string res = string.Empty;
            try
            {
                dblayer.Add_Panalrecord(rs);
                res = "Inserted";
                Session["CNIC"] = rs.CNIC;
            }
            catch (Exception)
            {
                res = "Failed";
                throw;
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //===============Patient Insert======================
        [HttpPost]
        public JsonResult TrsfrCNData(string CNIC)
        {
            try
            {
                Session["CNIC"] = CNIC;
                Session["TokenType"] = "Walk-In";
                Result = "Done";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        //===============Patient Address Insert======================
        [HttpPost]
        public JsonResult Add_Address(NewRegModel rs)
        {
            string res = string.Empty;
            try
            {
                dblayer.Add_Addressrecord(rs);
                res = "Inserted";
            }
            catch (Exception)
            {
                res = "Failed";
                throw;
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //===============Patient Contact Insert======================
        [HttpPost]
        public JsonResult Add_Contact(NewRegModel rs)
        {
            string res = string.Empty;
            try
            {
                dblayer.Add_Contactrecord(rs);
                res = "Inserted";
            }
            catch (Exception)
            {
                res = "Failed";
                throw;
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //===============Patient Whats App Contact Insert======================
        [HttpPost]
        public JsonResult Add_WContact(NewRegModel rs)
        {
            string res = string.Empty;
            try
            {
                dblayer.Add_WContactrecord(rs);
                res = "Inserted";
            }
            catch (Exception)
            {
                res = "Failed";
                throw;
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //===============Patient CNIC Detail Insert======================
        [HttpPost]
        public JsonResult Add_CNICDet(NewRegModel rs)
        {
            string res = string.Empty;
            try
            {
                dblayer.Add_CNICDetail(rs);
                res = "Inserted";
            }
            catch (Exception)
            {
                res = "Failed";
                throw;
            }
            return Json(res, JsonRequestBehavior.AllowGet);
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
        //===========Display Address Type Data by Dropdown=============
        [HttpPost]
        public JsonResult Get_AddressTyp()
        {
            try
            {
                DataSet ds = dblayer.get_Addressrecord();
                string RtnJS = JsonConvert.SerializeObject(ds.Tables[0]);
                return Json(RtnJS, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========Display Contact Type Data by Dropdown=============
        [HttpPost]
        public JsonResult Get_ContactTyp()
        {
            try
            {
                DataSet ds = dblayer.get_Contactrecord();
                string RtnJS = JsonConvert.SerializeObject(ds.Tables[0]);
                return Json(RtnJS, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}