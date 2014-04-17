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
									<dd><asp:HyperLink ID="lnkSubNavigator" Target="_blank" runat="server"></asp:HyperLink></dd>
								</ItemTemplate>
							</asp:Repeater>
							<asp:Repeater ID="rptArticles" runat="server" OnItemDataBound="rptArticles_ItemDataBound">
								<ItemTemplate>
									<dd><asp:HyperLink ID="lnkArticle" Target="_blank" runat="server"></asp:HyperLink></dd>
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
		<%--
		<ul class="clearfix">
			<li><h2><a href="#">首页</a></h2></li>
			<li>
				<h2><a href="#">关于熠镜</a></h2>
				<div class="subnav-bg">
					<div class="subnav clearfix">
						<dl>
							<dd><a href="#">公司新闻</a></dd>
							<dd><a href="#">行业新闻</a></dd>
							<dd><a href="#">资讯分享</a></dd>
						</dl>
						<div class="subnav-cont">
							<h3>NEWS&INFORMATION</h3>
							<p>新闻资讯</p>
						</div>
					</div>
				</div>
			</li>
			<li>
				<h2><a href="#">新闻资讯</a></h2>
				<div class="subnav-bg">
					<div class="subnav clearfix">
						<dl>
							<dd><a href="#">公司新闻</a></dd>
							<dd><a href="#">行业新闻</a></dd>
							<dd><a href="#">资讯分享</a></dd>
						</dl>
						<div class="subnav-cont">
							<h3>NEWS&INFORMATION</h3>
							<p>新闻资讯</p>
						</div>
					</div>
				</div>
			</li>
			<li>
				<h2><a href="#">案例展示</a></h2>
				<div class="subnav-bg">
					<div class="subnav clearfix">
						<dl>
							<dd><a href="#">品牌全案</a></dd>
							<dd><a href="#">互动营销</a></dd>
							<dd><a href="#">口碑营销</a></dd>
							<dd><a href="#">媒体合作</a></dd>
							<dd><a href="#">影视策划</a></dd>
						</dl>
						<div class="subnav-cont">
							<h3>SHOW CASE</h3>
							<p>案例展示</p>
						</div>
					</div>
				</div>
			</li>
			<li>
				<h2><a href="#">熠镜服务</a></h2>
				<div class="subnav-bg">
					<div class="subnav clearfix">
						<dl>
							<dd><a href="#">品牌全案</a></dd>
							<dd><a href="#">互动营销</a></dd>
							<dd><a href="#">口碑营销</a></dd>
							<dd><a href="#">媒体合作</a></dd>
							<dd><a href="#">影视策划</a></dd>
							<dd><a href="#">影视策划</a></dd>
							<dd><a href="#">影视策划</a></dd>
						</dl>
						<div class="subnav-cont">
							<h3>SERVICES</h3>
							<p>熠镜服务</p>
						</div>
					</div>
				</div>
			</li>
			<li>
				<h2><a href="#">联系我们</a></h2>
			</li>
		</ul>--%>
	</div>
	<uc1:Search ID="Search1" runat="server" />
</div>
</div>
<div class="blank_top"></div>
<script type="text/javascript" src="/scripts/slideto/js/jquery.slideto.min.js"></script>
<script type="text/javascript">
	$('.navi li').hover(function () {
		$(this).toggleClass('selected');
	});
	// scroll to(滚动效果).
	$(".navi a[rel]").on("click", function (e) {
		e.preventDefault();

		var objslideto = $("a[name=" + $(this).attr("rel") + "]");
		if (objslideto.length > 0) {
			//objslideto.slideto({ highlight: false, slide_duration: 'slow' });
			objslideto.slideto({ offset: (249 + 50 + 120) / 2 - $(window).height() / 2 });
		}
		else {
			var li = $(this).parent().parent();
			window.location = li.find("div.subnav dd:eq(0) a").attr("href");
		}

		return false;
	});
</script>



