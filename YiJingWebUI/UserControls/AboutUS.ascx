<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="AboutUS.ascx.cs" Inherits="YiJingWebUI.UserControls.AboutUS" %>

<div class="hd clearfix">
	<h3><asp:Literal ID="ltrName" runat="server"></asp:Literal>&nbsp;<span><asp:Literal ID="ltrNameLocal" runat="server"></asp:Literal></span></h3>
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