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
    public class CnicDetailController : Controller
    {
        // GET: CnicDetail
        string Result;
        Clinic_Proj.Database_Access.CnicDetailDb dblayer = new Clinic_Proj.Database_Access.CnicDetailDb();
        public ActionResult CnicDetail()
        {
            return View();
        }
        //Display CNIC data
        [HttpPost]
        public JsonResult Get_CNICdata()
        {
            try
            {
                string Rtn = dblayer.GetCNICRecord();
                var T = Json(Rtn, JsonRequestBehavior.AllowGet);
                T.MaxJsonLength = int.MaxValue;
                return T;
            }
            catch (Exception ex)
            {
                Result = "List Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //=============Search Data By ID=================
        [HttpPost]
        public JsonResult Get_Searchbyid(CnicMode rs)
        {
            try
            {
                    var tt = Json(dblayer.get_searchbyid(rs), JsonRequestBehavior.AllowGet);
                    tt.MaxJsonLength = int.MaxValue;
                    return tt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}