/* 
 * author: rcai 
 * version: 1.0.0.0
 * description: ajax loading article data and support action of carousel.
 * dependecy: jquery 1.9.1 and above.
 *			  jquery.hammer 1.1.3 and above.
 * remmarks: hammer don't support ie6,ie7 and ie8 drag event, 
 *           so it only can display article data, no swipe and drag effects.
 **/
function Carousel(element, options) {
	var _defaults = {
		url: "/api/articledetail.ashx", // 获取数据的文章数据的API
		containerSelector: ">div.panes", // Carousel的容器
		paneItemsSelector: ">div.panes>div", // Carousel的数据项集合
		paneItemTemplate: "<div class=\"pane pane-{index}\"><div class=\"maincontent\"><div id=\"loadingLayer\"></div><img id=\"loadingLayerImg\" alt=\"加载中...\" src=\"/content/images/ajax-loader.gif\" style=\"opacity:1; z-index:100001; position:absolute; {topLeftString}\" /></div></div>",

		totalPane: 0, 		// Carousel的总个数
		currPaneIndex: 0, 	// 当前显示的Pane序号，从0开始计算
		currSort: 0, 		// 当前页的根类编号

		onShowed: function () { },
		onContentLoaded: function () { },
		onPageIndexChanged: function () { }
	}

    element = $(element);
    options = $.extend({}, _defaults, options);

    var self = this;
    var paneStatuses = {};
    var paneDatas = {};

    var container = $(options.containerSelector, element);
    var pane_width = 0;
    var pane_count = options.totalPane;
    var current_pane = options.currPaneIndex;

    /**
    * initial
    */
    this.init = function () {
        var _topLeftString = topLeftString();
        // generate empty Carousel element.
        for (var i = 0; i < pane_count; i++) {
            container.append(options.paneItemTemplate.replace(/\{index\}/g, i).replace(/\{topLeftString\}/g, _topLeftString));
            paneStatuses["p" + i] = false;
        }

        setPaneDimensions();

        $(window).on("load resize orientationchange", function () {
            setPaneDimensions();
        });

        self.showPane(current_pane, false);
    };
    /*
     * show pane by index
     */
    this.showPane = function (index, animate) {
        // between the bounds
        index = Math.max(0, Math.min(index, pane_count - 1));
        var indexChanged = index != current_pane;
        current_pane = index;

        // show current pane content.
        var offset = -((100 / pane_count) * current_pane);
        setContainerOffset(offset, animate);

        if (!paneStatuses["p" + current_pane]) {
            LoadPaneDataAsync(current_pane, function () {
                handlePaneShow(indexChanged);
            });
        }
        else {
            handlePaneShow(indexChanged);
        }
    };

    this.next = function () { return this.showPane(current_pane + 1, true); };
    this.prev = function () { return this.showPane(current_pane - 1, true); };

    /**
    * set the pane dimensions and scale the container
    */
    function setPaneDimensions() {
        pane_width = element.width();
        $(options.paneItemsSelector, element).each(function () {
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
    /**
    * Remarks: data provider, it will get data from a web api by ajax.
    * @pane_index: the pane index needed to load.
    * @callback: callback function after loaded data.
    */
    function LoadPaneDataAsync(pane_index, callback) {
        if (pane_index < 0 && pane_index > pane_count - 1) return;
        if (paneStatuses["p" + pane_index]) return;

        $.ajax({
            url: options.url,
            data: { pn: pane_index + 1, cid: options.currSort },
            dataType: "json",
            error: function (jqXHR, textStatus, errorThrown) { },
            //complete: function (jqXHR, textStatus) { loading = false; },
            success: function (data, status) {
                if (data.code > 0) {
                    paneDatas["_" + pane_index] = data.dataItem;
                    _loadPaneDataHandler(pane_index, data.dataItem);
                    callback && callback();
                }
            }
        });
    }

    function _loadPaneDataHandler(pane_index, item) {
        if (item == null) return;

        var pane_this = $(">div.pane:eq(" + pane_index + ")", container);

        var o = $(item.articleHtml);
        var images = o.find("img");
        var image_loaded_count = 0;
        var image_count = images.length;
        //console.log(image_count);
        images.on("load", function (e) {
            //console.log(image_loaded_count++);
            image_loaded_count++
            if (image_loaded_count == image_count) {
                //console.log("done(" + pane_index + ")");
                var pane_height = pane_this.height();
                pane_this.attr("data-height", pane_height);
                //console.log("height(" + pane_index + "):" + pane_height);
                if (pane_index == current_pane) {
                    container.height(pane_height);
                }
                image_loaded_count = image_count = 0;
            }
        });

        pane_this.html(item.articleHtml);

        pane_this.attr("data-height", pane_this.height());

        //var bgStyle = "background:#" + item.bgcolor + " " + (item.bgpic ? "url(" + item.bgpic + ")" : "none") + " repeat-x center top;";
        //pane_this.attr("style", bgStyle + pane_this.attr);
        pane_this.css("background-color", "#" + item.bgcolor);
        pane_this.css("background-image", (item.bgpic ? "url(" + item.bgpic + ")" : "none"));
        pane_this.css("background-repeat", "no-repeat");
        pane_this.css("background-position", "center top");

        paneStatuses["p" + pane_index] = true;

        options.onContentLoaded && options.onContentLoaded(pane_index, item);
    }

    function _checkPaneDataLoadedStatus(pane_index) {
        if (pane_index < 0 && pane_index > pane_count - 1) {
            return true; // not existed pane, we set it to true, means that it no need to load.
        }
        else if (pane_index == 0) {
            return paneStatuses["p" + current_pane] && paneStatuses["p" + (current_pane + 1)];
        }
        else if (pane_index == pane_count - 1) {
            return paneStatuses["p" + current_pane] && paneStatuses["p" + (current_pane - 1)];
        }
        else {
            return paneStatuses["p" + current_pane] && paneStatuses["p" + (current_pane - 1)] && paneStatuses["p" + (current_pane + 1)];
        }
    }

    function topLeftString() {
        var top = 'top: ' + ((document.documentElement.clientHeight - 20) / 2 + document.documentElement.scrollTop) + 'px;';
        var left = 'left: ' + (document.documentElement.clientWidth - 160) / 2 + 'px;';
        return top + left;
    }
    /*
     *@indexChanged: to indicate if current page index is changed.
     */
    function handlePaneShow(indexChanged) {
        // do something when current index is changed.
        if (indexChanged) {
            // invoke page index changed callback.
            if (options.onPageIndexChanged)
                options.onPageIndexChanged(current_pane, paneDatas["_" + current_pane]);
        }

        // set the pane height;
        var pane_this = $(">div.pane:eq(" + current_pane + ")", container);
        container.height(pane_this.attr("data-height"));

        if (options.onShowed)
        	options.onShowed(current_pane, paneDatas["_" + current_pane]);
        
        // delay 0.5s to pre-load article data.
        setTimeout(function () {
            // Modernizr.hisotry detect if window.history.pushState is workable.
            // if it is false, we will refresh page to load article,
            // so pre-load is not needed.
            if (Modernizr.history && current_pane - 1 >= 0 && !paneStatuses["p" + (current_pane - 1)]) {
                LoadPaneDataAsync(current_pane - 1);
            }
            if (Modernizr.history && current_pane + 1 <= pane_count - 1 && !paneStatuses["p" + (current_pane + 1)]) {
                LoadPaneDataAsync(current_pane + 1);
            } 
        }, 500);
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

    //new Hammer(element[0], { drag_lock_to_axis: true }).on("release dragleft dragright swipeleft swiperight", handleHammer);
    element.hammer({ drag_lock_to_axis: true }).on("release dragleft dragright swipeleft swiperight", handleHammer);
}