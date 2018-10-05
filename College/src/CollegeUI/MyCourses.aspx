<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyCourses.aspx.cs" Inherits="CollegeUI.MyCourses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">
        <header class="page-heading clearfix">
            <h1 class="heading-title pull-left">Meus Cursos</h1>
            <div class="breadcrumbs pull-right">
                <ul class="breadcrumbs-list">
                    <li class="breadcrumbs-label">Você está em:</li>
                    <li><a class="baseQueryString" href="Default.aspx">Home</a><i class="fa fa-angle-right"></i></li>
                    <li class="current">Meus Cursos</li>
                </ul>
            </div>
            <!--//breadcrumbs-->
        </header>
        <div class="page-content">
            <div class="row page-row">
                <div class="alert"></div>
                <div class="jobs-wrapper col-md-12 col-sm-12">
                    <asp:Repeater ID="rptMyCourses" runat="server" OnItemDataBound="rptMyCourses_ItemDataBound">
                        <ItemTemplate>
                            <div class="panel panel-default page-row">
                                <div class="panel-heading">
                                    <h3 class="panel-title">
                                        <asp:HyperLink ID="hyCourse" class="baseQueryString" runat="server"></asp:HyperLink>
                                        <span class="label label-success pull-right">
                                            <asp:Literal ID="ltPerformance" runat="server"></asp:Literal>
                                            %</span></h3>
                                </div>
                                <div class="panel-body">
                                    <asp:Literal ID="ltSummary" runat="server"></asp:Literal>
                                </div>
                                <div class="panel-footer">
                                    <div class="row">
                                        <ul class="list-inline col-md-12 col-sm-12 col-xs-12">
                                            <li>
                                                <asp:HyperLink ID="hyMyCourse" class="baseQueryString" runat="server">Entrar</asp:HyperLink></li>
                                            <asp:PlaceHolder ID="phSendCode" runat="server" Visible="false">
                                                <li>
                                                    <div class="cod-group">
                                                        <input type="text" class="form-control" placeholder="Código da Matrícula">
                                                        <asp:HiddenField ID="hddEnrollmentId" runat="server" />
                                                        <asp:HiddenField ID="hddCourseId" runat="server" />
                                                    </div>
                                                    <button id="btnSendCode" type="button" class="btn btn-theme">Enviar</button>
                                                </li>
                                            </asp:PlaceHolder>
                                            <%--<li>
                                                <a href="Terms.aspx" target="_blank" class="baseQueryString">Termos de Uso</a></li>--%>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <!--//jobs-wrapper-->
            </div>
            <!--//page-row-->
        </div>
        <!--//page-content-->
    </div>
    <!--//page-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    <script type="text/javascript" src="assets/js/myCourses.js"></script>
</asp:Content>
