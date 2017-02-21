<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="FoodSupplementsSystem.Web.About" %>

<%@ Register Src="~/Controls/FooterControl.ascx" TagPrefix="mainFC" TagName="FooterControl" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
</asp:Content>

<asp:Content ID="MainFooter" ContentPlaceHolderID="FooterContainer" runat="server">   
    <mainFC:FooterControl runat="server" ID="FooterControl" />
</asp:Content>