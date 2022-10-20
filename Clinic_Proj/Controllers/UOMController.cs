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
    public class UOMController : Controller
    {
        Clinic_Proj.Database_Access.UOMDb dblayer = new Clinic_Proj.Database_Access.UOMDb();
        // GET: UOM
        public ActionResult UOM()
        {
            return View();
        }
        //==============Item Data Insert==================
        [HttpPost]
        public JsonResult Add_UOM(UOMModel rs)
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
        //===========Display All UOM Data by lookup=============
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
        //=============UOM Get Data By ID=================
        [HttpPost]
        public JsonResult Get_databyid(string id)
        {
            try
            {
                return Json(dblayer.get_recordbyid(id), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===============UOM Data Update=============
        [HttpPost]
        public JsonResult update_record(UOMModel rs)
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
        //============Delete UOM===============
        [HttpPost]
        public JsonResult OnDelete(int ID)
        {
            string res = string.Empty;
            if (ID != 0)
            {
                dblayer.deletedata(ID);
                res = "Delete";
            }
            else
            {
                res = "failed";
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //===============Get UOM ID==============
        [HttpPost]
        public JsonResult Get_UOMID()
        {
            DataSet ds = dblayer.Generate_UOM_ID();
            return Json(ds.Tables[0].Rows[0][0].ToString(), JsonRequestBehavior.AllowGet);
        }
    }
}