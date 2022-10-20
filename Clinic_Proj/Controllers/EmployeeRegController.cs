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
    public class EmployeeRegController : Controller
    {
        // GET: EmployeeReg
        Clinic_Proj.Database_Access.EmployeeRegDB dblayer = new Clinic_Proj.Database_Access.EmployeeRegDB();
        public ActionResult EmployeeReg()
        {
            return View();
        }
        //==============Employee Data Insert==================
        [HttpPost]
        public JsonResult Add_EMP(EmployeeRegMode rs)
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
        //===========Display All Employees Data by lookup=============
        [HttpPost]
        public JsonResult Get_data()
        {
            try
            {
                DataSet rs = dblayer.get_record();
                string RtnJS = JsonConvert.SerializeObject(rs.Tables[0]);
                var tt = Json(RtnJS, JsonRequestBehavior.AllowGet);
                tt.MaxJsonLength = int.MaxValue;
                return tt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Employee Search Data By ID=================
        [HttpPost]
        public JsonResult Get_Searchbyid(EmployeeRegMode rs)
        {
            try
            {
                //return Json(dblayer.get_searchbyid(rs), JsonRequestBehavior.AllowGet);
                var tt = Json(dblayer.get_searchbyid(rs), JsonRequestBehavior.AllowGet);
                tt.MaxJsonLength = int.MaxValue;
                return tt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Employee Get Data By ID=================
        [HttpPost]
        public JsonResult Get_databyid(EmployeeRegMode rs)
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
        //===================Auto Get Employee ID============================
        [HttpPost]
        public JsonResult Get_EmpID()
        {
            try
            {
                DataSet ds = dblayer.Generate_Employee_ID();
                string RtnJS = JsonConvert.SerializeObject(ds.Tables[0]);
                return Json(RtnJS, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Employee Update=============
        [HttpPost]
        public JsonResult update_record(EmployeeRegMode rs)
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
        //============Delete Employee===============
        [HttpPost]
        public JsonResult OnDelete(EmployeeRegMode rs)
        {
            string res = string.Empty;
            if (rs.EmpID != "")
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