<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeBehind="aSupplements.aspx.cs" 
    MasterPageFile="~/Site.Master" 
    Inherits="FoodSupplementsSystem.Web.Admin.FoodSupplements.aSupplements" %>

<asp:Content ID="ContentSupplement" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="container">
        <div class="raw">


            <div class="raw table-bordered">
                <div class="col-md-10 table-bordered">
                    <h1 class="red-fg">Mnage supplements <a href="../aDefault.aspx" class="nav-link">admin</a> page</h1>
                </div>
            </div>    

            <!-- Add the extra clearfix for only the required viewport -->
            <div class="clearfix visible-md"></div>
            <div class="raw">
                <div class="col-md-8 pull-right table-bordered">

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
                <div class="col-md-12 table-bordered">
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
                                <div class="col-md-1 table-bordered">
                                    Sortigs:
                                </div>
                                <div class="col-md-1 table-bordered">
                                    Id
                                </div>
                                <div class="col-md-2 table-bordered">
                                    Name
                                </div>
                                <div class="col-md-2 table-bordered">
                                    Category
                                </div>
                                <div class="col-md-2 table-bordered">
                                    Topic
                                </div>
                                <div class="col-md-2 table-bordered">
                                    Brand
                                </div>                                
                                <div class="col-md-1 table-bordered">
                                    Votes
                                </div>
                                <div class="col-md-1 table-bordered">
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

                        <ItemTemplate>
                            <li>  
                                <!-- Add the extra clearfix for only the required viewport -->
                                <div class="clearfix visible-md"></div>
                                <div class="raw" >                                      
                                    <div class="col-md-1 table-bordered" >
                                        <img src="<%#: Item.ImageUrl %>" width="100%"  style="max-width:100px;" alt="Supplements-Category-BrandName-ItemName" />
                                    </div>
                                    <div class="col-md-9 table-bordered">
                                        <div class="row">
                                            <div class="col-md-8 table-bordered">
                                                <table class="gridview" cellspacing="0" rules="all" border="1" style="border-collapse: collapse;">
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
                                                    </tbody>
                                                </table>
                                            </div>                                        
                                            <div class="col-md-2 table-bordered-none-byMe">
                                                <table class="gridview" cellspacing="0" border="1" style="border-collapse: collapse;">
                                                    <tbody class="table-hover">
                                                        <tr>
                                                            <td><strong>Votes</strong></td>
                                                            <td><span><%#: Item.Id %></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td><strong>Rating</strong></td>
                                                            <td><span><%#: Item.Id %></span></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-2 table-bordered">
                                        <asp:LinkButton ID="LinkButtonEdit" runat="server" 
                                            CssClass="btn btn-primary btn-sm" 
                                            Width="75%"
                                            Text="Fast Edit" 
                                            CommandName="Edit"/>   
                                        <asp:LinkButton ID="LinkButtonDetailEdit" runat="server" 
                                            CssClass="btn btn-primary btn-sm"
                                            Width="75%"
                                            Text="Detail Edit"
                                            href="aadd.aspx"/>  
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
                                <div class="raw" >                                      
                                    <div class="col-md-1 table-bordered" >
                                        <img src="<%#: Item.ImageUrl %>" width="100%"  style="max-width:100px;" alt="Supplements-Category-BrandName-ItemName" />
                                    </div>
                                    <div class="col-md-9 table-bordered">
                                        <div class="row">
                                            <div class="col-md-8 table-bordered">
                                                <table class="gridview" cellspacing="0" rules="all" border="1" style="border-collapse: collapse;">
                                                    <tbody class="table-hover">
                                                        <tr>
                                                            <td><strong>#</strong></td>
                                                            <td><span><%#: Item.Id %></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td><strong>Name</strong></td>                                                            
                                                            <td><asp:TextBox runat="server" ID="TextBoxName" Text="<%#: BindItem.Name %>" /></td>
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
                                                    </tbody>
                                                </table>
                                            </div>                                        
                                            <div class="col-md-2 table-bordered-none-byMe">
                                                <p>Votes:</p>
                                                <p>Rating:</p>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-2 table-bordered">
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
                <div class="col-md-2 table-bordered col-md-offset-8">                
                    <asp:LinkButton ID="LinkButtonGoToAddSupplement" runat="server" 
                        href="aadd.aspx" 
                        CssClass="btn btn-primary btn-sm pull-right">Add Supplement</asp:LinkButton>
                </div>            
            </div>
    
        </div>       
    </div>
</asp:Content>
