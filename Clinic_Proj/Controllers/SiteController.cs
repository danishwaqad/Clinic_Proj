using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using Clinic_Proj.Models;
using Newtonsoft.Json;
using Clinic_Proj.Database_Access;

namespace Clinic_Proj.Controllers
{
    [Authorize]
    public class SiteController : Controller
    {
        string Result = null;
        Clinic_Proj.Database_Access.Sitedb dblayer = new Clinic_Proj.Database_Access.Sitedb();
        public ActionResult Site()
        {
            return View();
        }
        //====================Insert Site==============
        [HttpPost]
        public JsonResult Add_record(SiteModel rs)
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
        //=======Site Lookup Data Active========
        [HttpPost]
        public JsonResult User_Site_List_Access()
        {
            try
            {
                string User = SystemHelper.Username;
                Result = dblayer.User_Access_List(User);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "Access Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //========Get Login Site Detail
        [HttpPost]
        public JsonResult Get_Login_Site_Detail(string SiteID)
        {
            try
            {
                string User = SystemHelper.Username;
                Result = dblayer.Login_Site_Detail(SiteID);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "Access Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //===================Display DTall site data=====
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

        //=================Display Site records by id=============
        [HttpPost]
        public JsonResult Get_databyid(SiteModel rs)
        {
            try
            {
                return Json(dblayer.get_recordbyid(rs), JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        //============Update Site records=====================
        [HttpPost]
        public JsonResult update_record(SiteModel rs)
        {
            string res = string.Empty;
            try
            {
                dblayer.update_record(rs);
                res = "Updated";
            }
            catch (Exception exc)
            {
                res = "failed";
                throw exc;
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //=======================Delete Site===============
        [HttpPost]
        public JsonResult OnDelete(SiteModel rs)
        {
            try
            {
                string res = string.Empty;
                if (rs.SiteCode != null && rs.SiteCode != "")
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
    }
}