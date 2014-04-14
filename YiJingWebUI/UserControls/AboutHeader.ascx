<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AboutHeader.ascx.cs" Inherits="YiJingWebUI.UserControls.AboutHeader" %>

<div class="detail-topbar">
	<div class="detailtopbar-inner clearfix">
		<div class="topbar-t">
			<h2><strong><asp:Literal ID="Name" runat="server"></asp:Literal></strong>&nbsp;<asp:Literal ID="NameLocal" runat="server"></asp:Literal></h2>
		</div>
		<div class="back"><a href="/"><i class="icon icon-x"></i>返回</a></div>
	</div>
</div>