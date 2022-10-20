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
    public class CurrentStockController : Controller
    {
        string Result = null;
        Clinic_Proj.Database_Access.CurrentStockDb dblayer = new Clinic_Proj.Database_Access.CurrentStockDb();
        // GET: CurrentStock
        public ActionResult CurrentStock()
        {
            return View();
        }
        //Display Current Sotck View data
        [HttpPost]
        public JsonResult Get_Viewdata(ReportsModel rs)
        {
            try
            {
                Result = dblayer.ViewCurrentData(rs);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        //=============Get Total For Current Stock=========
        [HttpPost]
        public JsonResult Get_Current_Total(ReportsModel rs)
        {
            try
            {
                Result = dblayer.get_CurrentTotal(rs);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}