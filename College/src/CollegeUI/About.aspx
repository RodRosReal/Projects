<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="CollegeUI.About" %>

<%@ Register Src="wuc/Contact.ascx" TagName="contact" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">
        <header class="page-heading clearfix">
            <h1 class="heading-title pull-left">Sobre Nós</h1>
            <div class="breadcrumbs pull-right">
                <ul class="breadcrumbs-list">
                    <li class="breadcrumbs-label">Você está em:</li>
                    <li><a class="baseQueryString" href="Default.aspx">Home</a><i class="fa fa-angle-right"></i></li>
                    <li class="current">Sobre Nós</li>
                </ul>
            </div>
            <!--//breadcrumbs-->
        </header>
        <div class="page-content">
            <div class="row page-row">
                <article class="welcome col-md-8 col-sm-7">
                    <p>
                        <asp:Image ID="imgAbout" CssClass="img-responsive" runat="server" />
                    </p>
                    <asp:Literal ID="ltAbout" runat="server"></asp:Literal>
                    <blockquote class="custom-quote">
                        <p>
                            <i class="fa fa-quote-left"></i>
                            <asp:Literal ID="ltTestimonial" runat="server"></asp:Literal>
                        </p>
                        <p class="people">
                            <span class="name">
                                <asp:Literal ID="ltTestimonialName" runat="server"></asp:Literal></span><br />
                            <span class="title">
                                <asp:Literal ID="ltTestimonialLocal" runat="server"></asp:Literal></span>
                        </p>
                    </blockquote>
                </article>
                <!--//page-content-->
                <aside class="page-sidebar  col-md-3 col-md-offset-1 col-sm-4 col-sm-offset-1">
                    <uc1:contact ID="wucContact" runat="server" />
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
