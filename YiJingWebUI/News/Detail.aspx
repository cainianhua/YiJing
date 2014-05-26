<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Content.Master" AutoEventWireup="false" CodeBehind="Detail.aspx.cs" Inherits="YiJingWebUI.News.Detail" %>
<%@ Register src="~/UserControls/Footer2.ascx" tagname="Footer2" tagprefix="uc2" %>
<%@ Register src="~/UserControls/ShareWidget.ascx" tagname="ShareWidget" tagprefix="uc1" %>
<%@ Register src="~/UserControls/ArticleMetas.ascx" tagname="ArticleMetas" tagprefix="uc5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Metas" runat="server">
	<uc5:ArticleMetas ID="ArticleMetas1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderStyles" runat="server">
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

<asp:Content ID="Content6" ContentPlaceHolderID="Footer" runat="server">
	<uc2:Footer2 ID="Footer21" runat="server" />
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="FooterScripts" runat="server">
	<script type="text/javascript">
		var carousel = new Carousel("#container", {
			"totalPane": totalCount,
			"currPaneIndex": currentPageNo - 1, // base on 0;
			"currSort": currentSort,
			"onPageIndexChanged": function (pageIndex, item) {
				var pageNo = pageIndex + 1;

				if (Modernizr.history) {
					document.title = item.title;
					document.getElementsByName("keywords")[0].content = item.keywords;
					document.getElementsByName("description")[0].content = item.description;

					$(".detail-topbar .prev").attr("href", "/news/detail.aspx?pn=" + Math.max(1, pageNo - 1));
					$(".detail-topbar .next").attr("href", "/news/detail.aspx?pn=" + Math.min(totalCount, pageNo + 1));
					$(".detail-topbar .prv-next span").html(pageNo + "/" + totalCount);

					window.history.pushState(null, item.title, "/news/detail.aspx?pn=" + pageNo);
				}
				else {
					window.location = "/news/detail.aspx?pn=" + pageNo
				}
			}
		});
		carousel.init();
		// if browser is not support history management, we will refresh page to load article.
		if (Modernizr.history) {
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
		}
	</script>
</asp:Content>
