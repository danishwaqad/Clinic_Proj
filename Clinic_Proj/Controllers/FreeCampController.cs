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

    public class FreeCampController : Controller
    {
        // GET: FreeCamp
        string Result = "";
        Clinic_Proj.Database_Access.FreeCampDb dblayer = new Clinic_Proj.Database_Access.FreeCampDb();
        public ActionResult FreeCamp()
        {
            return View();
        }
        //==================Insert Free Camp Entry==================
        [HttpPost]
        public JsonResult Add_FreeCmp_Recrd(FreeCampMode rs)
        {
            string res = string.Empty;
            try
            {
                dblayer.Add_Free_Camp_record(rs);
                res = "Inserted";
            }
            catch (Exception ex)
            {
                res = "Failed";
                throw ex;
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //===========Delete Free Camp=============
        [HttpPost]
        public JsonResult OnDelete(FreeCampMode rs)
        {
            try
            {
                string res = string.Empty;
                if (rs.ID != 0)
                {
                    dblayer.delete_FreeCmpdata(rs);
                    res = "Delete";
                }
                else
                {
                    res = "failed";
                }
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Display Free Camp data
        [HttpPost]
        public JsonResult Get_FreeCmpdata()
        { 
            try
            {
                Result = dblayer.get_FreeCmprecord();
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "New Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
    }
}