<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="ReportList.aspx.cs" Inherits="alwex.Pages.ReportList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <%--Navigering--%>
    <asp:LinkButton ID="CustomerLinkButton" CssClass="linkButton" runat="server" PostBackUrl="~/Pages/CustomerList.aspx">Till kunderna</asp:LinkButton>
    <asp:LinkButton ID="ReportLinkButton" CssClass="linkButton" runat="server" PostBackUrl="~/Pages/Default.aspx">Till Pallstansningarna</asp:LinkButton>

        <%--Lista med rapporterna--%>
    <asp:ListView ID="ReportListView" runat="server"
        ItemType="alwex.Model.BLL.Report"
        SelectMethod="ReportListView_GetData"
        DataKeyNames="ReportID">
        <LayoutTemplate>
            <table>
                <tr id="trHead">
                    <th>Pallstansnings nr</th>
                    <th>Kundnummer</th>
                    <th>Namn</th>
                    <th>Skuld</th>
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
                    <%#: Item.PsID %>
                </td>
                <td>
                    <%#: Item.CustomerNUM %>
                </td>
                <td>
                    <%#: Item.Name %>
                </td>
                <td>
                    <%#: Item.CustomerDebt %>
                </td>
            </tr>
        </ItemTemplate>
        <EmptyDataTemplate>
            <p>
                Rapporter saknas.
            </p>
        </EmptyDataTemplate>


    </asp:ListView>

</asp:Content>
