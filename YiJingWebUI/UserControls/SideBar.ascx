﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SideBar.ascx.cs" Inherits="YiJingWebUI.UserControls.SideBar" %>

<div id="floatShare">
    <ul>
        <li class="floatshare01" data-sub="qqshare" data-w="135"><a href="javascript:void(0);"><img src="/content/images/share_03_03.png" /></a></li>
        <li class="floatshare02" data-sub="weiboshare" data-w="490"><a href="javascript:void(0);"><img src="/content/images/share_03_06.png" /></a></li>
        <li class="floatshare03" data-sub="weichatshare" data-w="160"><a href="javascript:void(0);"><img src="/content/images/share_03_08.png" /></a></li>
        <li class="floatshare04" data-sub="mapshare" data-w="343"><a href="javascript:void(0);"><img src="/content/images/share_03_10.png" /></a></li>
    </ul>
	<div class="subfloatshare">
		<div class="sharebd qqshare" style="display:none;">
			<div class="hd">腾讯QQ<span class="close"></span></div>
			<div class="bd">
				<dl>
					<dd><a target="_blank" href="http://wpa.qq.com/msgrd?v=3&uin=1056412463&site=qq&menu=yes"><img border="0" src="http://wpa.qq.com/pa?p=2:1056412463:52" alt="点击这里给我发消息" title="点击这里给我发消息"/>&nbsp;普通小编</a></dd>
					<dd><a target="_blank" href="http://wpa.qq.com/msgrd?v=3&uin=692331938&site=qq&menu=yes"><img border="0" src="http://wpa.qq.com/pa?p=2:692331938:52" alt="点击这里给我发消息" title="点击这里给我发消息"/>&nbsp;文艺小编</a></dd>
					<dd><a target="_blank" href="http://wpa.qq.com/msgrd?v=3&uin=199856654&site=qq&menu=yes"><img border="0" src="http://wpa.qq.com/pa?p=2:199856654:52" alt="点击这里给我发消息" title="点击这里给我发消息"/>&nbsp;非正常小编</a></dd>
				</dl>
			</div>
			<div class="ft"></div>
		</div>
		<div class="sharebd weiboshare" style="display:none;">
			<div class="hd"><a href="http://weibo.com/u/3697506610" target="_blank"><img src="/content/images/weibotitle.png" /></a><span class="close"></span></div>
			<div class="bd">
                <iframe width="490" height="275" class="share_self"  frameborder="0" scrolling="no" src="http://widget.weibo.com/weiboshow/index.php?language=&width=490&height=275&fansRow=2&ptype=1&speed=0&skin=10&isTitle=0&noborder=0&isWeibo=1&isFans=0&uid=3697506610&verifier=0c7f8e5f&colors=d6f3f7,303030,666666,00A6BF,353535&dpc=1"></iframe>
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
        $(this).siblings().removeClass('on');
        $(this).toggleClass('on');
        var w = $(this).data('w');
        $('.subfloatshare>div:visible').hide();
        $('.' + $(this).data('sub'), '.subfloatshare').show();
        $('.subfloatshare').width(w);
        $('#floatShare').animate({ right: w + 'px' }, 100);
    });
	$('#floatShare .close').click(function (e) {
	    e.stopPropagation();
	    $('#floatShare li.on').removeClass('on');
	    $('#floatShare').animate({ right: '0' }, 100, function () {
	        $('.subfloatshare>div:visible').hide();
	    });
	});
	$(document).click(function (e) {
	    $('#floatShare li.on').removeClass('on');
	    $('#floatShare').animate({ right: '0' }, 100, function () {
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