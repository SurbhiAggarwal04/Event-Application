using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarRentedApplication
{
    public partial class TryIt_CarRentedpage : System.Web.UI.Page
    {
        static CarRentService.Service1Client client = new CarRentService.Service1Client();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
           
        }

        protected void ButtonFind_Click(object sender, EventArgs e)
        {
            
            if(TextBoxZip.Text=="" || TextBoxZip.Text.Length<5)
            {
                LabelError.Text = "Please provide the correct zipcode";
                LabelError.Visible = true;
            }
            else
            {
               
                string[] nearestAirportList = client.findNearestAirportList(TextBoxZip.Text);
                if (nearestAirportList == null )
                {
                  //  LabelError.Text = "Please provide the correct zipcode";
                  //  LabelError.Visible = true;
                    Label15.Visible = true;
                    TextBox6.Visible = false;
                    TextBox7.Visible = false;
                    TextBox8.Visible = false;
                    TextBox9.Visible = false;
                    TextBox10.Visible = false;

                    Button3.Visible = false;
                    Button4.Visible = false;
                    Button5.Visible = false;

                    Label13.Visible = false;
                    Label9.Visible = false;
                    Label10.Visible = false;
                    Label11.Visible = false;
                    Label12.Visible = false;
                }
                else
                {
                   LabelError.Visible = false;
                   Label15.Visible = false;
                    Label14.Visible = true;
                    switch(nearestAirportList.Length)
                    {
                        case 1: TextBox6.Visible = true;
                                TextBox6.Enabled = false;
                                TextBox6.Text = nearestAirportList[0];
                                Label13.Visible = true;
                                Button3.Visible = true;
                                break;

                        case 2: TextBox6.Visible = true;
                                TextBox6.Enabled = false;
                                TextBox6.Text = nearestAirportList[0];
                                TextBox7.Visible = true;
                                TextBox7.Enabled = false;
                                TextBox7.Text = nearestAirportList[1];
                                Label13.Visible = true;
                                Label9.Visible = true;
                                Button3.Visible = true;
                                Button4.Visible = true;
                                break;
                        case 3: TextBox6.Visible = true;
                                TextBox6.Enabled = false;
                                TextBox6.Text = nearestAirportList[0];
                                TextBox7.Visible = true;
                                TextBox7.Enabled = false;
                                TextBox7.Text = nearestAirportList[1];
                                TextBox8.Visible = true;
                                TextBox8.Enabled = false;
                                TextBox8.Text = nearestAirportList[2];
                                Label13.Visible = true;
                                Label9.Visible = true;
                                Label10.Visible = true;
                                Button3.Visible = true;
                                Button4.Visible = true;
                                Button5.Visible = true;
                                break;
                        case 4: TextBox6.Visible = true;
                                TextBox6.Enabled = false;
                                TextBox6.Text = nearestAirportList[0];
                                TextBox7.Visible = true;
                                TextBox7.Enabled = false;
                                TextBox7.Text = nearestAirportList[1];
                                TextBox8.Visible = true;
                                TextBox8.Enabled = false;
                                TextBox8.Text = nearestAirportList[2];
                                TextBox9.Visible = true;
                                TextBox9.Enabled = false;
                                TextBox9.Text = nearestAirportList[3];
                                Label13.Visible = true;
                                Label9.Visible = true;
                                Label10.Visible = true;
                                Label11.Visible = true;
                                Button3.Visible = true;
                                Button4.Visible = true;
                                Button5.Visible = true;
                                Button6.Visible = true;
                                break;
                        case 5: TextBox6.Visible = true;
                                TextBox6.Enabled = false;
                                TextBox6.Text = nearestAirportList[0];
                                TextBox7.Visible = true;
                                TextBox7.Enabled = false;
                                TextBox7.Text = nearestAirportList[1];
                                TextBox8.Visible = true;
                                TextBox8.Enabled = false;
                                TextBox8.Text = nearestAirportList[2];
                                TextBox9.Visible = true;
                                TextBox9.Enabled = false;
                                TextBox9.Text = nearestAirportList[3];
                                 TextBox10.Visible = true;
                                TextBox10.Enabled = false;
                                TextBox10.Text = nearestAirportList[4];
                                Label13.Visible = true;
                                Label9.Visible = true;
                                Label10.Visible = true;
                                Label11.Visible = true;
                                Label12.Visible = true;
                                Button3.Visible = true;
                                Button4.Visible = true;
                                Button5.Visible = true;
                                Button6.Visible = true;
                                Button7.Visible = true;
                                break;
                    }
                }
  
                   
                    LabelError.Visible = false;
                   
                    
                       

                }
            }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Label1.Visible = true;
            Label2.Visible = true;
            Label3.Visible = true;
            Label4.Visible = true;
            Label5.Visible = true;
            TextBox1.Text = TextBox6.Text; ;
            TextBox1.Visible = true;
            TextBox2.Visible = true;
            TextBox3.Visible = true;
            TextBox4.Visible = true;
            TextBox5.Visible = true;
            Button2.Visible = true;

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Label1.Visible = true;
            Label2.Visible = true;
            Label3.Visible = true;
            Label4.Visible = true;
            Label5.Visible = true;
            TextBox1.Text = TextBox7.Text; ;
            TextBox1.Visible = true;
            TextBox2.Visible = true;
            TextBox3.Visible = true;
            TextBox4.Visible = true;
            TextBox5.Visible = true;
            Button2.Visible = true;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Label1.Visible = true;
            Label2.Visible = true;
            Label3.Visible = true;
            Label4.Visible = true;
            Label5.Visible = true;
            TextBox1.Text = TextBox8.Text; ;
            TextBox1.Visible = true;
            TextBox2.Visible = true;
            TextBox3.Visible = true;
            TextBox4.Visible = true;
            TextBox5.Visible = true;
            Button2.Visible = true;
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Label1.Visible = true;
            Label2.Visible = true;
            Label3.Visible = true;
            Label4.Visible = true;
            Label5.Visible = true;
            TextBox1.Text = TextBox9.Text; ;
            TextBox1.Visible = true;
            TextBox2.Visible = true;
            TextBox3.Visible = true;
            TextBox4.Visible = true;
            TextBox5.Visible = true;
            Button2.Visible = true;
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Label1.Visible = true;
            Label2.Visible = true;
            Label3.Visible = true;
            Label4.Visible = true;
            Label5.Visible = true;
            TextBox1.Text = TextBox10.Text; ;
            TextBox1.Visible = true;
            TextBox2.Visible = true;
            TextBox3.Visible = true;
            TextBox4.Visible = true;
            TextBox5.Visible = true;
            Button2.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if(TextBox1.Text=="" ||TextBox2.Text==""||TextBox3.Text==""||TextBox4.Text==""||TextBox5.Text=="")
            {
                Label7.Visible=true;
            }
            else
            {
                Label7.Visible = false;
                string[] rentedCarList = client.findRentedCarlList(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text);
                if (rentedCarList != null)
                {
                    Table table = new Table();
                    table.BorderWidth = 3;
                    TableRow tr1 = new TableRow();
                    TableCell tc1 = new TableCell();
                    TableCell tc2 = new TableCell();
                    tc1.BorderWidth = 1;
                    tc2.BorderWidth = 1;
                    tc1.Controls.Add(new LiteralControl("S.No."));
                    tc2.Controls.Add(new LiteralControl("Model\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t ||     Type \t\t\t \t\t\t\t\t\t\t\t\t\t\t\t        ||      Seating \t\t\t\t\t\t\t\t    ||   Total Rent(including taxes) \t\t\t\t\t\t\t\t    ||    Description\t\t\t\t\t\t"));


                    tr1.Cells.Add(tc1);
                    tr1.Cells.Add(tc2);

                    table.Rows.Add(tr1);

                    for (int i = 0; i < rentedCarList.Length; i++)
                    {

                        TableRow tr2 = new TableRow();
                        TableCell tc11 = new TableCell();
                        TableCell tc12 = new TableCell();
                        tc11.BorderWidth = 1;
                        tc12.BorderWidth = 1;
                        tc11.Controls.Add(new LiteralControl(Convert.ToString(i + 1)));
                        tc12.Controls.Add(new LiteralControl(rentedCarList[i]));

                        tr2.Cells.Add(tc11);
                        tr2.Cells.Add(tc12);



                        table.Rows.Add(tr2);
                    }


                    form1.Controls.Add(table);
                }
                else
                {
                    Label label = new Label();
                    label.Text = "No rented Car list";
                    label.Visible = true;
                    form1.Controls.Add(label);
                }
                }
            }
        
            
        }
        }

      
    