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
    public class PatRefundFeeController : Controller
    {
        Clinic_Proj.Database_Access.PatRefundFeedb dblayer = new Clinic_Proj.Database_Access.PatRefundFeedb();
        string Result;
        // GET: PatRefundFee
        public ActionResult PatiRefundFee()
        {
            return View();
        }
        //===============Insert Refund Data=============
        [HttpPost]
        public JsonResult Add_Refund(FeeRefundModel rs)
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
        //==========Display Patient Data By Lookup===========
        [HttpPost]
        public JsonResult Get_data(FeeRefundModel rs)
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
        //=========Get Patient Data By ID=================
        [HttpPost]
        public JsonResult Get_databyid(FeeRefundModel rs)
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
        //==============Update Refund Data=================
        [HttpPost]
        public JsonResult update_record(FeeRefundModel rs)
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
        //==============Patient Refund Delete=================
        [HttpPost]
        public JsonResult OnDelete(FeeRefundModel rs)
        {
            try
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
            catch(Exception ex)
            {
                throw ex;
            }
        }
        //============Get Patient Refund Type============
        [HttpPost]
        public JsonResult Get_PatRefType()
        {
            try
            {
                DataSet ds = dblayer.get_PatRefundType();
                string RtnJS = JsonConvert.SerializeObject(ds.Tables[0]);
                return Json(RtnJS, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========Get Refund By Type===============
        [HttpPost]
        public JsonResult Get_RefByType(FeeRefundModel rs)
        {
            try
            {
                return Json(dblayer.get_RefundByType(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //============Display Refund View All Data===============
        [HttpPost]
        public JsonResult Get_Viewdata(FeeRefundModel rs)
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
        //==============View Refund Data Get By ID==============
        [HttpPost]
        public JsonResult Get_Viewdatabyid(FeeRefundModel rs)
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

    }
}