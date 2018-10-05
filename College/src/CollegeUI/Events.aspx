<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Events.aspx.cs" Inherits="CollegeUI.Events" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">
        <header class="page-heading clearfix">
            <h1 class="heading-title pull-left">Eventos</h1>
            <div class="breadcrumbs pull-right">
                <ul class="breadcrumbs-list">
                    <li class="breadcrumbs-label">Você está em:</li>
                    <li><a class="baseQueryString" href="Default.aspx">Home</a><i class="fa fa-angle-right"></i></li>
                    <li class="current">Eventos</li>
                </ul>
            </div>
            <!--//breadcrumbs-->
        </header>
        <div class="page-content">
            <div class="row page-row">
                <asp:HiddenField ID="hddUrlFeaturedEvent" ClientIDMode="Static" runat="server" />
                <div class="events-wrapper col-md-12 col-sm-11">
                    <asp:Repeater ID="rptEvents" runat="server" OnItemDataBound="rptEvents_ItemDataBound">
                        <HeaderTemplate></HeaderTemplate>
                        <ItemTemplate>
                            <article class="events-item page-row has-divider clearfix">
                                <div class="date-label-wrapper col-md-1 col-sm-2">
                                    <p class="date-label">
                                        <span class="month">
                                            <asp:Literal ID="ltMonth" runat="server"></asp:Literal></span>
                                        <span class="date-number">
                                            <asp:Literal ID="ltDay" runat="server"></asp:Literal></span>
                                    </p>
                                </div>
                                <!--//date-label-wrapper-->
                                <div class="details col-md-6 col-sm-5">
                                    <h3 class="title">
                                        <asp:Literal ID="ltEvent" runat="server"></asp:Literal></h3>
                                    <p class="meta">
                                        <span class="time"><i class="fa fa-clock-o"></i>
                                            <asp:Literal ID="ltHour" runat="server"></asp:Literal></span>
                                        <span class="location">
                                            <i class="fa fa-map-marker"></i>
                                            <asp:HyperLink ID="hyEvent" CssClass="hyVideo" NavigateUrl="javascript:void(0);" runat="server"></asp:HyperLink>
                                        </span>
                                    </p>
                                    <p class="desc">
                                        <asp:Literal ID="ltDescription" runat="server"></asp:Literal>
                                    </p>
                                </div>
                                <aside class="page-sidebar col-md-4 col-md-offset-1 col-sm-4 col-sm-offset-1">
                                    <section class="video">
                                        <asp:Literal ID="ltVideo" runat="server"></asp:Literal>
                                    </section>
                                </aside>
                                <!--//details-->
                            </article>
                        </ItemTemplate>
                        <FooterTemplate></FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <!--//page-row-->
        </div>
        <!--//page-content-->
    </div>
    <!--//page-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    <script type="text/javascript" src="assets/js/events.js"></script>
</asp:Content>
