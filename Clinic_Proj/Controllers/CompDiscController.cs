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
    public class CompDiscController : Controller
    {
        // GET: CompDisc
        Clinic_Proj.Database_Access.CompDiscDB dblayer = new Clinic_Proj.Database_Access.CompDiscDB();
        public ActionResult CompanyDisc()
        {
            return View();
        }
        //===========All Companies Discount Data Insert==================
        [HttpPost]
        public JsonResult Add_CompDisc(CompanyDiscMod rs)
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
        //===========Display All Companies Discount=============
        [HttpPost]
        public JsonResult Get_data()
        {
            try
            {
                DataSet rs = dblayer.get_record();
                string RtnJS = JsonConvert.SerializeObject(rs.Tables[0]);
                return Json(RtnJS, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==========All Companies Discount Data Update=============
        [HttpPost]
        public JsonResult update_record(CompanyDiscMod rs)
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
        //============Delete All Companies Discount===============
        [HttpPost]
        public JsonResult OnDelete(CompanyDiscMod rs)
        {
            try
            {
                string res = string.Empty;
                if (rs.CompanyID == 0)
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}