function sectionAnimate(section) {
    //最新最全最好的Bootstrap模板：http://www.bootstrapmb.com
	$(window).on('scroll',function(){
		var $st = $(window).scrollTop();
		var $windowH = $(window).height();
		var $thisTop = section.offset().top;
		var $mu = section.find('.move-up');
		var $ml = section.find('.move-left');
		var $mr = section.find('.move-right');
		var $md = section.find('.move-down');
		var $scale = section.find('.scale');
		if($st>($thisTop-$windowH/2)){
			$mu.addClass('up-in');
			$ml.addClass('left-in');
			$mr.addClass('right-in');
			$md.addClass('down-in');
			$scale.addClass('scale-in');
		}
	})
};

$(function(){

	//底部企业相关下拉框
	$('.select-box').on('click',function(){
		$(this).toggleClass('on');
		$(this).find('ul').slideToggle();
	})
	$('.select-box ul li').on('click',function(){
		$('.select-box').find('h3').html($(this).html());
	})

	$('.page-banner').find('.move-up').addClass('up-in');
	$('.page-banner').find('.move-left').addClass('left-in');
	$('.page-banner').find('.move-right').addClass('right-in');
	$('.page-banner').find('.move-down').addClass('down-in');
});


