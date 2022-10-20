using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using Clinic_Proj.Models;
using Newtonsoft.Json;
using Clinic_Proj.Database_Access;

namespace Clinic_Proj.Controllers
{
    [Authorize]
    public class TokenController : Controller
    {
        Clinic_Proj.Database_Access.TokenDb dblayer = new Clinic_Proj.Database_Access.TokenDb();
        string Result;
        // GET: Token
        public ActionResult DashBoard()
        {
            return View();
        }
        //Display all Pening Tokens
        [HttpPost]
        public JsonResult Get_ViewPend(TokenModel rs)
        {
            try
            {
                Result = dblayer.get_PendingTkn(rs);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "List Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //Display all Tokens
        [HttpPost]
        public JsonResult Get_Viewdata(TokenModel rs)
        {
            try
            {
                TokenModel temp_DrPatientDetails = new TokenModel();
                List<TokenModel> List_DrDetails = new List<TokenModel>();

                DataTable dt_Drs = dblayer.GetAllDr(rs);


                for (int i = 0; i < dt_Drs.Rows.Count; i++)
                {
                    temp_DrPatientDetails = new TokenModel();

                    temp_DrPatientDetails.DrID = dt_Drs.Rows[i]["DrID"].ToString();
                    temp_DrPatientDetails.DrName = dt_Drs.Rows[i]["DrName"].ToString();
                    //temp_DrPatientDetails.DivisionID = dt_Drs.Rows[i]["DivisionID"].ToString();
                    //temp_DrPatientDetails.SiteID = dt_Drs.Rows[i]["SiteID"].ToString();
                    DataTable dt_Paitent = dblayer.GetAllPatientByDr(dt_Drs.Rows[i]["DrID"].ToString(), SystemHelper.SiteID, SystemHelper.DivisionID);


                    temp_DrPatientDetails P = new temp_DrPatientDetails();
                    List<temp_DrPatientDetails> p_List = new List<temp_DrPatientDetails>();

                    for (int j = 0; j < dt_Paitent.Rows.Count; j++)
                    {
                        P = new temp_DrPatientDetails();

                        P.SerialNumber = dt_Paitent.Rows[j]["SerialNo"].ToString();
                        P.TokenNumber = dt_Paitent.Rows[j]["TokenNo"].ToString();
                        P.PatientName = dt_Paitent.Rows[j]["FullName"].ToString();

                        p_List.Add(P);
                    }

                    temp_DrPatientDetails.DrPatientDetails = p_List;

                    List_DrDetails.Add(temp_DrPatientDetails);

                }

                string RtnJS = JsonConvert.SerializeObject(List_DrDetails);


                //DataSet ds = dblayer.get_Tokenrecord();
                //string RtnJS = JsonConvert.SerializeObject(ds.Tables[0]);

                return Json(RtnJS, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}