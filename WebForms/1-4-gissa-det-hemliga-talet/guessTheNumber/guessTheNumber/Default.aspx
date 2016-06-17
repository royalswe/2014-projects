<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="guessTheNumber.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gissa det hemliga talet</title>
    <link href="~/Content/Style.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" defaultFocus="TextBox" defaultButton="Submit" runat="server">
    <div>

        <h1>Gissa det hemliga talet</h1>
            <asp:ValidationSummary ID="ValidationSummary1" CssClass="red" runat="server"/>        
        <div>
            Ange ett tal mellan 1 till 100: 
            <asp:TextBox ID="TextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ett tal måste anges" CssClass="red" Display="Dynamic" Text="*" ControlToValidate="TextBox"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Ett tal måste anges mellan 1 och 100" CssClass="red" Display="Dynamic" Text="*" ControlToValidate="TextBox" MinimumValue="1" MaximumValue="100" Type="Integer"></asp:RangeValidator>

            <asp:Button ID="Submit" runat="server" Text="Gissa" OnClick="Submit_Click" />
        </div>
        <div>
            <asp:Label ID="GuessLabel" runat="server" Text=""></asp:Label>
            <asp:Label ID="TextLabel" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="Answer" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Button ID="RestartButton" runat="server" Visible="false" Text="Slumpa nytt hemligt tal" CausesValidation="false" UseSubmitBehavior="False" />
        </div>
    </div>
    </form>
</body>
</html>
