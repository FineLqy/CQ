$(function(){
	var $banner = $('#banner');
	var $ul = $banner.find('ul');
	var $li = $ul.find('li');
	var $count = $li.length;
	var $circle = $banner.find('.circle');
	var $height = 672;
	var $initial = 0;
	var autoPlay = true;

	function setSize(){
		var $ww = $(window).width();
		$banner.height($ww*672/1920);
	}
	setSize();
	$(window).resize(function(){setSize()});

	for(var i=0;i<$count;i++){
		$circle.append('<span></span>');
	}

	$li.eq($initial).show();
	$circle.find('span').eq($initial).addClass('active');
	$li.eq($initial).find('.move-up').addClass('up-in');
	$li.eq($initial).find('.move-left').addClass('left-in');
	$li.eq($initial).find('.move-right').addClass('right-in');
	$li.eq($initial).find('.move-down').addClass('down-in');

	function bannerPlay(num){
		if(!$li.is(':animated')){
			$li.fadeOut();
			$li.find('.move-up').removeClass('up-in');
			$li.find('.move-left').removeClass('left-in');
			$li.find('.move-right').removeClass('right-in');
			$li.find('.move-down').removeClass('down-in');
			$li.eq(num).fadeIn(400,function(){
				$li.eq(num).find('.move-up').addClass('up-in');
				$li.eq(num).find('.move-left').addClass('left-in');
				$li.eq(num).find('.move-right').addClass('right-in');
				$li.eq(num).find('.move-down').addClass('down-in');
			});
			$circle.find('span').removeClass('active').eq(num).addClass('active');
		}
	}

	$circle.on('click','span',function(){
		$initial = $(this).index();
		bannerPlay($initial);
	});

	if(autoPlay){
		var timer = setInterval(function(){
			$initial++;
			$initial%=$count;
			bannerPlay($initial);
		},5000);

		$banner.hover(function(){
			clearInterval(timer);
		},function(){
			timer = setInterval(function(){
				$initial++;
				$initial%=$count;
				bannerPlay($initial);
			},5000);
		});
	}

});