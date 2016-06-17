<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ConvertTemperatures.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Konvertera Temperaturer</title>
    <link href="~/Content/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" defaultfocus="TextBoxStart" defaultbutton="SubmitButton" runat="server">
    <div>
        <header><h1>Konvertera Temperaturer</h1></header>
        <div id="grayBorder"></div>
        <%-- Felmeddelanden --%>
        <asp:ValidationSummary ID="ValidationSummary" CssClass="red" runat="server" />
        <%-- temperatur tabbellen --%>
        <asp:Table ID="TempTable" runat="server" Visible="false"></asp:Table>
        <%-- Start temperatur --%>
        <asp:Label ID="StartLabel" runat="server" Text="Starttemperatur"/>
        <br />
        <asp:TextBox ID="TextBoxStart" Text="-5" runat="server"/>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Starttemperatur kan inte vara tom" Display="Dynamic" Text="*" CssClass="red" ControlToValidate="TextBoxStart"/>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Start temperaturen måste innehålla ett heltal" Display="Dynamic" Text="*" CssClass="red" Type="Integer" ControlToValidate="TextBoxStart" Operator="DataTypeCheck"/>
        <br />
        <%-- Slut temperatur --%>
        <asp:Label ID="EndLabel" runat="server" Text="Sluttemperatur"/>
        <br />
        <asp:TextBox ID="TextBoxEnd" Text="25" runat="server"/>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Sluttemperatur kan inte vara tom" Display="Dynamic" Text="*" CssClass="red" ControlToValidate="TextBoxEnd"/>
        <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Slut temperaturen måste innehålla ett heltal större än starttemperatur" Display="Dynamic" Text="*" CssClass="red" Type="Integer" Operator="GreaterThanEqual" ControlToCompare="TextBoxStart" ControlToValidate="TextBoxEnd"/>
        <br /> 
        <%-- Slut temperatur --%>
        <asp:Label ID="StepLabel" runat="server" Text="Temperatursteg"/>
        <br />
        <asp:TextBox ID="TextBoxStep" Text="5" runat="server"/>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Stegtemperatur kan inte vara tom" Display="Dynamic" Text="*" CssClass="red" ControlToValidate="TextBoxStep"/>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Temperatursteget måste ligga mellan 1 och 100" Display="Dynamic" Text="*" CssClass="red" ControlToValidate="TextBoxStep" Type="Integer" MaximumValue="100" MinimumValue="1"/>
        <br /> 
        <%-- Typ av temperatur --%>
        <asp:Label ID="RadioLabel" runat="server" Text="Typ av konvertering"/>
        <br />
        <asp:RadioButtonList ID="RadioButtonList" runat="server">
            <asp:ListItem value="C" Selected="true">Celcius till fahrenheit</asp:ListItem>
            <asp:ListItem value="F">Fahrenheit till celcius</asp:ListItem>
        </asp:RadioButtonList>

        <%-- submit knapp --%>
        <asp:Button ID="SubmitButton" runat="server" Text="Konvertera" OnClick="SubmitButton_Click" />

    </div>
    </form>
</body>
</html>
