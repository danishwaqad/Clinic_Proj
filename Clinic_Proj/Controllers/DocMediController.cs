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
    public class DocMediController : Controller
    {
        // GET: Groups
        Clinic_Proj.Database_Access.DocMediDb dblayer = new Clinic_Proj.Database_Access.DocMediDb();
        public ActionResult DocMediView()
        {
            return View();
        }
        //=============Get Diagnose ID================
        [HttpPost]
        public JsonResult Get_DiagID()
        {
            try
            {
                DataSet rs = dblayer.Diagnose_ID();
                string RtnJS = JsonConvert.SerializeObject(rs.Tables[0]);
                return Json(RtnJS, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Diagnose Data Insert=================
        [HttpPost]
        public JsonResult Add_DiagRecrd(DocMediMode rs)
        {
            string res = string.Empty;
            try
            {
                dblayer.Add_DiagRecord(rs);
                res = "Inserted";
            }
            catch (Exception)
            {
                res = "Failed";
                throw;
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //==============Display Diagnose Data By Lookup===================
        [HttpPost]
        public JsonResult GetDiag_data(DocMediMode rs)
        {
            try
            {
                return Json(dblayer.getDiage_record(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Display Group 1 Data By Lookup===================
        [HttpPost]
        public JsonResult GetGroup1_data(DocMediMode rs)
        {
            try
            {
                return Json(dblayer.getGroup1_record(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Get Group 1 Data By ID============
        [HttpPost]
        public JsonResult Get_Group1_databyid(DocMediMode rs)
        {
            try
            {
                return Json(dblayer.get_Group1_byid(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //============Delete Group 1 Data================
        [HttpPost]
        public JsonResult OnGroup1_DataDelete(DocMediMode rs)
        {
            try
            {
                string res = string.Empty;
                if (rs.GroupID != "0")
                {
                    dblayer.dele_Group1_data(rs);
                    res = "Delete";
                }
                else
                {
                    res = "failed";
                }
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Get Doctor ID================
        [HttpPost]
        public JsonResult Get_DoctorID()
        {
            try
            {
                return Json(dblayer.get_ID_ByUser_Record(SystemHelper.Get_User_Session()), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //======================Consultancy========================
        //================Insert Medication==============
        [HttpPost]
        public JsonResult Add_Medication(DocMediMode rs)
        {
            string res = string.Empty;
            try
            {
                dblayer.Add_Medicate(rs);
                res = "Inserted";
            }
            catch (Exception ex)
            {
                res = "Failed";
                throw ex;
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //============Display Medication View All Data==============
        [HttpPost]
        public JsonResult GetMed_Viewdata(DocMediMode rs)
        {
            try
            {
                return Json(dblayer.getmed_Viewrecord(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============For Delete Medication==================
        [HttpPost]
        public JsonResult OnMediDelete(DocMediMode rs)
        {
            try
            {
                string res = string.Empty;
                if (rs.id != 0)
                {
                    dblayer.deleteMeddata(rs);
                    res = "Delete";
                }
                else
                {
                    res = "failed";
                }
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //======================Consultancy End=====================
    }
}