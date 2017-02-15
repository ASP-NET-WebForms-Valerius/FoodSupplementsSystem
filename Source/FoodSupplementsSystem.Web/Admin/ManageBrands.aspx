<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageBrands.aspx.cs" Inherits="FoodSupplementsSystem.Web.Admin.ManageBrands" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView runat="server" ID="gvBrands"
        ItemType="FoodSupplementsSystem.Data.Models.Brand"
        DataKeyNames="Id"
        SelectMethod="gvBrands_GetData"
        AutoGenerateColumns="true"
        AllowPaging="true"
        PageSize="10"
        UpdateMethod="gvBrands_UpdateItem"
        DeleteMethod="gvBrands_DeleteItem">
        <Columns>
            <asp:CommandField ShowEditButton="true" ControlStyle-CssClass="btn btn-info" />
            <asp:CommandField ShowDeleteButton="true" ControlStyle-CssClass="btn btn-info" />
        </Columns>
    </asp:GridView>
</asp:Content>
