<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="YiJingWebUI.Search.Default" %>
<%@ Register src="~/UserControls/Header.ascx" tagname="Header" tagprefix="uc1" %>
<%@ Register src="~/UserControls/Footer2.ascx" tagname="Footer2" tagprefix="uc2" %>
<%@ Register src="~/UserControls/SideBar.ascx" tagname="SideBar" tagprefix="uc3" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderStyles" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeaderScripts" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Header" runat="server">
		<uc1:Header ID="Header1" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
	<!--search info-->
	<div class="search-info">
		<p>搜索关键字<strong>“<asp:Literal ID="SearchText" runat="server"></asp:Literal>”</strong>，一共有<strong><asp:Literal ID="TotalCount" runat="server"></asp:Literal></strong>个结果&nbsp;&nbsp;<span>可在下方选择分类</span></p>
	</div>
	<!--searchbox-->
	<div class="box-search">
		<div class="hd clearfix">
			<asp:Repeater ID="rptCategories" runat="server">
				<ItemTemplate>
					<asp:HyperLink ID="lnkCategory" runat="server"></asp:HyperLink>
				</ItemTemplate>
			</asp:Repeater>
		</div>
		<div class="bd clearfix">
			<div class="bd_l">
				<asp:HyperLink ID="lnkKeywords" runat="server"></asp:HyperLink>
			</div>
			<div class="bd_r">
				<ul>
					<asp:Repeater ID="rptResults" runat="server">
						<ItemTemplate>
						<li>
							<h3><a target="_blank" href="<%#this.GenerateArticleLink(Convert.ToInt32(Eval("ParentId")), Convert.ToInt32(Eval("ArticleId"))) %>"><%#Eval("ArticleTitleLocal") %></a></h3>
							<p class="meta"><%#this.GenerateKeywordsLink(Eval("Tags").ToString()) %><span style="padding-left:20px;"><%#Convert.ToDateTime(Eval("CreatedDate")).ToString("yyyy.MM.dd") %></span></p>
							<p class="desc"><%#Eval("Description") %></p>
						</li>
						</ItemTemplate>
					</asp:Repeater>
					<asp:PlaceHolder ID="phEmpty" runat="server" Visible="false">
						<li>
							没有搜索到相关数据
						</li>	
					</asp:PlaceHolder>
				</ul>
			</div>
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
			<div class="line">
			</div>
			<div class="back">
				<a href="/"><i class="icon icon-x"></i>返回</a></div>
		</div>
	</div>
	<!--news end--> 
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Footer" runat="server">
	<uc2:Footer2 ID="Footer21" runat="server" />
	<uc3:SideBar ID="SideBar1" runat="server" />
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="FooterScripts" runat="server">
	<script type="text/javascript">
		$('.navi li').hover(function () {
			$(this).toggleClass('selected');
		});

		$('.box-listcase .bd li').hover(function () {
			$(this).toggleClass('on');
		});
	</script>
</asp:Content>
