using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NearestStore
{
    public partial class TryIt_NearestStorePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie myCookies = Request.Cookies["myCookieId"];
            String date = DateTime.Now.ToLongDateString();
            String time = DateTime.Now.ToLongTimeString();
            myCookies["CurrentRequestedTime"] = date + "  " + time;
            if (myCookies != null)
            {
                if (myCookies["LastInput"]!=null)
                Label3.Text = "Last Store Input  :  " + myCookies["LastInput"] + "  ||   Last Requested Time   :    " + myCookies["RequestedTime"] + "<br><br>";
                else
                    Label3.Text = "Last Requested Time   :    " + myCookies["RequestedTime"] + "<br><br>";
                Label4.Text = "Current Request Time   :    " + myCookies["CurrentRequestedTime"] + "<br><br>";
                
            }
        }

        protected void ButtonFind_Click(object sender, EventArgs e)
        {
            if (TextBoxZip.Text == "" || TextBoxStore.Text == "")
            {
                Label error = new Label();
                error.Text = "Please provide the inputs";
                form2.Controls.Add(error);
            }
            else
            {
                NearestStoreService.Service1Client client = new NearestStoreService.Service1Client();
                string result = client.findNearestStore(TextBoxZip.Text, TextBoxStore.Text);
                if (result != null)
                {
                    String date = DateTime.Now.ToLongDateString();
                    String time = DateTime.Now.ToLongTimeString();
                    HttpCookie myCookies = new HttpCookie("myCookieId");
                    myCookies["RequestedTime"] = date + "  "+time  ;
                    myCookies["LastInput"] = TextBoxStore.Text;
                    
                    myCookies.Expires = DateTime.Now.AddMonths(6);
                    Response.Cookies.Add(myCookies);
                    Label nearDetail = new Label();
                    nearDetail.Text = "Nearby Store Detail:";
                    nearDetail.Visible = true;
                    form2.Controls.Add(nearDetail);

                    Table table = new Table();
                    table.BorderWidth = 5;
                    TableRow tr1 = new TableRow();
                    TableRow tr2 = new TableRow();
                    TableRow tr3 = new TableRow();
                    TableCell tc = new TableCell();
                    tc.Controls.Add(new LiteralControl(result));
                    tr2.Cells.Add(tc);
                    table.Rows.Add(tr1);
                    table.Rows.Add(tr2);
                    table.Rows.Add(tr3);
                    table.Visible = true;
                    form2.Controls.Add(table);
                }
                else
                {
                    Label error = new Label();
                    error.Text = "Please provide the correct inputs";
                    form2.Controls.Add(error);
                }
            }
            
        }
    }
}