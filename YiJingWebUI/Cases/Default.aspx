<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="false" CodeBehind="Default.aspx.cs" Inherits="YiJingWebUI.Cases.Default" %>
<%@ Register src="~/UserControls/Header.ascx" tagname="Header" tagprefix="uc1" %>
<%@ Register src="~/UserControls/Footer.ascx" tagname="Footer" tagprefix="uc2" %>
<%@ Register src="~/UserControls/SideBar.ascx" tagname="SideBar" tagprefix="uc3" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="server">
	<div id="header" class="clearfix">
		<uc1:Header ID="Header1" runat="server" />
	</div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
	<!--newsbanner-->
	<div class="casebanner"></div>
	<!--newsbanner end-->
	<!--news-->
	<div class="box box-listcase"">
		<div class="hd clearfix">
			<asp:Repeater ID="rptCategories" runat="server">
				<ItemTemplate>
					<asp:HyperLink ID="lnkCategory" runat="server"></asp:HyperLink>
				</ItemTemplate>
			</asp:Repeater>
		</div>
		<div class="bd clearfix">
			<ul>
				<asp:Repeater ID="rptArticles" runat="server">
					<ItemTemplate>
					<li>
						<a target="_blank" title="<%#Eval("ArticleTitleLocal") %>" href="/cases/detail.aspx?aid=<%#Eval("ArticleId")%>">
							<img alt="<%#Eval("ArticleTitleLocal") %>" src="<%#Eval("Thumbnail")%>" /></a>
						<p>
							<a target="_blank" title="<%#Eval("ArticleTitleLocal")%>" href="/cases/detail.aspx?aid=<%#Eval("ArticleId")%>"><%#Eval("Description")%></a></p>
					</li>
					</ItemTemplate>
				</asp:Repeater>
			</ul>
		</div>
		<div class="ft">
			<webdiyer:aspnetpager id="AspNetPager1" runat="server"
					CssClass="pager" 
					ImagePath="/content/pager"
					PagingButtonSpacing="0px" 
					showcustominfosection="Never" 
					urlpaging="True" 
					CurrentPageButtonClass="current" 
					ShowFirstLast="false" 
					PrevNextButtonsClass="previouslink" 
					CurrentPageButtonPosition="Center"
					PagingButtonType="Text" 
					NumericButtonType="Text" 
					NavigationButtonType="Image"
					ButtonImageExtension="png" 
					ShowDisabledButtons="false"
					ShowNavigationToolTip="true" 
					UrlPageIndexName="pn"
					ShowPageIndexBox="Never" 
					NumericButtonCount="7"></webdiyer:aspnetpager>
			<div class="line"></div>
			<div class="back">
				<a href="javascript:history.go(-1);"><i class="icon icon-x"></i>返回</a></div>
		</div>
	</div>
	<!--news end-->
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="Footer" runat="server">
	<uc2:Footer ID="Footer21" runat="server" />
	<uc3:SideBar ID="SideBar1" runat="server" />
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="FooterScripts" runat="server">
	<script type="text/javascript" src="/scripts/waterfall.js"></script>
	<script type="text/javascript">
		//案例列表hover效果
		$('.box-listcase .bd li').hover(function () {
			$(this).toggleClass('on');
		});
		//瀑布流
		var myWaterfall = new Waterfall();
		myWaterfall.setting.cellSelector = '.box-listnews .bd li';
		myWaterfall.setting.container = '.box-listnews .bd ul';
		myWaterfall.setting.columnWidth = 300;
		myWaterfall.setting.columnNum = 4;
		myWaterfall.init();
	</script>
</asp:Content>