<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="FoodSupplementsSystem.Web.FoodSupplements.Details" %>

<%@ Register Src="~/Controls/FooterControl.ascx" TagPrefix="mainFC" TagName="FooterControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="raw">

            <div class="raw table-bordered">
                <div class="col-md-4 table-bordered">
                    <h3><strong class="dark-orange-fg">Supplement details</strong></h3>
                </div>
                <div class="col-md-6 table-bordered">
                    <span class="pull-right"> vote here!</span>
                    <asp:DropDownList ID="DropDownListRateValues" runat="server" 
                        CssClass="pull-right"
                        AutoPostBack="true" 
                        OnSelectedIndexChanged="DropDownListRateValues_SelectedIndexChanged">

                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <!-- Add the extra clearfix for only the required viewport -->
            <div class="clearfix visible-md"></div>
            <div class="raw">
                <div class="col-md-8 pull-right table-bordered">
                     <asp:PlaceHolder ID="PlaceHolderErrorMessage" runat="server" 
                        Visible="false" 
                        EnableViewState="false">
                        <span class="text-danger text-center"><%: this.ErrorMessage %></span>
                        <asp:Button ID="ButtonAcknoledgeErrorMessages" runat="server" 
                            CssClass="btn btn-danger btn-sm"
                            Visible="true"
                            Text="x" 
                            OnClick="ButtonAcknoledgeErrorMessages_Click" />
                    </asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolderSuccessMessage" runat="server" 
                        Visible="false" 
                        EnableViewState="false">
                        <span class="text-success text-center"><%: this.SuccessMessage %></span>
                        <asp:Button ID="ButtonAcknoledgeSuccessMessages" runat="server" 
                            CssClass="btn btn-success btn-sm"
                            Visible="true"
                            Text="x" 
                            OnClick="ButtonAcknoledgeSuccessMessages_Click" />
                    </asp:PlaceHolder>
                </div>                
            </div>

            <asp:ListView ID="ListViewSupplementDetails" runat="server" 
                ItemType="FoodSupplementsSystem.Data.Models.Supplement" >
                <LayoutTemplate>  
                    <ul class="list-unstyled">
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                    </ul>
                </LayoutTemplate>
                <ItemTemplate>
                    <li>                
                    
                        <div class="clearfix visible-md"></div>
                        <div class="raw">
                            <div class="col-md-2 table-bordered">
                                <img src="<%#: Item.ImageUrl %>" alt="Supplements-Category-Brand-Name" />
                            </div>
                            <div class="col-md-8 table-bordered">
                                <%--Name and Details button--%>
                                <div class="row">                        
                                    <div class="col-md-12 table-bordered-none-byMe">
                                        <h4><%#: Item.Name %></h4>
                                    </div>                   
                                </div>
                                <%--Rating stars--%>
                                <div class="row"> 
                                    <div class="col-md-4 table-bordered-none-byMe">                                            
                                        <ajaxToolkit:Rating ID="SupplementRating" runat="server"                                    
                                            CurrentRating='<%# this.GetAverageRatingValue() %>'
                                            MaxRating="5"
                                            Enabled="<%# this.User.Identity.IsAuthenticated %>"
                                            StarCssClass="ratingStar"
                                            EmptyStarCssClass="emptyRatingStar"
                                            FilledStarCssClass="filledRatingStar"
                                            WaitingStarCssClass="savedRatingStar"
                                            OnChanged="SupplementRating_Changed" />       
                                    </div>   
                                    <div class="col-md-3 table-bordered-none-byMe pull-right">
                                        <strong>Total Votes: </strong>   
                                        <asp:Label ID="LabelTotalVotes" runat="server" 
                                            Text="<%# this.Ratings.Count %>"
                                            Visible="true">
                                        </asp:Label>
                                    </div>
                                    <div class="col-md-3 table-bordered-none-byMe pull-right">
                                        <strong>Your Vote: </strong>                                        
                                        <asp:Label ID="LabelYourVote" runat="server" 
                                            Text="<%# this.GetCurrentUserVoteValue() %>"
                                            Visible="<%# this.CurrentUserHasVouted() %>">
                                        </asp:Label>
                                    </div>
                                </div>
                                <%--Category--%>
                                <div class="row">                        
                                    <div class="col-md-2 table-bordered">
                                        <p><strong>Category: </strong></p>
                                    </div>   
                                    <div class="col-md-6 table-bordered">
                                        <p><%# Item.Category.Name %></p>
                                    </div>          
                                </div>
                                <%--Topic--%>
                                <div class="row">                        
                                    <div class="col-md-2 table-bordered-none-byMe">
                                        <p><strong>Topic: </strong></p>
                                    </div>   
                                    <div class="col-md-6 table-bordered-none-byMe">
                                        <p><%# Item.Topic.Name %></p>
                                    </div>          
                                </div>
                                <%--Brand--%>
                                <div class="row">                        
                                    <div class="col-md-2 table-bordered-none-byMe">
                                        <p><strong>Brand: </strong></p>
                                    </div>   
                                    <div class="col-md-6 table-bordered-none-byMe">
                                        <p><%# Item.Brand.Name %></p>
                                    </div>          
                                </div>
                                <%--Web--%>
                                <div class="row">                        
                                    <div class="col-md-2 table-bordered-none-byMe">
                                        <p><strong>Web Site: </strong></p>
                                    </div>   
                                    <div class="col-md-8 table-bordered-none-byMe">
                                        <a href="<%#: Item.Brand.WebSite %>" target="_blank"><%#: Item.Brand.WebSite %></a>
                                    </div>          
                                </div>
                            </div>
                        </div>
                        <div class="clearfix visible-md"></div>
                        <div class="raw">
                            <div class="col-md-8 col-md-offset-2 table-bordered">
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
                
                    </li>
                </ItemTemplate>
                <EmptyDataTemplate>
                    No data
                </EmptyDataTemplate>
            </asp:ListView>

        </div>

        <!-- Add the extra clearfix for only the required viewport -->
        <div class="clearfix visible-md"></div>
        <div class="raw">
            <div class="col-md-4 table-bordered">
                <asp:Button ID="ButtonGoBack" runat="server" 
                    CssClass="btn btn-primary"
                    Text="Go back" 
                    OnClick="ButtonGoBack_Click" />
            </div>
        </div>
        
    </div>
</asp:Content>

<asp:Content ID="MainFooter" ContentPlaceHolderID="FooterContainer" runat="server">   
    <mainFC:FooterControl runat="server" ID="FooterControl" />
</asp:Content>
