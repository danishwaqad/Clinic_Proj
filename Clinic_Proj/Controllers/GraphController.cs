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
        string Result;
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
        //=================Display Daily Graph Data===================
        [HttpPost]
        public JsonResult Get_DailyGraphData(GraphMode rs)
        {
            try
            {
                return Json(dblayer.get_DailyGraphrecord(rs), JsonRequestBehavior.AllowGet);
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
        //=============Get Site Sale Graph Today=========
        [HttpPost]
        public JsonResult Site_Sale_Graph_Today_Clinic()
        {
            GraphMode response = new GraphMode();
            //string response = "";
            try
            {
                response = dblayer.Get_Site_Sale_Graph_Today_Clinic();
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "Site Clinic Sale Graph Today Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }

    }
}