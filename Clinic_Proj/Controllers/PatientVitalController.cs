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
    public class PatientVitalController : Controller
    {
        Clinic_Proj.Database_Access.PatVitalDb dblayer = new Clinic_Proj.Database_Access.PatVitalDb();
        string Result;
        // GET: PatientVital
        public ActionResult PatientVital()
        {
            return View();
        }
        //=============Insert Vital Data=======================
        [HttpPost]
        public JsonResult Add_Vital(PatientVitalMode rs)
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
        //===============Display All Data By Token Lookup=====================
        [HttpPost]
        public JsonResult Get_data(PatientVitalMode rs)
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
        //=================Display View All Vital Data===================
        [HttpPost]
        public JsonResult Get_Viewdata(PatientVitalMode rs)
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

        //=============Patient Data Get By ID==========================
        [HttpPost]
        public JsonResult Get_databyid(PatientVitalMode rs)
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
        //===================View Vital Data Get By ID==========================
        [HttpPost]
        public JsonResult Get_Viewdatabyid(PatientVitalMode rs)
        {
            try
            {
                return Json(dblayer.get_Viewrecordbyid(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===============Update Vital Data==========================
        [HttpPost]
        public JsonResult update_record(PatientVitalMode rs)
        {
            string res = string.Empty;
            try
            {
                dblayer.update_record(rs);
                res = "Updated";
            }
            catch (Exception ex)
            {
                res = "failed";
                throw ex;
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //==================Delete Vital Name And Value===============
        [HttpPost]
        public JsonResult OnDelete(PatientVitalMode rs)
        {
            string res = string.Empty;
            if ((rs.TokenNo != null && rs.TokenNo != "" ) && (rs.VitalName != "" && rs.VitalName != null))
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
        //=======================Get Vital List===============
        [HttpPost]
        public JsonResult Get_PatVitalNam()
        {
            try
            {
                DataSet ds = dblayer.get_PatVital();
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