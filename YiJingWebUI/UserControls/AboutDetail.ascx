<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AboutDetail.ascx.cs" Inherits="YiJingWebUI.UserControls.AboutDetail" %>
<%@ Register src="~/UserControls/ShareWidget.ascx" tagname="ShareWidget" tagprefix="uc1" %>

<div class="servicedetail-hd clearfix">
	<asp:Repeater ID="rptArticles" runat="server">
		<ItemTemplate>
			<asp:HyperLink ID="lnkArticle" runat="server"></asp:HyperLink>
		</ItemTemplate>
	</asp:Repeater>
</div>
<div id="carousel">
	<div class="articles">
		<div class="pane">
			<!--bd-->
			<div class="detail-bd">
				<div class="richcont">
					<asp:Literal ID="ltrContent" runat="server"></asp:Literal>
				</div>
			</div>
		</div>
	</div>
</div>
<!--bd end-->
<div class="detail-ft">
	<div class="sharebox"><uc1:ShareWidget ID="ShareWidget1" runat="server" /></div>
	<div class="line"></div>
	<div class="back"><a href="/"><i class="icon icon-x"></i>返回</a></div>
</div>