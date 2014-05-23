<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsDetail.ascx.cs" Inherits="YiJingWebUI.UserControls.NewsDetail" %>
<%@ Register src="~/UserControls/ShareWidget.ascx" tagname="ShareWidget" tagprefix="uc1" %>

<div class="maincontent">
	<!--<asp:Literal ID="TitleColor" runat="server"></asp:Literal>-->
	<div class="newsdetail-hd clearfix">
		<h2 style="color:#<%=TitleColor.Text%>">
			<asp:Literal ID="ArticleTitle" runat="server"></asp:Literal></h2>
		<p>
			<asp:Repeater ID="rptTags" runat="server">
				<ItemTemplate>
					<asp:HyperLink ID="lnkTag" runat="server"></asp:HyperLink>
				</ItemTemplate>
			</asp:Repeater>
			<span><asp:Literal ID="CreatedDate" runat="server"></asp:Literal></span></p>
		<div class="line">
		</div>
	</div>
	<!--bd-->
	<div class="detail-bd">
		<div class="richcont">
			<asp:Literal ID="HtmlContent" runat="server"></asp:Literal>
		</div>
	</div>
	<!--bd end-->
	<div class="detail-ft">
		<div class="sharebox"><uc1:ShareWidget ID="ShareWidget1" runat="server" /></div>
		<div class="line"></div>
		<div class="back"><a href="/news/"><i class="icon icon-x"></i>返回</a></div>
	</div>
</div>