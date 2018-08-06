using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Utilities
{
    public static class WebBrowser
    {
        public static string GetWebBrowserName()
        {
            string WebBrowserName = string.Empty;
            try
            {
                WebBrowserName = HttpContext.Current.Request.Browser.Browser;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return WebBrowserName;
        }
    }
}