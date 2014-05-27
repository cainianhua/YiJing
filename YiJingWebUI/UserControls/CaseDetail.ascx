<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CaseDetail.ascx.cs" Inherits="YiJingWebUI.UserControls.CaseDetail" %>
<%@ Register src="~/UserControls/ShareWidget.ascx" tagname="ShareWidget" tagprefix="uc1" %>

<div class="maincontent">
	<!--<asp:Literal ID="TitleColor" runat="server"></asp:Literal>-->
	<!--<asp:Literal ID="SubTitleColor" runat="server"></asp:Literal>-->
	<!--<asp:Literal ID="RemarksColor" runat="server"></asp:Literal>-->
	<!--<asp:Literal ID="TagsColor" runat="server"></asp:Literal>-->
	<div class="detail-hd clearfix">
		<div class="detail-hd-l">
			<h2><strong style="color:#<%=TitleColor.Text%>"><asp:Literal ID="ArticleTitle" runat="server"></asp:Literal></strong>&nbsp;<span style="color:#<%=SubTitleColor.Text%>"><asp:Literal ID="ArticleSubtitle" runat="server"></asp:Literal></span></h2>
			<p>
				<asp:Repeater ID="rptTags" runat="server">
					<ItemTemplate>
						<asp:HyperLink ID="lnkTag" runat="server"></asp:HyperLink>
					</ItemTemplate>
				</asp:Repeater>
			</p>
		</div>
		<div class="detail-hd-r" style="color:#<%=RemarksColor.Text%>">
			<asp:Literal ID="ArticleRemarks" runat="server"></asp:Literal>
			<!--<p>客户行业&nbsp;｜&nbsp;推荐案例/集团</p>
			<p>客户行业&nbsp;｜&nbsp;2012年</p>
			<p>客户行业&nbsp;｜&nbsp;推荐案集团</p>-->
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
		<div class="back"><a href="/cases/"><i class="icon icon-x"></i>返回</a></div>
	</div>
</div>