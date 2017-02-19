<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewComment.aspx.cs" Inherits="FoodSupplementsSystem.Web.Private.ViewComment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView runat="server" ID="fvCommentDetails"
        ItemType="FoodSupplementsSystem.Data.Models.Comment"
        SelectMethod="fvCommentDetails_GetItem">
        <HeaderTemplate>
            <foodSupplementsSystem:LikeHateCtrl ID="likeHate" runat="server" Visible="<%# HttpContext.Current.User.Identity.IsAuthenticated %>" />
        </HeaderTemplate>
        <ItemTemplate>
            <small>category: <%# Item.Topic.Name %></small>
            <p>
                <h3><%# Item.Content %></h3>
            </p>
            
            <p class="pull-right">
                <%# Item.CreationDate %>
            </p>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>