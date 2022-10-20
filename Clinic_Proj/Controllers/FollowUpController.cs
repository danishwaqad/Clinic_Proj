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
    public class FollowUpController : Controller
    {
        string Result;
        Clinic_Proj.Database_Access.FollowHistDb dblayer = new Clinic_Proj.Database_Access.FollowHistDb();
        // GET: FollowUp
        public ActionResult FollowUpHist()
        {
            return View();
        }
        //Display Follow Up History data
        [HttpPost]
        public JsonResult Get_Followdata(FollowUpModel rs)
        {
            try
            {
                return Json(dblayer.get_Folowrecord(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Display New Follow Up History data
        [HttpPost]
        public JsonResult Get_NewFollowdata(FollowUpModel rs)
        {
            try
            {
                Result = dblayer.get_NewFolowrecord(rs);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "List Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //==============Get Contact By id=================
        [HttpPost]
        public JsonResult Get_ContctViabyid(string Contctid)
        {
            try
            {
                return Json(dblayer.get_Conttactbyid(Contctid), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //================Save Follow Up Record in History Table====================
        [HttpPost]
        public JsonResult Save_FollowRec(FollowUpModel DM)
        {
            string res = string.Empty;
            try
            {
                dblayer.Add_Folowrecord(DM);
                res = "Inserted";
            }

            catch (Exception)
            {
                res = "failed";
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //================Save New Follow====================
        [HttpPost]
        public JsonResult Save_NewFollow(FollowUpModel DM)
        {
            string res = string.Empty;
            try
            {
                dblayer.Add_NewFolowrecord(DM);
                res = "Inserted";
            }

            catch (Exception)
            {
                res = "failed";
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //==============Get All Data By id and insert to Follow Up History=================
        [HttpPost]
        public JsonResult Get_AllDatbyid(FollowUpModel rs)
        {
            try
            {
                return Json(dblayer.get_Databyid(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=======Get Contact Via=========
        [HttpPost]
        public JsonResult Get_ContactVia()
        {
            try
            {
                DataSet ds = dblayer.get_CntctVia();
                string RtnJS = JsonConvert.SerializeObject(ds.Tables[0]);
                return Json(RtnJS, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=======Get View Data=========
        [HttpPost]
        public JsonResult Get_ViewData(FollowUpModel rs)
        {
            try
            {
                return Json(dblayer.get_ViewDataid(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}