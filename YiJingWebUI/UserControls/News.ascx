<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="News.ascx.cs" Inherits="YiJingWebUI.UserControls.News" %>

<div class="hd clearfix">
    <h3><div style="display:none;">请删除div<asp:Literal ID="ltrName" runat="server"></asp:Literal>&nbsp;<span><asp:Literal ID="ltrNameLocal" runat="server"></asp:Literal></span></div><img src="/Content/images/title3.png" alt="" /></h3>
</div>
<div class="bd clearfix">
	<ul>
		<asp:Repeater ID="rptNews" runat="server">
			<ItemTemplate>
			<li>
				<a target="_blank" title="<%#Eval("ArticleTitleLocal") %>" href="/news/detail.aspx?aid=<%#Eval("ArticleId") %>"><img alt="<%#Eval("ArticleTitleLocal") %>" src="<%#Eval("Thumbnail") %>" /></a>
				<h3><a target="_blank" title="<%#Eval("ArticleTitleLocal") %>" href="/news/detail.aspx?aid=<%#Eval("ArticleId") %>"><%#Eval("ArticleTitleLocal") %></a></h3>
				<p><a target="_blank" title="<%#Eval("ArticleTitleLocal") %>" href="/news/detail.aspx?aid=<%#Eval("ArticleId") %>"><%#Eval("Description") %></a></p>
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