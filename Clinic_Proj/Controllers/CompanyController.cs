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
    public class CompanyController : Controller
    {
        Clinic_Proj.Database_Access.CompanyDb dblayer = new Clinic_Proj.Database_Access.CompanyDb();
        // GET: Company
        public ActionResult Company()
        {
            return View();
        }
        //==================Insert Company Data=======================
        [HttpPost]
        public JsonResult Add_record(CompanyMode rs)
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
        //=============Display Company Data By LookUp=================
        [HttpPost]
        public JsonResult Get_data()
        {
            try
            {
                DataSet rs = dblayer.get_record();
                string RtnJS = JsonConvert.SerializeObject(rs.Tables[0]);
                var tt = Json(RtnJS, JsonRequestBehavior.AllowGet);
                tt.MaxJsonLength = int.MaxValue;
                return tt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Display Class Data By LookUp=================
        [HttpPost]
        public JsonResult Get_Classdata()
        {
            try
            {
                DataSet ds = dblayer.get_Classrecord();
                string RtnJS = JsonConvert.SerializeObject(ds.Tables[0]);
                return Json(RtnJS, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Company Data Get By ID=========================
        [HttpPost]
        public JsonResult Get_databyid(CompanyMode rs)
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
        //===================Auto Get Company ID============================
        [HttpPost]
        public JsonResult Get_CompID()
        {
            try
            {
                DataSet ds = dblayer.Generate_Company_ID();
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
        public JsonResult update_record(CompanyMode rs)
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
        //================Delete Company=============================
        [HttpPost]
        public JsonResult OnDelete(CompanyMode rs)
        {
            string res = string.Empty;
            dblayer.deletedata(rs);
            res = "Delete";
            RedirectToAction("Company");
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}