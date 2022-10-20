using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using Clinic_Proj.Models;
using Newtonsoft.Json;
using CrystalDecisions.CrystalReports.Engine;
using Clinic_Proj.Database_Access;

namespace Clinic_Proj.Controllers
{
    [Authorize]
    public class EmpDependController : Controller
    {
        // GET: EmpDepend
        Clinic_Proj.Database_Access.EmpDependDb dblayer = new Clinic_Proj.Database_Access.EmpDependDb();
        public ActionResult EmpDepend()
        {
            return View();
        }
        //==============Employee Dependant Data Insert==================
        [HttpPost]
        public JsonResult Add_EmpDepend(EmpDependMode rs)
        {
            string res = string.Empty;
            try
            {
                dblayer.Add_record(rs);
                res = "Inserted";
            }
            catch (Exception)
            {
                res = "Failed";
                throw;
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //===========Display All Employees Depend Data by lookup=============
        [HttpPost]
        public JsonResult Get_data()
        {
            try
            {
                DataSet rs = dblayer.get_record();
                string RtnJS = JsonConvert.SerializeObject(rs.Tables[0]);
                return Json(RtnJS, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Employee Depend Get Data By ID=================
        [HttpPost]
        public JsonResult Get_databyid(EmpDependMode rs)
        {
            try
            {
                return Json(dblayer.get_recordbyid(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Company Discount Update=============
        [HttpPost]
        public JsonResult update_record(EmpDependMode rs)
        {
            string res = string.Empty;
            try
            {
                dblayer.update_record(rs);
                res = "Updated";
            }
            catch (Exception)
            {
                res = "failed";
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //=================Display View All Employee Dependant Data===================
        [HttpPost]
        public JsonResult Get_Viewdata(EmpDependMode rs)
        {
            try
            {
                return Json(dblayer.get_Viewrecord(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //================Display View All Employee Dependant Data for Edit=================
        [HttpPost]
        public JsonResult Get_Viewdatabyid(EmpDependMode rs)
        {
            try
            {
                return Json(dblayer.get_EditViewrecord(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //============Delete Employee Dependent===============
        [HttpPost]
        public JsonResult OnDelete(EmpDependMode rs)
        {
            string res = string.Empty;
            if (rs.ID != 0)
            {
                dblayer.deletedata(rs);
                res = "Delete";
            }
            else
            {
                res = "failed";
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}