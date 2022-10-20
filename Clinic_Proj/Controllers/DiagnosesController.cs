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
    public class DiagnosesController : Controller  
    {
        Clinic_Proj.Database_Access.DiagnosesDb dblayer = new Clinic_Proj.Database_Access.DiagnosesDb();
        // GET: FirstAdd
        public ActionResult Diagnoses()
        {
            return View();
        }
        //=============Diagnose Data Insert=================
        [HttpPost]
        public JsonResult Add_Recrd(DiagnosesModel rs)
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
        //=======Display Diagnose All Data By lookup=================
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
        //============Diagnose Data Get By ID============
        [HttpPost]
        public JsonResult Get_databyid(DiagnosesModel rs)
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
        //==========Diagnose Update===========
        [HttpPost]
        public JsonResult update_record(DiagnosesModel rs)
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
        //===========Delete Diagnose=============
        [HttpPost]
        public JsonResult OnDelete(DiagnosesModel rs)
        {
            try
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
            catch(Exception ex)
            {
                throw ex;
            }
        }
        //================================Diagnose Level==================================
        public ActionResult DiagnoseLevel()
        {
            return View();
        }
        //===================Auto Get Node ID============================
        [HttpGet]
        public JsonResult Get_NodeID()
        {
            try
            {
                string Rtn = dblayer.Generate_Node_ID();
                return Json(Rtn, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===================Get Parent List============================
        [HttpGet]
        public JsonResult Get_ParentList()
        {
            try
            {
                string Rtn = dblayer.Get_Parent_List();
                return Json(Rtn, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Diagnose Level Data Insert=================
        [HttpPost]
        public JsonResult Add_NodeRecord(DiagnosesModel rs)
        {
            string res = string.Empty;
            try
            {
                dblayer.AddNode_record(rs);
                res = "Inserted";
            }
            catch (Exception)
            {
                res = "Failed";
                throw;
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //===================Get Child List============================
        [HttpPost]
        public JsonResult Get_ChildList(DiagnosesModel rs)
        {
            try
            {
                string Rtn = dblayer.Get_Child_List(rs);
                return Json(Rtn, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //============Diagnose Disease Data Get By ID============
        [HttpPost]
        public JsonResult Get_Diseasedatabyid(DiagnosesModel rs)
        {
            try
            {
                return Json(dblayer.get_Diseaserecordbyid(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========Delete Node=============
        [HttpPost]
        public JsonResult OnDelete_Node(DiagnosesModel rs)
        {
            try
            {
                string res = string.Empty;
                if (rs.NodeID != 0)
                {
                    dblayer.delete_Nodedata(rs);
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
    }
}