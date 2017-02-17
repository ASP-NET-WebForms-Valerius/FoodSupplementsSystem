<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Supplements.aspx.cs" Inherits="FoodSupplementsSystem.Web.FoodSupplements.Supplements" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="ContentAllSupplements" ContentPlaceHolderID="MainContent" runat="server">

    <script>
        $( function() {
            $(".descriptin-ingredients-use-accordion").accordion({
                active: false,
                collapsible: true,
                heightStyle: "content"
            });
        } );
    </script>

    <h3><strong>Supplemts ListView</strong></h3>

    <asp:Button ID="ButtonRemoveCategoryFilter" runat="server" 
        Text="Category Filter X" 
        Visible="<%# this.SupplementFilters.CategoryEnabled %>" 
        OnClick="ButtonRemoveCategoryFilter_Click"/>

    <asp:Button ID="ButtonRemoveTopicFilter" runat="server" 
        Text="Topic Filter X" 
        Visible="<%# this.SupplementFilters.TopicEnabled %>" 
        OnClick="ButtonRemoveTopicFilter_Click"/>

    <asp:Button ID="ButtonRemoveBrandFilter" runat="server" 
        Text="Brand Filter X" 
        Visible="<%# this.SupplementFilters.BrandEnabled %>" 
        OnClick="ButtonRemoveBrandFilter_Click"/>

    <asp:ListView ID="ListViewSupplements" runat="server" 
        ItemType="FoodSupplementsSystem.Data.Models.Supplement"
        OnPagePropertiesChanging="ListViewSupplements_PagePropertiesChanging" >
        <LayoutTemplate>            
            <ul class="list-unstyled">
                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
            </ul>
        </LayoutTemplate>
        <ItemTemplate>
            <li>
                <%--Helpers hidden fields--%>
                <asp:Label ID="LabelId" runat="server" 
                    Text="<%#: Item.Id %>" 
                    Visible="true">
                </asp:Label>

                <%--'<%# "Details.aspx?id=" + Item.Id.ToString() %>'--%>
                <asp:Label ID="LabelDatailsUrl" runat="server" 
                    Text='<%# "Details.aspx?id=" + Item.Id.ToString() %>'
                    Visible="true">
                </asp:Label>
                <%--End-Helpers hidden fields--%>

                <%--Additional data source, used for Rating Control--%>
                <asp:SqlDataSource ID="SqlDataSourceRating" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:FoodSupplementsContextConnectionString %>"
                    SelectCommand = "SELECT Count([Value]) AS VotesCount, AVG([Value]) AS VotesAverageValue FROM [Ratings] WHERE SupplementId = @supplementId" 
                    >
                    <SelectParameters>
                        <asp:ControlParameter ControlID="LabelId" PropertyName="Text" Name="supplementId" DbType="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <%--End-Additional data source, used for Rating Control--%>

                <asp:FormView ID="FormViewRatingHelper" runat="server" DataSourceID="SqlDataSourceRating">
                    <ItemTemplate>
                        <asp:Label ID="LabelVotesCountHelper" runat="server" 
                            Text='<%# "VotesCount: " + Eval("VotesCount") %>' 
                            Visible="true">
                        </asp:Label>
                        <asp:Label ID="LabelVotesAverageValueHelper" runat="server" 
                            Text='<%# "VotesAverageValue: " + Eval("VotesAverageValue") %>' 
                            Visible="true">
                        </asp:Label>
                    </ItemTemplate>
                </asp:FormView>


                <%--Supplement Item Row--%>
                <div class="row table-bordered">
                    <%--First Row with Main attributes--%>
                    <div class="row table-bordered">
                        <div class="col-md-2 table-bordered">
                            <img src="<%#: Item.ImageUrl %>" alt="Supplements-Category-Brand-Name" />
                        </div>
                        <div class="col-md-8 table-bordered">
                            <%--Name and Details button--%>
                            <div class="row">                        
                                <div class="col-md-8 table-bordered">
                                    <h4>
                                        <a href="<%# this.GetDetailsUrl(Item.Id) %>"><%#: Item.Name %></a>
                                    </h4>
                                </div>   
                                <div class="col-md-4 table-bordered">
                                    <asp:LinkButton ID="LinkButton1" runat="server"                             
                                        Text="Detail product view" 
                                        href='<%# this.GetDetailsUrl(Item.Id) %>'
                                        CssClass="btn btn-primary btn-sm pull-right">Detail product view</asp:LinkButton>
                                </div>                     
                            </div>
                            <%--Rating stars--%>
                            <div class="row"> 
                                <div class="col-md-8 table-bordered">
                                    <asp:FormView ID="FormViewVotesAverageValue" runat="server" DataSourceID="SqlDataSourceRating">
                                        <ItemTemplate>
                                            <asp:Label ID="LabelVotesAverageValue" runat="server" 
                                                Text='<%# Eval("VotesAverageValue") %>' 
                                                Visible="true">
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:FormView>
                                </div>   
                                <div class="col-md-4 table-bordered pull-right">
                                    <strong>Votes: </strong>    
                                    <asp:FormView ID="FormView1" runat="server" 
                                        DataSourceID="SqlDataSourceRating"
                                        CssClass="form-inline">
                                        <ItemTemplate>
                                            <asp:Label ID="LabelVotesCount" runat="server" 
                                                Text='<%# Eval("VotesCount") %>' 
                                                Visible="true">
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:FormView>                     
                                </div>
                            </div>
                            <%--Category--%>
                            <div class="row">                        
                                <div class="col-md-2 table-bordered">
                                    <strong>Category: </strong>
                                </div>   
                                <div class="col-md-10 table-bordered">
                                    <asp:LinkButton ID="LinkButtonSetCategoryFilter" runat="server" 
                                        OnCommand="LinkButtonSetCategoryFilter_Command"
                                        CommandArgument="<%# Item.Category.Name %>">
                                        <%# Item.Category.Name %>
                                    </asp:LinkButton>
                                </div>          
                            </div>
                            <%--Topic--%>
                            <div class="row">                        
                                <div class="col-md-2 table-bordered">
                                    <strong>Topic: </strong>
                                </div>   
                                <div class="col-md-10 table-bordered">
                                    <asp:LinkButton ID="LinkButtonSetTopicFilter" runat="server" 
                                        OnCommand="LinkButtonSetTopicFilter_Command"
                                        CommandArgument="<%# Item.Topic.Name %>">
                                        <%# Item.Topic.Name %>
                                    </asp:LinkButton>
                                </div>          
                            </div>
                            <%--Brand--%>
                            <div class="row">                        
                                <div class="col-md-2 table-bordered">
                                    <strong>Brand: </strong>
                                </div>   
                                <div class="col-md-10 table-bordered">
                                    <asp:LinkButton ID="LinkButtonSetBrandFilter" runat="server" 
                                        OnCommand="LinkButtonSetBrandFilter_Command"
                                        CommandArgument="<%# Item.Brand.Name %>">
                                        <%# Item.Brand.Name %>
                                    </asp:LinkButton>
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
                    <%--End-First Row with Main attributes--%>

                    <%--Second Row with Description, Ingredients and Use attributes--%>
                    <div class="row table-bordered">
                        <div class="col-md-2 table-bordered">                    
                        </div>
                        <div class="col-md-8 table-bordered">   
                            <div class="descriptin-ingredients-use-accordion">
                                <h3><a>Description</a></h3>
                                    <div>
                                        <p><%#: Item.Description %></p>
                                    </div>
                                <h3><a>Ingredients</a></h3>
                                    <div>
                                        <p><%#: Item.Ingredients %></p>
                                    </div>
                                <h3><a>Use</a></h3>
                                    <div>
                                        <p><%#: Item.Use %></p>
                                    </div>
                            </div>               
                        </div>
                    </div> 
                    <%-- End-Second Row with Description, Ingredients and Use attributes--%>
                              
                </div>
            </li>
        </ItemTemplate>
        <EmptyDataTemplate>
            No data
        </EmptyDataTemplate>
    </asp:ListView>

    <asp:DataPager ID="DataPagersSupplements" runat="server" 
        PagedControlID="ListViewSupplements" 
        PageSize="3"
        OnPreRender="DataPagersSupplements_PreRender">
        <Fields>
            <asp:NextPreviousPagerField 
                ButtonType="Button" 
                ButtonCssClass="btn btn-primary btn-sm"
                ShowPreviousPageButton="true"
                ShowNextPageButton="false"/>
            <asp:NumericPagerField Visible="true"/>
            <asp:NextPreviousPagerField 
                ButtonType="Button" 
                ButtonCssClass="btn btn-primary btn-sm"
                ShowPreviousPageButton="false"
                ShowNextPageButton="true"/>
        </Fields>
    </asp:DataPager>

</asp:Content>
