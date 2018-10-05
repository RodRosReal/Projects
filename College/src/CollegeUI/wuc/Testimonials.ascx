<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Testimonials.ascx.cs" Inherits="CollegeUI.wuc.Testimonials" %>
<section class="testimonials">
    <h1 class="section-heading text-highlight"><span class="line">Testemunhos</span></h1>
    <div class="carousel-controls">
        <a class="prev" href="#testimonials-carousel" data-slide="prev"><i class="fa fa-caret-left"></i></a>
        <a class="next" href="#testimonials-carousel" data-slide="next"><i class="fa fa-caret-right"></i></a>
    </div>
    <div class="section-content">
        <div id="testimonials-carousel" class="testimonials-carousel carousel slide">
            <div class="carousel-inner">
                <asp:Repeater ID="rptTestimonial" runat="server" OnItemDataBound="rptTestimonial_ItemDataBound">
                    <HeaderTemplate></HeaderTemplate>
                    <ItemTemplate>
                        <asp:Panel ID="pnTestimonial" runat="server">
                            <blockquote class="quote">
                                <p><i class="fa fa-quote-left"></i><asp:Literal ID="ltTestimonial" runat="server"></asp:Literal></p>
                            </blockquote>
                            <div class="row">
                                <p class="people col-md-8 col-sm-3 col-xs-8">
                                    <span class="name"><asp:Literal ID="ltTestimonialName" runat="server"></asp:Literal></span><br />
                                    <span class="title"><asp:Literal ID="ltTestimonialLocal" runat="server"></asp:Literal></span>
                                </p>
                                <asp:Image CssClass="profile col-md-4 pull-right" ID="imgTestimonial" runat="server" />
                            </div>
                        </asp:Panel>
                    </ItemTemplate>
                    <FooterTemplate></FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</section>
