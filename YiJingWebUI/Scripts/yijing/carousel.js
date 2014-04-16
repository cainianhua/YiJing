/**
* author	: Richard Cai
* version	: 1.0.0
* super simple carousel
* animation between panes happens with css transitions
*/
function Carousel(element, options) {
	var self = this;
	element = $(element);

	// default configurations.
	var defaults = {
		dataApi: "",
		containerSelector: ">ul",
		panesSelector: ">ul>li",
		cachedCount: 1,
		template: "<div class=\"newsdetail-hd clearfix\"><h2>{article}</h2><p>{tags}<span>{createddate}</span></p><div class=\"line\"></div></div><!--bd--><div class=\"detail-bd\"><div class=\"richcont\">{content}</div></div>"
	}

	options = $.extend({}, defaults, options);

	var container = $(options.containerSelector, element);
	var panes = $(options.panesSelector, element);

	var pane_width = 0;
	var pane_count = panes.length;

	var current_pane = 0;
	var loading = false;
	/**
	* initial
	*/
	this.init = function () {
		setPaneDimensions();

		$(window).on("load resize orientationchange", function () {
			setPaneDimensions();
		})
	};
	/**
	* show pane by index
	*/
	this.showPane = function (index, animate) {
		// between the bounds
		index = Math.max(0, Math.min(index, pane_count - 1));
		current_pane = index;

		var offset = -((100 / pane_count) * current_pane);
		setContainerOffset(offset, animate);
	};

	this.next = function () { return this.showPane(current_pane + 1, true); };
	this.prev = function () { return this.showPane(current_pane - 1, true); };

	/**
	* set the pane dimensions and scale the container
	*/
	function setPaneDimensions() {
		pane_width = element.width();
		panes.each(function () {
			$(this).width(pane_width);
		});
		container.width(pane_width * pane_count);
	};
	/**
	* set 
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

	function handleHammer(ev) {
		// disable browser scrolling
		ev.gesture.preventDefault();

		switch (ev.type) {
			case 'dragright':
			case 'dragleft':
				console.log("dragleft");
				// try to get new data items.
				loadNewPanes();

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
				console.log("release");
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
	function loadNewPanes() {
		if (!loading && pane_count - 1 - current_pane <= options.cachedCount) {
			loading = true;
			$.ajax({
				url: options.dataApi,
				data: { pn: currentPageIndex + 1, cid: currentCategoryId },
				dataType: "json",
				error: function (jqXHR, textStatus, errorThrown) { },
				complete: function (jqXHR, textStatus) { loading = false; },
				success: function (data, status) {
					$.each(data.items, function (index, item) {
						currentPageIndex++;

						var s = options.template;
						s = s.replace("{title}", item.title);
						s = s.replace("{subtitle}", item.subtitle);
						s = s.replace("{remarks}", item.remarks);
						s = s.replace("{tags}", item.tags);
						s = s.replace("{createddate}", item.createddate);
						s = s.replace("{content}", item.content);

						console.log(s);

						var o = $(s);


						container.append(o);
						updatePaneDimension(o);
					});
				}
			});
		}
	}
	/**
	* Update the new pane Dimension and recalculate the container width.
	*/
	function updatePaneDimension(panes) {
		panes = $(options.panesSelector, element);
		pane_count = panes.length;

		panes.each(function (index, item) {
			$(item).width(pane_width);
		});

		container.width(pane_width * pane_count);
	}

	new Hammer(element[0], { drag_lock_to_axis: true }).on("release dragleft dragright swipeleft swiperight", handleHammer);
}