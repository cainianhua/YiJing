//瀑布流布局
function Waterfall() {
    var waterfall = this,
        waterfallBox, //容器
        waterfallColumn = [], //用于记录列的高度
        minColumnHeight,
        minColumnIndex,
        maxColumnHeight;
    //参数
    this.setting = {
        columnNum: 4, //列数
        columnWidth: 210,
        container: '.waterfallbox',
        cellSelector: '.cell', //排列单元选择器
        loadIndex: 0, //加载次数初始值
        loadingStatus : true //ajax加载状态
    };
    //初始化
    this.init = function () {
        for (var i = 0; i < waterfall.setting.columnNum; i++) {//初始化waterfallColumn值为0
            waterfallColumn[i] = 0;
        }
        //排列
        waterfallBox = $(waterfall.setting.container);
        var renderData = $(waterfall.setting.cellSelector);
        waterfall.renderArray(renderData);

        //绑定滚动加载
        /*
        waterfall._scrollTimer2 = null;
        $(window).bind('scroll.waterfall', function () {
            if (waterfall.setting.loadingStatus) {
                clearTimeout(waterfall._scrollTimer2);
                waterfall._scrollTimer2 = setTimeout(scrollLoad, 300);
            }
        });
        */

        function scrollLoad() {//滚动加载
            var scrollTop = document.documentElement.scrollTop || document.body.scrollTop || 0; //滚动条距离
            var windowHeight = document.documentElement.clientHeight || document.body.clientHeight || 0; //窗口高度
            if (minColumnHeight - scrollTop - windowHeight < 10 && waterfall.setting.loadingStatus) {
                waterfall.ajaxGet();
            }
        }
    };

    //排列单个元素，设置position
    this.render = function (cell) {
        waterfall.getImageSize(cell.find('img').attr('src'),function(w,h) {
			//console.log('w/'+w+'h/'+h);
            var cellHeight = cell.outerHeight(true);
            minColumnHeight = Math.min.apply(null, waterfallColumn); //取得最小列的高度
            minColumnIndex = getArrayKey(waterfallColumn, minColumnHeight); //取得最小列的索引
            maxColumnHeight = Math.max.apply(null, waterfallColumn); //取得最大列的高度
            waterfallColumn[minColumnIndex] += cellHeight;
            cell.css({ 'top': minColumnHeight, 'left': minColumnIndex * waterfall.setting.columnWidth }).fadeIn();
            waterfallBox.css({ 'height': maxColumnHeight > (minColumnHeight + cellHeight) ? maxColumnHeight : (minColumnHeight + cellHeight) }); //容器高度
            function getArrayKey(s, v) { for (var k in s) { if (s[k] == v) { return k; } } } //取数组s中值为v的索引
        });
    };

    //批量排列一组元素
    this.renderArray = function (obj) {
        for (var i = 0; i < obj.length; i++) {
            waterfall.render(obj.eq(i));
        }
    };

    //ajax加载
    this.ajaxGet = function () {
        
    };

    //重排全部元素
    this.reRender = function () {
        for (var i = 0; i < waterfall.setting.columnNum; i++) { //初始化waterfallColumn值为0
            waterfallColumn[i] = 0;
        }
        //排列
        var renderData = $(waterfall.setting.cellSelector);
        waterfall.renderArray(renderData);
    };
    
    //get image real size
    this.getImageSize = function(url, callback, error) {
        var _width, _height, timer = null, maxCheckLoop = 20, isEnd = false;
        var ready, check;
        var img = new Image();

        // 加载错误后的事件 ie7,8需在src赋值之前
        img.onerror = function() {
            if (!isEnd) {
                error && error();
                isEnd = true;
            }
        }

        img.src = url;
        // 完全加载完毕的事件
        img.onload = function() {
            if (!isEnd) {
                isEnd = true;
                callback && callback(img.width, img.height);
            }
            img = img.onload = img.onerror = img.onreadystatechange = null; //gif动画在ie6中要置空
        }

        // 从缓存中读取
        if (img.complete) {
            if (!isEnd) {
                isEnd = true;
                callback && callback(img.width, img.height);
            }
            return;
        }

        // 通过占位提前获取图片头部数据
        _width = img.width;
        _height = img.height;
        check = function() {
            if (isEnd || img == null)
                return;

            if (img.width !== _width || img.height !== _height || img.width * img.height > 1024) {
                isEnd = true;
                callback && callback(img.width, img.height);
            } else {
                maxCheckLoop--;
                if (maxCheckLoop > 0) {
                    timer = setTimeout(check, 250);
                }
                ;
            }
        }
        check();
    };

}