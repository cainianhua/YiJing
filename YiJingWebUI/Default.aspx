<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Site.Master" CodeBehind="Default.aspx.cs" Inherits="YiJingWebUI._Default" %>
<%@ Register src="UserControls/Header.ascx" tagname="Header" tagprefix="uc1" %>
<%@ Register src="UserControls/SlideShow.ascx" tagname="SlideShow" tagprefix="uc2" %>
<%@ Register src="UserControls/AboutUS.ascx" tagname="AboutUS" tagprefix="uc3" %>
<%@ Register src="UserControls/Services.ascx" tagname="Services" tagprefix="uc4" %>
<%@ Register src="UserControls/News.ascx" tagname="News" tagprefix="uc5" %>
<%@ Register src="UserControls/SideBar.ascx" tagname="SideBar" tagprefix="uc6" %>
<%@ Register src="UserControls/Footer.ascx" tagname="Footer" tagprefix="uc7" %>

<asp:Content ContentPlaceHolderID="Header" runat="server">
		<uc1:Header ID="Header1" runat="server" />
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">	
	<!--slideshow-->
	<div class="slideshow slider">
		<uc2:SlideShow ID="SlideShow1" runat="server" />
	</div>
	<!--slideshow end-->
	<!--about us-->
	<a name="aboutus"></a>
	<a name="services"></a>
	<div class="box box-indexaboutus">
		<uc3:AboutUS ID="AboutUS1" runat="server" />
	</div>
	<!--about us end-->
	<!--services-->
	<div class="box box-indexservices">
		<uc4:Services ID="Services1" runat="server" />
	</div>
	<!--services end-->
	<!--news-->
	<div class="box box-indexnews">
		<uc5:News ID="News1" runat="server" />
	</div>
	<!--news end-->
</asp:Content>

<asp:Content ContentPlaceHolderID="Footer" runat="server">
	<uc7:Footer ID="Footer1" runat="server" />
	<uc6:SideBar ID="SideBar1" runat="server" />
</asp:Content>

<asp:Content ContentPlaceHolderID="FooterScripts" runat="server">
	<script type="text/javascript" src="/scripts/waterfall.js"></script>
	<script type="text/javascript" src="/scripts/slide.js"></script>
	<script type="text/javascript" src="/scripts/yijing/index.js"></script>
</asp:Content>
