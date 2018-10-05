<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Events.ascx.cs" Inherits="CollegeUI.wuc.Events" %>
<section class="events">
    <h1 class="section-heading text-highlight"><span class="line">Eventos</span></h1>
    <div class="section-content">
        <asp:Repeater ID="rptEvents" runat="server" OnItemDataBound="rptEvents_ItemDataBound">
            <HeaderTemplate></HeaderTemplate>
            <ItemTemplate>
                <div class="event-item">
                    <p class="date-label">
                        <span class="month">
                            <asp:Literal ID="ltMonth" runat="server"></asp:Literal></span>
                        <span class="date-number">
                            <asp:Literal ID="ltDay" runat="server"></asp:Literal></span>
                    </p>
                    <div class="details">
                        <h2 class="title">
                            <asp:Literal ID="ltEvent" runat="server"></asp:Literal></h2>
                        <p class="time"><i class="fa fa-clock-o"></i>
                            <asp:Literal ID="ltHour" runat="server"></asp:Literal></p>
                        <p class="location"><i class="fa fa-map-marker"></i>
                            <asp:HyperLink ID="hyEvent" runat="server" Target="_blank"></asp:HyperLink></p>
                    </div>
                </div>
            </ItemTemplate>
            <FooterTemplate></FooterTemplate>
        </asp:Repeater>
        <a class="baseQueryString read-more" href="Events.aspx">Ver Todos<i class="fa fa-chevron-right"></i></a>
    </div>
</section>
