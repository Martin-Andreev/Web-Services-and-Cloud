﻿using System.Web;
using System.Web.Mvc;

namespace Distance_Calculator_REST_Service
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
