
using NearByHotels.HotelService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NearByHotels
{
    public partial class TryIt_NearByHotelPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (TextBox1.Text.Trim() != "" || TextBox1.Text.Length==5)
                {
                    Label3.Visible = false;
                    Label1.Text = "";
                    Service1Client client = new Service1Client();
                    HotelService.Hotel[] hotelList = client.getHotels(TextBox1.Text.Trim());
                    if (hotelList != null)
                    {
                        for (int i = 0; i < hotelList.Count(); i++)
                        {
                            Label1.Text = Label1.Text + "<b>Name:</b> " + hotelList[i].name + "<br /><b>Address: </b>" + hotelList[i].address + " <br /><b>Reference: </b>" + hotelList[i].referenceId + " <br /><b>Rating: </b>" + hotelList[i].rating + "<br /><br />";
                            Label1.Visible = true;
                            Label2.Visible = false;
                        }
                    }
                    else
                    {
                        Label3.Text = "Please provide correct zipcode";
                        Label3.Visible = true;
                    }
                }
                else
                {
                    Label3.Text = "Please provide correct zipcode";
                    Label3.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Label1.Text = "No Data Found";
                Label1.Visible = true;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox2.Text.Trim() != "")
                {
                    Label4.Visible = false;
                    Label2.Text = "";
                    Service1Client client = new Service1Client();
                    HotelService.HotelDetails[] hotelDeatilsList= client.getHotelDetails(TextBox2.Text.Trim());
                    if(hotelDeatilsList!=null)
                    {
                        for (int i = 0; i < hotelDeatilsList.Count(); i++)
                        {
                            string s;
                            string number = "";
                            string website = "";
                            if (hotelDeatilsList[i].number != null)
                            {
                                number = hotelDeatilsList[i].number;
                            }
                            if (hotelDeatilsList[i].website != null)
                            {
                                website = hotelDeatilsList[i].website;
                            }
                            s = "<b>Name:</b> " + hotelDeatilsList[i].name +
                                " <br /><b>Phone Number: </b>" + number +
                                "<br /> <b>Website: </b>" + website + "<br /><br />";
                            for (int j = 0; j < hotelDeatilsList[i].reviewList.Count(); j++)
                            {
                                Review r = new Review();
                                string rate = "";
                                if (hotelDeatilsList[i].reviewList[j].rate != null)
                                {
                                    rate = hotelDeatilsList[i].reviewList[j].rate;
                                }
                                s = s + "<b>Review " + j + "</b>: " + hotelDeatilsList[i].reviewList[j].text +
                                    "<br /><b>Author</b>: " + hotelDeatilsList[i].reviewList[j].author_name +
                                    "<br /><b>Rating</b>: " + rate +
                                    "<br /><br />";
                            }
                            Label2.Text = Label2.Text + s;
                            Label2.Visible = true;
                            Label1.Visible = false;
                        }
                    }
                        else{
                             Label4.Text = "Please provide correct zipcode";
                               Label4.Visible = true;
                        }
                    }
                   
                
                else
                {
                    Label4.Text = "Please provide correct zipcode";
                    Label4.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Label2.Text = "No Data Found";
                Label2.Visible = true;
            }
            
        }
    }
}