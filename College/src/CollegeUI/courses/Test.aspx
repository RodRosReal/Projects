<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="CollegeUI.courses.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <!-- Meta -->
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="author" content="" />
    <link rel="stylesheet" href="../assets/css/openSans.css" />
    <link rel="stylesheet" href="../assets/plugins/bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../assets/plugins/font-awesome/css/font-awesome.css" />
    <link rel="stylesheet" href="../assets/plugins/flexslider/flexslider.css" />
    <link rel="stylesheet" href="../assets/plugins/pretty-photo/css/prettyPhoto.css" />
    <link rel="stylesheet" href="../assets/plugins/countdown/countdown.css" />
    <link rel="stylesheet" href="../assets/css/styles-purple.css" />
    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script type="text/javascript" src="../assets/js/html5shiv.js"></script>
      <script type="text/javascript" src="../assets/js/respond.min.js"></script>
    <![endif]-->
    <script type="text/javascript" src="../assets/plugins/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../assets/plugins/other/querystring-0.9.0.js"></script>
</head>
<body style="margin: 0px;">
    <form id="form1" runat="server">
        <div class="wrapper">
            <div class="content container">
                <div class="page-wrapper">
                    <div class="page-content">
                        <br />
                        <br />
                        <h3 class="title">Prova</h3>
                        <div id="countdown">
                            <asp:Panel ID="countdown_dashboard" ClientIDMode="Static" runat="server">
                                <div class="dash hours_dash">
                                    <div class="digit">0</div>
                                    <div class="digit">0</div>
                                </div>
                                <div class="dash minutes_dash">
                                    <div class="digit">0</div>
                                    <div class="digit">0</div>
                                </div>
                                <div class="dash seconds_dash">
                                    <div class="digit">0</div>
                                    <div class="digit">0</div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlCreateNewTest" ClientIDMode="Static" runat="server" Visible="false">
                                <asp:Button ID="btnCreateNewTest" runat="server" CssClass="btn btn-theme" Text="Fazer Prova Novamente" OnClick="btnCreateNewTest_Click" />
                            </asp:Panel>
                        </div>
                        <asp:Panel ID="pnMsg" ClientIDMode="Static" CssClass="alert" runat="server" Visible="false"></asp:Panel>
                        <asp:HiddenField ID="hddStatus" ClientIDMode="Static" runat="server" />
                        <asp:HiddenField ID="hddInitDate" ClientIDMode="Static" runat="server" />
                        <asp:HiddenField ID="hddDay" ClientIDMode="Static" runat="server" />
                        <asp:HiddenField ID="hddMonth" ClientIDMode="Static" runat="server" />
                        <asp:HiddenField ID="hddYear" ClientIDMode="Static" runat="server" />
                        <asp:HiddenField ID="hddHour" ClientIDMode="Static" runat="server" />
                        <asp:HiddenField ID="hddMin" ClientIDMode="Static" runat="server" />
                        <asp:HiddenField ID="hddSec" ClientIDMode="Static" runat="server" />
                        <asp:Repeater ID="rptTest" runat="server" OnItemDataBound="rptTest_ItemDataBound" OnItemCommand="rptTest_ItemCommand">
                            <HeaderTemplate></HeaderTemplate>
                            <ItemTemplate>
                                <div class="row">
                                    <article class="contact-form col-md-12 col-sm-12  page-row">
                                        <div>
                                            <p>
                                                <asp:Literal ID="ltTest" runat="server"></asp:Literal>
                                            </p>
                                            <div class="form-group message">
                                                <label>Resposta</label>
                                                <asp:TextBox ID="txReply" CssClass="form-control" Rows="6" TextMode="MultiLine" placeholder="Digite sua Resposta..." runat="server"></asp:TextBox>
                                            </div>
                                            <asp:PlaceHolder ID="phCorrection" runat="server">
                                                <div class="form-group message">
                                                    <label>Correção</label>
                                                    <asp:TextBox ID="txCorrection" CssClass="form-control" Rows="6" TextMode="MultiLine" placeholder="Digite sua Resposta..." runat="server"></asp:TextBox>
                                                </div>
                                            </asp:PlaceHolder>
                                            <asp:Button ID="btnSave" CssClass="btn btn-theme" runat="server" Text="Salvar" CommandName="save" />
                                        </div>
                                    </article>
                                </div>
                            </ItemTemplate>
                            <FooterTemplate></FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>

    </form>
    <script type="text/javascript" src="../assets/plugins/jquery-migrate-1.2.1.min.js"></script>
    <script type="text/javascript" src="../assets/plugins/bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../assets/plugins/bootstrap-hover-dropdown.min.js"></script>
    <script type="text/javascript" src="../assets/plugins/back-to-top.js"></script>
    <script type="text/javascript" src="../assets/plugins/jquery-placeholder/jquery.placeholder.js"></script>
    <script type="text/javascript" src="../assets/plugins/pretty-photo/js/jquery.prettyPhoto.js"></script>
    <script type="text/javascript" src="../assets/plugins/flexslider/jquery.flexslider-min.js"></script>
    <script type="text/javascript" src="../assets/plugins/jflickrfeed/jflickrfeed.min.js"></script>
    <script type="text/javascript" src="../assets/plugins/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../assets/plugins/countdown/jquery.lwtCountdown-1.0.js"></script>
    <script type="text/javascript" src="../assets/js/test.js"></script>
</body>
</html>
