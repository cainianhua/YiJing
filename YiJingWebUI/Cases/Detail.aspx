<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Content.Master" AutoEventWireup="false" CodeBehind="Detail.aspx.cs" Inherits="YiJingWebUI.Cases.Detail" %>
<%@ Register src="~/UserControls/ShareWidget.ascx" tagname="ShareWidget" tagprefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderStyles" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeaderScripts" runat="server">
	<script type="text/javascript" src="/scripts/modernizr.min.js"></script>
	<script type="text/javascript" src="/scripts/hammer/hammer.min.js"></script>
	<script type="text/javascript" src="/scripts/yijing/carousel_ajax.js"></script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Header" runat="server">
	<div class="detail-topbar">
		<div class="detailtopbar-inner clearfix">
			<div class="prv-next">
				<asp:HyperLink ID="lnkPrevious" CssClass="prev" runat="server">上一页</asp:HyperLink>
				<span><asp:Literal ID="ltrCurrPageIndex" runat="server"></asp:Literal>/<asp:Literal ID="ltrTotalCount" runat="server"></asp:Literal></span>
				<asp:HyperLink ID="lnkNext" CssClass="next" runat="server">下一页</asp:HyperLink>
			</div>
			<div class="back"><a href="/cases/"><i class="icon icon-x"></i>返回</a></div>
		</div>
	</div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
	<asp:PlaceHolder ID="Containers" runat="server"></asp:PlaceHolder>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="FooterScripts" runat="server">
	<script type="text/javascript">
		//var carousel = new Carousel("#container", {
		//	"totalPane": totalCount,
		//	"currentPane": currentPageNo - 1,
		//	"currentCategoryId": currentCategoryId,
		//	"onShowed": function (pageIndex) {
		//		var pageNo = pageIndex + 1;
		//		if (currentPageNo != pageNo) {
		//			window.location = "/cases/detail.aspx?pn=" + pageNo;
		//		}
		//	}
		//});
		var carousel = new Carousel("#container", {
			"totalPane": totalCount,
			"currentPane": currentPageNo - 1,
			"currentCategoryId": currentCategoryId,
			"onShowed": function (pageIndex) {
				var pageNo = pageIndex + 1;
				$(".detail-topbar .prev").attr("href", "/cases/detail.aspx?pn=" + Math.max(1, pageNo - 1));
				$(".detail-topbar .next").attr("href", "/cases/detail.aspx?pn=" + Math.min(totalCount, pageNo + 1));
				$(".detail-topbar .prv-next span").html(pageNo + "/" + totalCount);
				window.history.pushState(null, null, "/cases/detail.aspx?pn=" + pageNo);
			}
		});
		carousel.init();
		$(".detail-topbar .prev").on("click", function (e) {
			e.preventDefault();
			carousel.prev();
			return false;
		});
		$(".detail-topbar .next").on("click", function (e) {
			e.preventDefault();
			carousel.next();
			return false;
		});
	</script>
</asp:Content>
