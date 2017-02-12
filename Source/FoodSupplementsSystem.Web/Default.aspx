<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FoodSupplementsSystem.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

     <div class="row">
        <div class="col-md-4">
            <h2>Health Topics</h2>
            <img src="Images/Health-Topics-Main.jpg" alt="Health-Topics" width="100%"/>
            <p>
                Our Health Topics Categories
                Many of products we carry are organized under specific health topics to help you find the vitamins and supplements as per your particular health interests. We have over 30 health categories such as anti-aging, musculoskeletal health, children & teen health, cardiovascular support, digestive GI health, weight loss, even pet health and more. Our wide-ranging health topics and supplement categories will be useful when you want to narrow down your choices to the most relevant products.
            </p>
            <p>
                <a class="btn btn-default" href="/home">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Food Supplements</h2>
            <img src="Images/Supplements-Main.jpg" alt="Health-Topics" width="100%"/>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="/foodsupplements/supplements">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Famous Brands</h2>
            <img src="Images/Famous-Brands.jpg" alt="Health-Topics" width="100%"/>
            <p>
                How are the brands that Rockwell Nutrition carries selected?  Do they go through quality assessments?
                The professional-grade brands we carry on our site are excellent quality, they do go through rigorous vetting by our health professional distributors for purity, potency, and quality, this is a little more info on their quality program if you care to read about it, there is also a video on there site about their quality program:
            </p>
            <p>
                <a class="btn btn-default" href="/brands">Learn more &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
