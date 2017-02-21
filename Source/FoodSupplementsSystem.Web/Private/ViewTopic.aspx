<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewTopic.aspx.cs" Inherits="FoodSupplementsSystem.Web.Private.ViewTopic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView runat="server" ID="fvDetails"
        ItemType="FoodSupplementsSystem.Data.Models.Topic"
        SelectMethod="fvDetails_GetItem">
        <ItemTemplate>
            <b><h3><%# Item.Name %></b></h3>           
            <p>
                    <i>Description:</i>
                    <p><h2><%# Item.Description %></h2></p>
            </p>
            <br/>
            <asp:ListView runat="server" ItemType="FoodSupplementsSystem.Data.Models.Comment" DataSource="<%# Item.Comments %>">
                    <LayoutTemplate>
                        <p>
                            <i>All comments in this topic!</i>
                        </p>
                        <ul runat="server" id="itemPlaceholder">
                        </ul>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <p>Comment number in recieving order: <%# Item.Id %></p>
                        <a href="ViewComment.aspx?id=<%# Item.Id %>"><%# Item.Content.Length > 300 ? Item.Content.Substring(0, 300) + "..." : Item.Content %></a>
                        <p>
                            Likes: <%# Item.Likes.Count() %>
                        </p>
                        <i>Created on: <%# Item.CreationDate %></i>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        No comments.
                    </EmptyDataTemplate>
                </asp:ListView>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
