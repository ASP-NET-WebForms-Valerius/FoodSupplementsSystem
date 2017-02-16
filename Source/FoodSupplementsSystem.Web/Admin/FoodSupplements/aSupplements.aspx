<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="aSupplements.aspx.cs" Inherits="FoodSupplementsSystem.Web.Admin.FoodSupplements.aSupplements" %>

<asp:Content ID="ContentSupplement" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="red-fg">Mnage supplements <a href="../aDefault.aspx" class="nav-link">admin</a> page</h1>

    <asp:ValidationSummary ShowModelStateErrors="true" runat="server" />

    <asp:GridView ID="GridViewSupplements" runat="server" 
        ItemType="FoodSupplementsSystem.Data.Models.Supplement" DataKeyNames="Id" 
        AllowSorting="False" AllowPaging="True" PageSize="3"
        AutoGenerateColumns="false"
        Height="147px"
        SelectMethod="GridViewSupplements_GetData"
        UpdateMethod="GridViewSupplements_UpdateItem"
        DeleteMethod="GridViewSupplements_DeleteItem" >
        <Columns>
            <asp:ImageField DataImageUrlField="ImageUrl"  
                ItemStyle-Width="20%" />
            <asp:BoundField DataField="Name" HeaderText="Name" 
                ItemStyle-Width="20%" ItemStyle-Wrap="false" />
            <asp:BoundField DataField="Ingredients" HeaderText="Ingredients" 
                ItemStyle-Width="20%" ItemStyle-Wrap="true"/>
            <asp:BoundField DataField="Description" HeaderText="Description" 
                ItemStyle-Width="20%" ItemStyle-Wrap="true"/>
            <asp:BoundField DataField="CreationDate" HeaderText="CreationDate" 
                ItemStyle-Width="20%" ItemStyle-Wrap="false"/>               

            <asp:CommandField ShowEditButton="true" ButtonType="Button">
                <ControlStyle Width="75px" />
            </asp:CommandField>
            <asp:CommandField ShowDeleteButton="true" ButtonType="Button">
                <ControlStyle Width="75px" />
            </asp:CommandField>
            
        </Columns>
    </asp:GridView>

    <br />
    <asp:LinkButton ID="LinkButtonAddSupplement" runat="server" href="Add.aspx" CssClass="btn btn-primary btn-sm">Add Supplement</asp:LinkButton>

</asp:Content>
