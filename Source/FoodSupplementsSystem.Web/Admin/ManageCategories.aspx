<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageCategories.aspx.cs" Inherits="FoodSupplementsSystem.Web.Admin.ManageCategories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView runat="server" ID="gvCategories"
        ItemType="FoodSupplementsSystem.Data.Models.Category" 
        DataKeyNames="Id" 
        SelectMethod="gvCategories_GetData" 
        AutoGenerateColumns="true" 
        AllowPaging="true" 
        PageSize="10" 
        AllowSorting="true">
        <Columns>
            <asp:BoundField SortExpression="Name" DataField="Name" HeaderText="Sort by name"/>
            <asp:CommandField ShowEditButton="true" ControlStyle-CssClass="btn btn-info"/>
            <asp:CommandField ShowDeleteButton="true" ControlStyle-CssClass="btn btn-info"/>
        </Columns>
    </asp:GridView>
</asp:Content>
