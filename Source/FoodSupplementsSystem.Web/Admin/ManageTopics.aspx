<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageTopics.aspx.cs" Inherits="FoodSupplementsSystem.Web.Admin.ManageTopics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView runat="server" ID="gvTopics"
        ItemType="FoodSupplementsSystem.Data.Models.Topic"
        DataKeyNames="Id"
        SelectMethod="gvTopics_GetData"
        AutoGenerateColumns="true"
        AllowPaging="true"
        PageSize="8"
        UpdateMethod="gvTopics_UpdateItem"
        DeleteMethod="gvTopics_DeleteItem">
        <Columns>
            <asp:CommandField ShowEditButton="true" ControlStyle-CssClass="btn btn-info" />
            <asp:CommandField ShowDeleteButton="true" ControlStyle-CssClass="btn btn-info" />
        </Columns>
    </asp:GridView>
    <br/>
    <h3>Add new Topic</h3>
    <p>Name:</p>
    <asp:RequiredFieldValidator ForeColor="Red" ErrorMessage="Topic name is mandatory!" ControlToValidate="tbInsertName" runat="server" />
    <br />
    <asp:TextBox runat="server" ID="tbInsertName" />
    <br/>
    <br/>
    <p>Description:</p>
    <asp:TextBox runat="server" ID="tbInsertDescription" />
    <asp:Button Text="Insert" ID="btnInsert" runat="server" OnClick="btnInsert_Click" CssClass="btn btn-info" />
    <asp:Button Text="Cancel" ID="btnCancel" runat="server" OnClick="Button1_Click" CssClass="btn btn-danger" />
</asp:Content>
