using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using Clinic_Proj.Models;
using Newtonsoft.Json;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using Clinic_Proj.Database_Access;
using QRCoder;
using Microsoft.Win32;
using System.Drawing.Imaging;
using System.Drawing;
using System.Net;
using System.Configuration;

namespace Clinic_Proj.Controllers
{
    [Authorize]
    public class CalenderController : Controller
    {
        Clinic_Proj.Database_Access.CalenderDB dblayer = new Clinic_Proj.Database_Access.CalenderDB();
        // GET: FirstAdd
        string Result = "";
        DataTable dt = new DataTable();
        // GET: Calender
        public ActionResult Calender()
        {
            return View();
        }
        //================Add Calender Events=========================
        [HttpPost]
        public JsonResult Add_CalenderRecrd(CalenderMode rs)
        {
            string res = string.Empty;
            try
            {
                dblayer.AddCalender_record(rs);
                res = "Inserted";
            }
            catch (Exception)
            {
                res = "Failed";
                throw;
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //=============Display Calender Data=================
        [HttpPost]
        public JsonResult Get_data()
        {
            try
            {
                DataSet ds = dblayer.get_Cal_record();
                string RtnJS = JsonConvert.SerializeObject(ds.Tables[0]);
                return Json(RtnJS, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}