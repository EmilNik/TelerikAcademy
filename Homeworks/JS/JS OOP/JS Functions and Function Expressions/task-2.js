/* Task description */
/*
	Write a function a function that finds all the prime numbers in a range
		1) it should return the prime numbers in an array
		2) it must throw an Error if any on the range params is not convertible to `string`
		3) it must throw an Error if any of the range params is missing
*/

function solve(x, y) {
var result = [],
        i,
        j,
        maxDivisor,
        isPrime;
    x = +x;
    y = +y;

    if (arguments.length < 2) {
        throw new Error;
    } else if (isNaN(arguments[0]) || isNaN(arguments[1])) {
        throw new Error;
    }

    for (i = x; i <= y; i += 1) {
        maxDivisor = Math.sqrt(i);
        isPrime = true;

        if (i < 2) {
            isPrime = false;
        }

        for (j = 2; j <= maxDivisor; j += 1) {
            if (!(i % j)) {
                isPrime = false;
                break;
            }
        }

        if (isPrime) {
            result.push(i);
        }
    }
    return result;
}

module.exports = solve;