using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using Clinic_Proj.Models;
using Clinic_Proj.Controllers;
using Newtonsoft.Json;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using Clinic_Proj.Database_Access;
using System.Net;
using System.Web.Security;

namespace Clinic_Proj.Controllers
{
    [Authorize]
    public class TokenGenrateController : Controller
    {
        string Result = null;
        DataTable dt = new DataTable();
        Clinic_Proj.Database_Access.TokenGenerateDb dblayer = new Clinic_Proj.Database_Access.TokenGenerateDb();
        // GET: TokenGenrate
        public ActionResult TokenGenrate()
        {
            return View();
        }
        //===============Update CNIC Register======================
        [HttpPost]
        public JsonResult Update_Cnic_record(TokenGenerateMode rs)
        {
            string res = string.Empty;
            try
            {
                dblayer.Update_Record(rs);
                res = "Inserted";
            }
            catch (Exception)
            {
                res = "Failed";
                throw;
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //================Delete Today Token=============================
        [HttpPost]
        public JsonResult OnDelete_TodayTkn(TokenGenerateMode rs)
        {
            string res = string.Empty;
            dblayer.deletedata_Todaytkn(rs);
            res = "Delete";
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //================Delete Today Token Get Back=============================
        [HttpPost]
        public JsonResult OnDeleteBack_TodayTkn(TokenGenerateMode rs)
        {
            string res = string.Empty;
            dblayer.deletedata_TodaytknBack(rs);
            res = "Delete";
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //==========Display All Today Token Patient Related lookup Data================
        [HttpPost]
        public JsonResult GetToken_data(TokenGenerateMode rs)
        {
            try
            {
                Result = dblayer.get_TodyTknrecord(rs);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "List Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //=============Today Token Data Get Data By id=================
        [HttpPost]
        public JsonResult Get_TknTodaybyid(TokenGenerateMode rs)
        {
            try
            {
                return Json(dblayer.get_Tknrecordbyid(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========Get Patient Data By CNIC IF Already Available===========
        [HttpPost]
        public JsonResult Get_PatAvailable(TokenGenerateMode rs)
        {
            try
            {
                return Json(dblayer.get_PatAvail(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}