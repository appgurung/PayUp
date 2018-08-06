using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;

namespace Utilities
{
    public static class GeoLocation
    {
        public static DataTable GetLocation(string ipaddress)
        {
            WebRequest rssReq = WebRequest.Create("http://freegeoip.appspot.com/xml/" + ipaddress);
            WebProxy px = new WebProxy("http://freegeoip.appspot.com/xml/" + ipaddress, true);
            rssReq.Proxy = px;
            rssReq.Timeout = 2000;
            try
            {
                WebResponse rep = rssReq.GetResponse();
                XmlTextReader xtr = new XmlTextReader(rep.GetResponseStream());
                DataSet ds = new DataSet();
                ds.ReadXml(xtr);
                return ds.Tables[0];
            }
            catch
            {
                return null;
            }
        }

        public static string GetLocation2( string ip)
        { 
            XmlDocument doc = new XmlDocument();

            string getdetails = "http://www.freegeoip.net/xml/" + ip;

            doc.Load(getdetails);

            XmlNodeList nodeLstCountry = doc.GetElementsByTagName("CountryName");

           return nodeLstCountry[0].InnerText;
        }
    }
}