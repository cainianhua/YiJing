<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="Header.ascx.cs" Inherits="YiJingWebUI.UserControls.Header" %>
<%@ Register src="Search.ascx" tagname="Search" tagprefix="uc1" %>

<div id="header" class="clearfix">
	<div class="headerinner">
		<h2 class="logo">
			<a href="/" title="广州熠镜品牌策划">
				<asp:Image ID="imgTopLogo" runat="server" AlternateText="广州熠镜品牌策划" /></a></h2>
		<div class="navi">
			<ul class="clearfix">
			<asp:Repeater ID="rptNavigator" runat="server" onitemdatabound="rptNavigator_ItemDataBound">
				<ItemTemplate>
					<li>
						<h2><asp:HyperLink ID="lnkNavigator" runat="server"></asp:HyperLink></h2>
						<asp:Panel ID="pnlSubnav" runat="server" CssClass="subnav-bg">
							<div class="subnav clearfix">
								<dl>
								<asp:Repeater ID="rptSubNavigator" runat="server" OnItemDataBound="rptSubNavigator_ItemDataBound">
									<ItemTemplate>
										<dd><asp:HyperLink ID="lnkSubNavigator" runat="server"></asp:HyperLink></dd>
									</ItemTemplate>
								</asp:Repeater>
								<asp:Repeater ID="rptArticles" runat="server" OnItemDataBound="rptArticles_ItemDataBound">
									<ItemTemplate>
										<dd><asp:HyperLink ID="lnkArticle" runat="server"></asp:HyperLink></dd>
									</ItemTemplate>
								</asp:Repeater>
								</dl>
								<div class="subnav-cont">
									<h3><asp:Literal ID="Name" runat="server"></asp:Literal></h3>
									<p><asp:Literal ID="NameLocal" runat="server"></asp:Literal></p>
								</div>
							</div>
						</asp:Panel>
					</li>
				</ItemTemplate>
			</asp:Repeater>
			</ul>
		</div>
		<uc1:Search ID="Search1" runat="server" />
	</div>
</div>
<div class="blank_top"></div>
<script type="text/javascript">
	$('.navi li').hover(function () {
		$(this).toggleClass('selected');
	});
	// scroll to(滚动效果).
	$(".navi a[rel]").on("click", function (e) {
		e.preventDefault();

		var destination = $("a[name=" + $(this).attr("rel") + "]");
		if (destination.length > 0) {
			$("html, body").animate({
				scrollTop: (destination.offset().top - $(window).height() / 2 + (249 + 50 + 40/*未知*/) / 2) + "px"
			}, {
				duration: 500,
				easing: "swing"
			});
		}
		else {
			var li = $(this).parent().parent();
			window.location = li.find("div.subnav dd:eq(0) a").attr("href");
		}

		return false;
	});
</script>
