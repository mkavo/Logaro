﻿using System.Web;
using System.Web.Mvc;
using Logaro.Controllers;

namespace Logaro
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            filters.Add(new MyExceptionFileAttribute());
        }

    }
}
