<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="cashReceipt.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Kassa Kvitto</title>
    <link href="~/Content/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" defaultfocus="InputBox" defaultbutton="CalculateButton">
    <div>
        <h1>Kassakvitto</h1>
        <p>Total köpesumma</p>
        <asp:TextBox ID="InputBox" runat="server" TextMode="SingleLine"></asp:TextBox> kr
         <%-- Validera felmeddelanden --%>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="red" ErrorMessage="Ange en total köpesumma!" Display="Dynamic" ControlToValidate="InputBox"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" CssClass="red" ErrorMessage="Ange summa större än 0!" ControlToValidate="InputBox" Display="Dynamic" Operator="GreaterThan" Type="Currency" ValueToCompare="0"></asp:CompareValidator>
        <br /><br />
        <asp:Button ID="CalculateButton" runat="server" Text="Räkna ut rabatt" OnClick="CalculateButton_Click" />
        <br /><br />
        <%-- Presentera kvittot --%>
        <asp:PlaceHolder ID="PlaceHolder" runat="server" Visible="false">
            <div class="receipt">
                <asp:Label ID="CalculatedReceipt" runat="server">
                    <p class="receiptText">Kassa kvitto<br />
                    Tel:0470-12345<br />
                    Öppetider 8-17</p>
                    <hr />
                    {0}
                    <hr />
                    <p class="receiptText">ORG.NR 201573821<br />
                    VÄLKOMMEN ÅTER</p>
                </asp:Label>
            </div>
        </asp:PlaceHolder>
    </div>
    </form>
</body>
</html>
