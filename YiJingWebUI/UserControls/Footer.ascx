<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="YiJingWebUI.UserControls.Footer" %>

<a name="contactus"></a>
<div id="footer" <%=ContactUsBackgroundBottomString%>>
	<div class="footerinner">
		<div class="footerinfo clearfix">
			<div class="footerinfo-l">
				<asp:Image ID="MirrorPic" runat="server" />
			</div>
			<div class="footerinfo-c">
				<asp:Literal ID="bottomWords" runat="server"></asp:Literal>
			</div>
			<div class="footerinfo-r">
				<ul>
					<asp:Repeater ID="rptContactUs" runat="server" onitemdatabound="rptContactUs_ItemDataBound">
						<ItemTemplate>
						<li><i><asp:Image Width="21px" Height="21px" ID="iconValue" runat="server" /></i><asp:Literal ID="itemValue" runat="server"></asp:Literal></li>
						</ItemTemplate>
					</asp:Repeater>
				</ul>
			</div>
		</div>
		<div class="footerlogo">
			<a href="javascript:void(0);">
				<asp:Image ID="BottomLogo" runat="server" AlternateText="熠镜品牌策划" /></a></div>
		<div class="copyright">
			--<a href="#">粤ICP备ＸＸＸＸＸ号</a>&nbsp;&nbsp;Copyright © 2014 广州熠镜品牌策划有限公司&nbsp;&nbsp;All
			Rights Reserved--</div>
	</div>
</div>
<script type="text/javascript">
	$(".footerlogo a").on("click", function (e) {
		e.preventDefault();
		$("a[name=top]").slideto({
			highlight: false,
			slide_duration: 'slow'
		});
		return false;
	});
</script>