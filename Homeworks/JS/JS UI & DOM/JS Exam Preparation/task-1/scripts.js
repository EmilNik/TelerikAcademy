function solve(selector, items) {
	var bigTitle,
		bigImg;
	
	var root = document.querySelector(selector);
	
	var left = document.createElement('div'),
		right = document.createElement('div');
	
	left.className += ' image-preview';
	
	left.style.float = 'left';
	right.style.float = 'left';
	
	//left
	bigTitle = document.createElement('h1');
	bigTitle.innerHTML = items[0].title;
	left.appendChild(bigTitle);
	
	bigImg = document.createElement('img');
	bigImg.src = items[0].url;
	bigImg.width = 400;
	left.appendChild(bigImg);
	
	//right
	
	//right filter
	var filterInput = document.createElement('input'),
		filterLable = document.createElement('lable');
	
	filterLable.innerHTML = 'Filter';
	filterLable.style.display = 'block';
	filterLable.style.textAlign = 'center';
	
	var id = 'input-id' + Math.random();
	filterLable.setAttribute('for', id);
	filterInput.id = id;
	
	filterInput.addEventListener('input', function() {
		var titles = imageList.querySelectorAll('div'),
			input = filterInput.value.toLowerCase(),
			i, len;
			
		for (i = 0, len = titles.length; i < len; i+=1) {
			if (titles[i].innerText.toLowerCase().indexOf(input) < 0) {
				titles[i].style.display = 'none';
			} else {
				titles[i].style.display = 'block';
			}
		}
	})
	
	right.appendChild(filterLable);
	right.appendChild(filterInput);
	
	//right img list
	var imageList = document.createElement('div');
	
	imageList.style.overflowY = 'scroll';
	imageList.style.height = '400px';
	
	items.forEach(function(item) {
		var title = document.createElement('strong');
		title.innerHTML = item.title;
		title.style.display = 'block';
		
		var img = document.createElement('img');
		img.src = item.url;
		img.width = 150;
		
		var container = document.createElement('div');
		
		container.style.textAlign = 'center';
		container.className += ' image-container';
		
		container.appendChild(title);
		container.appendChild(img);
	
		imageList.appendChild(container);
	})
	
	right.appendChild(imageList);
	
	imageList.addEventListener('mouseover', function(ev) {
		var target = ev.target;
		
		while(target.className.indexOf('image-container') < 0) {
			target = target.parentNode;
		}
		
		target.style.background = 'pink';
	})
	
	imageList.addEventListener('mouseout', function(ev) {
		var target = ev.target;
		
		while(target.className.indexOf('image-container') < 0) {
			target = target.parentNode;
		}
		
		target.style.background = '';
	})
	
	imageList.addEventListener('click', function(ev) {
		var target = ev.target;
		
		while(target.className.indexOf('image-container') < 0) {
			target = target.parentNode;
		}
		
		var img = target.querySelector('img');
		var title = target.querySelector('strong');
		
		bigTitle.innerHTML = title.innerHTML;
		bigImg.src = img.src;
	})
	
	root.appendChild(left);
	root.appendChild(right);
}

//module.exports = solve();