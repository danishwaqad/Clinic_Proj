using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using Clinic_Proj.Models;
using Clinic_Proj.Controllers;
using Newtonsoft.Json;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using Clinic_Proj.Database_Access;
using System.Net;
using System.Web.Security;


namespace Clinic_Proj.Controllers
{
    [Authorize]
    public class FirstAddController : Controller
    {
        string Result = null;
        DataTable dt = new DataTable();
        Clinic_Proj.Database_Access.FirstAddDb dblayer = new Clinic_Proj.Database_Access.FirstAddDb();
        // GET: FirstAdd
        public ActionResult FirstAdd()
        {
            return View();
        }
        //===========Display All Services By lookup=============
        [HttpPost]
        public JsonResult Get_Servicedata()
        {
            try
            {
                DataSet rs = dblayer.get_Servrecord();
                string RtnJS = JsonConvert.SerializeObject(rs.Tables[0]);
                return Json(RtnJS, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Get Service Name By ID============
        [HttpPost]
        public JsonResult Get_Servdatabyid(FirstAddModal rs)
        {
            try
            {
                return Json(dblayer.get_Servrecordbyid(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Get FA Check List============
        [HttpPost]
        public JsonResult FA_CheckList(FirstAddModal rs)
        {
            try
            {
                return Json(dblayer.get_FArecordbyid(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==================Check Service Before Out Command=======================
        [HttpPost]
        public JsonResult FA_CheckServcBef(FirstAddModal rs)
        {
            try
            {
                return Json(dblayer.get_FACheckBefOut(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==========View Service All Data==============
        [HttpPost]
        public JsonResult Get_Viewdata(FirstAddModal rs)
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
        //========Display Recomendation View All Data==============
        [HttpPost]
        public JsonResult GetRec_Viewdata(FirstAddModal rs)
        {
            try
            {
                return Json(dblayer.getRec_Viewrecord(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //============Recomendation Delete=====================
        [HttpPost]
        public JsonResult OnrecDelete(FirstAddModal rs)
        {
            try
            {
                string res = string.Empty;
                if (rs.id != 0)
                {
                    dblayer.deleRecdata(rs);
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
        //=============Get Total=========
        [HttpPost]
        public JsonResult Get_Charges_Total(FirstAddModal rs)
        {
            try
            {
                Result = dblayer.get_ChargesByID(rs);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "List Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }

        //=============Insert Service Data=================
        [HttpPost]
        public JsonResult Add_Recrd(FirstAddModal rs)
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
        //===========Insert Data For In And Out=================
        [HttpPost]
        public JsonResult Add_InOutRecrd(FirstAddModal rs)
        {
            try
            {
                string res;
                dblayer.AddInOutRecrd(rs);
                res = "Inserted";
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        //===========Insert Data For Service Header=================
        //[HttpPost]
        //public JsonResult Add_FAHeadRecord(FirstAddModal rs)
        //{
        //    try
        //    {
        //        string res;
        //        dblayer.AddFaHeadRecrd(rs);
        //        res = "Inserted";
        //        return Json(res, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //==============Display Patient Look up Data===================
        [HttpPost]
        public JsonResult Get_data(FirstAddModal rs)
        {
            try
            {
                Result = dblayer.get_record(rs);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "List Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //=============Display Patient Data Get By ID================
        [HttpPost]
        public JsonResult Get_databyid(FirstAddModal rs)
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
        //=============Mode Data Get By ID==========
        [HttpPost]
        public JsonResult Get_Modebyid(FirstAddModal rs)
        {
            try
            {
                return Json(dblayer.get_Modebyid(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Update records
        //[HttpPost]
        //public JsonResult update_record(FeeRefundModel rs)
        //{

        //    string res = string.Empty;

        //    try

        //    {

        //        dblayer.update_record(rs);

        //        res = "Updated";

        //    }

        //    catch (Exception)

        //    {

        //        res = "failed";

        //    }
        //    return Json(res, JsonRequestBehavior.AllowGet);
        //}
        //===============Delete First Aid Services==============
        [HttpPost]
        public JsonResult OnDelete(FirstAddModal rs)
        {
            try
            {
                string res = string.Empty;
                if (rs.id != 0)
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
    }
}