using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logaro.log;

namespace Logaro.Controllers
{
    public class MyExceptionFileAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            LogHelper.WriteLog(filterContext.Exception.ToString());
        }
    }
}