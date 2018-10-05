<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CollegeUI.Default" %>

<%@ Register src="wuc/Testimonials.ascx" tagname="Testimonials" tagprefix="uc1" %>

<%@ Register src="wuc/Events.ascx" tagname="Events" tagprefix="uc2" %>

<%@ Register src="wuc/Videos.ascx" tagname="Videos" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="promo-slider" class="slider flexslider">
        <ul class="slides">
            <asp:Repeater ID="rptBanners" runat="server" OnItemDataBound="rptBanners_ItemDataBound">
            <HeaderTemplate></HeaderTemplate>
            <ItemTemplate>
            <li>
                <asp:Image ID="imgBanner" runat="server" />
                <p class="flex-caption">
                    <span class="main">
                        <asp:Literal ID="ltMainCaption" runat="server"></asp:Literal></span>
                    <br />
                    <span class="secondary clearfix"><asp:Literal ID="ltSecondaryCaption" runat="server"></asp:Literal></span>
                </p>
            </li>
            </ItemTemplate>
            <FooterTemplate></FooterTemplate>
        </asp:Repeater>
        </ul>
    </div>
    <div class="row cols-wrapper">
        <div class="col-md-3">
            <uc2:Events ID="wucEvents" runat="server" />
        </div>
        <!--//col-md-3-->
        <div class="col-md-6">            
            <uc3:Videos ID="wucVideos" runat="server" />
        </div>
        <div class="col-md-3">
            <uc1:Testimonials ID="wucTestimonials" runat="server" />
        </div>
        <!--//col-md-3-->
    </div>
    <!--//cols-wrapper-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
