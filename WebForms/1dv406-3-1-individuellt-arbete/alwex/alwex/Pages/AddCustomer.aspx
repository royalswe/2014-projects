<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="AddCustomer.aspx.cs" Inherits="alwex.Pages.AddCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="AddType" CssClass="ErrorPrompt" runat="server" />

    <%-- Registrerings formulär. --%>
    <asp:FormView ID="CustomerFormView" runat="server"
        ItemType="alwex.Model.BLL.Customer"
        DefaultMode="Insert"
        InsertMethod="CustomerFormView_InsertItem">
        <InsertItemTemplate>
        <div id="addCustomerForm">
            <h2>Registrera Kund</h2>
            <ul>
                <li>
                    <p>Kundnummer</p>
                    <asp:TextBox ID="CustomerNUM" runat="server" MaxLength="10" Text='<%# BindItem.CustomerNUM %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="AddType" ErrorMessage="Kundnummer får inte vara tomt" Display="Dynamic" Text="•" CssClass="red" ControlToValidate="CustomerNUM" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorNUM" runat="server" ValidationGroup="AddType" ErrorMessage="Kundnummer får endast innehålla siffror" Display="Dynamic" Text="•" CssClass="red" ValidationExpression="\d+" ControlToValidate="CustomerNUM"/>
                </li>
                <li>
                    <p>Namn</p>
                    <asp:TextBox ID="Name" runat="server" MaxLength="25" Text='<%# BindItem.Name %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="AddType" ErrorMessage="Namnet får inte vara tomt" Display="Dynamic" Text="•" CssClass="red" ControlToValidate="Name" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorName" runat="server" ValidationGroup="AddType" ErrorMessage="Namn är av fel typ" ValidationExpression="^[a-zåäöA-ZÅÄÖ -]+$" Display="Dynamic" Text="•" CssClass="red" ControlToValidate="Name" />
                </li>
                <li>
                    <p>Ort</p>
                    <asp:TextBox ID="City" runat="server" MaxLength="25" Text='<%# BindItem.City %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="AddType" ErrorMessage="Ort får inte vara tomt" CssClass="red" Display="Dynamic" Text="•" ControlToValidate="City" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorOrt" runat="server" ValidationGroup="AddType" ErrorMessage="Ort är av fel typ" ValidationExpression="^[a-zåäöA-ZÅÄÖ -]+$" Display="Dynamic" Text="•" CssClass="red" ControlToValidate="City" />

                </li>
                <li>
                    <p>Postnummer</p>
                    <asp:TextBox ID="PostalCode" runat="server" MaxLength="6" Text='<%# BindItem.PostalCode %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="AddType" ErrorMessage="Postnumret får inte vara tomt" CssClass="red" Display="Dynamic" Text="•" ControlToValidate="PostalCode" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorPC" ValidationGroup="AddType" runat="server" ErrorMessage="Postnumret är inte i korrekt format" CssClass="red" Display="Dynamic" Text="•" ValidationExpression="^[1-9]\d{2} ?\d{2}" ControlToValidate="PostalCode"/>                    
                </li>
                <li>
                    <p>Telefonnummer</p>
                    <asp:TextBox ID="Phone" runat="server" MaxLength="15" Text='<%# BindItem.Phone %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="AddType" ErrorMessage="Telefonnumret får inte vara tomt" CssClass="red" Display="Dynamic" Text="•" ControlToValidate="Phone" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorTel" runat="server" ValidationGroup="AddType" ValidationExpression="^(\+|0)\d{6,15}" ErrorMessage="Telefon numret får endast innehålla siffror alternativt börja på +" CssClass="red" Display="Dynamic" Text="•" ControlToValidate="Phone" />
                </li>
                <li>
                    <asp:LinkButton runat="server" ValidationGroup="AddType" CssClass="AddCustomerButton" Text="Spara" CommandName="Insert" />
                    <asp:LinkButton ID="AddCustomerLinkButton" runat="server" CssClass="AddCustomerButton" PostBackUrl="~/Pages/CustomerList.aspx">Tillbaka till kunderna</asp:LinkButton>
                </li>
            </ul>
        </div>
        </InsertItemTemplate>


    </asp:FormView>
</asp:Content>
