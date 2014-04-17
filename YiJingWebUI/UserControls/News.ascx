<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="News.ascx.cs" Inherits="YiJingWebUI.UserControls.News" %>

<div class="hd clearfix">
    <h3><asp:Image ID="CategoryLogo" runat="server" /></h3>
</div>
<div class="bd clearfix">
	<ul>
		<asp:Repeater ID="rptNews" runat="server">
			<ItemTemplate>
			<li>
				<a title="<%#Eval("ArticleTitleLocal") %>" href="/news/detail.aspx?aid=<%#Eval("ArticleId") %>"><img alt="<%#Eval("ArticleTitleLocal") %>" src="<%#Eval("Thumbnail") %>" /></a>
				<h3><a title="<%#Eval("ArticleTitleLocal") %>" href="/news/detail.aspx?aid=<%#Eval("ArticleId") %>"><%#Eval("ArticleTitleLocal") %></a></h3>
				<p><a title="<%#Eval("ArticleTitleLocal") %>" href="/news/detail.aspx?aid=<%#Eval("ArticleId") %>"><%#Eval("Description") %></a></p>
			</li>
			</ItemTemplate>
		</asp:Repeater>
	</ul>
</div>
<div class="ft">
	<div class="more">
		<a href="/news/">
			<img alt="更多新闻..." src="/content/images/index_41.png" /></a></div>
	<div class="line">
	</div>
</div>