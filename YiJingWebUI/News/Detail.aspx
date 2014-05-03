﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Content.Master" AutoEventWireup="false" CodeBehind="Detail.aspx.cs" Inherits="YiJingWebUI.News.Detail" %>
<%@ Register src="~/UserControls/Footer2.ascx" tagname="Footer2" tagprefix="uc2" %>
<%@ Register src="~/UserControls/ShareWidget.ascx" tagname="ShareWidget" tagprefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderStyles" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeaderScripts" runat="server">
	<script type="text/javascript" src="/scripts/modernizr.min.js"></script>
	<script type="text/javascript" src="/scripts/hammer/hammer.min.js"></script>
	<script type="text/javascript" src="/scripts/yijing/carousel.js"></script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Header" runat="server">
	<div class="detail-topbar">
		<div class="detailtopbar-inner clearfix">
			<div class="prv-next">
				<asp:HyperLink ID="lnkPrevious" CssClass="prev" runat="server">上一页</asp:HyperLink>
				<span><asp:Literal ID="ltrCurrPageIndex" runat="server"></asp:Literal>/<asp:Literal ID="ltrTotalCount" runat="server"></asp:Literal></span>
				<asp:HyperLink ID="lnkNext" CssClass="next" runat="server">下一页</asp:HyperLink>
			</div>
			<div class="back">
				<a href="/news/"><i class="icon icon-x"></i>返回</a></div>
		</div>
	</div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
	<div class="maincontent">
		<div class="newsdetail-hd clearfix">
			<h2>
				<asp:Literal ID="ArticleTitle" runat="server"></asp:Literal></h2>
			<p>
				<asp:Repeater ID="rptTags" runat="server">
					<ItemTemplate>
						<asp:HyperLink ID="lnkTag" runat="server"></asp:HyperLink>
					</ItemTemplate>
				</asp:Repeater>
				<span><asp:Literal ID="CreatedDate" runat="server"></asp:Literal></span></p>
			<div class="line">
			</div>
		</div>
		<!--bd-->
		<div class="detail-bd">
			<div class="richcont">
				<asp:Literal ID="HtmlContent" runat="server"></asp:Literal>
			</div>
		</div>
		<!--bd end-->
		<div class="detail-ft">
			<div class="sharebox"></div>
			<div class="line">
			</div>
			<div class="back">
				<a href="/news/"><i class="icon icon-x"></i>返回</a></div>
		</div>
	</div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Footer" runat="server">
	<uc2:Footer2 ID="Footer21" runat="server" />
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="FooterScripts" runat="server">
	<script type="text/javascript">
		var carousel = new Carousel("#container", {
			"totalPane": totalCount,
			"currentPane": currentPageNo - 1,
			"currentCategoryId": currentCategoryId,
			"onShowed": function (pageIndex) {
				var pageNo = pageIndex + 1;

				if (currentPageNo != pageNo) {
					window.location = "/news/detail.aspx?pn=" + pageNo;
				}
				/*
				$(".detail-topbar .prev").attr("href", "/news/detail.aspx?pn=" + Math.max(1, pageNo - 1));
				$(".detail-topbar .next").attr("href", "/news/detail.aspx?pn=" + Math.min(totalCount, pageNo + 1));
				$(".detail-topbar .prv-next span").html(pageNo + "/" + totalCount);
				window.history.pushState(null, null, "/news/detail.aspx?pn=" + pageNo); 
				*/
			}
		});
		carousel.init();
	</script>
</asp:Content>
