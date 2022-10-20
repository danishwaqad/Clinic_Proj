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
    public class CmpToEmpController : Controller
    {
        // GET: CmpToEmp
        string Result;
        Clinic_Proj.Database_Access.CmpToEmpDB dblayer = new Clinic_Proj.Database_Access.CmpToEmpDB();
        public ActionResult CompanyToEmp()
        {
            return View();
        }
        //Display Companies
        [HttpPost]
        public JsonResult Get_Companydata()
        {
            try
            {
                DataSet ds = dblayer.get_Comprecord();
                string RtnJS = JsonConvert.SerializeObject(ds.Tables[0]);
                return Json(RtnJS, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Display Employees
        [HttpPost]
        public JsonResult Get_Empdata(CmpToEmpMode rs)
        {
            try
            {
                var tt = Json(dblayer.get_EmpData(rs), JsonRequestBehavior.AllowGet);
                tt.MaxJsonLength = int.MaxValue;
                return tt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Display Employees Dependent
        [HttpPost]
        public JsonResult Get_EmpDepdata(CmpToEmpMode rs)
        {
            try
            {
                return Json(dblayer.get_EmpDepData(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}