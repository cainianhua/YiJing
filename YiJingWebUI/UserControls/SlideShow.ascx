<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SlideShow.ascx.cs" Inherits="YiJingWebUI.UserControls.SlideShow" %>

<ul>
	<asp:Repeater ID="Repeater1" runat="server">
	<ItemTemplate>
		<li><a href="<%#Eval("LinkTo") %>" target="_blank">
			<img alt="<%#Eval("Description") %>" src="<%#Eval("Pic") %>"></a></li>
	</ItemTemplate>
	</asp:Repeater>
</ul>