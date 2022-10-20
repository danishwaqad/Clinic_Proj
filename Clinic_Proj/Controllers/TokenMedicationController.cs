using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using Clinic_Proj.Models;

namespace Clinic_Proj.Controllers
{
    public class TokenMedicationController : Controller
    {
        Clinic_Proj.Database_Access.TokenMediDb dblayer = new Clinic_Proj.Database_Access.TokenMediDb();
        string Result = "";
        DataTable dt = new DataTable();
        // GET: TokenMedication
        public ActionResult TokenMedi()
        {
            return View();
        }
        //========Display Medication By token  View API All Data=================
        [HttpGet]
        public JsonResult Get_PharmacyMedTkn(TokenMediMode rs)
        {
            try
            {

                Result = dblayer.get_PharmaMeditknecord(rs);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "Lookup Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
    }
}