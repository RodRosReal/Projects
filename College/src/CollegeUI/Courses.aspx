<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Courses.aspx.cs" Inherits="CollegeUI.Courses" %>

<%@ Register Src="wuc/Contact.ascx" TagName="contact" TagPrefix="uc1" %>

<%@ Register Src="wuc/Testimonials.ascx" TagName="Testimonials" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">
        <header class="page-heading clearfix">
            <h1 class="heading-title pull-left">Nossos Cursos</h1>
            <div class="breadcrumbs pull-right">
                <ul class="breadcrumbs-list">
                    <li class="breadcrumbs-label">Você está em:</li>
                    <li><a class="baseQueryString" href="Default.aspx">Home</a><i class="fa fa-angle-right"></i></li>
                    <li class="current">Nossos Cursos</li>
                </ul>
            </div>
            <!--//breadcrumbs-->
        </header>
        <div class="page-content">
            <div class="row page-row">
                <div class="courses-wrapper col-md-8 col-sm-7">
                    <div class="featured-courses tabbed-info page-row">
                        <ul class="nav nav-tabs">
                            <asp:Repeater ID="rptTabs" runat="server" OnItemDataBound="rptTabs_ItemDataBound">
                                <ItemTemplate>
                                    <asp:Literal ID="ltTabs" runat="server"></asp:Literal>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                        <div class="tab-content">
                            <asp:Repeater ID="rptTab" runat="server" OnItemDataBound="rptTab_ItemDataBound">
                                <ItemTemplate>
                                    <asp:Panel CssClass="tab-pane" ID="pnTab" ClientIDMode="Static" runat="server">
                                        <div class="row">
                                            <asp:Repeater ID="rptTabContent" runat="server" OnItemDataBound="rptTabContent_ItemDataBound">
                                                <ItemTemplate>
                                                    <div class="item col-md-3 col-sm-6 col-xs-6">
                                                        <asp:Image ID="imgCourse" CssClass="img-responsive" runat="server" />
                                                        <p class="text-center">
                                                            <asp:HyperLink CssClass="baseQueryString" ID="hyCourse" runat="server"></asp:HyperLink>
                                                        </p>
                                                    </div>
                                                    <div class="clearfix visible-xs"></div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </asp:Panel>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                    <!--//featured-courses-->
                </div>
                <!--//courses-wrapper-->
                <aside class="page-sidebar  col-md-3 col-md-offset-1 col-sm-4 col-sm-offset-1">
                    <uc1:contact ID="wucContact" runat="server" />
                    <div class="home-page">
                        <uc2:Testimonials ID="wucTestimonials" runat="server" />
                    </div>
                </aside>
            </div>
            <!--//page-row-->
        </div>
        <!--//page-content-->
    </div>
    <!--//page-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
