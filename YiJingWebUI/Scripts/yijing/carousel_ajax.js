/**
* author	: Richard Cai
* version	: 1.0.0
* super simple carousel
* animation between panes happens with css transitions
*/
function Carousel(element, options) {
	var self = this;
	element = $(element);

	var defaults = {
		dataApi: "/api/articledetail.ashx", // 获取数据的文章数据的API
		containerSelector: ">ul", 			// Carousel的容器
		panesSelector: ">ul>li", 			// Carousel的数据项
		//cachedCount: 1,					// 缓存的页数，就是每次从数据表里面获取多少个数据
		//penaCssClass: '<div class="pane"></div>',
		paneDataTemplate: '<div class="newsdetail-hd clearfix"><h2>{title}</h2><p>{tags}<span>{createddate}</span></p><div class="line"></div></div><!--bd--><div class="detail-bd"><div class="richcont">{content}</div></div>',
		totalPane: 10, 						// Carousel的总个数
		currentPane: 0, 					// 当前显示的Pane序号，从0开始计算
		currentCategoryId: 0, 				// 当前页的根类编号
		onShowed: function () { }
	}
	var paneStatuses = {};

	options = $.extend({}, defaults, options);

	var container = $(options.containerSelector, element);
	//var panes = $(options.panesSelector, element);

	var pane_width = 0;
	var pane_count = options.totalPane;

	var current_pane = options.currentPane;
	var loading = false;

	//
	var image_count = 0;
	var image_load_count = 0;
	/**
	* initial
	*/
	this.init = function () {
		// current page is loaded.
		//paneStatuses["p" + current_pane] = true;

		// generate empty Carousel element.
		for (var i = current_pane - 1; i >= 0; i--) {
			container.prepend('<div class="pane pane-' + i + '"></div>');
			paneStatuses["p" + i] = false;
		}
		for (var i = current_pane + 1; i < pane_count; i++) {
			container.append('<div class="pane pane-' + i + '"></div>');
			paneStatuses["p" + i] = false;
		}
		setPaneDimensions();

		$(window).on("load resize orientationchange", function () {
			setPaneDimensions();
		});

		self.showPane(current_pane, true);
	};
	/**
	* show pane by index
	*/
	this.showPane = function (index, animate) {
		// between the bounds
		index = Math.max(0, Math.min(index, pane_count - 1));
		current_pane = index;

		// try to get new data items.
		if (!paneStatuses["p" + current_pane]) {
			LoadPaneDataAsync();
		}

		var offset = -((100 / pane_count) * current_pane);
		setContainerOffset(offset, animate);

		// set the pane height;
		var pane_this = $(">div.pane:eq(" + current_pane + ")", container);
		container.height(pane_this.attr("data-height"));
		$("body").attr("style", pane_this.attr("article-bg"));

		if (options.onShowed)
			options.onShowed(current_pane);
	};

	this.next = function () { return this.showPane(current_pane + 1, true); };
	this.prev = function () { return this.showPane(current_pane - 1, true); };

	/**
	* set the pane dimensions and scale the container
	*/
	function setPaneDimensions() {
		pane_width = element.width();
		$(options.panesSelector, element).each(function () {
			$(this).width(pane_width);
		});
		container.width(pane_width * pane_count);
	};
	/**
	* set the container offset to decide which pane to show.
	*/
	function setContainerOffset(percent, animate) {
		container.removeClass("animate");

		if (animate) {
			container.addClass("animate");
		}

		if (Modernizr.csstransforms3d) {
			container.css("transform", "translate3d(" + percent + "%,0,0) scale3d(1,1,1)");
		}
		else if (Modernizr.csstransforms) {
			container.css("transform", "translate(" + percent + "%,0)");
		}
		else {
			var px = ((pane_width * pane_count) / 100) * percent;
			container.css("left", px + "px");
		}
	}
	//
	function handleHammer(ev) {
		// disable browser scrolling
		ev.gesture.preventDefault();

		switch (ev.type) {
			case 'dragright':
			case 'dragleft':
				// stick to the finger
				var pane_offset = -(100 / pane_count) * current_pane;
				var drag_offset = ((100 / pane_width) * ev.gesture.deltaX) / pane_count;

				// slow down at the first and last pane
				if ((current_pane == 0 && ev.gesture.direction == "right") ||
                        (current_pane == pane_count - 1 && ev.gesture.direction == "left")) {
					drag_offset *= .4;
				}

				setContainerOffset(drag_offset + pane_offset);
				break;

			case 'swipeleft':
				self.next();
				ev.gesture.stopDetect();
				break;

			case 'swiperight':
				self.prev();
				ev.gesture.stopDetect();
				break;

			case 'release':
				// more then 50% moved, navigate
				if (Math.abs(ev.gesture.deltaX) > pane_width / 2) {
					if (ev.gesture.direction == 'right') {
						self.prev();
					} else {
						self.next();
					}
				}
				else {
					self.showPane(current_pane, true);
				}
				break;
		}
	}
	/**
	* data provider, it will get data from a web api by ajax.
	*/
	function LoadPaneDataAsync() {
		if (!loading) {
			loading = true;
			$.ajax({
				url: options.dataApi,
				data: { pn: current_pane + 1, cid: options.currentCategoryId },
				dataType: "json",
				error: function (jqXHR, textStatus, errorThrown) { },
				complete: function (jqXHR, textStatus) { loading = false; },
				success: function (data, status) {
					if (data.code > 0) {
						var item = data.dataItem;

						var s = options.paneDataTemplate;
						s = s.replace("{title}", item.title);
						s = s.replace("{subtitle}", item.subtitle);
						s = s.replace("{remarks}", item.remarks);
						s = s.replace("{tags}", item.tags);
						s = s.replace("{createddate}", item.createddate);
						s = s.replace("{content}", item.content);

						var pane_this = $(">div.pane:eq(" + current_pane + ")", container);

						var o = $(s);
						var images = o.find("img");
						image_count = images.length;

						images.on("load", function (e) {
							image_load_count++;
							if (image_load_count == image_count) {
								pane_this.attr("data-height", pane_this.height());
								image_load_count = image_count = 0;
							}
						});

						pane_this.html(s);
						//	$("body").animate({
						//		backgroundcolor: "#" + item.bgcolor
						//	},500);

						if (image_count == 0)
							pane_this.attr("data-height", pane_this.height());

						var bgStyle = "background:#" + item.bgcolor + " " + (item.bgpic ? "url(" + item.bgpic + ")" : "") + " repeat-x center top;";
						$("body").attr("style", bgStyle);

						pane_this.attr("article-bg", bgStyle);

						paneStatuses["p" + current_pane] = true;
					}
				}
			});
		}
	}

	new Hammer(element[0], { drag_lock_to_axis: true }).on("release dragleft dragright swipeleft swiperight", handleHammer);
}