/* globals $ */

/* 

Create a function that takes an id or DOM element and an array of contents

* if an id is provided, select the element
* Add divs to the element
  * Each div's content must be one of the items from the contents array
* The function must remove all previous content from the DOM element provided
* Throws if:
  * The provided first parameter is neither string or existing DOM element
  * The provided id does not select anything (there is no element that has such an id)
  * Any of the function params is missing
  * Any of the function params is not as described
  * Any of the contents is neight `string` or `number`
    * In that case, the content of the element **must not be** changed   
*/

module.exports = function () {
  return function solve (element, contents) {
    var domElement,
        docFragment,
        div,
        divToBeAdded,
        i, len;
    
    function validateParameter(parameter){   
      if(parameter === undefined || parameter === null){
        throw new Error();
      }
    }
    
    validateParameter(element);
    validateParameter(contents);
      
    if(!Array.isArray(contents)){
      throw new Error();
    }

    for(i = 0, len = contents.length; i < len; i += 1){
      validateContent(contents[i]);
    }

    function validateContent (content) {
      if(typeof content !== "string" && typeof content !== "number"){
          throw new Error();
      }
    }
    
    function getValidElement (element) {
      if(typeof element === "string"){
          element = document.getElementById(element);
      }

      if(!(element instanceof HTMLElement)){
          throw new Error();
      }

      return element;
    }
    
    domElement = getValidElement(element);
    
    domElement.innerHTML = '';
    div = document.createElement('div');
    docFragment = document.createDocumentFragment();

    for(i = 0, len = contents.length; i < len; i += 1){
      divToBeAdded = div.cloneNode(true);
      divToBeAdded.innerHTML = contents[i];
      docFragment.appendChild(divToBeAdded);
    }

    domElement.appendChild(docFragment);
  };
};