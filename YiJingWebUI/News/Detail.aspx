<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="false" CodeBehind="Detail.aspx.cs" Inherits="YiJingWebUI.News.Detail" %>
<%@ Register src="~/UserControls/Footer2.ascx" tagname="Footer2" tagprefix="uc2" %>
<%@ Register src="~/UserControls/ShareWidget.ascx" tagname="ShareWidget" tagprefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderStyles" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeaderScripts" runat="server">
	<script type="text/javascript" src="/scripts/move/js/jquery.event.move.js"></script>
	<script type="text/javascript" src="/scripts/swipe/js/jquery.event.swipe.js"></script>
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
		<div class="sharebox"><uc1:ShareWidget ID="ShareWidget1" runat="server" /></div>
		<div class="line">
		</div>
		<div class="back">
			<a href="/news/"><i class="icon icon-x"></i>返回</a></div>
	</div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Footer" runat="server">
	<uc2:Footer2 ID="Footer21" runat="server" />
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="FooterScripts" runat="server">
	<script type="text/javascript">
		


		jQuery(function ($) {
			var slides = jQuery('body')

			slides.on('swipeleft', function (e) {
				console.log("swipeleft");
				//$("a[id$=lnkNext]").trigger("click");
				window.location = $("a[id$=lnkNext]").attr("href");
			}).on('swiperight', function (e) {
				console.log("swiperight");
				//$("a[id$=lnkPrevious]").trigger("click");
				window.location = $("a[id$=lnkPrevious]").attr("href");
			});
		});
	</script>
</asp:Content>
