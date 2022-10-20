using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json;
using Clinic_Proj.Models;

namespace Clinic_Proj.Controllers
{
    [Authorize]
    public class DivisionController : Controller
    {
        Clinic_Proj.Database_Access.Divdb dblayer = new Clinic_Proj.Database_Access.Divdb();
        public ActionResult Division()
        {
            return View();
        }
        //================Insert Division====================
        [HttpPost]
        public JsonResult Add_record(register rs)
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
        //========================Dt All Data Get=============================
        [HttpPost]
        public JsonResult Get_data()
        {
            try
            {
                DataSet ds = dblayer.get_record();
                string RtnJS = JsonConvert.SerializeObject(ds.Tables[0]);
                return Json(RtnJS, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //=================Display Division record by id=================
        [HttpPost]
        public JsonResult Get_databyid(register rs)
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

        //================Update Division records====================
        [HttpPost]
        public JsonResult update_record(register rs)
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
        //============Delete Division==================
        [HttpPost]
        public JsonResult OnDelete(register rs)
        {
            string res = string.Empty;
            if (rs.DivisionCode != null && rs.DivisionCode != "")
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