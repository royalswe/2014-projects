<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="alwex.Pages.CustomerList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--Navigering--%>
    <asp:LinkButton ID="AddCustomerLinkButton" CssClass="customerLinkButton" PostBackUrl="~/Pages/AddCustomer.aspx" runat="server">Lägg till kund</asp:LinkButton>
    <asp:LinkButton ID="LinkButton1" CssClass="linkButton" PostBackUrl="~/Pages/Default.aspx" runat="server">Till Pallstansningen</asp:LinkButton>
    <asp:LinkButton ID="DefaultLinkButton" CssClass="linkButton" PostBackUrl="~/Pages/ReportList.aspx" runat="server">Till Rapporterna</asp:LinkButton>

    <asp:ValidationSummary ID="ValidationSummary1" CssClass="ErrorPrompt" runat="server" />

    <%-- Lista med kunduppgifter. --%>
    <asp:ListView ID="CustomerListView" runat="server"
        ItemType="alwex.Model.BLL.Customer"
        SelectMethod="CustomerListView_GetData"
        DeleteMethod="CustomerListView_DeleteItem"
        UpdateMethod="CustomerListView_UpdateItem"
        DataKeyNames="CustomerID">
        <LayoutTemplate>
            <table id="tableView">
                <tr id="CustomertrHead">
                    <th>Kundnummer</th>
                    <th>Namn</th>
                    <th>Ort</th>
                    <th>Postnummer</th>
                    <th>Telefon</th>
                    <th>Redigera</th>
                </tr>
                <asp:PlaceHolder ID="ItemPlaceHolder" runat="server" />
            </table>
        </LayoutTemplate>
        <ItemTemplate>
                <%-- Mall för nya rader. --%>
                <tr id="trBody">
                    <td>
                        <%# Item.CustomerNUM %>
                    </td>
                    <td>
                        <%#: Item.Name %>
                    </td>
                    <td>
                        <%#: Item.City %>
                    </td>
                    <td>
                        <%#: Item.PostalCode %>
                    </td>
                    <td>
                        <%#: Item.Phone %>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="Delete" Text="Ta bort / " CausesValidation="false"
                        OnClientClick='<%# String.Format("return confirm(\"Vill du ta bort {0}?\")", Item.CustomerNUM) %>' />
                        <asp:LinkButton runat="server" CommandName="Edit" Text=" Redigera" CausesValidation="false" />
                    </td>
                </tr>
        </ItemTemplate>
        <EmptyDataTemplate>
              <p>
                  Kunduppgifter saknas.
              </p>
        </EmptyDataTemplate>
        <%-- Mall för rad i tabellen för att redigera kunduppgifter. --%>
        <EditItemTemplate>
            <tr>
                <td>
                    <asp:TextBox ID="CustomerNUM" runat="server" MaxLength="10" Text='<%# BindItem.CustomerNUM %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Kundnummer får inte vara tomt" CssClass="red" Display="Dynamic" Text="•" ControlToValidate="CustomerNUM" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorNUM" runat="server" ErrorMessage="Kundnummer får endast innehålla siffror" CssClass="red" Display="Dynamic" Text="•" ValidationExpression="\d+" ControlToValidate="CustomerNUM"/>
                </td>
                <td>
                    <asp:TextBox ID="Name" runat="server" MaxLength="25" Text='<%# BindItem.Name %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Namnet får inte vara tomt" CssClass="red" Display="Dynamic" Text="•" ControlToValidate="Name" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorName" runat="server" ErrorMessage="Namn är av fel typ" ValidationExpression="^[a-zåäöA-ZÅÄÖ -]+$" Display="Dynamic" Text="•" CssClass="red" ControlToValidate="Name" />
                </td>
                <td>
                    <asp:TextBox ID="City" runat="server" MaxLength="25" Text='<%# BindItem.City %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Ort får inte vara tomt" CssClass="red" Display="Dynamic" Text="•" ControlToValidate="City" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorCity" runat="server" ErrorMessage="Ort är av fel typ" ValidationExpression="^[a-zåäöA-ZÅÄÖ -]+$" Display="Dynamic" Text="•" CssClass="red" ControlToValidate="City" />                
                </td>
                <td>
                    <asp:TextBox ID="PostalCode" runat="server" MaxLength="6" Text='<%# BindItem.PostalCode %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Postnumret får inte vara tomt" CssClass="red" Display="Dynamic" Text="•" ControlToValidate="PostalCode" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Postnumret är inte korrekt" CssClass="red" Display="Dynamic" Text="•" ValidationExpression="^[1-9]\d{2} ?\d{2}" ControlToValidate="PostalCode"/>                    
                </td>
                <td>
                    <asp:TextBox ID="Phone" runat="server" MaxLength="15" Text='<%# BindItem.Phone %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Telefonnumret får inte vara tomt" CssClass="red" Display="Dynamic" Text="•" ControlToValidate="Phone" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Telefon numret får endast innehålla siffror alternativt börja på +" CssClass="red" Display="Dynamic" Text="•" ValidationExpression="^(\+|0)\d{6,15}" ControlToValidate="Phone"/>
                
                </td>
                <td>
                    <%-- "Kommandknappar" för att uppdatera en kunduppgift och avbryta. --%>
                    <asp:LinkButton runat="server" CommandName="Update" Text="Spara / " />
                    <asp:LinkButton runat="server" CommandName="Cancel" Text="Avbryt / " CausesValidation="false" />
                </td>
            </tr>
        </EditItemTemplate>
    </asp:ListView>

</asp:Content>
