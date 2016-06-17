<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Versaler.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hur många versaler</title>
    <link href="~/Content/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Hur många versaler?</h1>
        <asp:TextBox ID="TextBox" runat="server" TextMode="MultiLine" CssClass="textarea"></asp:TextBox>
        <br />

        <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
            <asp:Literal ID="Result" runat="server">Texten innehåller {0} versaler.</asp:Literal>
            <br />
            <asp:Button ID="RefreshButton" runat="server" Text="Rensa" UseSubmitBehavior="False" />
        </asp:PlaceHolder>
        <br />
        <asp:Button ID="SendButton" runat="server" Text="Bestäm antalet versaler" OnClick="SendButton_Click" />
        
        <br />
        
    </div>
    </form>
</body>
</html>
