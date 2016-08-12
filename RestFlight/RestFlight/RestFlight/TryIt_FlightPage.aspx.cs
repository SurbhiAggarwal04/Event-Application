using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Xml;

namespace RestFlight
{
    public partial class TryIt_FlightPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BulletedList1.Items.Clear();

            if ("".Equals(TextBox1.Text))
            {
                BulletedList1.Items.Clear();

            }
            else
            {
                List<string> airValue = new List<string>();

                String urllink = "http://localhost:63953/Service1.svc/flightSearch?x=" + TextBox1.Text;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urllink);
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader sreader = new StreamReader(dataStream);
                string responsereader = sreader.ReadToEnd();
                response.Close();

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(responsereader);
                string val = doc.InnerText;
                string[] arr = val.Split('|');

                for (int i = 0; i < arr.Length - 1; i++)
                {
                    BulletedList1.Items.Add(arr[i]);
                }
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}