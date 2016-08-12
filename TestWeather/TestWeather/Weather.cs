using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWeather
{
    public class Weather
    {
        private string _date;

        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }
        private string _day;

        public string Day
        {
            get { return _day; }
            set { _day = value; }
        }
        private string _min;

        public string Min
        {
            get { return _min; }
            set { _min = value; }
        }
        private string _max;

        public string Max
        {
            get { return _max; }
            set { _max = value; }
        }
        private string _humidity;

        public string Humidity
        {
            get { return _humidity; }
            set { _humidity = value; }
        }
        private string _clouds;

        public string Clouds
        {
            get { return _clouds; }
            set { _clouds = value; }
        }

    }
}