using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Clinic_Proj.Models;
using Newtonsoft.Json;

namespace Clinic_Proj.Database_Access
{
    public class SignUpDb
    {
        string Query;
        string RtnJS;
        DataTable dt = new DataTable();
        DB_Helper help = new DB_Helper();
        //DataSet ds = new DataSet();

        public string Get_Login_List()
        {
            try
            {
                dt = new DataTable();
                Query = "SELECT * FROM VW_Login ORDER BY Username ASC";
                dt = help.Return_DataTable_Query(Query);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Get_Dr_Names(string Name)
        {
            try
            {
                DataTable docId = new DataTable();
                docId = help.ReturnParameterizedDataTableProcedure("UD_Login_Name", "@DocName", Name);
                return docId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Get_Login_Type_Active()
        {
            try
            {
                dt = new DataTable();
                Query = "SELECT TypeID FROM LoginType where InActive = 0";
                dt = help.Return_DataTable_Query(Query);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Check_Ex_User(string User)
        {
            try
            {
                dt = new DataTable();
                Query = "SELECT * FROM Login WHERE Username = '" + User + "'";
                dt = help.Return_DataTable_Query(Query);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //====For Insert
        public void SignUp(SignUp_Mode Sign)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_SignUp", "@Name ,@Designation ,@Username ,@Password ,@EmailID ,@InActive ,@LoginID ,@TypeID ,@Department ,@Section ,@ContactNo ,@IsFixIP ", Sign.Name, Sign.Designation, Sign.Username, Sign.Password, Sign.EmailID, Sign.InActive, Sign.LoginID, Sign.UserType, Sign.Department, Sign.Section, Sign.ContactNo, Sign.IsFixIP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=======For Update
        public void UpdateLogin(SignUp_Mode Sign)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_SignUp", "@Name,@Designation,@Username,@Password,@EmailID,@InActive,@LoginID,@TypeID,@Department,@Section,@ContactNo,@IsFixIP", Sign.Name, Sign.Designation, Sign.Username, Sign.Password, Sign.EmailID, Sign.InActive, Sign.LoginID, Sign.UserType, Sign.Department, Sign.Section, Sign.ContactNo, Sign.IsFixIP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=======Already Exist Login
        public string ExistLogin(SignUp_Mode Sign)
        {
            try
            {
                dt = new DataTable();
                dt = help.ReturnParameterizedDataTableProcedure("UD_AllReady_Exist", "@Code", Sign.Username);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Get_Menu_Rights_All(SignUp_Mode sm)
        {
            try
            {
                dt = new DataTable();
                //dt = help.ReturnParameterizedDataTableProcedure("UD_GetUserRights", "@Username,@LoginID", sm.Username, sm.LoginID);
                dt = help.ReturnParameterizedDataTableProcedure("UD_GetAllRoles_UserWise", "@Username", sm.Username);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Get_LoginBYID(SignUp_Mode sm)
        {
            try
            {
                dt = new DataTable();
                dt = help.ReturnParameterizedDataTableProcedure("UD_GetLogin_ByID", "@Username", sm.Username);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Get_Site_Rights_All(SignUp_Mode sm)
        {
            try
            {
                dt = new DataTable();
                dt = help.ReturnParameterizedDataTableProcedure("UD_GetUserSiteRights", "@Username,@LoginID", sm.Username, sm.LoginID);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Add_Site_Rights(SignUp_Mode sm)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Login_Site_Rights", "@Username ,@SiteID,@LoginID,@IsAllow", sm.Username, sm.SiteID, sm.LoginID, sm.IsAllow);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Add_Menu_Allow_Rights(SignUp_Mode sm)
        {
            try
            {
                //help.ExecuteParameterizedProcedure("UD_Add_Login_Menu_Allow_Rights", "@Username ,@MenuID,@LoginID,@IsAllow", sm.Username, sm.MenuID, sm.LoginID, sm.IsAllow);
                help.ExecuteParameterizedProcedure("UD_Update_UserMenuList", "@Username, @MenuName, @IsAllow", sm.Username, sm.MenuID, sm.IsAllow);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Add_Menu_Print_Rights(SignUp_Mode sm)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Login_Menu_Print_Rights", "@Username ,@MenuID,@LoginID,@IsPrint", sm.Username, sm.MenuID, sm.LoginID, sm.IsPrint);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===============Delete Login==============
        public void deletedata(SignUp_Mode rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Delete_Login", "@Code", rs.Username);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}