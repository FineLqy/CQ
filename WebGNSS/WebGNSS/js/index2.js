

$(function () {

    //搜索框
    function searchSize() {
        var ww = $(window).width();
        $('.search-box').width(ww - 283);
    }
    searchSize();
    $(window).resize(function () { searchSize() });
    $('.top-search').hover(
		function () {
		    if (!$('.search-box').is(':animated')) {
		        $('.search-box').fadeIn();
		    }
		},
		function () {
		    if (!$('.search-box').is(':animated')) {
		        setTimeout(function () {
		            $('.search-box').fadeOut();
		        }, 200)
		    }
		}
	);



    sectionAnimate($('.index-about'));
    sectionAnimate($('.solution'));
    sectionAnimate($('.index-news'));

    //发展战略
    var mySwiper1 = new Swiper('#mySwiper1', {
        autoplay: 3000,
        autoplayDisableOnInteraction: false,
        loop: true,
    })
    $('.img-prev').click(function () {
        mySwiper1.swipePrev();
    })
    $('.img-next').click(function () {
        mySwiper1.swipeNext();
    })


    //解决方案
    var mySwiper2 = new Swiper('#mySwiper2', {
        autoplay: 3000,
        loop: true,
        autoplayDisableOnInteraction: false,
        onSlideChangeStart: function (swiper) {
            var Index = mySwiper2.activeIndex;
            var count = mySwiper2.slides.length;
            if (Index == 0) {
                $('.solution-prev').addClass('disabled');
            } else {
                $('.solution-prev').removeClass('disabled');
            }
            if (Index == count - 1) {
                $('.solution-next').addClass('disabled');
            } else {
                $('.solution-next').removeClass('disabled');
            }
        }
    })
    $('.solution-prev').addClass('disabled');
    $('.solution-prev').click(function () {
        mySwiper2.swipePrev();
    })
    $('.solution-next').click(function () {
        mySwiper2.swipeNext();
    })


    //公司介绍图片
    var mySwiper3 = new Swiper('#mySwiper3', {
        autoplay: 5000, //间隔时间
        autoplayDisableOnInteraction: false, //用户操作后，是否禁止自动播放
        pagination: '.pagination1', //分页器
        loop: true,	//	是否循环
        resizeReInit: true,
        paginationClickable: true, //分页器点击是否切换
        calculateHeight: true //自适应高度
    })


    //产品展示
    Caroursel.init($('.caroursel'));

});

//视频播放
jwplayer('myVideo').setup({
    'flashplayer': 'jwplayer/jwplayer.flash.swf',
    'image': 'images/poster.jpg',
    'id': 'playerID',
    'width': '100%',
    'height': '190px',
    'aspectratio': '10:6',
    'file': 'video/1.mp4'
});

