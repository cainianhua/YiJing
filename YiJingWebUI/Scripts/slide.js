/**
*
* var s = new Slider('#slide',{
*       control : true,     // 是否出现左右控制
*       delay : 800,        // 运动时间间隔
*       interval : 3000,    // 自动播放时间间隔
*       auto : true,        // 是否自动播放
*       page : true,         // 是否出现分页
*       animate : 'fade',     //'fade'切换模式为fade,'cycleslide'为循环滑动,其它为slide
*       controlFixed : true,   //只有一张图片里是否要显示左右控制按钮
*       viewItems:1,
*		controlHover: true	// 左右控制按钮鼠标移上去显示，移除之后消失，默认为false（一直显示）
*   })
*/
var Slider = function (element, options) {
    this.elem = $(element);
    this.opts = $.extend({}, { viewItems: 1 }, typeof options == 'object' ? options : {});
    this.pos = 0;
    this.init();
    if (this.count <= this.opts.viewItems) {
        return;
    }
    this.elem
        .on('mouseenter', $.proxy(this.pause, this))
        .on('mouseleave', $.proxy(this.cycle, this));
}
Slider.prototype = {
	constructor: Slider,
	init: function () {
		var t = this,
            $this = this.elem;
		this.wrap = $this.find('ul:first');
		this.item = this.wrap.find('li');
		this.w = this.item.outerWidth(true);
		this.count = this.item.length;
		if (this.count <= t.opts.viewItems) {
			if (t.opts.controlFixed) {//只有一张图片里是否要显示左右控制按钮
				$this.addClass('disabled');
				$this.prepend([
                    '<a href="#1" data-navi="prev" class="btn-prev">prev</a>',
                    '<a href="#1" data-navi="next" class="btn-next">next</a>',
                ].join(''));
			}
			return;
		}
		if (t.opts.animate == 'fade') {
			$this.addClass('animate-fade');
			this.item.css({ 'display': 'none', 'position': 'absolute' }).eq(this.pos).show();
		} else {
			this.wrap.css('width', this.w * this.count);
		}
		if (this.opts.control) {
			$this.prepend([
                '<a href="#1" data-navi="prev" class="btn-prev">prev</a>',
                '<a href="#1" data-navi="next" class="btn-next">next</a>',
            ].join(''));
			$this.on('click', '[data-navi]', function (e) {
				//e.preventDefault();
				var type = $(e.target).data('navi');
				if (!type) return;
				if (type == 'prev') {
					e.preventDefault();
					t.prev();
				}
				if (type == 'next') {
					e.preventDefault();
					t.next();
				}
			})
		}
		if (this.opts.auto) {
			t.cycle();
		}
		if (this.opts.page) {
			this.page = [];
			this.item.each(function (i) {
				t.page.push('<span data-index="' + (i + 1) + '">' + (i + 1) + '</span>');
			})
			$this.append('<div class="pages">' + this.page.join('') + '</div>');
			this.navi = $this.find('.pages')
			this.navi.children('span:first').addClass('current');
			$this.delegate('span', 'click', function (e) {
				var $e = $(e.target),
                     $idx = $e.data('index');
				if (!$idx || $e.hasClass('current') || t.sliding) return;
				t.pos = ($idx - 1);
				t.slide(t.wrap, t.pos, function () {
					t.sliding = false;
				})
			})//.off('click','span');
		}
		if (this.opts.controlHover) {
			$(".btn-prev, .btn-next", this.elem).hide();
		}
	},
	cycle: function () {
		var t = this;
		this.timer = setInterval(function () {
			t.action('auto');
		}, t.opts.interval < 1500 ? 2500 : t.opts.interval);
		if (this.opts.controlHover) {
			$(".btn-prev, .btn-next", this.elem).hide();
		}
	},
	pause: function () {
		clearInterval(this.timer);
		this.timer = null;
		if (this.opts.controlHover) {
			$(".btn-prev, .btn-next", this.elem).show();
		}
	},
	next: function () {
		if (this.sliding) return;
		this.action('next');
	},
	prev: function () {
		if (this.sliding) return;
		this.action('prev');
	},
	action: function (type) {
		var t = this;
		if (type == 'next' || type == 'auto') {
			if (t.pos >= t.count - 1) t.pos = -1;
			t.slide(t.wrap, t.pos + 1, function () {
				t.pos++;
			})
		}
		if (type == 'prev') {
			if (t.pos <= 0) t.pos = t.count;
			if (t.opts.animate == 'cycleslide') {
				t.slide(t.wrap, t.pos - 1, function () {
					t.pos--;
				}, 'slideright')
			} else {
				t.slide(t.wrap, t.pos - 1, function () {
					t.pos--;
				})
			}
		}
		t.sliding = false;
	},
	slide: function (elem, pos, callback, cycleslide) {
		var t = this;
		this.sliding = true;
		/*console.log(t.pos+'/'+pos)*/
		if (t.opts.animate == 'fade') {
			if (t.opts.page) {
				t.navi.find('.current').removeClass('current').end()
                 .find('span:eq(' + pos + ')').addClass('current');
			}
			t.item.filter(':visible').stop(true, true).fadeOut(500);
			t.item.eq(pos).stop(true, true).fadeIn(800, function () {
				callback && callback();
			});
		} else if (t.opts.animate == 'cycleslide') {
			if (cycleslide == 'slideright') {
				elem.filter(':not(:animated)').prepend(elem.children(':last-child')).css("margin-left", "-" + t.w + "px").animate({ 'margin-left': "+=" + t.w }, t.opts.delay, function () {
					callback && callback();
				});
			} else {
				elem.filter(':not(:animated)').animate({
					'margin-left': -t.w
				}, t.opts.delay, function () {
					callback && callback();
					elem.append(elem.children().eq(0)).css("margin-left", "0");
				});
			}
		} else {
			elem.filter(':not(:animated)').animate({
				'margin-left': -t.w * pos
			}, t.opts.delay, function () {
				callback && callback();
				if (t.opts.page) {
					t.navi.find('.current').removeClass('current').end()
                             .find('span:eq(' + t.pos + ')').addClass('current');
				}
			})
		}
	}
}
