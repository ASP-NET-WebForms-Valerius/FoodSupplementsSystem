<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="aDefault.aspx.cs" Inherits="FoodSupplementsSystem.Web.Admin.aDefault" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="red-fg">Home page admin</h1>
    <p>Manage all brands, categories, topicks and food supplements</p>

    <asp:TreeView ID="TreeViewAllPages" runat="server" 
        DataSourceID="SiteMapDataSource">
    </asp:TreeView>
    <asp:SiteMapDataSource ID="SiteMapDataSource" runat="server" />

</asp:Content>
