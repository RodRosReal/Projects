<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CollegeUI.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">
        <header class="page-heading clearfix">
            <h1 class="heading-title pull-left">Login</h1>
            <div class="breadcrumbs pull-right">
                <ul class="breadcrumbs-list">
                    <li class="breadcrumbs-label">Você está em:</li>
                    <li><a class="baseQueryString" href="Default.aspx">Home</a><i class="fa fa-angle-right"></i></li>
                    <li class="current">Login</li>
                </ul>
            </div>
            <!--//breadcrumbs-->
        </header>
        <div class="page-content">
            <div class="row">
                <aside class="page-sidebar col-md-3 col-sm-4">
                    <section class="links">
                        <h3 class="title">Links Rápidos</h3>
                        <div class="section-content">
                            <p><a class="baseQueryString" href="Forgot.aspx"><i class="fa fa-caret-right"></i>Esqueci Minha Senha</a></p>
                            <p><a class="baseQueryString" href="MyAccont.aspx"><i class="fa fa-caret-right"></i>Cadastre-se</a></p>
                        </div>
                        <!--//section-content-->
                    </section>
                    <!--//links-->
                </aside>
                <!--//page-sidebar-->
                <article class="contact-form col-md-8 col-sm-7  page-row">
                    <div class="alert"></div>
                    <h3 class="title">Já é cadastrado?</h3>
                    <p>Se você já é cadastrado entre com seus dados de login.</p>
                    <div>
                        <div class="form-group email">
                            <label for="email" class="req">Email<span class="required">*</span></label>
                            <input id="email" type="email" class="form-control" placeholder="Digite seu Email"/>
                        </div>
                        <!--//form-group-->
                        <div class="form-group password">
                            <label for="password" class="req">Senha<span class="required">*</span></label>
                            <input id="password" type="password" class="form-control" placeholder="Digite sua Senha"/>
                        </div>
                        <!--//form-group-->
                        <asp:Button ID="btnLogin" ClientIDMode="Static" runat="server" CssClass="btn btn-theme" Text="Entrar" />
                    </div>
                </article>
                <!--//contact-form-->                
            </div>
            <!--//page-row-->
            <div class="page-row"></div>
        </div>
        <!--//page-content-->
    </div>
    <!--//page-wrapper-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    <script type="text/javascript" src="assets/plugins/other/querystring-0.9.0.js"></script>
    <script type="text/javascript" src="assets/js/login.js"></script>
</asp:Content>
