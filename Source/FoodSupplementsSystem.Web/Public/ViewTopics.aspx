<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewTopics.aspx.cs" Inherits="FoodSupplementsSystem.Web.Public.ViewTopics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView runat="server" ID="lvTopics"
        ItemType="FoodSupplementsSystem.Data.Models.Topic"
        SelectMethod="lvTopics_GetData">
        <LayoutTemplate>
            <h2>All Topics</h2>
            <div runat="server" id="itemPlaceholder"></div>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="col-md-6">
                <b><h3><a href="../Private/ViewTopic.aspx?id=<%# Item.Id %>"><%# Item.Name %></a></h3></b>
                <p>
                    Description: 
                    <p><%#: Item.Description %></p>
                </p>
                <asp:ListView runat="server" ItemType="FoodSupplementsSystem.Data.Models.Supplement" DataSource="<%# Item.Supplements %>">
                    <LayoutTemplate>
                        <p>
                            All registered supplements in this topic!
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
