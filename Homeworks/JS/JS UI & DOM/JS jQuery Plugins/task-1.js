function solve(){
  return function(selector){
	 var index,
	     selectors=$(selector).children(),
	     len=selectors.length;
	  
        $(selector).attr('id', 'the-select');
	$('<div/>', {'class': 'dropdown-list'}).appendTo('body');
	
	$(selector).appendTo('.dropdown-list').css("display", "none");
	
	$('<div/>', {'class': 'current',
				'data-value':'',
				text:'Option 1'})
	.appendTo('.dropdown-list');
	
	$('<div/>', {'class':'options-container'})
	.css({'display': 'none',
		 'position': 'absolute'})
	.appendTo('.dropdown-list');
	
	for(index=0;index<len;index+=1) {  
		$('<div/>', {'class': 'dropdown-item',
				'data-value': $(selectors).eq(index).val(),
				'data-index': index,
				text:$(selectors).eq(index).text()})
		.appendTo('.options-container');
	}  
	
	$('.current').click(function(){
		$('.options-container').show();
	});
	 
	$('.dropdown-item').click(function(){
	$(selector).val($(this).attr('data-value'));
	$('.current').text($(this).text());
	$('.options-container').hide();
	});
	
  };
}

module.exports = solve;