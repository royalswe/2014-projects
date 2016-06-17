<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="alwex.Pages.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--Navigering--%>
    <asp:LinkButton ID="CustomerLinkButton" CssClass="linkButton" runat="server" PostBackUrl="~/Pages/CustomerList.aspx">Till kunderna</asp:LinkButton>
    <asp:LinkButton ID="ReportLinkButton" CssClass="linkButton" runat="server" PostBackUrl="~/Pages/ReportList.aspx">Till Rapporterna</asp:LinkButton>

    <%--Felmeddelanden--%>
    <asp:ValidationSummary ID="ValidationSummary1" CssClass="ErrorPrompt" runat="server" />
    <asp:ValidationSummary ID="ValidationSummary2" ValidationGroup="EditType" CssClass="ErrorPrompt" ShowModelStateErrors="false" runat="server" />
    <asp:ValidationSummary ID="ValidationSummary3" ValidationGroup="InsertType" CssClass="ErrorPrompt" ShowModelStateErrors="false" runat="server" />

    <asp:ListView ID="PsListView" runat="server"
        ItemType="alwex.Model.BLL.PalletStatement"
        SelectMethod="PsListView_GetData"
        DeleteMethod="PsListView_DeleteItem"
        InsertMethod="PsListView_InsertItem"
        UpdateMethod="PsListView_UpdateItem"
        DataKeyNames="PsID"
        InsertItemPosition="FirstItem">
        <LayoutTemplate>
            <table>
                <tr id="trHead">
                    <th>Kund-id</th>
                    <th>Datum ut</th>
                    <th>Datum in</th>
                    <th>A pallar in</th>
                    <th>B pallar in</th>
                    <th>A pallar ut</th>
                    <th>Redigera</th>
                </tr>
                <asp:PlaceHolder ID="ItemPlaceHolder" runat="server" />
            </table>
            <div id="pagination">
                <asp:DataPager ID="DataPager1" runat="server" PageSize="5">
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
                    <%#: Item.CustomerNUM %>
                </td>
                <td>
                    <%#: Item.OutDate %>
                </td>
                <td>
                    <%#: Item.InDate %>
                </td>
                <td>
                    <%#: Item.Apallet %>
                </td>
                <td>
                    <%#: Item.Bpallet %>
                </td>
                <td>
                    <%#: Item.ApalletOUT %>
                </td>
                <td>
                    <%-- "Kommandknappar" för att radera en pallstansning och redigera. --%>
                    <asp:LinkButton runat="server" CommandName="Delete" Text="Ta bort" CausesValidation="false"
                        OnClientClick='<%# String.Format("return confirm(\"Vill du ta bort kundnummer {0}?\")", Item.CustomerNUM) %>' />
                    <asp:LinkButton runat="server" CommandName="Edit" Text="Redigera" CausesValidation="false" />
                </td>
            </tr>
        </ItemTemplate>
        <EmptyDataTemplate>
            <%-- Detta visas då pallstansningar saknas i databasen. --%>
            <p>
                Kunduppgifter saknas.       
            </p>
        </EmptyDataTemplate>
        <EditItemTemplate>
            <%-- Mall för rad i tabellen för att redigera pallstansningar. --%>
            <tr>
                <td>
                    <asp:TextBox ID="CustomerNUM" MaxLength="10" runat="server" Text='<%# BindItem.CustomerNUM %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="EditType" CssClass="red" ErrorMessage="Kundid måste anges" Display="Dynamic" Text="•" ControlToValidate="CustomerNUM" />
                    <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" ValidationGroup="EditType" CssClass="red" ControlToValidate="CustomerNUM" Display="Dynamic" Text="•" ErrorMessage="Kundnumret måste består av heltal" />
                </td>
                <td>
                    <asp:TextBox ID="OutDate" runat="server" Text='<%# BindItem.OutDate %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="EditType" CssClass="red" ErrorMessage="Utgående datum måste anges" Display="Dynamic" Text="•" ControlToValidate="OutDate" />
                    <%--Validering av datum och tid på många olika vis / tid är inte obligatoriskt/ sec är inte obligatorisk för tid--%>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ValidationGroup="EditType" CssClass="red" Display="Dynamic" Text="•" ErrorMessage="Ut Datumet är i fel format, exempel på format 2015-03-05 12:35:45 eller 15:03:05" ControlToValidate="OutDate" ValidationExpression="(20)?\d\d[- /.:](0[1-9]|1[012])[- /.:](0[1-9]|[12]\d|3[01])([- /.:]([01]?[0-9]|2[0-3])[- /.:][0-5][0-9])?([- /.:][0-5][0-9])?" /> 
                </td>
                <td>
                    <asp:TextBox ID="InDate" runat="server" Text='<%# BindItem.InDate %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="EditType" CssClass="red" ErrorMessage="Ingående datum måste anges" Display="Dynamic" Text="•" ControlToValidate="InDate" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationGroup="EditType" CssClass="red" Display="Dynamic" Text="•" ErrorMessage="In Datumet är i fel format, exempel på format 2015-03-05 12:35:45 eller 15-03-05" ControlToValidate="InDate" ValidationExpression="(20)?\d\d[- /.:](0[1-9]|1[012])[- /.:](0[1-9]|[12]\d|3[01])([- /.:]([01]?[0-9]|2[0-3])[- /.:][0-5][0-9])?([- /.:][0-5][0-9])?" />
                </td>
                <td>
                    <asp:TextBox ID="Apallet" MaxLength="4" runat="server" Text='<%# BindItem.Apallet %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="EditType" CssClass="red" ErrorMessage="Antal A-pallar måste anges" Display="Dynamic" Text="•" ControlToValidate="Apallet" />
                    <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" ValidationGroup="EditType" CssClass="red" ControlToValidate="Apallet" Display="Dynamic" Text="•" ErrorMessage="Antal A pallar måste består av heltal" />               
                </td>
                <td>
                    <asp:TextBox ID="Bpallet" MaxLength="4" runat="server" Text='<%# BindItem.Bpallet %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="EditType" CssClass="red" ErrorMessage="Antal B-pallar måste anges" Display="Dynamic" Text="•" ControlToValidate="Bpallet" />
                    <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" ValidationGroup="EditType" CssClass="red" ControlToValidate="Bpallet" Display="Dynamic" Text="•" ErrorMessage="Antal B pallar måste består av heltal" />
                </td>
                <td>
                    <asp:TextBox ID="ApalletOUT" MaxLength="4" runat="server" Text='<%# BindItem.ApalletOUT %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="EditType" CssClass="red" ErrorMessage="Antal utgående A-pallar måste anges" Display="Dynamic" Text="•" ControlToValidate="ApalletOUT" />
                    <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" ValidationGroup="EditType" CssClass="red" ControlToValidate="ApalletOUT" Display="Dynamic" Text="•"  ErrorMessage="Antal utgående A pallar måste består av heltal" />
                </td>
                <td>
                    <%-- "Kommandknappar" för att uppdatera en pallstansning och avbryta. --%>
                    <asp:LinkButton runat="server" CommandName="Update" ValidationGroup="EditType" Text="Spara" />
                    <asp:LinkButton runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false" />
                </td>
            </tr>
        </EditItemTemplate>
        <InsertItemTemplate>
            <%-- Mall för rad i tabellen för att lägga till nya pallstansningar. Visas bara om InsertItemPosition 
                 har värdet FirstItemPosition eller LasItemPosition.--%>
            <tr>
                <td>
                    <asp:TextBox ID="CustomerNUM" MaxLength="10" runat="server" Text='<%# BindItem.CustomerNUM %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="red" ValidationGroup="InsertType" ErrorMessage="Kundnummer får inte vara tomt" Display="Dynamic" Text="•" ControlToValidate="CustomerNUM" />
                    <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" CssClass="red" ValidationGroup="InsertType" ControlToValidate="CustomerNUM" Display="Dynamic" Text="•"  ErrorMessage="Kundnumret måste består av heltal" />
                </td>
                <td>
                    <asp:TextBox ID="OutDate" runat="server" Text='<%# BindItem.OutDate %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="red" ValidationGroup="InsertType" ErrorMessage="Utgående datum måste anges" Display="Dynamic" Text="•" ControlToValidate="OutDate" />
                    <asp:RegularExpressionValidator runat="server" ValidationGroup="InsertType" CssClass="red" Display="Dynamic" Text="•" ErrorMessage="Ut Datumet är i fel format, exempel på format 2015-03-05 12:35:45 eller 15:03:05" ControlToValidate="OutDate" ValidationExpression="(20)?\d\d[- /.:](0[1-9]|1[012])[- /.:](0[1-9]|[12]\d|3[01])([- /.:]([01]?[0-9]|2[0-3])[- /.:][0-5][0-9])?([- /.:][0-5][0-9])?" /> 
                </td>
                <td>
                    <asp:TextBox ID="InDate" runat="server" Text='<%# BindItem.InDate %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="red" ValidationGroup="InsertType" ErrorMessage="Ingående datum måste anges" Display="Dynamic" Text="•" ControlToValidate="InDate" />
                    <asp:RegularExpressionValidator runat="server" ValidationGroup="InsertType" CssClass="red" Display="Dynamic" Text="•" ErrorMessage="In Datumet är i fel format, exempel på format 2015-03-05 12:35:45 eller 15:03:05" ControlToValidate="InDate" ValidationExpression="(20)?\d\d[- /.:](0[1-9]|1[012])[- /.:](0[1-9]|[12]\d|3[01])([- /.:]([01]?[0-9]|2[0-3])[- /.:][0-5][0-9])?([- /.:][0-5][0-9])?" /> 
                </td>
                <td>
                    <asp:TextBox ID="Apallet" MaxLength="4" runat="server" Text='<%# BindItem.Apallet %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="red" ValidationGroup="InsertType" ErrorMessage="Antal A-pallar måste anges" Display="Dynamic" Text="•" ControlToValidate="Apallet" />
                    <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" CssClass="red" ValidationGroup="InsertType" ControlToValidate="Apallet" Display="Dynamic" Text="•"  ErrorMessage="Antal A pallar måste består av heltal" />
                </td>
                <td>
                    <asp:TextBox ID="Bpallet" MaxLength="4" runat="server" Text='<%# BindItem.Bpallet %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" CssClass="red" ValidationGroup="InsertType" ErrorMessage="Antal B-pallar måste anges" Display="Dynamic" Text="•" ControlToValidate="Bpallet" />
                    <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" CssClass="red" ControlToValidate="Bpallet" ErrorMessage="Antal B pallar måste består av heltal" Display="Dynamic" Text="•" />
                </td>
                <td>
                    <asp:TextBox ID="ApalletOUT" MaxLength="4" runat="server" Text='<%# BindItem.ApalletOUT %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" CssClass="red" ValidationGroup="InsertType" ErrorMessage="Antal utgående A-pallar måste anges" Display="Dynamic" Text="•" ControlToValidate="ApalletOUT" />
                    <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" CssClass="red" ValidationGroup="InsertType" ControlToValidate="ApalletOUT" ErrorMessage="Antal utgående A pallar måste består av heltal" Display="Dynamic" Text="•" />
                </td>
                <td>
                    <%-- "Kommandknappar" för att lägga till en ny kunduppgift och rensa texfälten. --%>
                    <asp:LinkButton runat="server" CommandName="Insert" ValidationGroup="InsertType" Text="Lägg till" />
                    <asp:LinkButton runat="server" CommandName="Cancel" Text="Rensa" CausesValidation="false" />
                </td>
            </tr>
        </InsertItemTemplate>

    </asp:ListView>

</asp:Content>
