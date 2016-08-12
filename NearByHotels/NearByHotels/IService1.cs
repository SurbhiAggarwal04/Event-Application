using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace NearByHotels
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        List<Hotel> getHotels(string zipcode);

        [OperationContract]
        List<HotelDetails> getHotelDetails(string hotelId);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Hotel
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string address { get; set; }
        [DataMember]
        public string rating { get; set; }
        
        [DataMember]
        public string referenceId { get; set; }
    }

    [DataContract]
    public class HotelDetails
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string number { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public string website { get; set; }
        [DataMember]
        public List<Review> reviewList { get; set; }
       
        
    }
    [DataContract]
    public class Review
    {
        [DataMember]
        public string time { get; set; }
        [DataMember]
        public string text { get; set; }
        [DataMember]
        public string author_name { get; set; }
        [DataMember]
        public string rate { get; set; }
       

    }
}
