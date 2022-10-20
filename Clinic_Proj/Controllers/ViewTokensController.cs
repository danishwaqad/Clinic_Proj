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
    public class ViewTokensController : Controller
    {
        // GET: ViewTokens
        public ActionResult ViewTokens()
        {
            return View();
        }
        string Result;
        Clinic_Proj.Database_Access.ViewTokensDb dblayer = new Clinic_Proj.Database_Access.ViewTokensDb();
        //Display Patients data
        [HttpPost]
        public JsonResult Get_Tokensdata(ViewTokensModel rs)
        {
            try
            {
                return Json(dblayer.get_ViewDataid(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}