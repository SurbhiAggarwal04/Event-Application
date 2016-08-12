using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace TestWeather
{
    public partial class TestWeatherPage : System.Web.UI.Page
    {
        static int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
           if(Cache["NoOfRequest"]!=null)
           {
               Label4.Text = "No. of Request till now  :  " + Cache["NoOfRequest"];
           }
           else
           {
               Label4.Text = "No. of Request till now  :  " + 0;
           }
        }

        protected void ButtonFind_Click(object sender, EventArgs e)
        {
            if (TextBoxZip.Text == "" || TextBoxZip.Text.Length < 5)
            {
                Label2.Visible = true;
                Label3.Visible = false;
            }
            else
            {
                count++;
                Cache["NoOfRequest"] = count;
                Label2.Visible = false;
                string url = "http://localhost:61611/Service1.svc/weatherForecast?x=" + TextBoxZip.Text;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                Stream responseStream = response.GetResponseStream();


                StreamReader reader = new StreamReader(responseStream);
                string responsereader = reader.ReadToEnd();
                if (responsereader != null && responsereader != "")
                {
                    //string[] weatherResult = client.getWeatherForecast(TextBoxZip.Text);
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.LoadXml(responsereader);
                    XmlNodeList dateList = xmldoc.GetElementsByTagName("Date");
                    XmlNodeList dayList = xmldoc.GetElementsByTagName("Day");
                    XmlNodeList minList = xmldoc.GetElementsByTagName("Min");
                    XmlNodeList maxList = xmldoc.GetElementsByTagName("Max");
                    XmlNodeList humidityList = xmldoc.GetElementsByTagName("Humidity");
                    XmlNodeList cloudList = xmldoc.GetElementsByTagName("Clouds");

                    Label3.Visible = true;

                    int l = 0;
                    string[] result = new string[30];
                    for (int i = 0; i < dateList.Count; i++)
                    {
                        string date = Convert.ToString(dateList[i].InnerXml);
                        result[l] = date;
                        string day = Convert.ToString(dayList[i].InnerXml);
                        result[l + 1] = day;
                        string min = Convert.ToString(minList[i].InnerXml);
                        result[l + 2] = min;
                        string max = Convert.ToString(maxList[i].InnerXml);
                        result[l + 3] = max;
                        string humidity = Convert.ToString(humidityList[i].InnerXml);
                        result[l + 4] = humidity;
                        string clouds = Convert.ToString(cloudList[i].InnerXml);
                        result[l + 5] = clouds;

                        l = l + 6;
                    }

                    TableRow tr1 = new TableRow();
                    TableCell tc1 = new TableCell();
                    TableCell tc2 = new TableCell();
                    TableCell tc3 = new TableCell();
                    TableCell tc4 = new TableCell();
                    TableCell tc5 = new TableCell();
                    TableCell tc6 = new TableCell();
                    TableCell tc7 = new TableCell();

                    tc1.BorderWidth = 1;
                    tc2.BorderWidth = 1;
                    tc3.BorderWidth = 1;
                    tc4.BorderWidth = 1;
                    tc5.BorderWidth = 1;
                    tc6.BorderWidth = 1;
                    tc7.BorderWidth = 1;

                    tc1.Controls.Add(new LiteralControl("S.NO."));
                    tc2.Controls.Add(new LiteralControl("Date"));
                    tc3.Controls.Add(new LiteralControl("Day"));
                    tc4.Controls.Add(new LiteralControl("Min"));
                    tc5.Controls.Add(new LiteralControl("Max"));
                    tc6.Controls.Add(new LiteralControl("Humidity"));
                    tc7.Controls.Add(new LiteralControl("Clouds"));


                    tr1.Cells.Add(tc1);
                    tr1.Cells.Add(tc2);
                    tr1.Cells.Add(tc3);
                    tr1.Cells.Add(tc4);
                    tr1.Cells.Add(tc5);
                    tr1.Cells.Add(tc6);
                    tr1.Cells.Add(tc7);


                    Table1.Rows.Add(tr1);
                    l = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        TableRow tr2 = new TableRow();
                        TableCell tc11 = new TableCell();
                        TableCell tc12 = new TableCell();
                        TableCell tc13 = new TableCell();
                        TableCell tc14 = new TableCell();
                        TableCell tc15 = new TableCell();
                        TableCell tc16 = new TableCell();
                        TableCell tc17 = new TableCell();
                        tc11.BorderWidth = 1;
                        tc12.BorderWidth = 1;
                        tc13.BorderWidth = 1;
                        tc14.BorderWidth = 1;
                        tc15.BorderWidth = 1;
                        tc16.BorderWidth = 1;
                        tc17.BorderWidth = 1;

                        tc11.Controls.Add(new LiteralControl(Convert.ToString(i + 1)));
                        tc12.Controls.Add(new LiteralControl(result[l + 0]));
                        tc13.Controls.Add(new LiteralControl(result[l + 1]));
                        tc14.Controls.Add(new LiteralControl(result[l + 2]));
                        tc15.Controls.Add(new LiteralControl(result[l + 3]));
                        tc16.Controls.Add(new LiteralControl(result[l + 4]));
                        tc17.Controls.Add(new LiteralControl(result[l + 5]));
                        l = l + 6;


                        tr2.Cells.Add(tc11);
                        tr2.Cells.Add(tc12);
                        tr2.Cells.Add(tc13);
                        tr2.Cells.Add(tc14);
                        tr2.Cells.Add(tc15);
                        tr2.Cells.Add(tc16);
                        tr2.Cells.Add(tc17);


                        Table1.Rows.Add(tr2);

                    }
                    Table1.Visible = true;
                }
                else
                {
                    Label2.Visible = true;
                    Label3.Visible = false;
                }
            }
        }

        protected void textBoxFaltu_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}