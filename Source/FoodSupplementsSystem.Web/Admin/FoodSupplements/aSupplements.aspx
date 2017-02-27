<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeBehind="aSupplements.aspx.cs" 
    MasterPageFile="~/Site.Master" 
    Inherits="FoodSupplementsSystem.Web.Admin.FoodSupplements.aSupplements" %>

<asp:Content ID="ContentSupplement" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="container">
        <div class="raw">


            <div class="raw table-bordered">
                <div class="col-md-10 table-bordered-none-byMe">
                    <h1 class="red-fg">Manage supplements <a href="../aDefault.aspx" class="nav-link">admin</a> page</h1>
                </div>
            </div>    

            <!-- Add the extra clearfix for only the required viewport -->
            <div class="clearfix visible-md"></div>
            <div class="raw">
                <div class="col-md-8 pull-right table-bordered-none-byMe">
                    <asp:ValidationSummary ShowModelStateErrors="true" runat="server" />
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

            <!-- Add the extra clearfix for only the required viewport -->
            <!-- ListView row -->
            <div class="clearfix visible-md"></div>
            <div class="raw">
                <div class="col-md-12 table-bordered-none-byMe">
                    <asp:ListView ID="ListViewManageSupplements" runat="server"
                        ItemType="FoodSupplementsSystem.Data.Models.Supplement"
                        DataKeyNames="Id"
                        SelectMethod="ListViewManageSupplements_GetData"
                        DeleteMethod="ListViewManageSupplements_DeleteItem"
                        UpdateMethod="ListViewManageSupplements_UpdateItem">

                        <LayoutTemplate>

                            <!-- Add the extra clearfix for only the required viewport -->
                            <div class="clearfix visible-md"></div>
                            <div class="row" style="margin-top: 10px; margin-bottom:4px;">
                                <div class="col-md-1 table-bordered-none-byMe">
                                    Sortigs:
                                </div>
                                <div class="col-md-1 table-bordered-none-byMe">
                                    Id
                                </div>
                                <div class="col-md-2 table-bordered-none-byMe">
                                    Name
                                </div>
                                <div class="col-md-2 table-bordered-none-byMe">
                                    Category
                                </div>
                                <div class="col-md-2 table-bordered-none-byMe">
                                    Topic
                                </div>
                                <div class="col-md-2 table-bordered-none-byMe">
                                    Brand
                                </div>                                
                                <div class="col-md-1 table-bordered-none-byMe">
                                    Votes
                                </div>
                                <div class="col-md-1 table-bordered-none-byMe">
                                    Rating
                                </div>
                            </div>                         

                            <!-- Add the extra clearfix for only the required viewport -->
                            <div class="clearfix visible-md"></div>
                            <div class="raw">
                                <ul class="list-unstyled">  
                                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                                </ul>
                            </div>

                            <!-- Add the extra clearfix for only the required viewport -->
                            <div class="clearfix visible-md"></div>
                            <div class="raw">
                                Data pager
                            </div>
                            
                        </LayoutTemplate>
                        <ItemSeparatorTemplate>
                            <!-- Add the extra clearfix for only the required viewport -->
                            <%--<div class="clearfix visible-md"></div>
                            <div class="raw" style="margin: 10px 0px 10px 0px;">                                      
                                <div class="col-md-12 table-bordered" >
                                </div>
                            </div>--%>
                        </ItemSeparatorTemplate>
                        <ItemTemplate>
                            <li>  
                                <!-- Add the extra clearfix for only the required viewport -->
                                <div class="clearfix visible-md"></div>
                                <div class="raw" style="margin: 10px 0px 10px 0px;">                                      
                                    <div class="col-md-12 table-bordered" style="border-color: dodgerblue">
                                    </div>
                                </div>

                                <!-- Add the extra clearfix for only the required viewport -->
                                <div class="clearfix visible-md"></div>
                                <div class="raw" >                                      
                                    <div class="col-md-1 table-bordered-none-byMe" >
                                        <img src="<%#: Item.ImageUrl %>" width="100%"  style="max-width:100px;" alt="Supplements-Category-BrandName-ItemName" />
                                    </div>
                                    <div class="col-md-9 table-bordered-none-byMe">
                                        
                                        <table class="gridview" cellspacing="0" rules="rows" border="0" style="border-collapse: collapse; border-color: lightgray;" >
                                            <tbody class="table-hover">
                                                <tr>
                                                    <td><strong>#</strong></td>
                                                    <td><span><%#: Item.Id %></span></td>
                                                </tr>
                                                <tr>
                                                    <td><strong>Name</strong></td>
                                                    <td><span><%#: Item.Name %></span></td>
                                                </tr>
                                                <tr>
                                                    <td><strong>Topic</strong></td>
                                                    <td><span><%#: Item.Topic.Name %></span></td>
                                                </tr>
                                                <tr>
                                                    <td><strong>Brand</strong></td>
                                                    <td><span><%#: Item.Brand.Name %></span></td>
                                                </tr>
                                                <tr>
                                                    <td><strong>WebSite</strong></td>
                                                    <td><a href="<%#: Item.Brand.WebSite %>" target="_blank"><%#: Item.Brand.WebSite %></a></td>
                                                </tr>

                                                <tr>
                                                    <td><strong>Ingredients</strong></td>
                                                    <td><span><%#: Item.Ingredients %></span></td>
                                                </tr>
                                                <tr>
                                                    <td><strong>Use</strong></td>
                                                    <td><span><%#: Item.Use %></span></td>
                                                </tr>
                                                <tr>
                                                    <td><strong>Description</strong></td>
                                                    <td><span><%#: Item.Description %></span></td>
                                                </tr>
                                                <tr>
                                                    <td><strong>Creation Date</strong></td>
                                                    <td><span><%#: Item.CreationDate %></span></td>
                                                </tr>

                                                <tr>
                                                    <td><strong>Votes</strong></td>
                                                    <td><span><%#: Item.RatingsReceived.Count %></span></td>
                                                </tr>
                                                <tr>
                                                    <td><strong>Average Rating</strong></td>
                                                    <td><span><%#: this.GetAverageRatingValue(Item.RatingsReceived.ToList()) %></span></td>
                                                </tr>
                                            </tbody>
                                        </table>

                                    </div>
                                    <div class="col-md-2 table-bordered-none-byMe">
                                        <asp:LinkButton ID="LinkButtonEdit" runat="server" 
                                            CssClass="btn btn-primary btn-sm" 
                                            Width="75%"
                                            Text="Fast Edit" 
                                            CommandName="Edit"/>   
                                        <%--<asp:LinkButton ID="LinkButtonDetailEdit" runat="server" 
                                            CssClass="btn btn-primary btn-sm"
                                            Width="75%"
                                            Text="Detail Edit"
                                            href="aadd.aspx"/>  --%>
                                        <asp:LinkButton ID="LinkButtonDelete" runat="server" 
                                            CssClass="btn btn-danger btn-sm"
                                            Width="75%"
                                            Text="Delete" 
                                            CommandName="Delete"/>                                        
                                    </div>
                                </div>                                    
                            </li>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <!-- Add the extra clearfix for only the required viewport -->
                            <div class="clearfix visible-md"></div>
                            <div class="raw" style="margin: 10px 0px 10px 0px;">                                      
                                <div class="col-md-12 table-bordered" style="border-color: dodgerblue">
                                </div>
                            </div>

                            <!-- Add the extra clearfix for only the required viewport -->
                            <div class="clearfix visible-md"></div>
                            <div class="raw" >   
                                                                       
                                <div class="col-md-1 table-bordered" >
                                    <img src="<%#: Item.ImageUrl %>" width="100%"  style="max-width:100px;" alt="Supplements-Category-BrandName-ItemName" />
                                </div>
                                                                    
                                <div class="col-md-9 table-bordered-none-byMe">
                                        
                                    <table class="gridview" cellspacing="0"  rules="rows" border="0" style="width:100%; border-collapse: collapse; border-color: lightgray;" >
                                        <tbody class="table-hover">
                                            <tr>
                                                <td class="col-md-3"><strong>#</strong></td>
                                                <td><span><%#: Item.Id %></span></td>
                                            </tr>


                                            <tr>
                                                <td class="col-md-3"><strong>Image Url</strong></td>
                                                <td><asp:TextBox runat="server" ID="TextBoxImageUrl" Width="100%" Text="<%#: BindItem.ImageUrl %>" /></td>
                                            </tr>
                                            <tr>
                                                <td class="col-md-3"><strong>Name</strong></td>
                                                <td><asp:TextBox runat="server" ID="TextBoxName" Width="100%" Text="<%#: BindItem.Name %>" /></td>
                                            </tr>
                                            <tr>
                                                <td class="col-md-3"><strong>Topic</strong></td>
                                                <td><span><%#: Item.Topic.Name %></span></td>
                                            </tr>
                                            <tr>
                                                <td class="col-md-3"><strong>Brand</strong></td>
                                                <td><span><%#: Item.Brand.Name %></span></td>
                                            </tr>
                                            <tr>
                                                <td class="col-md-3"><strong>WebSite</strong></td>
                                                <td><asp:TextBox runat="server" ID="TextBoxWebSite" Width="100%" Text="<%#: BindItem.Brand.WebSite %>" /></td>
                                            </tr>

                                            <tr>
                                                <td class="col-md-3"><strong>Ingredients</strong></td>
                                                <td><asp:TextBox runat="server" ID="TextBoxIngredients" TextMode="MultiLine" Rows="3" Width="100%" Text="<%#: BindItem.Ingredients %>" /></td>
                                            </tr>
                                            <tr>
                                                <td class="col-md-3"><strong>Use</strong></td>
                                                <td><asp:TextBox runat="server" ID="TextBoxUse" TextMode="MultiLine" Rows="3" Width="100%" Text="<%#: BindItem.Use %>" /></td>
                                            </tr>
                                            <tr>
                                                <td class="col-md-3"><strong>Description</strong></td>
                                                <td><asp:TextBox runat="server" ID="TextBoxDescription" TextMode="MultiLine" Rows="5" Width="100%" Text="<%#: BindItem.Description %>" /></td>
                                            </tr>
                                            <tr>
                                                <td class="col-md-3"><strong>Creation Date</strong></td>
                                                <td><span><%#: Item.CreationDate %></span></td>
                                            </tr>

                                            <tr>
                                                <td class="col-md-3"><strong>Votes</strong></td>
                                                <td><span><%#: Item.RatingsReceived.Count %></span></td>
                                            </tr>
                                            <tr>
                                                <td class="col-md-3"><strong>Average Rating</strong></td>
                                                <td><span><%#: this.GetAverageRatingValue(Item.RatingsReceived.ToList()) %></span></td>
                                            </tr>
                                        </tbody>
                                    </table>

                                </div>


                                <div class="col-md-2 table-bordered-none-byMe">
                                    <asp:LinkButton ID="LinkButtonEdit" runat="server" 
                                        CssClass="btn btn-success btn-sm" 
                                        Width="75%"
                                        Text="Save" 
                                        CommandName="Update"/>
                                    <asp:LinkButton ID="LinkButtonCancel" runat="server" 
                                        CssClass="btn btn-warning btn-sm"
                                        Width="75%"
                                        Text="Cancel" 
                                        CommandName="Cancel"/>                                        
                                </div>
                            </div>   
                        </EditItemTemplate>


                    </asp:ListView>
                </div>                
            </div>           

            
            <div class="clearfix visible-md"></div>
            <div class="raw">            
                <div class="col-md-2 table-bordered-none-byMe col-md-offset-8">                
                    <asp:LinkButton ID="LinkButtonGoToAddSupplement" runat="server" 
                        href="aadd.aspx" 
                        CssClass="btn btn-primary btn-sm pull-right">Add Supplement</asp:LinkButton>
                </div>            
            </div>
    
        </div>       
    </div>
</asp:Content>
