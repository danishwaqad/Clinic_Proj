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
    public class AddVitalController : Controller
    {
        Clinic_Proj.Database_Access.AddVitalDb dblayer = new Clinic_Proj.Database_Access.AddVitalDb();
        public ActionResult AddVitalList()
        {
            return View();
        }
        //==============Vital Data Insert==================
        [HttpPost]
        public JsonResult Add_Vital(AddVital rs)
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
        //===========Display All patient Data by lookup=============
        [HttpPost]
        public JsonResult Get_data()
        {
            try
            {
                DataSet rs = dblayer.get_record();
                string RtnJS = JsonConvert.SerializeObject(rs.Tables[0]);
                return Json(RtnJS, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Patient Get Data By ID=================
        [HttpPost]
        public JsonResult Get_databyid(AddVital rs)
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
        //===============Vital Data Update=============
        [HttpPost]
        public JsonResult update_record(AddVital rs)
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
        //============Delete Vitals===============
        [HttpPost]
        public JsonResult OnDelete(AddVital rs)
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
        //===============Get Vital ID==============
        [HttpPost]
        public JsonResult Get_VitalID()
        {
            DataSet ds = dblayer.Generate_Vital_ID();
            return Json(ds.Tables[0].Rows[0][0].ToString(), JsonRequestBehavior.AllowGet);
        }
    }
}