<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="FoodSupplementsSystem.Web.FoodSupplements.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    
    <h3>Supplement details</h3>
        <asp:DetailsView ID="DetailsViewSupplement" runat="server" 
            ItemType="FoodSupplementsSystem.Data.Models.Supplement">
            
            <EmptyDataTemplate>
                
                
                <div>
                        <img src="<%#: Item.ImageUrl %>" alt="Supplements-Category-Brand-Name" />
                    </div>
                    <div>
                        <h4><%#: Item.Name %></h4>

                        <p><span><strong>Category: </strong> <%#: Item.Category.Name %></span></p>
                        <div><span><strong>Topic: </strong><%#: Item.Topic.Name %></span></div>
                        <div><span><strong>Brand: </strong><%#: Item.Brand.Name %></span></div>
                        <div><span><strong>web: </strong><%#: Item.Brand.WebSite %></span></div>
                    </div>
            </EmptyDataTemplate>
        </asp:DetailsView>
        <asp:Button ID="ButtonGoBack" runat="server" Text="Go back" OnClick="ButtonGoBack_Click" />
</asp:Content>
