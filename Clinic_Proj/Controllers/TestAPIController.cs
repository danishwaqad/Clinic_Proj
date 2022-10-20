using Clinic_Proj.Database_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Clinic_Proj.Controllers
{
    [Authorize]
    public class TestAPIController : Controller
    {
        // GET: TestAPI
        APIdb Obj = new APIdb();
        string Result = "";
        public ActionResult API()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetAPI()
        {
            try
            {
                //Refresh();
                DataTable dt = Obj.GetPath();
                WebClient web = new WebClient();
                string Server = dt.Rows[0]["ServerName"].ToString();
                string APIPath = dt.Rows[0]["APIPath"].ToString();

                Result = web.DownloadString(APIPath);

                //var Response = await client.GetStringAsync(APIPath);
                //client.get

                //TEst();
                string T = Result.Replace(@"\", string.Empty);
                //string qw = "\"";
                string W = T.Replace("\"[{", "[{");

                string WW = W.Replace(@"}]" + "\"", "}]");

                return Json(WW, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Result = "List Failed.." + ex.Message;
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
        }

    }
}