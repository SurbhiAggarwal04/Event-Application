using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;

namespace NearestStore
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
       public string findNearestStore(string zipCode, string storeName)
        {
            try
            {
                string url = "http://zipcodedistanceapi.redline13.com/rest/YVWB6M7EHLKljlSVrrOVWLO5iiSGvyottk4z7beOXZahk2cMt1HqMwv5OoLjWaNq/info.xml/" + zipCode + "/degrees";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader sreader = new StreamReader(dataStream);
                string responsereader = sreader.ReadToEnd();
                response.Close();
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(responsereader);
                XmlNodeList latList = xmldoc.GetElementsByTagName("lat");
                XmlNodeList lonList = xmldoc.GetElementsByTagName("lng");
                string latitude = Convert.ToString(latList[0].InnerXml);
                string longitude = Convert.ToString(lonList[0].InnerXml);




                string url2 = "https://maps.googleapis.com/maps/api/place/nearbysearch/xml?name=" + storeName + "&location=" + latitude + "," + longitude + "&rankby=distance&key=AIzaSyBsx7n1z8IDW9NbheaRtmYaVT3sjeZiE2A";
                WebClient wc = new WebClient();
                StreamReader reader = new StreamReader(wc.OpenRead(url2));
                string input = reader.ReadToEnd();

                XmlReader xmlRead;
                xmlRead = XmlReader.Create(new StringReader(input));
                xmlRead.ReadToFollowing("status");
                string status = Convert.ToString(xmlRead.ReadString());
                string name = "";
                string vicinity = "";
                string type = "";
                string result = "";
                if (status.Equals("OK"))
                {



                    xmlRead.ReadToFollowing("name");
                    name = "Name: " + Convert.ToString(xmlRead.ReadString());

                    xmlRead.ReadToFollowing("vicinity");
                    vicinity = "Address: " + Convert.ToString(xmlRead.ReadString());

                    xmlRead.ReadToFollowing("type");
                    type = "Type of Store: " + Convert.ToString(xmlRead.ReadString());

                    xmlRead.ReadToFollowing("lat");
                    latitude = "Store Latitude: " + Convert.ToString(xmlRead.ReadString());

                    xmlRead.ReadToFollowing("lng");
                    longitude = "Store Longitude: " + Convert.ToString(xmlRead.ReadString());

                    string delimiter = " || ";
                    result = name + delimiter + vicinity + delimiter + type + delimiter + latitude + delimiter + longitude;
                    return result;
                }
                else
                {
                    return "No store found within the given zip-code";
                }

            }
           catch(Exception e)
            {
                return null;
            }
                 
                 
             }
            
        }
    }


