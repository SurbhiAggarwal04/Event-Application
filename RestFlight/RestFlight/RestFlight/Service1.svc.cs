using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using System.Net;
using System.IO;
using System.Xml;
namespace RestFlight
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetairData(string airport)
        {
            List<string> airValue = new List<string>();



            String urllink = "https://api.flightstats.com/flex/flightstatus/rest/v2/xml/airport/tracks/" + airport + "/dep?appId=920c9617&appKey=27b99f6a5de4cdc23938bafe1acc16a4&includeFlightPlan=true&maxPositions=2&maxFlights=5";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urllink);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();

             XmlDocument xmldoc = new XmlDocument();
             xmldoc.LoadXml(responsereader);
             XmlNodeList airList = xmldoc.GetElementsByTagName("name");
             string s="";

                 for (int i = 0; i < airList.Count; i++)
                 {

                     if (!airList[i].ParentNode.Name.Equals("airport"))
                     {
                        
                         s += Convert.ToString(airList[i].InnerXml) + "|";
                     }
                 }
            return s;
        }
    }
}
