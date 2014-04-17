/* home page javascript */
(function ($) {
	// 新闻资讯hover效果
	$('.box-indexnews .bd li').hover(function () {
		$(this).toggleClass('on');
	});
	//瀑布流
	var myWaterfall = new Waterfall();
	myWaterfall.setting.cellSelector = '.box-indexnews .bd li';
	myWaterfall.setting.container = '.box-indexnews .bd ul';
	myWaterfall.setting.columnWidth = 300;
	myWaterfall.setting.columnNum = 4;
	myWaterfall.init();
	// 焦点图slideshow
	var s1 = new Slider('.slideshow', {
		control: true,
		delay: 800,
		interval: 3000,
		auto: true,
		page: true,
		animate: 'fade',
		controlHover: true
	});
	// 关于熠镜slideshow
	var s2 = new Slider('.box-indexaboutus .bd', {
		control: true,
		delay: 500,
		interval: 3000,
		auto: true,
		page: false,
		animate: 'slide'
	});
	// 新闻资讯more
	$(".ft .more").one("click", function (e) {
		e.preventDefault();

		$.ajax({
			url: "/api/news.ashx",
			data: { pn: 2 },
			dataType: "json",
			success: function (data, status) {
				var lis = [];
				$.each(data, function (index, item) {
					var li = '<li>'
						   + '    <a title="' + item.ArticleTitleLocal + '" href="/news/detail.aspx?aid=' + item.ArticleId + '"><img alt="' + item.ArticleTitleLocal + '" src="' + item.Thumbnail + '" /></a>'
						   + '    <h3><a title="' + item.ArticleTitleLocal + '" href="/news/detail.aspx?aid=' + item.ArticleId + '">' + item.ArticleTitleLocal + '</a></h3>'
						   + '    <p><a title="' + item.ArticleTitleLocal + '" href="/news/detail.aspx?aid=' + item.ArticleId + '">' + item.Description + '</a></p>'
						   + '</li>'; 
					lis.push(li);
				});

				$(lis.join('')).appendTo($(".box-indexnews .bd ul"));
				myWaterfall.init();
			},
			error: function () { }
		});
		return false;
	});
	// 熠镜服务
	var tabtitle = $('.tabtitle li');
	var tabcont = $('.tabcont li');

	tabtitle.click(function () {
		tabtitle.filter('.selected').removeClass('selected');
		tabtitle.eq($(this).index()).addClass('selected');
		tabcont.filter('.selected').removeClass('selected');
		tabcont.eq($(this).index()).addClass('selected');
	});
	tabtitle.eq(0).click();
})(jQuery);