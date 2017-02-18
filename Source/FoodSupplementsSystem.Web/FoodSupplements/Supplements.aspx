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

    <h3><strong class="dark-orange-fg">Supplements</strong></h3>

    <asp:PlaceHolder ID="PlaceHolderRemoveCategoryFilterButtons" runat="server"
        Visible="<%# this.SupplementFilters.CategoryEnabled %>">
        
        <div class="btn-group" role="group" aria-label="..." >
            <asp:Button ID="Button1" runat="server"  
                CssClass="btn btn-default btn-sm"               
                Text="Category filter" 
                Enabled="false"/>

            <asp:Button ID="ButtonRemoveCategoryFilter" runat="server" 
                CssClass="btn btn-danger btn-sm"
                Text="X" 
                OnClick="ButtonRemoveCategoryFilter_Click"/>
        </div>
    </asp:PlaceHolder>

    <asp:PlaceHolder ID="PlaceHolderRemoveTopicFilterButtons" runat="server"
        Visible="<%# this.SupplementFilters.TopicEnabled %>">
        
        <div class="btn-group" role="group" aria-label="..." >
            <asp:Button ID="Button2" runat="server"  
                CssClass="btn btn-default btn-sm"               
                Text="Toplic filter" 
                Enabled="false"/>

            <asp:Button ID="ButtonRemoveTopicFilter" runat="server" 
                CssClass="btn btn-danger btn-sm"
                Text="x" 
                OnClick="ButtonRemoveTopicFilter_Click"/>
        </div>
    </asp:PlaceHolder>

    <asp:PlaceHolder ID="PlaceHolderRemoveBrandFilterButtons" runat="server"
        Visible="<%# this.SupplementFilters.BrandEnabled %>">
        
        <div class="btn-group" role="group" aria-label="..." >
            <asp:Button ID="Button3" runat="server"  
                CssClass="btn btn-default btn-sm"               
                Text="Brand filter" 
                Enabled="false"/>
            <asp:Button ID="ButtonRemoveBrandFilter" runat="server" 
                CssClass="btn btn-danger btn-sm"
                Text="x" 
                OnClick="ButtonRemoveBrandFilter_Click"/>
        </div>
    </asp:PlaceHolder>

    

    <asp:ListView ID="ListViewSupplements" runat="server"         
        ItemType="FoodSupplementsSystem.Data.Models.Supplement"
        OnPagePropertiesChanging="ListViewSupplements_PagePropertiesChanging" >
        <LayoutTemplate>            
            <ul class="list-unstyled">
                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
            </ul>
        </LayoutTemplate>
        <ItemSeparatorTemplate>
            <br />
        </ItemSeparatorTemplate>
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
                <div class="row table-bordered-none-byMe">
                    <%--First Row with Main attributes--%>
                    <div class="row table-bordered-none-byMe">
                        <div class="col-md-2 table-bordered-none-byMe">
                            <img src="<%#: Item.ImageUrl %>" alt="Supplements-Category-Brand-Name" />
                        </div>
                        <div class="col-md-8 veryverylight-gray-bg table-bordered-none-byMe">
                            <%--Name and Details button--%>
                            <div class="row ">                        
                                <div class="col-md-8 table-bordered-none-byMe">
                                    <h4>
                                        <a href="<%# this.GetDetailsUrl(Item.Id) %>"><%#: Item.Name %></a>
                                    </h4>
                                </div>   
                                <div class="col-md-4 table-bordered-none-byMe">
                                    <asp:LinkButton ID="LinkButton1" runat="server"                             
                                        Text="Detail product view" 
                                        href='<%# this.GetDetailsUrl(Item.Id) %>'
                                        CssClass="btn btn-primary btn-sm pull-right">Detail product view</asp:LinkButton>
                                </div>                     
                            </div>
                            <%--Rating stars--%>
                            <div class="row"> 
                                <div class="col-md-8 table-bordered-none-byMe">
                                    <asp:FormView ID="FormViewVotesAverageValue" runat="server" DataSourceID="SqlDataSourceRating">
                                        <ItemTemplate>
                                            <asp:Label ID="LabelVotesAverageValue" runat="server" 
                                                Text='<%# Eval("VotesAverageValue") %>' 
                                                Visible="true">
                                            </asp:Label>
                                            
                                            <asp:FormView ID="FormViewRatingValue" runat="server" DataSourceID="SqlDataSourceRating">
                                                <ItemTemplate>
                                                    <ajaxToolkit:Rating ID="SupplementRating" runat="server"                                    
                                                        CurrentRating='<%# Eval("VotesAverageValue") %>'
                                                        MaxRating="5"
                                                        Enabled="<%# this.User.Identity.IsAuthenticated %>"
                                                        StarCssClass="ratingStar"
                                                        EmptyStarCssClass="emptyRatingStar"
                                                        FilledStarCssClass="filledRatingStar"
                                                        WaitingStarCssClass="savedRatingStar"
                                                        OnChanged="SupplementRating_Changed" />       
                                                </ItemTemplate>  
                                            </asp:FormView>    

                                        </ItemTemplate>
                                    </asp:FormView>
                                </div>   
                                <div class="col-md-4 table-bordered-none-byMe pull-right">
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
                                <div class="col-md-2 table-bordered-none-byMe">
                                    <strong>Category: </strong>
                                </div>   
                                <div class="col-md-10 table-bordered-none-byMe">
                                    <asp:LinkButton ID="LinkButtonSetCategoryFilter" runat="server" 
                                        OnCommand="LinkButtonSetCategoryFilter_Command"
                                        CommandArgument="<%# Item.Category.Name %>">
                                        <%# Item.Category.Name %>
                                    </asp:LinkButton>
                                </div>          
                            </div>
                            <%--Topic--%>
                            <div class="row">                        
                                <div class="col-md-2 table-bordered-none-byMe">
                                    <strong>Topic: </strong>
                                </div>   
                                <div class="col-md-10 table-bordered-none-byMe">
                                    <asp:LinkButton ID="LinkButtonSetTopicFilter" runat="server" 
                                        OnCommand="LinkButtonSetTopicFilter_Command"
                                        CommandArgument="<%# Item.Topic.Name %>">
                                        <%# Item.Topic.Name %>
                                    </asp:LinkButton>
                                </div>          
                            </div>
                            <%--Brand--%>
                            <div class="row">                        
                                <div class="col-md-2 table-bordered-none-byMe">
                                    <strong>Brand: </strong>
                                </div>   
                                <div class="col-md-10 table-bordered-none-byMe">
                                    <asp:LinkButton ID="LinkButtonSetBrandFilter" runat="server" 
                                        OnCommand="LinkButtonSetBrandFilter_Command"
                                        CommandArgument="<%# Item.Brand.Name %>">
                                        <%# Item.Brand.Name %>
                                    </asp:LinkButton>
                                </div>          
                            </div>
                            <%--Web--%>
                            <div class="row">                        
                                <div class="col-md-2 table-bordered-none-byMe">
                                    <strong>Web Site: </strong>
                                </div>   
                                <div class="col-md-10 table-bordered-none-byMe">
                                    <a href="<%#: Item.Brand.WebSite %>" target="_blank"><%#: Item.Brand.WebSite %></a>
                                </div>          
                            </div>
                        </div>
                    </div>    
                    <%--End-First Row with Main attributes--%>

                    <%--Second Row with Description, Ingredients and Use attributes--%>
                    <div class="row table-bordered-none-byMe">
                        <div class="col-md-2 table-bordered-none-byMe">                    
                        </div>
                        <div class="col-md-8 veryverylight-gray-bg table-bordered-none-byMe">   
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
