<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyCourse.aspx.cs" Inherits="CollegeUI.MyCourse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">
        <header class="page-heading clearfix">
            <h1 class="heading-title pull-left">
                <asp:Literal ID="ltCourse" runat="server"></asp:Literal></h1>
            <div class="breadcrumbs pull-right">
                <ul class="breadcrumbs-list">
                    <li class="breadcrumbs-label">Você está em:</li>
                    <li><a class="baseQueryString" href="Default.aspx">Home</a><i class="fa fa-angle-right"></i></li>
                    <li><a class="baseQueryString" href="MyCourses.aspx">Meus Cursos</a><i class="fa fa-angle-right"></i></li>
                    <li class="current">
                        <asp:Literal ID="ltCourseHead" runat="server"></asp:Literal></li>
                </ul>
            </div>
            <!--//breadcrumbs-->
        </header>
        <div class="page-content">
            <div class="row page-row">
                <div class="content-wrapper col-md-12 col-sm-12">
                    <div class="page-row">
                        <div class="table-responsive">
                            <asp:Repeater ID="rptModule" runat="server" OnItemDataBound="rptModule_ItemDataBound">
                                <ItemTemplate>
                                    <table class="table table-striped">
                                        <thead>
                                            <tr>
                                                <th class="item-course">
                                                    <asp:Literal ID="ltModuleTitle" runat="server"></asp:Literal></th>
                                                <th class="status-course"></th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td class="module-course"><i class="fa fa-caret-square-o-right"></i>
                                                    <asp:HyperLink ID="hyModule" runat="server"></asp:HyperLink>
                                                </td>
                                                <td class="status-course">
                                                    <asp:Literal ID="ltStatusModule" runat="server"></asp:Literal></td>
                                            </tr>
                                            <asp:Repeater ID="rptBlock" runat="server" OnItemDataBound="rptBlock_ItemDataBound">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="block-course"><i class="fa fa-arrow-circle-o-right"></i>
                                                            <asp:HyperLink ID="hyBlock" runat="server"></asp:HyperLink></td>
                                                        <td class="status-course">
                                                            <asp:Literal ID="ltStatusBlock" runat="server"></asp:Literal></td>
                                                    </tr>
                                                        <tr>
                                                            <td class="exercise-course"><i class="fa fa-pencil-square-o"></i>
                                                                <asp:HyperLink ID="hyExercise" runat="server"></asp:HyperLink>
                                                            </td>
                                                            <td class="status-course">
                                                                <asp:Literal ID="ltStatusExercise" runat="server"></asp:Literal></td>
                                                        </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                                <tr>
                                                    <td class="resource-course"><i class="fa fa-clipboard"></i>
                                                        <asp:HyperLink ID="hyResource" runat="server"></asp:HyperLink>
                                                    </td>
                                                    <td class="status-course">
                                                        <asp:Literal ID="ltStatusResource" runat="server"></asp:Literal></td>
                                                </tr>
                                                <tr>
                                                    <td class="test-course"><i class="fa fa-pencil-square-o"></i>
                                                        <asp:HyperLink ID="hyTest" runat="server"></asp:HyperLink></td>
                                                    <td class="status-course">
                                                        <asp:Literal ID="ltStatusTest" runat="server"></asp:Literal></td>
                                                </tr>
                                        </tbody>
                                    </table>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                    <!--//page-row-->
                </div>
                <!--//content-wrapper-->
            </div>
            <!--//page-row-->
        </div>
        <!--//page-content-->
    </div>
    <!--//page-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    <script type="text/javascript" src="assets/plugins/other/bootbox.js"></script>
</asp:Content>
