<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SideBar.ascx.cs" Inherits="YiJingWebUI.UserControls.SideBar" %>

<div id="floatShare">

  <ul>
    <li class="floatshare01" data-sub="qqshare" data-w=100><a href="javascript:void(0);"><img src="/content/images/share_03_03.png" /></a>
	</li>
    <li class="floatshare02" data-sub="weiboshare" data-w=490><a href="#"><img src="/content/images/share_03_06.png" /></a></li>
    <li class="floatshare03" data-sub="weichatshare" data-w=160><a href="javascript:void(0);"><img src="/content/images/share_03_08.png" /></a>
	</li>
    <li class="floatshare04" data-sub="mapshare" data-w=343><a href="#"><img src="/content/images/share_03_10.png" /></a></li>
  </ul>
	<div class="subfloatshare">
		<div class="sharebd qqshare">
			<div class="hd">腾讯QQ<span class="close"></span></div>
			<div class="bd">
				<dl>
					<dd><a target="_blank" href="http://wpa.qq.com/msgrd?v=3&uin=83193739&site=qq&menu=yes"><img border="0" src="http://wpa.qq.com/pa?p=2:83193739:52" alt="点击这里给我发消息" title="点击这里给我发消息"/></a>&nbsp;用户名</dd>
					<dd><a target="_blank" href="http://wpa.qq.com/msgrd?v=3&uin=83193739&site=qq&menu=yes"><img border="0" src="http://wpa.qq.com/pa?p=2:83193739:52" alt="点击这里给我发消息" title="点击这里给我发消息"/></a>&nbsp;用户名</dd>
					<dd><a target="_blank" href="http://wpa.qq.com/msgrd?v=3&uin=83193739&site=qq&menu=yes"><img border="0" src="http://wpa.qq.com/pa?p=2:83193739:52" alt="点击这里给我发消息" title="点击这里给我发消息"/></a>&nbsp;用户名</dd>
				</dl>
			</div>
			<div class="ft"></div>
		</div>
		<div class="sharebd weiboshare">
			<div class="hd"><a href="http://weibo.com/u/3697506610" target="_blank"><img src="/content/images/weibotitle.png" /></a><span class="close"></span></div>
			<div class="bd">				
				<iframe width="490" height="240" class="share_self"  frameborder="0" scrolling="no" src="http://widget.weibo.com/weiboshow/index.php?language=&width=490&height=240&fansRow=2&ptype=1&speed=0&skin=10&isTitle=0&noborder=0&isWeibo=1&isFans=0&uid=3697506610&verifier=a698177a&colors=d6f3f7,030408,666666,00A6BF,030408&dpc=1"></iframe>
			</div>
		</div>
		<div class="sharebd weichatshare" style="display:none;">
			<div class="hd">微信WECHAT<span class="close"></span></div>
			<div class="bd">
				<img src="/content/images/weichatcode.png" />
			</div>
		</div>
		<div class="sharebd mapshare" style="display:none;">
			<div class="hd">地址Address<span class="close"></span></div>
			<div class="bd">
				<a href="http://j.map.baidu.com/wEatr" target="_blank"><img src="/content/images/ditu.png" /></a>
			</div>
		</div>
	</div>
</div>
<script type="text/javascript">
	$('#floatShare li').click(function (e) {
		e.stopPropagation();
		var w=$(this).data('w');
		$('.subfloatshare>div:visible').hide();
		$('.'+$(this).data('sub'),'.subfloatshare').show();
		$('.subfloatshare').width(w);
		$('#floatShare').animate({right:w+'px'},100);
	});
	$('#floatShare .close').click(function (e) {
		e.stopPropagation();
		$('#floatShare').animate({right:'0'},100,function(){
			$('.subfloatshare>div:visible').hide();
		});
	});
	$(document).click(function (e) {		
		$('#floatShare').animate({right:'0'},100,function(){
			$('.subfloatshare>div:visible').hide();
		});
	});
	//ie6不支持position fixed
	//if ($.browser.msie && ($.browser.version == "6.0") && !$.support.style) {
	if ('undefined' == typeof (document.body.style.maxHeight)) {
		var floatShare = $('#floatShare');
		floatShare.css('position', 'absolute');
		$(window).scroll(function () {
			floatShare.css({ 'top': $(window).scrollTop() + 180, 'position': 'absolute' });
		});
	}
</script>