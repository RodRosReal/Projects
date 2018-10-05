<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Course.aspx.cs" Inherits="CollegeUI.Course" %>

<%@ Register Src="wuc/Testimonials.ascx" TagName="Testimonials" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">
        <header class="page-heading clearfix">
            <h1 class="heading-title pull-left">
                <asp:Literal ID="ltCourseName" runat="server"></asp:Literal></h1>
            <div class="breadcrumbs pull-right">
                <ul class="breadcrumbs-list">
                    <li class="breadcrumbs-label">Você está em:</li>
                    <li><a class="baseQueryString" href="Default.aspx">Home</a><i class="fa fa-angle-right"></i></li>
                    <li><a class="baseQueryString" href="Courses.aspx">Nossos Cursos</a><i class="fa fa-angle-right"></i></li>
                    <li class="current">
                        <asp:Literal ID="ltCourseNameLocal" runat="server"></asp:Literal></li>
                </ul>
            </div>
            <!--//breadcrumbs-->
        </header>
        <div class="page-content">
            <div class="row page-row">
                <div class="alert"></div>
                <div class="course-wrapper col-md-8 col-sm-7">
                    <article class="course-item">
                        <p class="featured-image page-row">
                            <asp:Image ID="imgCourseContent" CssClass="img-responsive" runat="server" />
                        </p>
                    </article>
                </div>
                <aside class="page-sidebar col-md-3 col-md-offset-1 col-sm-4 col-sm-offset-1">
                    <section class="widget has-divider">
                        <h3 class="title text-info">
                            <asp:Literal ID="ltCourseValue" runat="server"></asp:Literal></h3>
                        <p>
                            <asp:Literal ID="ltObs" runat="server"></asp:Literal>
                        </p>
                        <asp:HyperLink ID="hyEnrollment" runat="server">
                            <i class="fa fa-arrow-circle-o-right"></i>
                            <asp:Literal ID="ltEnrollment" runat="server"></asp:Literal>
                        </asp:HyperLink>
                    </section>
                </aside>
            </div>
            <div class="row page-row">
                <div class="alert"></div>
                <div class="course-wrapper col-md-12 col-sm-11">
                    <article class="course-item">
                        <asp:Literal ID="ltCourseContent" runat="server"></asp:Literal>
                    </article>
                    <!--//course-item-->
                </div>
                <!--//course-wrapper-->

            </div>
            <!--//page-row-->
        </div>
        <!--//page-content-->
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    <script type="text/javascript" src="assets/plugins/other/querystring-0.9.0.js"></script>
    <script type="text/javascript" src="assets/js/course.js"></script>
</asp:Content>
