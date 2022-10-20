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
    [Authorize]
    public class FirstAidSetupController : Controller
    {
        Clinic_Proj.Database_Access.FirstAidSetDb dblayer = new Clinic_Proj.Database_Access.FirstAidSetDb();
        // GET: FirstAdd
        public ActionResult FirstAidSetup()
        {
            return View();
        }
        //===============Get First Aid ID==============
        [HttpPost]
        public JsonResult Get_FirstAidID()
        {
            DataSet ds = dblayer.get_record();
            return Json(ds.Tables[0].Rows[0][0].ToString(), JsonRequestBehavior.AllowGet);
        }
        //===================First Aid Insert==============
        [HttpPost]
        public JsonResult Add_Record(FirstAidSetup rs)
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
        //===========Display All Service Name By lookUp==============
        [HttpPost]
        public JsonResult Get_data()
        {
            try
            {
                DataSet rs = dblayer.get_Lookuprecord();
                string RtnJS = JsonConvert.SerializeObject(rs.Tables[0]);
                return Json(RtnJS, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //============Get Service Name By ID===========
        [HttpPost]
        public JsonResult Get_databyid(FirstAidSetup rs)
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
        //==========Display Charge Type By Lookup==========
        [HttpPost]
        public JsonResult Get_Charge()
        {
            try
            {
                DataSet ds = dblayer.get_Char_record();
                string RtnJS = JsonConvert.SerializeObject(ds.Tables[0]);
                return Json(RtnJS, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //==========Get Charge Type By ID====================
        [HttpPost]
        public JsonResult Get_Charbyid(string id)
        {
            try
            {
                return Json(dblayer.get_Charbyid(id), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========Display All Services By LookUp============
        [HttpPost]
        public JsonResult Get_Service()
        {
            try
            {
                DataSet ds = dblayer.get_Serv_record();
                string RtnJS = JsonConvert.SerializeObject(ds.Tables[0]);
                return Json(RtnJS, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Get Service Type By ID=============
        [HttpPost]
        public JsonResult Get_Serbyid(string id)
        {
            try
            {
                return Json(dblayer.get_Serbyid(id), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //============First Aid Update=============
        [HttpPost]
        public JsonResult update_record(FirstAidSetup rs)
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
        //==========First Aid Delete============
        [HttpPost]
        public JsonResult OnDelete(FirstAidSetup rs)
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
    }
}