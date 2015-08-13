function solve() {
  return function (selector, isCaseSensitive) {
    isCaseSensitive = isCaseSensitive || false;
    
    if (!selector) {
      throw new Error();
    }
    
    if (typeof selector !== 'string') {
      throw new Error();
    }
    
    var root = document.querySelector(selector);
    
    if (!root) {
      throw new Error();
    }
    
    root.className += 'items-control'
    
    //enter text
    var enterTextDiv = document.createElement('div');
    
    enterTextDiv.className += ' add-controls';
    
    var textLable = document.createElement('label');
    
    textLable.innerHTML = 'Enter text';
    
    var textInput = document.createElement('input');
    
    var textButon = document.createElement('button');
    
    textButon.className += ' button';
    textButon.innerHTML = 'Add';
    
    enterTextDiv.appendChild(textLable);
    enterTextDiv.appendChild(textInput);
    enterTextDiv.appendChild(textButon);
    
    root.appendChild(enterTextDiv);
    
    
    //search
    var searchDiv = document.createElement('div');
    
    searchDiv.className += ' search-controls';
    
    var searchLable = document.createElement('label');
    var searchInput = document.createElement('input');
    
    searchLable.innerHTML = 'Search:';
    
    searchDiv.appendChild(searchLable);
    searchDiv.appendChild(searchInput);
    
    root.appendChild(searchDiv);
    
    //Result elements
    
    var resultDiv = document.createElement('div');
    
    resultDiv.className += ' result-controls';
    
    var items = document.createElement('div');
    items.className += ' items-list';
    
    resultDiv.appendChild(items);
    
    root.appendChild(resultDiv);
    
    //adding elements
    textButon.addEventListener('click', function() {
      var input = textInput.value;
      
      if (!input) {
        return;
      }
      
      var newButton = document.createElement('button');
      newButton.className += ' button';
      newButton.innerHTML = 'X';
      
      var newDiv = document.createElement('div');
      newDiv.className += ' list-item';
      
      newButton.addEventListener('click', function(ev) {
        ev.target.parentNode.remove();
      })
      
      newDiv.appendChild(newButton);
      
      var strong = document.createElement('strong');
      strong.innerHTML = input;
      
      newDiv.appendChild(strong);
      items.appendChild(newDiv);
    })
      
    //searching
    searchInput.addEventListener('input', function() {
      var items = document.querySelectorAll('.items-list .list-item strong'),
          input = searchInput.value,
          i, len,
          value;
          
          if (!isCaseSensitive) {
            input = input.toLowerCase();
          }
      
      for (i = 0, len = items.length; i < len; i+=1) {
        value = items[i].innerHTML;
        
        if (!isCaseSensitive) {
          value = value.toLowerCase();
        }
        
        if (value.indexOf(input) < 0) {
          items[i].parentNode.style.display = 'none';
        } else {
          items[i].parentNode.style.display = 'block';
        }
      }
    })
  }
};

module.exports = solve;