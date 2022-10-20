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
    public class ReceivingController : Controller
    {
        string Result = null;
        Clinic_Proj.Database_Access.ReceivingDb dblayer = new Clinic_Proj.Database_Access.ReceivingDb();
        string res = string.Empty;
        // GET: Receiving
        public ActionResult Receiving()
        {
            return View();
        }
        //===========Create Document No=================
        public JsonResult get_Doc_No(ReceivingModel rs)
        {
            try
            {
                return Json(dblayer.get_DocNo(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Get Expiry Days=========
        [HttpPost]
        public JsonResult Get_Expiry()
        {
            try
            {
                Result = dblayer.Get_Expiry_Days();
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "Expiry Days Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //=============View Product By ID=================
        [HttpPost]
        public JsonResult Get_Prodbyid(ReceivingModel rs)
        {
            try
            {
                return Json(dblayer.get_Prodrecordbyid(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============View Total Amount By Doc=================
        [HttpPost]
        public JsonResult Get_Amountbyid(ReceivingModel rs)
        {
            try
            {
                return Json(dblayer.get_Amountbyid(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========View Doc Data=================
        //public JsonResult GetDoc_data()
        //{
        //    try
        //    {
        //        Result = dblayer.get_Docrecord();
        //        return Json(Result, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        Result = "New Failed.." + ex.Message;
        //        return Json(Result, JsonRequestBehavior.AllowGet);
        //    }
        //}
        //===========Document Lookup Data============
        [HttpPost]
        public JsonResult GetProd_data(ReceivingModel rs)
        {
            try
            {
                return Json(dblayer.getDocrecord(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========Display Auto Batch============
        [HttpPost]
        public JsonResult GetAutoBatch_data(ReceivingModel rs)
        {
            try
            {
                return Json(dblayer.getAbatchrecord(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //================Save Document Number===============
        [HttpPost]
        public JsonResult SaveDocNum(ReceivingModel ROM)
        {
            try
            {
                dblayer.Add_Doc_Num(ROM);
                Result = "Inserted";
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "Get Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //================Save Cart===============
        [HttpPost]
        public JsonResult SaveCart(ReceivingModel ROM)
        {
            try
            {
                dblayer.Add_Cart(ROM);
                Result = "Inserted";
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "Get Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //==============Save Complete Document Number============
        [HttpPost]
        public JsonResult SaveDocCom(ReceivingModel ROM)
        {
            try
            {
                dblayer.Sav_CompDoc(ROM);
                Result = "Inserted";
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "Get Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //===================Post Document Number===============
        [HttpPost]
        public JsonResult PostDocCom(ReceivingModel ROM)
        {
            try
            {
                dblayer.Post_DocNum(ROM);
                Result = "Inserted";
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "Get Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //============Delete Product===============
        [HttpPost]
        public JsonResult OnDelete(ReceivingModel rs)
        {
            string res = string.Empty;
            dblayer.deletedata(rs);
            res = "Delete";
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}