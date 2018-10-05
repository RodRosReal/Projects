<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Videos.ascx.cs" Inherits="CollegeUI.wuc.Videos" %>
<section class="video">
    <h1 class="section-heading text-highlight"><span class="line">Eventos</span></h1>
    <div class="carousel-controls">
        <a class="prev" href="#videos-carousel" data-slide="prev"><i class="fa fa-caret-left"></i></a>
        <a class="next" href="#videos-carousel" data-slide="next"><i class="fa fa-caret-right"></i></a>
    </div>
    <div class="section-content">
        <div id="videos-carousel" class="videos-carousel carousel slide">
            <div class="carousel-inner">
                <asp:Repeater ID="rptVideos" runat="server" OnItemDataBound="rptVideos_ItemDataBound">
                    <HeaderTemplate></HeaderTemplate>
                    <ItemTemplate>
                        <asp:Panel ID="pnVideo" runat="server">
                            <asp:Literal ID="ltVideo" runat="server"></asp:Literal>
                        </asp:Panel>
                    </ItemTemplate>
                    <FooterTemplate></FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</section>
