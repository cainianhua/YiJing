﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="YiJingWebUI.Services.Default" %>
<%@ Register src="~/UserControls/Footer2.ascx" tagname="Footer2" tagprefix="uc2" %>
<%@ Register src="~/UserControls/SideBar.ascx" tagname="SideBar" tagprefix="uc3" %>
<%@ Register src="~/UserControls/AboutDetail.ascx" tagname="AboutDetail" tagprefix="uc1" %>
<%@ Register src="~/UserControls/AboutHeader.ascx" tagname="AboutHeader" tagprefix="uc4" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderStyles" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeaderScripts" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Header" runat="server">
	<uc4:AboutHeader ID="AboutHeader1" Sort="Services" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
	<uc1:AboutDetail ID="AboutDetail1" Sort="Services" runat="server" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Footer" runat="server">
	<uc2:Footer2 ID="Footer21" runat="server" />
	<uc3:SideBar ID="SideBar1" runat="server" />
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="FooterScripts" runat="server">
	<script type="text/javascript" src="/scripts/modernizr.min.js"></script>
	<script type="text/javascript" src="/scripts/hammer/hammer.min.js"></script>
	<script type="text/javascript" src="/scripts/yijing/carousel.js"></script>
	<script type="text/javascript">
		var carousel = new Carousel("#carousel", {
			"containerSelector": ">div.articles",
			"panesSelector": ">div.articles>div",
			//"paneDataTemplate": '<div class="newsdetail-hd clearfix"><h2>{title}</h2><p>{tags}<span>{createddate}</span></p><div class="line"></div></div><!--bd--><div class="detail-bd"><div class="richcont">{content}</div></div>',
			"totalPane": totalCount,
			"currentPane": currentPageNo - 1,
			"currentCategoryId": currentCategoryId,
			"onShowed": function (pageIndex) {
				var pageNo = pageIndex + 1;
				if (currentPageNo != pageNo) {
					window.location = "/services/?pn=" + pageNo;
				}
			}
		});
		carousel.init();
	</script>
</asp:Content>
