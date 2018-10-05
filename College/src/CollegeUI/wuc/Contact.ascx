<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Contact.ascx.cs" Inherits="CollegeUI.wuc.Contact" %>
<section class="widget">
    <h3 class="title">Contato</h3>
    <p>
        Atendimento ao usuário
    </p>
    <asp:PlaceHolder ID="phTel" runat="server" Visible="false">
        <p class="tel">
            <i class="fa fa-phone"></i>Tel:
        <asp:Literal ID="ltTel" runat="server"></asp:Literal>
        </p>
    </asp:PlaceHolder>
    <p class="email">
        <i class="fa fa-envelope"></i>Email: <span class="text-primary">
            <asp:Literal ID="ltEmail" runat="server"></asp:Literal></span>
    </p>
</section>
