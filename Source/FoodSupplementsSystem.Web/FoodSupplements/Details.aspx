<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="FoodSupplementsSystem.Web.FoodSupplements.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        
    <h3>Supplement details</h3>

    <asp:PlaceHolder ID="PlaceHolderErrorMessage" runat="server" 
        Visible="false" 
        EnableViewState="false">
        <p class="text-danger"><%: this.ErrorMessage %></p>
    </asp:PlaceHolder>

    <asp:ListBox ID="ListBoxRateValues" runat="server" 
        AutoPostBack="true"        
        OnDataBinding="ListBoxRateValues_DataBinding" 
        OnSelectedIndexChanged="ListBoxRateValues_SelectedIndexChanged">
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
        <asp:ListItem>4</asp:ListItem>
        <asp:ListItem>5</asp:ListItem>
    </asp:ListBox>

    <asp:ListView ID="ListViewSupplementDetails" runat="server" 
        ItemType="FoodSupplementsSystem.Data.Models.Supplement" >
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
                <%--End-Helpers hidden fields--%>

                <%--Additional data source, used for Rating Control--%>
                <asp:SqlDataSource ID="SqlDataSourceRating" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:FoodSupplementsContextConnectionString %>"
                    SelectCommand = "SELECT Count([Value]) AS VotesCount, AVG([Value]) AS VotesAverageValue FROM [Ratings] WHERE SupplementId = @supplementId" >
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
                            Visible="true" OnDataBinding="LabelVotesAverageValueHelper_DataBinding" 
                            OnLoad="LabelVotesAverageValueHelper_Load">
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
                        <div class="col-md-8 table-bordered-none-byMe">
                            <%--Name and Details button--%>
                            <div class="row">                        
                                <div class="col-md-8 table-bordered-none-byMe">
                                    <h4><%#: Item.Name %></h4>
                                </div>   
                                <div class="col-md-4 table-bordered-none-byMe">                                    
                                </div>                     
                            </div>
                            <%--Rating stars--%>
                            <div class="row"> 
                                <div class="col-md-8 table-bordered-none-byMe">
                                    
                                    <asp:Label ID="LabelVotesAverageValue" runat="server" 
                                        Text='<%# this.GetAverageRatingValue() %>' 
                                        Visible="true">
                                    </asp:Label>
                                            
                                    <ajaxToolkit:Rating ID="SupplementRating" runat="server"                                    
                                        CurrentRating='<%# this.GetAverageRatingValue() %>'
                                        MaxRating="5"
                                        StarCssClass="ratingStar"
                                        EmptyStarCssClass="emptyRatingStar"
                                        FilledStarCssClass="filledRatingStar"
                                        WaitingStarCssClass="savedRatingStar"
                                        OnChanged="SupplementRating_Changed" />       
                                </div>   
                                <div class="col-md-4 table-bordered-none-byMe pull-right">
                                    <strong>Votes: </strong>   
                                    <p><%# Ratings.Count %></p>  
                                </div>
                            </div>
                            <%--Category--%>
                            <div class="row">                        
                                <div class="col-md-2 table-bordered-none-byMe">
                                    <strong>Category: </strong>
                                </div>   
                                <div class="col-md-10 table-bordered-none-byMe">
                                    <p><%# Item.Category.Name %></p>
                                </div>          
                            </div>
                            <%--Topic--%>
                            <div class="row">                        
                                <div class="col-md-2 table-bordered-none-byMe">
                                    <strong>Topic: </strong>
                                </div>   
                                <div class="col-md-10 table-bordered-none-byMe">
                                    <p><%# Item.Topic.Name %></p>
                                </div>          
                            </div>
                            <%--Brand--%>
                            <div class="row">                        
                                <div class="col-md-2 table-bordered-none-byMe">
                                    <strong>Brand: </strong>
                                </div>   
                                <div class="col-md-10 table-bordered-none-byMe">
                                    <p><%# Item.Brand.Name %></p>
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
                        <div class="col-md-8 table-bordered-none-byMe">   
                            <div class="no-use-accordion">
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
        
    <asp:Button ID="ButtonGoBack" runat="server" 
        CssClass="btn btn-default"
        Text="Go back" 
        OnClick="ButtonGoBack_Click" />

</asp:Content>
