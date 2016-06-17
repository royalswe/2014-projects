<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WP14_Contacts.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Kontakter</title>
    <link href="~/Content/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <%--Rättmeddelanden--%>
        <div id="SuccesPrompt" visible="false" runat="server">
            <asp:Label ID="SuccesText" runat="server" Text="{0}"></asp:Label>
            <asp:ImageButton ID="ErrorImageButton" ImageUrl="Content/closebutton.jpg" runat="server" OnClick="ErrorImageButton_Click" />
        </div>

        <%--Felmeddelanden--%>
        <asp:ValidationSummary ID="ValidationSummary1" CssClass="ErrorPrompt" runat="server" />
        <asp:ValidationSummary ID="ValidationSummary3" CssClass="ErrorPrompt" runat="server" ValidationGroup="EditType" ShowModelStateErrors="false" />

        <asp:ListView ID="ContactListView" runat="server"
            ItemType="WP14_Contacts.Model.BLL.Contact"
            SelectMethod="ContactListView_GetData"
            DeleteMethod="ContactListView_DeleteItem"
            InsertMethod="ContactListView_InsertItem"
            UpdateMethod="ContactListView_UpdateItem"
            DataKeyNames="ContactID"
            InsertItemPosition="FirstItem">            
            <LayoutTemplate>
                <table>
                    <tr id="trHead">
                        <th>Förnamn</th>
                        <th>Efternamn</th>
                        <th>Epost</th>
                        <th>Redigera</th>
                    </tr>
                    <asp:PlaceHolder ID="ItemPlaceHolder" runat="server" />
                </table>
                <div id="pagination">
                <asp:DataPager ID="DataPager1" runat="server" PageSize="10">
                    <Fields>
                        <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowNextPageButton="false" FirstPageText="<< Första" PreviousPageText="< Föregående" ButtonCssClass="button" />
                        <asp:NumericPagerField ButtonType="Link" ButtonCount="10" />
                        <asp:NextPreviousPagerField ShowLastPageButton="true" ShowPreviousPageButton="false" NextPageText="Nästa >" LastPageText="Sista >>" ButtonCssClass="button" />
                    </Fields>
                </asp:DataPager>
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <%-- Mall för nya rader. --%>
                <tr id="trBody">
                    <td>
                        <%#: Item.FirstName %>
                    </td>
                    <td>
                        <%#: Item.LastName %>
                    </td>
                    <td>
                        <%#: Item.EmailAdress %>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="Delete" Text="Ta bort" CausesValidation="false"
                            OnClientClick='<%# String.Format("return confirm(\"Vill du ta bort {0}?\")", Item.FirstName) %>' />
                        <asp:LinkButton runat="server" CommandName="Edit" Text="Redigera" CausesValidation="false" />
                    </td>
                </tr>
            </ItemTemplate>
            <EmptyDataTemplate>
                <%-- Detta visas då kunduppgifter saknas i databasen. --%>
                <p>
                    Kunduppgifter saknas.
                </p>
            </EmptyDataTemplate>
            <EditItemTemplate>
              <%-- Mall för rad i tabellen för att redigera kunduppgifter. --%>
                <tr>
                    <td>
                        <asp:TextBox ID="FirstName" runat="server" MaxLength="50" Text='<%# BindItem.FirstName %>' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="EditType" ErrorMessage="Förnamnet får inte vara tomt" Display="Dynamic" Text="•" ControlToValidate="FirstName"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="LastName" runat="server" MaxLength="50" Text='<%# BindItem.LastName %>' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="EditType" ErrorMessage="Efternamnet får inte vara tomt" Display="Dynamic" Text="•" ControlToValidate="LastName"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="EmailAdress" runat="server" MaxLength="50" Text='<%# BindItem.EmailAdress %>' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="EditType" ErrorMessage="Epost får inte vara tomt" Display="Dynamic" Text="•" ControlToValidate="EmailAdress"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="EditType" ErrorMessage="Eposten innehåller fel format" Display="Dynamic" Text="•" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="EmailAdress"></asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <%-- "Kommandknappar" för att uppdatera en kunduppgift och avbryta. --%>
                        <asp:LinkButton runat="server" CommandName="Update" ValidationGroup="EditType" Text="Spara" />
                        <asp:LinkButton runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false" />
                    </td>
                </tr>
            </EditItemTemplate>
            <InsertItemTemplate>
                <%-- Mall för rad i tabellen för att lägga till nya kunduppgifter. Visas bara om InsertItemPosition 
                     har värdet FirstItemPosition eller LasItemPosition.--%>
                <tr>
                    <td>
                        <asp:TextBox ID="FirstName" runat="server" MaxLength="50" Text='<%# BindItem.FirstName %>' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Förnamnet får inte vara tomt" Display="Dynamic" Text="•" ControlToValidate="FirstName"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="LastName" runat="server" MaxLength="50" Text='<%# BindItem.LastName %>' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Efternamnet får inte vara tomt" Display="Dynamic" Text="•" ControlToValidate="LastName"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="EmailAdress" runat="server" MaxLength="50" Text='<%# BindItem.EmailAdress %>' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Epost får inte vara tomt" Display="Dynamic" Text="•" ControlToValidate="EmailAdress"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Eposten innehåller fel format" Display="Dynamic" Text="•" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="EmailAdress"></asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <%-- "Kommandknappar" för att lägga till en ny kunduppgift och rensa texfälten. --%>
                        <asp:LinkButton runat="server" CommandName="Insert" Text="Lägg till" />
                        <asp:LinkButton runat="server" CommandName="Cancel" Text="Rensa" CausesValidation="false" />
                    </td>
                </tr>
            </InsertItemTemplate>
        </asp:ListView>
    </div>
    </form>
</body>
</html>
