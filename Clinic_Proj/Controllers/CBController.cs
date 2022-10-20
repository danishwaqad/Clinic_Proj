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
    public class CBController : Controller
    {
        string Result = null;
        DataTable dt = new DataTable();
        Clinic_Proj.Database_Access.CbDB dblayer = new Clinic_Proj.Database_Access.CbDB();
        public ActionResult CBView()
        {
            return View();
        }
        //========New Doc Number======
        [HttpPost]
        public JsonResult Generate_DocNum()
        {
            try
            {
                Result = dblayer.Generate_DcNum();
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "New Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //=============Add Doc Number=========
        [HttpPost]
        public JsonResult AddDoc(CB_Mode DM)
        {
            try
            {
                dblayer.Add_DocNum(DM);
                Result = "Inserted";
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "Insert Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //================Update Doc Record records====================
        [HttpPost]
        public JsonResult update_Docrecord(CB_Mode rs)
        {
            string res = string.Empty;
            try
            {
                dblayer.update_DCrecord(rs);
                res = "Inserted";
            }

            catch (Exception)
            {
                res = "failed";
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //===============Display dropdown Rupees Data================
        [HttpPost]
        public JsonResult Get_RupeesdtAll()
        {
            try
            {
                DataSet ds = dblayer.get_RupeesAll();
                string RtnJS = JsonConvert.SerializeObject(ds.Tables[0]);
                return Json(RtnJS, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Add Detail=========
        [HttpPost]
        public JsonResult Add_Detail(CB_Mode DM)
        {
            try
            {
                dblayer.Add_AllDetail(DM);
                Result = "Inserted";
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "Insert Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //==========View All Data================
        [HttpPost]
        public JsonResult GetView_data(string id)
        {
            try
            {
                return Json(dblayer.get_Viewrecord(id), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==========Get Opening Balance Data================
        [HttpPost]
        public JsonResult GetCB_data(string id)
        {
            try
            {
                return Json(dblayer.get_CBrecord(id), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //============Delete Record==================
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
    }
}