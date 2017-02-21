<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="TreeView.aspx.cs" Inherits="FoodSupplementsSystem.Web.TreeView" %>

<%@ Register Src="~/Controls/FooterControl.ascx" TagPrefix="mainFC" TagName="FooterControl" %>


<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Site map page</h1>
    <asp:TreeView ID="TreeViewFoodSupplements" runat="server" 
        DataSourceID="SiteMapDataSource">
    </asp:TreeView>
    <asp:SiteMapDataSource ID="SiteMapDataSource" runat="server" />
</asp:Content>

<asp:Content ID="MainFooter" ContentPlaceHolderID="FooterContainer" runat="server">    
    <mainFC:FooterControl runat="server" ID="FooterControl" />
</asp:Content>