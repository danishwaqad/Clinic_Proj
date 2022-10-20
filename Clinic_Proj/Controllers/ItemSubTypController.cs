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
    public class ItemSubTypController : Controller
    {
        // GET: ItemSubTyp
        Clinic_Proj.Database_Access.ItemSubTypeDb dblayer = new Clinic_Proj.Database_Access.ItemSubTypeDb();
        public ActionResult ItemSubTyp()
        {
            return View();
        }
        //==============Item Sub Data Insert==================
        [HttpPost]
        public JsonResult Add_ItemType(ItemSubTypModel rs)
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
        //===========Display All Item Sub Type Data by lookup=============
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
        //===========Display All Item Type Data by lookup=============
        [HttpPost]
        public JsonResult Get_Typdata()
        {
            try
            {
                DataSet ds = dblayer.get_Typrecord();
                string RtnJS = JsonConvert.SerializeObject(ds.Tables[0]);
                return Json(RtnJS, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Item Sub Type Get Data By ID=================
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
        //=============Item Type Get Data By ID=================
        [HttpPost]
        public JsonResult Get_Typdatabyid(string id)
        {
            try
            {
                return Json(dblayer.get_Typrecordbyid(id), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===============Item Sub Type Data Update=============
        [HttpPost]
        public JsonResult update_record(ItemSubTypModel rs)
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
        //============Delete Item Type===============
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
        //===============Get Item Type ID==============
        [HttpPost]
        public JsonResult Get_ItemTypeID()
        {
            DataSet ds = dblayer.Generate_ItemType_ID();
            return Json(ds.Tables[0].Rows[0][0].ToString(), JsonRequestBehavior.AllowGet);
        }
    }
}