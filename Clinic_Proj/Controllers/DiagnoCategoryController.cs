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

namespace Clinic_Proj.Controllers
{
    public class DiagnoCategoryController : Controller
    {
        // GET: DiagnoCategory
        string Result = "";
        Clinic_Proj.Database_Access.DiagCategDb dblayer = new Clinic_Proj.Database_Access.DiagCategDb();
        public ActionResult DiagnoCategory()
        {
            return View();
        }
        //=============Header Data Insert=================
        [HttpPost]
        public JsonResult Add_HeadRecrd(DiagCategMode rs)
        {
            string res = string.Empty;
            try
            {
                dblayer.Add_Headerecord(rs);
                res = "Inserted";
            }
            catch (Exception)
            {
                res = "Failed";
                throw;
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //=============Diagnose Data Insert=================
        [HttpPost]
        public JsonResult Add_DisRecrd(DiagCategMode rs)
        {
            string res = string.Empty;
            try
            {
                dblayer.Add_Diagrecord(rs);
                res = "Inserted";
            }
            catch (Exception)
            {
                res = "Failed";
                throw;
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //=============Get Header ID================
        [HttpPost]
        public JsonResult Get_HeadID()
        {
            try
            {
                DataSet rs = dblayer.Header_ID();
                string RtnJS = JsonConvert.SerializeObject(rs.Tables[0]);
                return Json(RtnJS, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Get Diagnose ID================
        [HttpPost]
        public JsonResult Get_DiagID()
        {
            try
            {
                DataSet rs = dblayer.Diagnose_ID();
                string RtnJS = JsonConvert.SerializeObject(rs.Tables[0]);
                return Json(RtnJS, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=======Display Header All Data By lookup=================
        [HttpPost]
        public JsonResult Get_Headdata()
        {
            try
            {
                DataSet rs = dblayer.getHead_record();
                string RtnJS = JsonConvert.SerializeObject(rs.Tables[0]);
                return Json(RtnJS, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=======Display Diagnose All Data By lookup=================
        [HttpPost]
        public JsonResult Get_Disdata(DiagCategMode rs)
        {
            try
            {
                Result = dblayer.getDis_record(rs);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //============Header Data Get By ID============
        [HttpPost]
        public JsonResult Get_Headbyid(DiagCategMode rs)
        {
            try
            {
                return Json(dblayer.get_Headbyid(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //============Diagnose Data Get By ID============
        [HttpPost]
        public JsonResult Get_Disdatabyid(DiagCategMode rs)
        {
            try
            {
                return Json(dblayer.get_Disbyid(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========Delete Header=============
        [HttpPost]
        public JsonResult OnHeadDelete(DiagCategMode rs)
        {
            try
            {
                string res = string.Empty;
                if (rs.ID != "")
                {
                    dblayer.deleteHeaddata(rs);
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
        //===========Delete Diagnose=============
        [HttpPost]
        public JsonResult OnDisDelete(DiagCategMode rs)
        {
            try
            {
                string res = string.Empty;
                if (rs.ID != "")
                {
                    dblayer.deleteDisdata(rs);
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
        public JsonResult Get_DiagnoseViewdataByid(DiagCategMode rs)
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
    }
}