/* globals $ */

/* 
Create a function that takes an id or DOM element and:
  
  If an id is provided, select the element
    Finds all elements with class 'button' or 'content' within the provided element
      Change the content of all .button elements with "hide"
    When a .button is clicked:
      Find the topmost .content element, that is before another .button and:
        If the .content is visible:
          Hide the .content
          Change the content of the .button to "show"
        If the .content is hidden:
          Show the .content
          Change the content of the .button to "hide"
        If there isn't a .content element after the clicked .button and before other .button, do nothing
  Throws if:
    The provided DOM element is non-existant
    The id is either not a string or does not select any DOM element
*/

function solve(){
  var CONST = {
        class: {
            button: 'button',
            content: 'content'
        },
        display: {
            hidden: 'none',
            visible: ''
        },
        buttonInnerHTML: {
            onHidden: 'show',
            onVisible: 'hide'
        }
    },
    validator = {
      validateInput: function(input) {
        if (typeof input !== 'string' && !(input instanceof HTMLElement)) {
          throw new Error();
        }
      },
      getValidElement: function(item){
        var result = item;
        if(typeof item === 'string'){
            result = document.getElementById(item);

            if(result === null){
                throw new Error();
            }

            return result;
        }
      }
    };
    
    function getChildrenWithClass(element, className) {
      var current,
          i, len,
          result = [],
          children = element.children;
          
          for (i = 0, len = children.length; i < len; i += 1) {
            current = children[i];
            
            if (current.className === className) {
              result.push(current);
            }
          }
          
          return result;
    }
    
    function buttonEvent (event) {
        var canToggleVisibility,
            contentElement,
            clicked = event.target,
            nextElement = clicked.nextElementSibling;

        while(nextElement){
            if(nextElement.className == CONST.class.content){
                contentElement = nextElement;

                while(nextElement){
                    if(nextElement.className == CONST.class.button){
                        canToggleVisibility = true;
                        break;
                    }

                    nextElement = nextElement.nextElementSibling;
                }

                break;
            } else {
                nextElement = nextElement.nextElementSibling;
            }
        }

        if(canToggleVisibility){
            if(contentElement.style.display == CONST.display.hidden){
                contentElement.style.display = CONST.display.visible;
                clicked.innerHTML = CONST.buttonInnerHTML.onVisible;
            } else {
                contentElement.style.display = CONST.display.hidden;
                clicked.innerHTML = CONST.buttonInnerHTML.onHidden;
            }
        }
    }

    return function (selector) {
      var element, buttons;

      validator.validateInput(selector);
      element = validator.getValidElement(selector);

      buttons = getChildrenWithClass(element, CONST.class.button)
        .map(function(button){
            button.innerHTML = CONST.buttonInnerHTML.onVisible;
            button.addEventListener('click', buttonEvent);
        });
    };
}

module.exports = solve;