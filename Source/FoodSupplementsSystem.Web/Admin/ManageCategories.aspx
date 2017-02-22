<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageCategories.aspx.cs" Inherits="FoodSupplementsSystem.Web.Admin.ManageCategories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView runat="server" ID="gvCategories"
        ItemType="FoodSupplementsSystem.Data.Models.Category" 
        DataKeyNames="Id" 
        SelectMethod="gvCategories_GetData" 
        AutoGenerateColumns="true" 
        AllowPaging="true" 
        PageSize="10" 
        AllowSorting="true"
        UpdateMethod="gvCategories_UpdateItem"
        DeleteMethod="gvCategories_DeleteItem">
        <Columns>
            <asp:BoundField SortExpression="Name" DataField="Name" HeaderText="Sort by name"/>
            <asp:CommandField ShowEditButton="true" ControlStyle-CssClass="btn btn-info"/>
            <asp:CommandField ShowDeleteButton="true" ControlStyle-CssClass="btn btn-info"/>
        </Columns>
    </asp:GridView>
    <asp:RequiredFieldValidator ForeColor="Red" ErrorMessage="Category name is mandatory!" ControlToValidate="tbInsert" runat="server" />
    <br />
    <asp:TextBox runat="server" ID="tbInsert" />
    <asp:Button Text="Insert" ID="btnInsert" runat="server" OnClick="btnInsert_Click" CssClass="btn btn-info" />
    <asp:Button Text="Cancel" ID="btnCancel" runat="server" OnClick="btnCancel_Click" CssClass="btn btn-info" />
</asp:Content>