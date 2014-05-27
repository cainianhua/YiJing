<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer2.ascx.cs" Inherits="YiJingWebUI.UserControls.Footer2" %>

<div id="footer2">
	<div class="footerinner2">
		<div class="copyright2">
			--<a href="#">粤ICP备ＸＸＸＸＸ号</a>&nbsp;&nbsp;Copyright © 2014 广州熠镜品牌策划有限公司&nbsp;&nbsp;All
			Rights Reserved--</div>
	</div>
</div>
<script type="text/javascript">
	//导航
	var scrollTimes;

	$(window).scroll(function () {
	    clearTimeout(scrollTimes);
	    //if ($(window).scrollTop() <= 0) {
	    //    $('.detail-topbar').css('position', 'relative');
	    //} else {
	        //$('.detail-topbar').css('position', 'fixed');
	        /*if ('undefined' == typeof (document.body.style.maxHeight)) {
	            $('.detail-topbar').css({ 'position': 'absolute', 'bottom': '' });
	        }
	        if ('undefined' == typeof (document.body.style.maxHeight)) {
	            $('.detail-topbar').css('top', $(window).scrollTop());
	        }*/
	        if (!$('body').hasClass('onscroll')) {
	            $('body').addClass('onscroll');
	        }
	    //}

	    scrollTimes = setTimeout(function () {
	        $('body').removeClass('onscroll');
	    }, 300);
	});
</script>