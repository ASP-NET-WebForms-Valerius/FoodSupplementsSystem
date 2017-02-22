<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageBrands.aspx.cs" Inherits="FoodSupplementsSystem.Web.Admin.ManageBrands" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView runat="server" ID="gvBrands"
        ItemType="FoodSupplementsSystem.Data.Models.Brand"
        DataKeyNames="Id"
        SelectMethod="gvBrands_GetData"
        AutoGenerateColumns="true"
        AllowPaging="true"
        PageSize="8"
        UpdateMethod="gvBrands_UpdateItem"
        DeleteMethod="gvBrands_DeleteItem">
        <Columns>
            <asp:CommandField ShowEditButton="true" ControlStyle-CssClass="btn btn-info" />
            <asp:CommandField ShowDeleteButton="true" ControlStyle-CssClass="btn btn-info" />
        </Columns>
    </asp:GridView>
    <br/>
    <h3>Add new Brand</h3>
    <p>Name:</p>
    <asp:RequiredFieldValidator ForeColor="Red" ErrorMessage="Brand name is mandatory!" ControlToValidate="tbInsertName" runat="server" />
    <br />
    <asp:TextBox runat="server" ID="tbInsertName" />
    <br/>
    <br/>
    <p>WebSite:</p>
    <asp:TextBox runat="server" ID="tbInsertWebSite" />
    <asp:Button Text="Insert" ID="btnInsert" runat="server" OnClick="btnInsert_Click" CssClass="btn btn-info" />
    <asp:Button Text="Cancel" ID="btnCancel" runat="server" OnClick="btnCancel_Click" CssClass="btn btn-danger" />
</asp:Content>
