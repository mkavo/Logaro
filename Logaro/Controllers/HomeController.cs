using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using log4net;
using Logaro.App_Data;
using Logaro.Models;
using Microsoft.Ajax.Utilities;
using PagedList;
// using Logaro = Logaro.Models.Logaro;


namespace Logaro.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        [HttpGet]
        public  ActionResult Log()
        {
            IEnumerable<WebApplication> apps = LogaroRepository.Instance.AppsConfig();
            int selectedStateId = 0;
            // Do this if you don't care about selection
            //List<SelectListItem> selectList = apps.Select(state => new SelectListItem {Value = selectList..ToString(), Text = state.Name}).ToList();

            List<SelectListItem> selectList = apps.Select(app => new SelectListItem { Value = app.ApplicationId.ToString(), Text = app.ApplicationName, Selected = (app.ApplicationId == selectedStateId) }).OrderBy(app => app.Text).ToList();
            selectList.Insert(0, new SelectListItem{ Value = "0", Text = "Choose Web-App" , Selected = true});
            ViewData["LogList"] = selectList;
            Logger.Debug("message:Här kommer testet!");
            
            return  View(); 
        }

        [HttpPost]
        public ActionResult Log(FormCollection form)
        {
            string appId = form["WebApplication"];
            string item = form["app1"];
            
            if (appId == "0")
            {
                TempData["Message"] = "Choose Web-app";
               return RedirectToAction("Log");
            }
            else
            {
                var tablename = "";
                var tn = LogaroRepository.Instance.TableName(int.Parse(appId));
                tablename = tn.Select(m => m.TableName).FirstOrDefault();
                Logger.Error(tablename);
                return RedirectToAction("ToLog", new { tableName = tablename });
            }
        }


        public ActionResult ToLog(int? page,string tableName )
        {
            int pageSize = 7;
            //string tableName = "";
            int pageIndex = 1;
            ViewData["AppName"]= tableName;
            ViewBag.tableName = tableName;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<Models.Logaro> log = null;
            Models.Logaro objLogaro = new Models.Logaro();
            var objLogaroList = LogaroRepository.Instance.logaroListBind(tableName);
            objLogaro.Log = objLogaroList.OrderBy(m=>m.Id).ToList();
            log = objLogaroList.ToPagedList(pageIndex, pageSize);
            
            return View(log);
        }
       

        [HttpGet]
        public ActionResult FilteredLog()
        {
            return View();
        }

        [HttpPost]

        public ActionResult FilteredLog(FormCollection form)
        {
            
            string day = form["TimeFilter"];
            string tableName = form["TableName"];

            if (tableName == null )
            {
                TempData["Message1"] = "Choose Web-app";
                return RedirectToAction("FilteredLog");
            }

            if (day == "0")
            {
                TempData["Message2"] = "Choose Date and time First";
                return RedirectToAction("FilteredLog");
            }
            var tb = 0;
            if (tableName == "Viola_Log")
            { tb = 1; }
            if (tableName == "Knut_Log")
            { tb = 2; }
            if (tableName == "VService_Log")
            { tb = 3; }
            if (tableName == "ViolaDev_Log")
            { tb = 4; }
            if (tableName == "KnutDev_Log")
            { tb = 5; }
            if (tableName == "Logaro_Log")
            { tb = 6; }

            var tn = LogaroRepository.Instance.TableName(tb);
            tableName = tn.Select(m => m.TableName).FirstOrDefault();
            return RedirectToAction("ToFilteredLog", new {day, tableName });   
        }

       
        public ActionResult ToFilteredLog(int? page, string day , string tableName)
        {
            int pageSize = 7;
            int pageIndex = 1;
            ViewData["AppName"] = tableName;
            ViewBag.day = day;
            ViewBag.tableName = tableName;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<Models.Logaro> log = null;
            Models.Logaro objLogaro = new Models.Logaro();
            var objLogaroList = LogaroRepository.Instance.LogaroList(day, tableName);
            objLogaro.Log = objLogaroList.OrderBy(m => m.Id).ToList();
            log = objLogaroList.ToPagedList(pageIndex, pageSize);

            return View(log);
        }
        
        [HttpGet]
        public PartialViewResult DropDownPartial(string TableName)
        {
            //var selectList = new SelectList(items, "Key", "Value");
            IEnumerable<Models.Logaro> apps = LogaroRepository.Instance.logaroListBind(TableName);
            List<SelectListItem> selectList = apps.Select(app => new SelectListItem { Value = app.Date.ToShortDateString(), Text = app.Date.ToShortDateString() + "]><[" + app.Date.ToLongTimeString() }).OrderBy(app => app.Text).ToList();
            selectList.Insert(0, new SelectListItem { Value = "0", Text = "Choose Date and Time" });
            ViewData["ddlName"] = selectList; // ur dropdownlist name id
            var webApp = new WebApplication();
            webApp.TableName = TableName;
            ViewBag.TableName = TableName;
            return PartialView("_DropDownListHtml"); //, selectList
        }

        [HttpGet]
        public ActionResult FreeTextResult()
        {
            IEnumerable<WebApplication> apps = LogaroRepository.Instance.AppsConfig();
            int selectedStateId = 0;

            List<SelectListItem> selectList = apps.Select(app => new SelectListItem { Value = app.ApplicationId.ToString(), Text = app.ApplicationName, Selected = (app.ApplicationId == selectedStateId) }).OrderBy(app => app.Text).ToList();
            selectList.Insert(0, new SelectListItem { Value = "0", Text = "Choose Web-App", Selected = true });
            ViewData["LogList"] = selectList;

            return View();
        }

        [HttpPost]

    public ActionResult FreeTextResult(FormCollection form, string text)
        {
            int tableId = Int32.Parse(form["WebApplication"]);
            string FreeText = form["FreeText"];

            if (tableId == 0)
            {
                TempData["Message3"] = "Choose Web-app";
                return RedirectToAction("FreeTextResult");
            }
            if (FreeText == "" || FreeText == "Write your Text Here:")
            {
                TempData["Message4"] = "Skriv Free Text";
                return RedirectToAction("FreeTextResult");
            }

            var tableName = string.Empty;
            switch (tableId)
            {
                case  1:
                    tableName = "Viola_Log";
                    break;
                case 2:
                    tableName = "Knut_Log";
                    break;
                case 3:
                    tableName = "VService_Log";
                    break;
                case 4:
                    tableName = "ViolaDev_Log";
                    break;
                case 5:
                    tableName = "KnutDev_Log";
                    break;
                case 6:
                    tableName = "Logaro_Log";
                    break;
                default:
                    return DropDownPartial(tableName); //to default                    
            }

            return RedirectToAction("ToFreeTextResult", new { FreeText, tableName });
        }

        public ActionResult ToFreeTextResult(int? page, string freeText, string tableName)
        {

            int pageSize = 7;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<Models.Logaro> log = null;
            
            var objLogaroList = LogaroRepository.Instance.LogaroListFreeText(freeText, tableName);
            Models.Logaro objLogaro = new Models.Logaro();
            objLogaro.Log = objLogaroList.OrderBy(m => m.Id).ToList();
            log = objLogaroList.ToPagedList(pageIndex, pageSize);
            return View(log);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            //log4net.Config.XmlConfigurator.Configure();
            //Logger.Debug("Debug logg");
            //Logger.Info("Info logg");
            //Logger.Error("Error logg");
            //Logger.Fatal("Fatal logg");
            Logger.Warn("Warning logg");
            LogManager.Flush(1);
            var a = Request.ContentLength.ToString();
            var d = a.Length / 0;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            //log4net.Config.XmlConfigurator.Configure();
            //Logger.Debug("log Debug");
            //Logger.Info("log Info");
            return View();
        }

        public ActionResult Create()
        {
            throw new NotImplementedException();
        }

    }
}