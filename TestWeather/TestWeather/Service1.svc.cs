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

namespace TestWeather
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public List<Weather> getWeatherForecast(string zipcode)
        {
            List<Weather> weatherList = new List<Weather>();
            string[] cityState = findCity(zipcode);
            if(cityState!=null)
            { 
            string url = "http://api.openweathermap.org/data/2.5/forecast/daily?q=" + cityState[0] + "&mode=xml&units=metric&cnt=7";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(responsereader);
            XmlNodeList countryList = xmldoc.GetElementsByTagName("country");
            string country = Convert.ToString(countryList[0].InnerXml);
            if (country.Equals("US"))
            {
                XmlNodeList dateList = xmldoc.GetElementsByTagName("time");
                XmlNodeList tempList = xmldoc.GetElementsByTagName("temperature");
                XmlNodeList humidityList = xmldoc.GetElementsByTagName("humidity");
                XmlNodeList cloudList = xmldoc.GetElementsByTagName("clouds");
                // string result = "";
                for (int i = 0; i < 5; i++)
                {


                    string date = Convert.ToString(dateList[i].Attributes["day"].Value);
                    string day = Convert.ToString(tempList[i].Attributes["day"].Value);
                    string min = Convert.ToString(tempList[i].Attributes["min"].Value);
                    string max = Convert.ToString(tempList[i].Attributes["max"].Value);
                    string humidity = Convert.ToString(humidityList[i].Attributes["value"].Value) + Convert.ToString(humidityList[i].Attributes["unit"].Value);
                    string clouds = Convert.ToString(cloudList[i].Attributes["value"].Value);

                    Weather weather = new Weather();
                    weather.Date = date;
                    weather.Day = day;
                    weather.Min = min;
                    weather.Max = max;
                    weather.Humidity = humidity;
                    weather.Clouds = clouds;
                    weatherList.Add(weather);

                    //   result = date + "|" + day + "|" + min + "|" + max + "|" + humidity + "|" + clouds + "|" + result;
                }

                return weatherList;
            }
            else
            {
                return null;
            }

            }
            else
                return null;
        }
        private string[] findCity(string zipcode)
        {
            string[] cityStateArr = new string[2];

            string url = "http://zipcodedistanceapi.redline13.com/rest/YVWB6M7EHLKljlSVrrOVWLO5iiSGvyottk4z7beOXZahk2cMt1HqMwv5OoLjWaNq/info.xml/" + zipcode;
            try
            {

            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(responsereader);
            XmlNodeList cityList = xmldoc.GetElementsByTagName("city");
            XmlNodeList stateList = xmldoc.GetElementsByTagName("state");

            cityStateArr[0] = Convert.ToString(cityList[0].InnerXml);
            cityStateArr[1] = Convert.ToString(stateList[0].InnerXml);
            return cityStateArr;
           }
        catch(WebException e)
        {
        return null;
        }

        }
    }
}
