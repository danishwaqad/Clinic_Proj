using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using Clinic_Proj.Database_Access;
using Clinic_Proj.Models;
using Newtonsoft.Json;
using System.Net;
using System.Web.Security;

namespace Clinic_Proj.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        // GET: Account
        Clinic_Proj.Database_Access.SignIn_Qry Log = new Clinic_Proj.Database_Access.SignIn_Qry();
        Clinic_Proj.Database_Access.SignUpDb Sign = new Clinic_Proj.Database_Access.SignUpDb();
        string Result = null;
        DataTable dt = new DataTable();
        DataTable DocID = new DataTable();

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        public string GetIp()
        {
            string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ip))
            {
                ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            return ip;
        }
        //=========Sign Out=================
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("LogIn", "Account");
        }
        // GET: Account
        [AllowAnonymous]
        [HttpPost]
        public ActionResult SignIn(string Username, string Password)
        {
            if (Username != null && Password != null)
            {
                dt = Log.Login(Username, Password);

                if (dt.Rows.Count > 0)
                {
                    string IP = GetIp();
                    string HostName = Dns.GetHostName();
                    string IP2 = Dns.GetHostByName(HostName).AddressList[0].ToString();

                    string UType = dt.Rows[0]["UserType"].ToString().Trim().ToLower();
                    if (UType == "discontinue")
                    {
                        ViewBag.Msg = "User don't have access";
                        return View("LogIn");
                    }
                    
                    else
                    {
                        FormsAuthentication.SetAuthCookie(Username, false);
                        if (TempData["ReturnUrl"] != null)
                        {
                            Response.Redirect(TempData["ReturnUrl"].ToString());
                        }
                        Session["Name"] = dt.Rows[0]["Name"].ToString().Trim();
                        SystemHelper.Name = dt.Rows[0]["Name"].ToString().Trim();
                        //TempData["Name"] = dt.Rows[0]["Name"].ToString().Trim();
                        Session["UserID"] = Username;
                        Session["UserType"] = dt.Rows[0]["UserType"].ToString().Trim();
                        SystemHelper.Username = Username;
                        SystemHelper.LoginType = dt.Rows[0]["UserType"].ToString().Trim();
                        SystemHelper.Password = Password;

                        if (UType.Contains("doctor") || UType.Contains("Admin"))
                        {
                            string doctor;
                            doctor = SystemHelper.Username;
                            if (doctor != null)
                            {
                                DocID = Sign.Get_Dr_Names(doctor);
                                if (DocID.Rows.Count > 0)
                                {
                                    SystemHelper.DoctorID = DocID.Rows[0]["DoctorID"].ToString().Trim();
                                    Session["DoctorID"]= DocID.Rows[0]["DoctorID"].ToString().Trim();
                                }
                            }
                        }
                        //return RedirectToAction("Dashboard", "Home");
                        return View("SiteSelection");

                    }
                }
                else
                {
                    ViewBag.Msg = "Invalid Username or Password";
                    return View("LogIn");
                }
            }
            else
            {
                ViewBag.Msg = "Username and Password Required!";
                return View("LogIn");
            }
        }
        public ActionResult SiteSelection()
        {
            return View();
        }
        //============Proceed to Dashboard
        [HttpPost]
        public JsonResult Proceed(string SiteID, string DivisionID)
        {
            if (SiteID != null && DivisionID != null)
            {
                dt = Log.Get_Site_Name(SiteID);
                if (dt.Rows.Count > 0)
                {
                    Session["SiteName"] = dt.Rows[0][0].ToString();
                }
                else
                {
                    Session["SiteName"] = "";
                }
                SystemHelper.SiteID = SiteID;
                SystemHelper.DivisionID = DivisionID;
                Session["SiteiD"] = SiteID;
                Session["DivisionID"] = DivisionID;
                Result = "Done";
            }
            else
            {
                Result = "Null or Empty";
            }
            return Json(Result, JsonRequestBehavior.AllowGet);
            //return RedirectToAction("Dashboard", "Home");
        }
        public ActionResult SignUp()
        {
            return View();
        }
        //=============Get Login List=========
        [HttpPost]
        public JsonResult GetLoginList()
        {
            try
            {
                Result = Sign.Get_Login_List();
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "List Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //=============Get Login Type Active List=========
        [HttpPost]
        public JsonResult Active_LoginType_List()
        {
            try
            {
                Result = Sign.Get_Login_Type_Active();
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "List Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //=============Check Ex Login=========
        [HttpPost]
        public JsonResult Check_Ex_Username(string Username)
        {
            try
            {
                Result = Sign.Check_Ex_User(Username);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "List Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //=============Create New Login=========
        [HttpPost]
        public JsonResult CreateNew(SignUp_Mode sm)
        {
            string res = string.Empty;
            try
            {
                Sign.SignUp(sm);
                res = "Inserted";
            }
            catch (Exception)
            {
                res = "Failed";
                throw;
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //================Delete Login=============================
        [HttpPost]
        public JsonResult OnDelete(SignUp_Mode rs)
        {
            try
            {
                string res = string.Empty;
                if (rs.Username != "")
                {
                    Sign.deletedata(rs);
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
        //=============Login Update=========
        [HttpPost]
        public JsonResult UpdateLoginNew(SignUp_Mode sm)
        {
            string res = string.Empty;
            try
            {
                Sign.UpdateLogin(sm);
                res = "Updated";
            }
            catch (Exception)
            {
                res = "Failed";
                throw;
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //=============Login Exist=========
        [HttpPost]
        public JsonResult AllReadyExist(SignUp_Mode sm)
        {
            try
            {
                Result = Sign.ExistLogin(sm);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "Menu List Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult UserRights()
        {
            return View();
        }
        //=============Get User All Rights=========
        [HttpPost]
        public JsonResult Get_Login_RightsAll(SignUp_Mode sm)
        {
            try
            {
                Result = Sign.Get_Menu_Rights_All(sm);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "Menu List Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //=============Get User Data By ID=========
        [HttpPost]
        public JsonResult Get_LoginByID(SignUp_Mode sm)
        {
            try
            {
                Result = Sign.Get_LoginBYID(sm);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "Menu List Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //=============Get User Site All Rights=========
        [HttpPost]
        public JsonResult Get_Site_RightsAll(SignUp_Mode sm)
        {
            try
            {
                Result = Sign.Get_Site_Rights_All(sm);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "Site List Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //=============Add USer Site Rights=========
        [HttpPost]
        public JsonResult Add_Site_Rights(SignUp_Mode sm)
        {
            try
            {
                Sign.Add_Site_Rights(sm);
                Result = "Done";
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "Site Rights Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //=============Add User Allow Rights=========
        [HttpPost]
        public JsonResult Add_Menu_Allow_Rights(SignUp_Mode sm)
        {
            try
            {
                Sign.Add_Menu_Allow_Rights(sm);
                Result = "Done";
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "Allow Rights Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
        //=============Add User Print Rights=========
        [HttpPost]
        public JsonResult Add_Menu_Print_Rights(SignUp_Mode sm)
        {
            try
            {
                Sign.Add_Menu_Print_Rights(sm);
                Result = "Done";
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "Print Rights Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }
    }
}