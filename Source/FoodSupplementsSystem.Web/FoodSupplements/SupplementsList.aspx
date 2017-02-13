<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SupplementsList.aspx.cs" Inherits="FoodSupplementsSystem.Web.FoodSupplements.SupplementsList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="ListViewSupplements" runat="server" 
        ItemType="FoodSupplementsSystem.Data.Models.Supplement">
        <LayoutTemplate>
            <h3>Supplemts ListView</h3>
            <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
        </LayoutTemplate>
        <ItemSeparatorTemplate>
            <asp:Panel ID="PanelItemSeparatorTemplate" runat="server" 
                BorderColor="#33cc33" 
                Height="2px">
            </asp:Panel>
        </ItemSeparatorTemplate>
        <ItemTemplate>
            <asp:Panel ID="PanelItemTemplate" runat="server" BorderWidth="1px" BorderStyle="Solid" Width="80%">
                <p>
                    <div>
                        <img src="<%#: Item.ImageUrl %>" alt="Supplements-Category-Brand-Name" />
                    </div>
                    <div>
                        <h4><%#: Item.Name %></h4>

                        <asp:LinkButton ID="ButtonGoToDetails" runat="server"                             
                            Text="Detail product view" 
                            href='<%# "Details.aspx?id=" + Item.Id.ToString() %>'
                            CssClass="btn btn-primary btn-sm">Detail product view</asp:LinkButton>

                        <p><span><strong>Category: </strong> <%#: Item.Category.Name %></span></p>
                        <div><span><strong>Topic: </strong><%#: Item.Topic.Name %></span></div>
                        <div><span><strong>Brand: </strong><%#: Item.Brand.Name %></span></div>
                        <div><span><strong>web: </strong><%#: Item.Brand.WebSite %></span></div>
                    </div>
                </p>                
                <p>
                    <div>
                        <h5>Description</h5>
                        <p>
                            <%#: Item.Description %>
                        </p>
                    </div>
                    <div>
                        <h5>Ingredients</h5>
                        <p>
                            <%#: Item.Ingredients %>
                        </p>
                    </div>
                </p>
                
            </asp:Panel>
        </ItemTemplate>
    </asp:ListView>
    <asp:DataPager ID="DataPagersSupplements" runat="server" 
        PagedControlID="ListViewSupplements" 
        PageSize="5">

    </asp:DataPager>
</asp:Content>
