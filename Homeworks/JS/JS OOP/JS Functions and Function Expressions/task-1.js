/* Task Description */
/* 
	Write a function that sums an array of numbers:
		numbers must be always of type Number
		returns `null` if the array is empty
		throws Error if the parameter is not passed (undefined)
		throws if any of the elements is not convertible to Number	

*/

function sum(numbers) {
	var i, len, element, sum = 0;
	
	if (!numbers.length) {
		return null;
	}
	
	for (i = 0, len = numbers.length; i < len; i += 1) {
		element = +numbers[i];
		
		if (isNaN(element) || element == undefined) {
			throw new Error;
		}
		sum += element;
	}
	return sum;
}

module.exports = sum;