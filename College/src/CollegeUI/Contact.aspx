<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="CollegeUI.Contact" %>

<%@ Register src="wuc/Contact.ascx" tagname="Contact" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">
        <header class="page-heading clearfix">
            <h1 class="heading-title pull-left">Contato</h1>
            <div class="breadcrumbs pull-right">
                <ul class="breadcrumbs-list">
                    <li class="breadcrumbs-label">Você está em:</li>
                    <li><a class="baseQueryString" href="Default.aspx">Home</a><i class="fa fa-angle-right"></i></li>
                    <li class="current">Contato</li>
                </ul>
            </div>
            <!--//breadcrumbs-->
        </header>
        <div class="page-content">
            <div class="row">
                <article class="contact-form col-md-8 col-sm-7  page-row">
                    <div class="alert"></div>
                    <h3 class="title">Ajuda & Suporte</h3>
                    <div>
                        <div class="form-group name">
                            <label for="name" class="req">Nome<span class="required">*</span></label>
                            <input id="name" type="text" class="form-control" placeholder="Digite seu Nome"/>
                        </div>
                        <div class="form-group email">
                            <label for="email" class="req">Email<span class="required">*</span></label>
                            <input id="email" type="email" class="form-control" placeholder="Digite seu Email"/>
                        </div>
                        <div class="form-group message">
                            <label for="message" class="req">Mensagem<span class="required">*</span></label>
                            <textarea id="message" class="form-control" rows="6" placeholder="Digite sua Mensagem..."></textarea>
                        </div>
                        <button id="btnSend" type="button" class="btn btn-theme">Enviar</button>
                    </div>
                </article>
                <aside class="page-sidebar  col-md-3 col-md-offset-1 col-sm-4 col-sm-offset-1">
                    <uc1:Contact ID="wucContact" runat="server" />
                </aside>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    <script type="text/javascript" src="assets/plugins/other/querystring-0.9.0.js"></script>
    <script type="text/javascript" src="assets/js/contact.js"></script>
</asp:Content>
