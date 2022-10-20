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
    public class GraphController : Controller
    {
        Clinic_Proj.Database_Access.GraphDb dblayer = new Clinic_Proj.Database_Access.GraphDb();
        // GET: Graph
        public ActionResult Index()
        {
            return View();
        }
        //=================Display Graph Data===================
        [HttpPost]
        public JsonResult Get_GraphData(GraphMode rs)
        {
            try
            {
                return Json(dblayer.get_Graphrecord(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Closed All Tokens=================
        [HttpPost]
        public JsonResult Get_Closeddata(GraphMode rs)
        {
            string res;
            try
            {
                dblayer.get_Closedrecord(rs);
                res = "Done";
            }
            catch (Exception)
            {
                res = "Failed";
                throw;
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}