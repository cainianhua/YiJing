<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="Services.ascx.cs" Inherits="YiJingWebUI.UserControls.Services" %>

<div class="hd clearfix">
	<h3><div style="display:none;">请删除div<asp:Literal ID="ltrName" runat="server"></asp:Literal>&nbsp;<span><asp:Literal ID="ltrNameLocal" runat="server"></asp:Literal></span></div><img src="/Content/images/title2.png" alt="" /></h3>
</div>
<div class="bd clearfix">
	<div class="tabtitle">
		<ul>
			<asp:Repeater ID="rptArticles" runat="server">
				<ItemTemplate>
				<li><%#Eval("ArticleTitleLocal") %><i></i></li>
				</ItemTemplate>
			</asp:Repeater>
		</ul>
	</div>
	<div class="tabcont">
		<ul>
			<asp:Repeater ID="rptArticles2" runat="server">
			<ItemTemplate>
			<li>
				<a target="_blank" href="/services/?aid=<%#Eval("ArticleId") %>">
					<img src="<%#Eval("Thumbnail") %>" alt="<%#Eval("ArticleTitleLocal") %>" /></a>
			</li>
			</ItemTemplate>
			</asp:Repeater>
		</ul>
	</div>
</div>