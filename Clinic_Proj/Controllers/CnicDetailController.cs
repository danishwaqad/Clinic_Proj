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
                return Json(Rtn, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "List Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
    }
}