<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Faq.aspx.cs" Inherits="CollegeUI.Faq" %>

<%@ Register src="wuc/Contact.ascx" tagname="Contact" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">
        <header class="page-heading clearfix">
            <h1 class="heading-title pull-left">Perguntas Frequentes</h1>
            <div class="breadcrumbs pull-right">
                <ul class="breadcrumbs-list">
                    <li class="breadcrumbs-label">Você está em:</li>
                    <li><a class="baseQueryString" href="Default.aspx">Home</a><i class="fa fa-angle-right"></i></li>
                    <li class="current">Dúvidas</li>
                </ul>
            </div>
            <!--//breadcrumbs-->
        </header>
        <div class="page-content">
            <div class="row page-row">
                <div class="faq-wrapper col-md-8 col-sm-7">
                    <div class="panel-group" id="accordion">
                        <asp:Repeater ID="rptFaq" runat="server" OnItemDataBound="rptFaq_ItemDataBound">
                            <HeaderTemplate></HeaderTemplate>
                            <ItemTemplate>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <asp:HyperLink ID="hyCollapse" data-toggle="collapse" data-parent="#accordion" class="collapsed" runat="server"></asp:HyperLink>
                                        </h4>
                                    </div>
                                    <!--//pane-heading-->
                                    <asp:Panel ID="pnCollapse" CssClass="panel-collapse collapse" ClientIDMode="Static" runat="server">
                                        <div class="panel-body">
                                            <asp:Literal ID="ltAnswer" runat="server"></asp:Literal>                                      
                                        </div>
                                        <!--//panel-body-->
                                    </asp:Panel>
                                    <!--//panel-colapse-->
                                </div>
                                <!--//panel-->
                            </ItemTemplate>
                            <FooterTemplate></FooterTemplate>
                        </asp:Repeater>
                    </div>
                    <!--//panel-group-->
                </div>
                <aside class="page-sidebar  col-md-3 col-md-offset-1 col-sm-4 col-sm-offset-1">
                    <uc1:Contact ID="wucContact" runat="server" />
                </aside>
            </div>
        </div>
    </div>
    <!--//page-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    
</asp:Content>
