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
    public class TokenCloseController : Controller
    {
        Clinic_Proj.Database_Access.TknCloseDb dblayer = new Clinic_Proj.Database_Access.TknCloseDb();
        string Result;
        // GET: PatRefundFee
        public ActionResult TokenClose()
        {
            return View();
        }
        //==============SAVE For Token Closing=============
        [HttpPost]
        public JsonResult Add_Record(TknCloseModel rs)
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
        //==============Display Patient Token All Data==============
        [HttpPost]
        public JsonResult Get_data(TknCloseModel rs)
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

        //==============Patient Token Data Get By ID===================
        [HttpPost]
        public JsonResult Get_databyid(TknCloseModel rs)
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
        //========Display Patient View All Data=====================
        [HttpPost]
        public JsonResult Get_Viewdata(TknCloseModel rs)
        {
            return Json(dblayer.get_Viewrecord(rs), JsonRequestBehavior.AllowGet);
        }
        //========Update records============
        //[HttpPost]
        //public JsonResult update_record(TknCloseModel rs)
        //{
        //    string res = string.Empty;
        //    try
        //    {
        //        dblayer.update_record(rs);
        //        res = "Updated";
        //    }
        //    catch (Exception)
        //    {
        //        res = "failed";
        //    }
        //    return Json(res, JsonRequestBehavior.AllowGet);
        //}
        //=============Delete===========
        //[HttpPost]
        //public JsonResult OnDelete(int ID)
        //{
        //    string res = string.Empty;
        //    if (ID != 0)
        //    {
        //        dblayer.deletedata(ID);
        //        res = "Delete";
        //    }
        //    else
        //    {
        //        res = "failed";
        //    }
        //    return Json(res, JsonRequestBehavior.AllowGet);
        //}
        // Display View records by id
        //[HttpPost]
        //public JsonResult Get_Viewdatabyid(int id)
        //{
        //    DataSet dS = dblayer.get_Viewrecordbyid(id);
        //    DataTable dt = dS.Tables[0];
        //    string Result = JsonConvert.SerializeObject(dt);
        //    return Json(Result, JsonRequestBehavior.AllowGet);
        //}

    }
}