using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using log4net;
using Logaro.App_Data;
using Logaro.Models;
using Microsoft.Ajax.Utilities;
using PagedList;


namespace Logaro.Controllers
{
    public class HomeController : Controller
    {

        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        [HttpGet]
        public  ActionResult Index()
        {
            IEnumerable<WebApplication> apps = LogaroRepository.Instance.AppsConfig();
            int selectedStateId = 1;
            // Do this if you don't care about selection
            //List<SelectListItem> selectList = apps.Select(state => new SelectListItem {Value = selectList..ToString(), Text = state.Name}).ToList();

            List<SelectListItem> selectList = apps.Select(app => new SelectListItem { Value = app.ApplicationId.ToString(), Text = app.ApplicationName, Selected = (app.ApplicationId == selectedStateId) }).OrderBy(app => app.Text).ToList();
            ViewData["LogList"] = selectList;
            
            return  View(); 
        }

        [HttpPost]

        public ActionResult Index(FormCollection form)
        {
            string appId = form["WebApplication"];
            var tn = LogaroRepository.Instance.TableName(int.Parse(appId));
            var tablename = tn.Select(m=>m.TableName).FirstOrDefault();
            //ToLog(1, tablename);
            return RedirectToAction("ToLog", new {tableName = tablename });
        }


        public ActionResult ToLog(int? page, string tableName)
        {
            int pageSize = 7;
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