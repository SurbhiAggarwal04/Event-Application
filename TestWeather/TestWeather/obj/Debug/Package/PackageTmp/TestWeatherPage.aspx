<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestWeatherPage.aspx.cs" Inherits="TestWeather.TestWeatherPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
        <div>
            <h2>Service Description: This service provides the Weather forecast of 5 consecutive days</h2>
            <h3>Open Weather Map- openweathermap(RestFul Implementation)</h3>
           <h3> <p>Operation: List<Weather> getWeatherForecast(string x)</p></h3>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Enter zip-code(US)"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBoxZip" runat="server" Height="21px" Width="189px"></asp:TextBox>
        </div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonFind" runat="server" OnClick="ButtonFind_Click" Text="Find" />
        &nbsp;
        <asp:Label ID="Label2" runat="server" Text="Please provide correct input." Visible="False"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="18pt" Text="Weather Forecast" Visible="False"></asp:Label>
        <asp:Table ID="Table1" runat="server" Visible="False">
        </asp:Table>
        <br />
        <br />
    </form>
   
</body>
</html>
