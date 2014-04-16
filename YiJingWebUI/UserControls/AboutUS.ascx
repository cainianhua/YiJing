<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="AboutUS.ascx.cs" Inherits="YiJingWebUI.UserControls.AboutUS" %>

<div class="hd clearfix">
	<h3><div style="display:none;">请删除div<asp:Literal ID="ltrName" runat="server"></asp:Literal>&nbsp;<span><asp:Literal ID="ltrNameLocal" runat="server"></asp:Literal></span></div><img src="/Content/images/title1.png" alt="" /></h3>
</div>
<div class="bd slider clearfix">
	<ul>
		<asp:Repeater ID="rptAboutUs" runat="server">
		<ItemTemplate>
		<li>
			<a target="_blank" href="/aboutus/?aid=<%#Eval("ArticleId") %>">
				<img src="<%#Eval("Thumbnail") %>" alt="<%#Eval("ArticleTitleLocal") %>" /></a>
		</li>
		</ItemTemplate>
		</asp:Repeater>
	</ul>
</div>