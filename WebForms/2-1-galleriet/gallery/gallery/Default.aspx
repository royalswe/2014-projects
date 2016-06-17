<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="gallery.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Galleri</title>    
    <link href="~/Content/style.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/Script.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>

<%-- Lyckad uppladning --%>
        <div id="savedImg" Visible="false" runat="server">
            <asp:Label ID="FileName" runat="server">
                Bilden {0} har sparats.               
            </asp:Label>
            <asp:ImageButton ID="ImageButton" runat="server" ImageUrl="Content/closebutton.jpg" OnClick="ImageButton_Click" />
        </div>

<%-- Large image --%>
        <div id="BigImg">
            <asp:Image ID="LargeImage" runat="server" />
        </div>
<%-- Repeater start --%>
    <asp:Repeater ID="ImgRepeater" runat="server" 
        ItemType="gallery.Model.Gallery" 
        SelectMethod="ImgRepeater_GetData"> 
        <headertemplate>
            <ul>
        </headertemplate>
            <itemtemplate>
                <li class="thumbs">
                    <asp:HyperLink ID="HyperLink1" runat="server"
                    NavigateUrl='<%#: "?name=" + Item.Name %>' 
                    ImageUrl='<%#: Item.Thumb %>' /> 
                </li>
            </itemtemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>       
    </asp:Repeater>
<%-- Repeater slut --%>

    <div id="StatusField" Visible="false" runat="server">
        <asp:Label ID="StatusLabel" runat="server"></asp:Label>
    </div>

<%-- Ladda upp fil start --%>
        <div>
            <fieldset>
                <legend>Ladda upp bild</legend>

                <asp:ValidationSummary ID="ValidationSummary1" CssClass="validationSummaryCss" runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="En fil måste väljas." Display="Dynamic" Text="•" CssClass="red" ControlToValidate="FileUpload"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Endast png, jpg eller gif är tillåtna" Display="Dynamic" Text="•" CssClass="red" ControlToValidate="FileUpload" ValidationExpression=".*\.(gif|jpg|png)$"></asp:RegularExpressionValidator>


                <asp:FileUpload ID="FileUpload" runat="server" />
                <asp:Button ID="UpploadButton" runat="server" Text="Ladda upp bild" OnClick="UpploadButton_Click" />
            </fieldset>
        </div>
<%-- Ladda upp slut --%>
    
    </div>
    </form>
</body>
</html>
