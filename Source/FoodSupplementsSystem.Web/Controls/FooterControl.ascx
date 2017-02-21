<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FooterControl.ascx.cs" 
    Inherits="FoodSupplementsSystem.Web.Controls.FooterControl" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

        <footer class="footer-bg">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse-footer" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
            </div>            
            <div class="navbar-collapse collapse-footer">
                <ul class="nav navbar-nav navbar-right">
                    <li><a runat="server" href="~/about-us">About</a></li>
                    <li><a runat="server" href="~/contact">Contact</a></li>
                    <li><a runat="server" href="~/TreeView.aspx">Site Map</a></li>
                </ul>
            </div>        
            <p>&copy; <%: DateTime.Now.Year %> - My ASP.NET Application</p>

        </footer>
    </ContentTemplate>
</asp:UpdatePanel>
