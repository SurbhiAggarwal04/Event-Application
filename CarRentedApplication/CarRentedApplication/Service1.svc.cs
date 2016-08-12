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

namespace CarRentedApplication
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string[] findNearestAirportList(string zipcode)
        {
            string[] cityStateArr = findCity(zipcode);
            if (cityStateArr != null)
            {
                string[] nearestAirportList = getNearestAirport(cityStateArr[0], cityStateArr[1]);

                return nearestAirportList;
            }
            else
            {
                return null;
            }
            
        }

        private string[] findCity(string zipcode)
        {
            string[] cityStateArr = new string[2];
            try
            {
                string url = "http://zipcodedistanceapi.redline13.com/rest/YVWB6M7EHLKljlSVrrOVWLO5iiSGvyottk4z7beOXZahk2cMt1HqMwv5OoLjWaNq/info.xml/" + zipcode;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader sreader = new StreamReader(dataStream);
                string responsereader = sreader.ReadToEnd();
                response.Close();
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(responsereader);
                XmlNodeList erorList = xmldoc.GetElementsByTagName("error");
                if (erorList[0] != null || erorList != null)
                {
                    XmlNodeList cityList = xmldoc.GetElementsByTagName("city");
                    XmlNodeList stateList = xmldoc.GetElementsByTagName("state");

                    cityStateArr[0] = Convert.ToString(cityList[0].InnerXml);
                    cityStateArr[1] = Convert.ToString(stateList[0].InnerXml);
                    return cityStateArr;
                }
                else
                {
                    return null;
                }
            }
            catch (WebException e)
            {
                return null;
            }
            
        }

        private string[] getNearestAirport(string city, string state)
        {
            try
            {
                string url = "http://maps.googleapis.com/maps/api/geocode/xml?address=airport%20" + city + "," + state + "&sensor=false";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader sreader = new StreamReader(dataStream);
                string responsereader = sreader.ReadToEnd();
                response.Close();
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(responsereader);
                XmlNodeList airportShortNameList = xmldoc.GetElementsByTagName("short_name");
                int count = airportShortNameList.Count;
                int j = 0;
                count = count / 6;
                string[] nearestAirportList = new string[count];
                for (int i = 0; i < airportShortNameList.Count; i++)
                {
                    nearestAirportList[j] = Convert.ToString(airportShortNameList[i].InnerXml);
                    i = i + 5;
                    j++;
                    if (j >= count) break;
                }
                return nearestAirportList;
            }
            catch (WebException e)
            {
                return null;
            }
       }


        public string[] findRentedCarlList(string airport, string startDate, string endDate, string pickUpTime, string dropoffTime)
        {

            try
            {
                string url = "http://api.hotwire.com/v1/search/car?apikey=xqaqqjdwyam82f574vhrxd9k&dest=" + airport + "&startdate=" + startDate + "&enddate=" + endDate + "&pickuptime=" + pickUpTime + "&dropofftime=" + dropoffTime;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader sreader = new StreamReader(dataStream);
                string responsereader = sreader.ReadToEnd();
                response.Close();
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(responsereader);
                XmlNodeList PossibleModels = xmldoc.GetElementsByTagName("PossibleModels");
                XmlNodeList CarTypeName = xmldoc.GetElementsByTagName("CarTypeName");
                XmlNodeList TypicalSeating = xmldoc.GetElementsByTagName("TypicalSeating");
                XmlNodeList TotalPrice = xmldoc.GetElementsByTagName("TotalPrice");
                XmlNodeList LocationDescription = xmldoc.GetElementsByTagName("LocationDescription");
                XmlNodeList CarResult = xmldoc.GetElementsByTagName("CarResult");

                string[] rentedCarList = new string[PossibleModels.Count];

                for (int i = 0; i < PossibleModels.Count; i++)
                {
                    string model = Convert.ToString(PossibleModels[i].InnerXml);
                    string seating = Convert.ToString(TypicalSeating[i].InnerXml);
                    string type = Convert.ToString(CarTypeName[i].InnerXml);
                    string price = Convert.ToString(TotalPrice[i].InnerXml);
                    string description = Convert.ToString(LocationDescription[i].InnerXml);
                    rentedCarList[i] = model + "   ||    " + type + "   ||   " + seating + "   ||   " + price + "   ||   " + description;
                }
                return rentedCarList;
            }
            catch (WebException e)
            {
                return null;
            }
        }
    }
}
