using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using Clinic_Proj.Models;
using Newtonsoft.Json;

namespace Clinic_Proj.Controllers
{
    [Authorize]
    public class DoctorRegController : Controller
    {
        Clinic_Proj.Database_Access.DrRegdb dblayer = new Clinic_Proj.Database_Access.DrRegdb();
        public ActionResult DoctorReg()
        {

            return View();
        }
        //==================Insert Dr Data=======================
        [HttpPost]
        public JsonResult Add_record(DoctorRegisterModel rs)
        {
            string res = string.Empty;
            try
            {
                dblayer.Add_record(rs);
                res = "Inserted";
            }
            catch (Exception ex)
            {
                res = "Failed";
                throw ex;
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //==================Insert Dr Share=======================
        [HttpPost]
        public JsonResult Add_Sharerecord(DoctorRegisterModel rs)
        {
            string res = string.Empty;
            try
            {
                dblayer.Add_shareRecord(rs);
                res = "Inserted";
            }
            catch (Exception ex)
            {
                res = "Failed";
                throw ex;
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //=============Display Doctor Data By LookUp=================
        [HttpPost]
        public JsonResult Get_data(DoctorRegisterModel rs)
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
        //==============Doctor Data Get By ID=========================
        [HttpPost]
        public JsonResult Get_databyid(DoctorRegisterModel rs)
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
        //===================Auto Get Dr ID============================
        [HttpPost]
        public JsonResult Get_DrID()
        {
            try
            {
                DataSet ds = dblayer.Generate_Doctor_ID();
                string RtnJS = JsonConvert.SerializeObject(ds.Tables[0]);
                return Json(RtnJS, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===============Get Dr shift LookUp Data=====================
        [HttpPost]
        public JsonResult Get_DrdataShift()
        {
            try
            {
                DataSet ds = dblayer.get_DrShift();
                string RtnJS = JsonConvert.SerializeObject(ds.Tables[0]);
                return Json(RtnJS, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===============Get Dr Share LookUp Data=====================
        [HttpPost]
        public JsonResult Get_DrdataShare()
        {
            try
            {
                DataSet ds = dblayer.get_DrShare();
                string RtnJS = JsonConvert.SerializeObject(ds.Tables[0]);
                return Json(RtnJS, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==================Display Dr Type Data By lookup==================
        [HttpPost]
        public JsonResult Get_DrdataType()
        {
            try
            {
                DataSet ds = dblayer.get_DrType();
                string RtnJS = JsonConvert.SerializeObject(ds.Tables[0]);
                return Json(RtnJS, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //================Update Dr Data==============================
        [HttpPost]
        public JsonResult update_record(DoctorRegisterModel rs)
        {
            string res = string.Empty;
            try
            {
                dblayer.update_record(rs);
                res = "Updated";
            }
            catch (Exception)
            {
                res = "failed";
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //================Delete Doctor=============================
        [HttpPost]
        public JsonResult OnDelete(DoctorRegisterModel rs)
        {
            string res = string.Empty;
            dblayer.deletedata(rs);
            res = "Delete";
            RedirectToAction("DoctorReg");
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}