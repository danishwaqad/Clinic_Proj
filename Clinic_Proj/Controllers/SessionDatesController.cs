using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using Clinic_Proj.Models;
using Newtonsoft.Json;
using Clinic_Proj.Database_Access;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace Clinic_Proj.Controllers
{
    [Authorize]
    public class SessionDatesController : Controller
    {
        // GET: SessionDates
        public ActionResult SessionDates()
        {
            return View();
        }
        DataTable dt = new DataTable();
        // GET: Session
        Clinic_Proj.Database_Access.SessionDatesDb dblayer = new Clinic_Proj.Database_Access.SessionDatesDb();
        string Result;
        string res = string.Empty;
        public ActionResult PatientSession()
        {
            return View();
        }
        //===============Display Session Tokens=====================
        [HttpPost]
        public JsonResult Get_data(SessionDatesMode rs)
        {
            try
            {
                //Result = dblayer.get_SessionRecord(rs);
                //return Json(Result, JsonRequestBehavior.AllowGet);
                string Rtn = dblayer.get_SessionRecord(rs);
                var T = Json(Rtn, JsonRequestBehavior.AllowGet);
                T.MaxJsonLength = int.MaxValue;
                return T;
            }
            catch (Exception ex)
            {
                Result = "Session Token Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //==================Save Change Date Session===============
        [HttpPost]
        public JsonResult Add_ChangeDate(SessionDatesMode DM)
        {
            string res = string.Empty;
            try
            {
                dblayer.Add_DateChangeRecord(DM);
                res = "Inserted";
            }

            catch (Exception)
            {
                res = "failed";
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //=============Patient Session Data Get By ID==========================
        [HttpPost]
        public JsonResult Get_databyid(SessionDatesMode rs)
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
    }
}