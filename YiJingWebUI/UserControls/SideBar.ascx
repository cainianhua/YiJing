<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SideBar.ascx.cs" Inherits="YiJingWebUI.UserControls.SideBar" %>

<div id="floatShare">
  <ul>
    <li class="floatshare01"><a href="javascript:void(0);"><img src="/content/images/share_03_03.png" /></a>
	<div class="subfloatshare">
		<i class="icon"></i>
		<div class="qqshare">
			<div class="hd">QQ<span class="close"></span></div>
			<div class="bd">
				<dl>
					<dd><a target="_blank" href="http://wpa.qq.com/msgrd?v=3&uin=83193739&site=qq&menu=yes"><img border="0" src="http://wpa.qq.com/pa?p=2:83193739:52" alt="点击这里给我发消息" title="点击这里给我发消息"/></a>&nbsp;用户名</dd>
					<dd><a target="_blank" href="http://wpa.qq.com/msgrd?v=3&uin=83193739&site=qq&menu=yes"><img border="0" src="http://wpa.qq.com/pa?p=2:83193739:52" alt="点击这里给我发消息" title="点击这里给我发消息"/></a>&nbsp;用户名</dd>
					<dd><a target="_blank" href="http://wpa.qq.com/msgrd?v=3&uin=83193739&site=qq&menu=yes"><img border="0" src="http://wpa.qq.com/pa?p=2:83193739:52" alt="点击这里给我发消息" title="点击这里给我发消息"/></a>&nbsp;用户名</dd>
				</dl>
			</div>
			<div class="ft"></div>
		</div>
	</div>
	</li>
    <li class="floatshare02"><a href="#"><img src="/content/images/share_03_06.png" /></a></li>
    <li class="floatshare03"><a href="javascript:void(0);"><img src="/content/images/share_03_08.png" /></a>
	<div class="subfloatshare">
		<i class="icon"></i>
		<div class="weichatshare">
			<div class="hd">微信<span class="close"></span></div>
			<div class="bd">
				<img src="/content/images/weichatcode.png" />
			</div>
		</div>
	</div>
	</li>
    <li class="floatshare04"><a href="#"><img src="/content/images/share_03_10.png" /></a></li>
  </ul>
</div>
<script type="text/javascript">
	$('#floatShare li').click(function (e) {
		e.stopPropagation();
		$(this).toggleClass('on');
	});
	$('#floatShare .close').click(function (e) {
		e.stopPropagation();
		$(this).parents('.on').removeClass('on');
	});
	$(document).click(function (e) {
		$('#floatShare li.on').removeClass('on');
	});
	//ie6不支持position fixed
	if ($.browser.msie && ($.browser.version == "6.0") && !$.support.style) {
		var floatShare = $('#floatShare');
		floatShare.css('position', 'absolute');
		$(window).scroll(function () {
			floatShare.css({ 'top': $(window).scrollTop() + 180, 'position': 'absolute' });
		});
	} 
</script>