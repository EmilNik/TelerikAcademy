/* globals $ */
$.fn.gallery = function (columns) {
	var i,
		$this,
		count,
		$images;
	
	columns = columns || 4;
	
	$this = $(this);
	
	$('#gallery').addClass('gallery');
	
	$('.selected').hide();
	
	$images = $('.image-container').addClass();
	
	for (i = 0, count = 0; i < $images.length; i+=1) {
		if (!(count % columns)) {
			$($images[i]).addClass('clearfix');
			count = 0;
		}
		count += 1;
	}
	
	$('.gallery-list').on('click', function(ev) {
		var index,
			prev,
			next;
			
		index = +$(ev.target).attr('data-info');
		prev = index - 1;
		
		if (!prev) {
			prev = $images.length;
		}
		
		next = index % $images.length + 1;
		
		$($('.selected .previous-image img')[0]).attr('src', 'imgs/' + prev + '.jpg').attr('data-info', prev);
		$($('.selected .current-image img')[0]).attr('src', 'imgs/' + index + '.jpg').attr('data-info', index);
		$($('.selected .next-image img')[0]).attr('src', 'imgs/' + next + '.jpg').attr('data-info', next);
		
		$('.gallery-list').addClass('blurred').addClass('disabled-background');
		
		$('.selected').show();
	})
	
	$('.selected .current-image').on('click', function(ev) {
		$('.gallery-list').removeClass('blurred').removeClass('disabled-background');
		
		$('.selected').hide();
	})
	
	$('.selected .previous-image').on('click', function(ev) {
		var index,
			prev,
			next;
			
		index = +$(ev.target).attr('data-info');
		prev = index - 1;
		
		if (!prev) {
			prev = $images.length;
		}
		
		next = index % $images.length + 1;
		
		$($('.selected .previous-image img')[0]).attr('src', 'imgs/' + prev + '.jpg').attr('data-info', prev);
		$($('.selected .current-image img')[0]).attr('src', 'imgs/' + index + '.jpg').attr('data-info', index);
		$($('.selected .next-image img')[0]).attr('src', 'imgs/' + next + '.jpg').attr('data-info', next);
	})
	
	$('.selected .next-image').on('click', function(ev) {
		var index,
			prev,
			next;
			
		index = +$(ev.target).attr('data-info');
		prev = index - 1;
		
		if (!prev) {
			prev = $images.length;
		}
		
		next = index % $images.length + 1;
		
		$($('.selected .previous-image img')[0]).attr('src', 'imgs/' + prev + '.jpg').attr('data-info', prev);
		$($('.selected .current-image img')[0]).attr('src', 'imgs/' + index + '.jpg').attr('data-info', index);
		$($('.selected .next-image img')[0]).attr('src', 'imgs/' + next + '.jpg').attr('data-info', next);
	})
};