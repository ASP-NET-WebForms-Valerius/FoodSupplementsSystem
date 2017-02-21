<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="aAdd.aspx.cs" Inherits="FoodSupplementsSystem.Web.Admin.FoodSupplements.aAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="raw">

            <div class="raw table-bordered">
                <div class="col-md-10 table-bordered">
                    <h1 class="red-fg">Add new supplement <a href="../aDefault.aspx" class="nav-link">admin</a> page</h1>
                </div>
            </div>    

            <!-- Add the extra clearfix for only the required viewport -->
            <div class="clearfix visible-md"></div>
            <div class="raw">
                <div class="col-md-8 pull-right table-bordered">

                    <%--<asp:ValidationSummary ShowModelStateErrors="true" runat="server" />--%>

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
            <div class="clearfix visible-md"></div>
            <!-- Detail row -->
            <div class="raw">
                <div class="col-md-8 table-bordered">  
                    <asp:FormView ID="FormViewAddSupplement" runat="server" 
                        ItemType="FoodSupplementsSystem.Data.Models.Supplement"
                        SelectMethod="FormViewAddSupplement_GetItem"
                        UpdateMethod="FormViewAddSupplement_UpdateItem"
                        InsertMethod="FormViewAddSupplement_InsertItem" 
                        OnModeChanging="FormViewAddSupplement_ModeChanging">
                    
                        <ItemTemplate>  
                            <div class="row">  
                                <div class="col-md-12 table-bordered">        
                                    <p><strong>Name: </strong><%#: Item.Name %></p>                            
                                    <p><strong>ImageUrl: </strong><%#: Item.ImageUrl %></p>                            
                                    <p><strong>Ingredients: </strong><%#: Item.Ingredients %></p>                            
                                    <p><strong>Use: </strong><%#: Item.Use %></p>                            
                                    <p><strong>Description: </strong><%#: Item.Description %></p>                            
                                    <p><strong>CreationDate: </strong>><%#: Item.CreationDate %></p>
                            
                                    <p><strong>Author: </strong><%#: Item.AuthorId %></p>                            
                                    <p><strong>Category: </strong><%#: this.GetSelectedCategoryName() %></p>                            
                                    <p><strong>Topic: </strong><%#: this.GetSelectedTopicName() %></p>                            
                                    <p><strong>Brand: </strong><%#: this.GetSelectedBrandName() %></p>
                                </div>
                            </div>
                        
                            <!-- Add the extra clearfix for only the required viewport -->
                            <div class="clearfix visible-md"></div>
                            <div class="row">
                                <div class="col-md-8 table-bordered">
                                    <asp:LinkButton ID="LinkButtonInsert" runat="server"
                                        CssClass="btn btn-primary btn-sm"
                                        Width="75%"
                                        Text="Edit Mode"
                                        CommandName="Edit"/>
                                    <asp:LinkButton ID="LinkButtonCancel" runat="server" 
                                        CssClass="btn btn-warning btn-sm"
                                        Width="75%"
                                        Text="Cancel" 
                                        CommandName="Cancel"/>                                        
                                </div>
                            </div>
                                                
                        </ItemTemplate>
                        <EditItemTemplate>
                            <div class="row">  
                                <div class="col-md-12 table-bordered">        
                                    <p><strong>Name: </strong></p> 
                                    <asp:TextBox runat="server" ID="TextBoxName" Text="<%#: BindItem.Name %>" />                            
                                    <p><strong>ImageUrl: </strong></p> 
                                    <asp:TextBox runat="server" ID="TextBoxImageUrl" Text="<%#: BindItem.ImageUrl %>" />                            
                                    <p><strong>Ingredients: </strong></p> 
                                    <asp:TextBox runat="server" ID="TextBoxIngredients" Text="<%#: BindItem.Ingredients %>" />                            
                                    <p><strong>Use: </strong></p> 
                                    <asp:TextBox runat="server" ID="TextBoxUse" Text="<%#: BindItem.Use %>" />                            
                                    <p><strong>Description: </strong></p> 
                                    <asp:TextBox runat="server" ID="TextBoxDescription" Text="<%#: BindItem.Description %>" />                            
                                    <p><strong>CreationDate: </strong><%#: Item.CreationDate %></p>      
                                    <p><strong>AuthorId: </strong><%# this.User.Identity.Name %> - <%#: Item.AuthorId %></p> 
                                    <br />                           
                                    <p><strong>Select Category: </strong></p> 
                                    <asp:DropDownList ID="DropDownListCategories" runat="server"
                                        AutoPostBack="true"
                                        OnDataBinding="DropDownListCategories_DataBinding"
                                        OnSelectedIndexChanged="DropDownListCategories_SelectedIndexChanged"></asp:DropDownList>                                                             
                                    <p><strong>Select Topic</strong></p>     
                                    <asp:DropDownList ID="DropDownListTopics" runat="server"
                                        AutoPostBack="true"
                                        OnDataBinding="DropDownListTopics_DataBinding"
                                        OnSelectedIndexChanged="DropDownListTopics_SelectedIndexChanged"></asp:DropDownList>                       
                                    <p><strong>Select Brand</strong></p>
                                    <asp:DropDownList ID="DropDownListBrands" runat="server"
                                        AutoPostBack="true"
                                        OnDataBinding="DropDownListBrands_DataBinding"
                                        OnSelectedIndexChanged="DropDownListBrands_SelectedIndexChanged"></asp:DropDownList>

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-8 table-bordered">
                                    <asp:LinkButton ID="LinkButtonEdit" runat="server" 
                                        CssClass="btn btn-success btn-sm" 
                                        Width="75%"
                                        Text="Insert" 
                                        Visible="<%# this.ItemIsReadyToBeInserted() %>"
                                        CommandName="Update"/>
                                    <asp:Button ID="ButtonCheckIfReady" runat="server" 
                                        CssClass="btn btn-primary btn-sm" 
                                        Width="75%"
                                        Text="Check if Ready" 
                                        Visible="<%# !this.ItemIsReadyToBeInserted() %>"
                                        OnClick="ButtonCheckIfReady_Click"/>
                                    <asp:LinkButton ID="LinkButtonCancel" runat="server" 
                                        CssClass="btn btn-warning btn-sm"
                                        Width="75%"
                                        Text="Preview Mode" 
                                        CommandName="Cancel"/>                                        
                                </div>
                            </div>

                        </EditItemTemplate>

                        <InsertItemTemplate>
                            Insert mode
                            <!-- Add the extra clearfix for only the required viewport -->
                            <%--<div class="clearfix visible-md"></div>
                            <div class="row">
                                <div class="col-md-8 table-bordered">
                                    <asp:LinkButton ID="LinkButtonInsert" runat="server"
                                        CssClass="btn btn-primary btn-sm"
                                        Width="75%"
                                        Text="Insert Supplement"
                                        CommandName="Insert"/>
                                    <asp:LinkButton ID="LinkButtonCancel" runat="server" 
                                        CssClass="btn btn-warning btn-sm"
                                        Width="75%"
                                        Text="Preview Mode" 
                                        CommandName="Select"/>                                        
                                </div>
                            </div>--%>
                        </InsertItemTemplate>

                    </asp:FormView>
                
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="MainFooter" ContentPlaceHolderID="FooterContainer" runat="server">    
</asp:Content>