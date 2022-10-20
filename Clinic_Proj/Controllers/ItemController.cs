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
    public class ItemController : Controller
    {
        string Result = null;
        //ROConfig_Qry ConfigQry = new ROConfig_Qry();
        //ROProposal_Qry ProQry = new ROProposal_Qry();
        // GET: Item
        Clinic_Proj.Database_Access.ItemDb dblayer = new Clinic_Proj.Database_Access.ItemDb();
        public ActionResult Item()
        {
            return View();
        }
        //===========Display All Item Data by lookup=============
        [HttpPost]
        public JsonResult GetItem_data(ItemModel rs)
        {
            try
            {
                return Json(dblayer.get_Itemrecord(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Item Get Data By ID=================
        [HttpPost]
        public JsonResult Get_Itemdatabyid(ItemModel rs)
        {
            try
            {
                return Json(dblayer.get_Itemrecordbyid(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //================Save Ro Proposal===============
        //[HttpPost]
        //public JsonResult SaveRO_Proposal(ItemModel rs)
        //{
        //    try
        //    {
        //        dblayer.Add_RO(rs);
        //        Result = "Inserted";
        //        return Json(Result, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        Result = "Get Failed.." + ex.Message;
        //        return Json(Result, JsonRequestBehavior.AllowGet);
        //    }
        //}
        //=========Save Product==============
        [HttpPost]
        public JsonResult SaveNew(ItemModel rs)
        {
            try
            {
                dblayer.Add_Product(rs);
                Result = "Inserted...";
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "Insert Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //=========Update Product==============
        [HttpPost]
        public JsonResult UpdateNew(ItemModel rs)
        {
            try
            {
                dblayer.Update_Product(rs);
                Result = "Update...";
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "Insert Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //============Delete Item Type===============
        [HttpPost]
        public JsonResult OnDelete(ItemModel ROM)
        {
            string res = string.Empty;
            //if (ID <> '')
            //{
                dblayer.deletedata(ROM);
                res = "Delete";
            //}
            //else
            //{
                //res = "failed";
            //}
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //================Save Ro Config===============
        [HttpPost]
        public JsonResult SaveRO_Config(ItemModel ROM)
        {
            try
            {
                dblayer.Add_RO_Config(ROM);
                Result = "Inserted";
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "Get Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //=========Generate Code==============
        [HttpPost]
        public JsonResult Get_RO_List(string ItemCode)
         {
            try
            {
                Result = dblayer.Get_RO(ItemCode);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "List Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //=========Generate Ro By Code==============
        [HttpPost]
        public JsonResult Get_ROById(string ItemCode)
        {
            try
            {
                Result = dblayer.Get_ROByid(ItemCode);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "List Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //===============Get Item Code==============
        [HttpPost]
        public JsonResult Get_ItemCode(ItemModel rs)
        {
            try
            {
                return Json(dblayer.Generate_Item_Code(rs), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}