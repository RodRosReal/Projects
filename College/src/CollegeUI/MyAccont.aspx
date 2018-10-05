<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyAccont.aspx.cs" Inherits="CollegeUI.MyAccont" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">
        <header class="page-heading clearfix">
            <h1 class="heading-title pull-left">Meu Perfil</h1>
            <div class="breadcrumbs pull-right">
                <ul class="breadcrumbs-list">
                    <li class="breadcrumbs-label">Você está em:</li>
                    <li><a class="baseQueryString" href="Default.aspx">Home</a><i class="fa fa-angle-right"></i></li>
                    <li class="current">Meu Perfil</li>
                </ul>
            </div>
            <!--//breadcrumbs-->
        </header>
        <div class="page-content">
            <div class="row">
                <article class="contact-form col-md-12 col-sm-12  page-row">
                    <div class="alert"></div>
                    <article class="contact-form col-md-6 col-sm-6  page-row">
                        <div>
                            <div class="form-group name">
                                <label for="name" class="req">Nome<span class="required">*</span></label>
                                <asp:TextBox ID="name" CssClass="form-control" placeholder="Digite seu Nome" MaxLength="20" ClientIDMode="Static" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group name">
                                <label for="surname" class="req">Sobrenome<span class="required">*</span></label>
                                <asp:TextBox ID="surname" CssClass="form-control" placeholder="Digite seu Sobrenome" MaxLength="180" ClientIDMode="Static" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group name">
                                <label for="cpf" class="req">CPF<span class="required">*</span></label>
                                <asp:TextBox ID="cpf" CssClass="form-control cpf" placeholder="Digite seu CPF" MaxLength="14" ClientIDMode="Static" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group name">
                                <label for="email" class="req">Email<span class="required">*</span></label>
                                <asp:TextBox ID="email" CssClass="form-control" placeholder="Digite seu Email" MaxLength="200" ClientIDMode="Static" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </article>
                    <article class="contact-form col-md-6 col-sm-6  page-row">
                        <div>
                            <div class="form-group name">
                                <label for="tel">Telefone</label>
                                <asp:TextBox ID="tel" CssClass="form-control tel" placeholder="Digite seu Telefone" MaxLength="14" ClientIDMode="Static" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group name">
                                <label for="cel" class="req">Celular<span class="required">*</span></label>
                                <asp:TextBox ID="cel" CssClass="form-control cel" placeholder="Digite seu Celular" MaxLength="14" ClientIDMode="Static" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group name">
                                <label for="password" class="req">Senha<span class="required">*</span></label>
                                <asp:TextBox ID="password" CssClass="form-control" placeholder="Digite sua Senha" MaxLength="8" ClientIDMode="Static" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group name">
                                <label for="confirm" class="req">Confimação da Senha<span class="required">*</span></label>
                                <asp:TextBox ID="confirm" CssClass="form-control" placeholder="Confirme sua Senha" MaxLength="8" ClientIDMode="Static" runat="server"></asp:TextBox>
                            </div>
                            <asp:Button ID="btnMyAccont" ClientIDMode="Static" CssClass="btn btn-theme" runat="server" Text="Salvar" />
                        </div>
                    </article>
                    <!--//contact-form-->
                </article>
            </div>
            <!--//page-row-->
        </div>
        <!--//page-content-->
    </div>
    <!--//page-wrapper-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    <script type="text/javascript" src="assets/plugins/other/querystring-0.9.0.js"></script>
    <script type="text/javascript" src="assets/plugins/other/jquery.maskedinput.js"></script>
    <script type="text/javascript" src="assets/plugins/other/jquery.cpf-validate.1.0.min.js"></script>
    <script type="text/javascript" src="assets/js/myAccont.js"></script>
</asp:Content>
