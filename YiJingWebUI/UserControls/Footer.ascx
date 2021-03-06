﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="YiJingWebUI.UserControls.Footer" %>

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
			--<a href="http://www.miitbeian.gov.cn" target="_blank">粤ICP备14029741号</a>&nbsp;&nbsp;Copyright © 2014 广州熠镜品牌策划有限公司&nbsp;&nbsp;All
			Rights Reserved--</div>
	</div>
</div>
<div class="bodycover" <%=ContactUsBackgroundTopString%>></div>
<script type="text/javascript">
	$(".footerlogo a").on("click", function (e) {
		e.preventDefault();
		$('html,body').animate({ scrollTop: 0 }, 500);
		return false;
	});
	
	//if ($.browser.msie && ($.browser.version == "6.0") && !$.support.style) {
	/*if ('undefined' == typeof (document.body.style.maxHeight)) {
		$('#header').css({ 'position': 'absolute', 'bottom': '' });
	}*/
	$(window).on("resize load", function () {
		$('.bodycover').height(Math.max($(window).height() - $('#footer').outerHeight(true), 0));
		//console.log($(window).height());
		//console.log($('#footer').outerHeight(true));
	});
</script>