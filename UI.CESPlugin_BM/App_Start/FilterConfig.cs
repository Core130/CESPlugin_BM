﻿using System.Web;
using System.Web.Mvc;

namespace UI.CESPlugin_BM
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
