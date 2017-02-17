<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewBrands.aspx.cs" Inherits="FoodSupplementsSystem.Web.Public.ViewBrands" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView runat="server" ID="lvBrands"
        ItemType="FoodSupplementsSystem.Data.Models.Brand"
        SelectMethod="lvBrands_GetData">
        <LayoutTemplate>
            <h2>All Brands</h2>
            <div runat="server" id="itemPlaceholder"></div>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="col-md-6">
                <b><h3><%#: Item.Name %></h3></b>
                <p>
                    <i>Web site: 
                    <a href="<%#: Item.WebSite %>"><%#: Item.WebSite %></a></i>
                </p>
                <asp:ListView runat="server" ItemType="FoodSupplementsSystem.Data.Models.Supplement" DataSource="<%# Item.Supplements %>">
                    <LayoutTemplate>
                        <p>
                            All registered supplements in this brand!
                        </p>
                        <ul runat="server" id="itemPlaceholder">
                        </ul>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <a href="../FoodSupplements/Details.aspx?id=<%# Item.Id %>"><img src="<%# Item.ImageUrl %>" /></a>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        No supplements.
                    </EmptyDataTemplate>
                </asp:ListView>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>