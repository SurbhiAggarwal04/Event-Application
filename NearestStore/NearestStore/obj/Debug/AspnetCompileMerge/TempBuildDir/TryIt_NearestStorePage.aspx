<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TryIt_NearestStorePage.aspx.cs" Inherits="NearestStore.TryIt_NearestStorePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
        <div>
            <h2>Nearest Store Location Service</h2>
            <br />
            <h3>Service Description : It returns the nearest store location based on the input store and zipcode</h3>
            <h4>Operation : string findNearestStore(string zipCode, string storeName)</h4>
            <p>
                &nbsp;</p>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Enter the store name"></asp:Label>
        <asp:TextBox ID="TextBoxStore" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Enter Zip-Code(US)"></asp:Label>
        <asp:TextBox ID="TextBoxZip" runat="server"></asp:TextBox>
        &nbsp;
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonFind" runat="server" OnClick="ButtonFind_Click" Text="Find" />
        <br />
        <br />
        
    </form>
    
</body>
</html>
