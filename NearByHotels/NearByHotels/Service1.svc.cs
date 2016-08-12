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

namespace NearByHotels
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public List<Hotel> getHotels(string zipcode)
        {
            try
            {
                List<Hotel> hotelList = new List<Hotel>();
                string url = "https://maps.googleapis.com/maps/api/place/textsearch/xml?key=AIzaSyBtKHpv3Z6jMlmb_heh8lBzEvs-rUzRIvY&query=restaurants%20in%20," + zipcode;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                WebResponse response = request.GetResponse();

                Stream dataStream = response.GetResponseStream();
                StreamReader sreader = new StreamReader(dataStream);
                string responsereader = sreader.ReadToEnd();
                response.Close();
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(responsereader);
                XmlNodeList statusList = xmldoc.GetElementsByTagName("status");
                if (statusList[0].InnerText.Equals("OK"))
                {
                    XmlNodeList hotelElements = xmldoc.GetElementsByTagName("result");
                    foreach (XmlNode node in hotelElements)
                    {
                        if (node.SelectSingleNode("rating") != null)
                        {
                            Hotel hotel = new Hotel();
                            hotel.name = node.SelectSingleNode("name").InnerText;
                            hotel.address = node.SelectSingleNode("formatted_address").InnerText;
                            hotel.rating = node.SelectSingleNode("rating").InnerText;
                            hotel.referenceId = node.SelectSingleNode("place_id").InnerText;
                            hotelList.Add(hotel);
                        }

                    }
                    return hotelList;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception e)
            {
                return null;
            }
        }
       public  List<HotelDetails> getHotelDetails(string hotelId)
        {
            try
            {
                List<HotelDetails> hotelDeatilsList = new List<HotelDetails>();
                string url = "https://maps.googleapis.com/maps/api/place/details/xml?key=AIzaSyBtKHpv3Z6jMlmb_heh8lBzEvs-rUzRIvY&placeid=" + hotelId;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                WebResponse response = request.GetResponse();

                Stream dataStream = response.GetResponseStream();
                StreamReader sreader = new StreamReader(dataStream);
                string responsereader = sreader.ReadToEnd();
                response.Close();
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(responsereader);
                XmlNodeList statusList = xmldoc.GetElementsByTagName("status");
                if (statusList[0].InnerText.Equals("OK"))
                {
                    XmlNodeList hotelDetails = xmldoc.GetElementsByTagName("result");
                    foreach (XmlNode node in hotelDetails)
                    {
                        List<Review> reviewList = new List<Review>();
                        HotelDetails hoteldetails = new HotelDetails();
                        hoteldetails.name = node.SelectSingleNode("name").InnerText;
                        hoteldetails.number = node.SelectSingleNode("formatted_phone_number").InnerText;
                        hoteldetails.url = node.SelectSingleNode("url").InnerText;
                        hoteldetails.website = node.SelectSingleNode("website").InnerText;
                        XmlNodeList ReviewList = node.SelectNodes("review");
                        foreach (XmlNode node1 in ReviewList)
                        {
                            Review review = new Review();
                            review.author_name = node1.SelectSingleNode("author_name").InnerText;
                            review.time = node1.SelectSingleNode("time").InnerText;
                            review.rate = node1.SelectSingleNode("rating").InnerText;
                            review.text = node1.SelectSingleNode("text").InnerText;
                            reviewList.Add(review);
                        }
                        hoteldetails.reviewList = reviewList;
                        hotelDeatilsList.Add(hoteldetails);
                    }
                    return hotelDeatilsList;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }

        }
    }
}
