<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SupplementsList.aspx.cs" Inherits="FoodSupplementsSystem.Web.FoodSupplements.SupplementsList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script>
        $( function() {
            $(".descriptin-ingredients-use-accordion").accordion();
        } );
    </script>

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
            <asp:Label ID="LabelId" runat="server" Text="<%#: Item.Id %>" Visible="false"></asp:Label>

            <asp:SqlDataSource ID="SqlDataSourceRating" runat="server" 
                ConnectionString="<%$ ConnectionStrings:FoodSupplementsContextConnectionString %>"
                SelectCommand = "SELECT Count([Value]) AS VotesCount, AVG([Value]) AS AverageValue FROM [Ratings] WHERE SupplementId = @supplementId">
                <SelectParameters>
                    <asp:ControlParameter ControlID="LabelId" PropertyName="Text" Name="supplementId" DbType="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>

            <%--Row with Main attributes--%>
            <div class="row table-bordered">
                <div class="col-md-2 table-bordered">
                    <img src="<%#: Item.ImageUrl %>" alt="Supplements-Category-Brand-Name" />
                </div>
                <div class="col-md-8 table-bordered">
                    <%--Name and Details button--%>
                    <div class="row">                        
                        <div class="col-md-8 table-bordered">
                            <h4><a href="#"><%#: Item.Name %></a>  </h4>
                        </div>   
                        <div class="col-md-4 table-bordered">
                            <asp:LinkButton ID="LinkButton1" runat="server"                             
                                    Text="Detail product view" 
                                    href='<%# "Details.aspx?id=" + Item.Id.ToString() %>'
                                    CssClass="btn btn-primary btn-sm">Detail product view</asp:LinkButton>
                        </div>                     
                    </div>
                    <%--Rating stars--%>
                    <div class="row">                        
                        <div class="col-md-8 table-bordered">
                            <h4>
                                <asp:Label ID="LabelRatingValue" runat="server"  Text="Stars come here"></asp:Label>                                
                            </h4>
                        </div>   
                        <div class="col-md-4 table-bordered">
                            <p><strong>Votes: </strong>
                                <asp:DetailsView ID="DetailsViewRatingValue" runat="server" 
                                    Height="50px" 
                                    Width="125px" DataSourceID="SqlDataSourceRating"></asp:DetailsView>
                            </p>
                        </div>                     
                    </div>
                    <%--Category--%>
                    <div class="row">                        
                        <div class="col-md-2 table-bordered">
                            <strong>Category: </strong>
                        </div>   
                        <div class="col-md-10 table-bordered">
                            <p><%#: Item.Category.Name %></p>
                        </div>          
                    </div>
                    <%--Topic--%>
                    <div class="row">                        
                        <div class="col-md-2 table-bordered">
                            <strong>Topic: </strong>
                        </div>   
                        <div class="col-md-10 table-bordered">
                            <p><%#: Item.Topic.Name %></p>
                        </div>          
                    </div>
                    <%--Brand--%>
                    <div class="row">                        
                        <div class="col-md-2 table-bordered">
                            <strong>Brand: </strong>
                        </div>   
                        <div class="col-md-10 table-bordered">
                            <p><%#: Item.Brand.Name %></p>
                        </div>          
                    </div>
                    <%--Web--%>
                    <div class="row">                        
                        <div class="col-md-2 table-bordered">
                            <strong>Web Site: </strong>
                        </div>   
                        <div class="col-md-10 table-bordered">
                            <a href="<%#: Item.Brand.WebSite %>" target="_blank"><%#: Item.Brand.WebSite %></a>
                        </div>          
                    </div>
                </div>               
            </div>


            <div class="descriptin-ingredients-use-accordion">
                <h3>Description</h3>
                    <div>
                        <p><%#: Item.Description %></p>
                    </div>
                <h3>Ingredients</h3>
                    <div>
                        <p><%#: Item.Ingredients %></p>
                    </div>
                <h3>Use</h3>
                    <div>
                        <p><%#: Item.Use %></p>
                    </div>
            </div>


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
