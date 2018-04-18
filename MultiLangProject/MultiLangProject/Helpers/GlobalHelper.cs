using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Configuration;

namespace MultiLangProject.Helpers
{
    public class GlobalHelper
    {
        public static string CurrentCulture
        {
            get
            {
                return Thread.CurrentThread.CurrentUICulture.Name;
            }
        }

        public static string DefaultCulture
        {
            get
            {
                Configuration cfg = WebConfigurationManager.OpenWebConfiguration("/");
                GlobalizationSection sect = (GlobalizationSection)cfg.GetSection("system.web/globalization");
                return sect.UICulture;
            }
        }
    }
}