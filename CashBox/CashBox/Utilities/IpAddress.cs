using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Utilities { 
    public static class IpAddress
    {
        public static string GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }

        public static string GetIPAddress2()
        {
            string varIPAddress = string.Empty;
            string varVisitorCountry = string.Empty;
            string varIpAddress = string.Empty;
            varIpAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(varIpAddress))
            {
                if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
                {
                    varIpAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                }
            }

            //varIPAddress = (System.Web.UI.Page)Request.ServerVariables["HTTP_X_FORWARDED_FOR"];    
            if (varIPAddress == "" || varIPAddress == null)
            {
                if (HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"] != null)
                {
                    varIpAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }
            }
            //varIPAddress = Request.ServerVariables["REMOTE_ADDR"];    
            return varIpAddress;
        }
    }
}