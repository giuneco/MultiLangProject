using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace MultiLangProject
{
    public class MyViewEngine : VirtualPathProviderViewEngine
    {
        public MyViewEngine()
        {
            this.ViewLocationFormats = new string[] { "~/Views/{1}/{0}.myview", "~/Views/Shared/{0}.myview" };
            this.PartialViewLocationFormats = new string[] { "~/Views/{1}/{0}.myview", "~/Views/Shared/{0}.myview" };
        }
        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            var physicalpath = controllerContext.HttpContext.Server.MapPath(partialPath);
            return new MyView(physicalpath);
        }

        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            var physicalpath = controllerContext.HttpContext.Server.MapPath(viewPath);
            return new MyView(physicalpath);
        }
    }

    public class MyView : IView
    {
        private string _viewPhysicalPath;

        public MyView(string ViewPhysicalPath)
        {
            _viewPhysicalPath = ViewPhysicalPath;
        }


        public void Render(ViewContext viewContext, System.IO.TextWriter writer)
        {
            //Load File
            string rawcontents = File.ReadAllText(_viewPhysicalPath);

            //Perform Replacements
            string parsedcontents = Parse(rawcontents, viewContext.ViewData);

            writer.Write(parsedcontents);
        }



        public string Parse(string contents, ViewDataDictionary viewdata)
        {
            return Regex.Replace(contents, "\\{(.+)\\}", m => GetMatch(m, viewdata));
        }

        public virtual string GetMatch(Match m, ViewDataDictionary viewdata)
        {
            if (m.Success)
            {
                string key = m.Result("$1");
                if (viewdata.ContainsKey(key))
                {
                    return viewdata[key].ToString();
                }
            }
            return string.Empty;
        }
    }
}