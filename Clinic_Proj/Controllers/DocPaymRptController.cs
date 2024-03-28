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

namespace Clinic_Proj.Controllers
{
    public class DocPaymRptController : Controller
    {
        string Result = null;
        DataTable dt = new DataTable();
        Clinic_Proj.Database_Access.DocPaymentRptDb dblayer = new Clinic_Proj.Database_Access.DocPaymentRptDb();
        // GET: DocPaymRpt
        public ActionResult DocPaymRpt()
        {
            return View();
        }
        //==============Display Doctor Payment Look up Data===================
        [HttpPost]
        public JsonResult Get_DoLokupdata(DocPaymentRptMode rs)
        {
            try
            {
                return Json(dblayer.get_DocrecordLokup(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}