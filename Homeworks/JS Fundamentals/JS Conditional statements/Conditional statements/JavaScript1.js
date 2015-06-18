var a,
    b,
    c,
    d,
    e,
    biggest,
    count,
    number,
    result,
    hundreds,
    tens,
    ones,
    text;

//Write an if statement that takes two double variables a and b and exchanges their values
//if the first one is greater than the second.
//As a result print the values a and b, separated by a space.

function FindGreater() {
    a = document.getElementById("find-greater-a").value;
    b = document.getElementById("find-greater-b").value;

    a = +a;
    b = +b;

    if (b > a) {
        a = a + b;
        b = a - b;
        a = a - b;
    }

    document.getElementById("find-greater-p").innerHTML = a + " " + b;
}

//Write a script that shows the sign (+, - or 0) of the product of three real numbers, without calculating it.
//Use a sequence of if operators.

function ProductOfThree() {
    a = document.getElementById("product-of-three-a").value;
    b = document.getElementById("product-of-three-b").value;
    c = document.getElementById("product-of-three-c").value;

    a = +a;
    b = +b;
    c = +c;

    count = 0;

    if (a < 0) {
        count += 1;
    }

    if (b < 0) {
        count += 1;
    }

    if (c < 0) {
        count += 1;
    }

    if (!(count % 2)) {
        document.getElementById("product-of-three-p").innerHTML = "Product is +!";
    } else {
        document.getElementById("product-of-three-p").innerHTML = "Product is -!";
    }
}

//Write a script that finds the biggest of three numbers.
//Use nested if statements.


function BiggestOfThree() {
    a = document.getElementById("biggest-of-three-a").value;
    b = document.getElementById("biggest-of-three-b").value;
    c = document.getElementById("biggest-of-three-c").value;

    a = +a;
    b = +b;
    c = +c;

    if (a > b) {
        if (a > c) {
            document.getElementById("biggest-of-three-p").innerHTML = a;
        } else {
            document.getElementById("biggest-of-three-p").innerHTML = c;
        }
    } else {
        if (c > b) {
            document.getElementById("biggest-of-three-p").innerHTML = c;
        } else {
            document.getElementById("biggest-of-three-p").innerHTML = b;
        }
    }
}

//Sort 3 real values in descending order.
//Use nested if statements.

function SortThreeNumbers() {
    a = document.getElementById("sort-three-a").value;
    b = document.getElementById("sort-three-b").value;
    c = document.getElementById("sort-three-c").value;

    a = +a;
    b = +b;
    c = +c;

    if (a > b) {
        if (b > c) {
            document.getElementById("sort-three-p").innerHTML = a + " " + b + " " + c + "!";
        } else {
            if (a > c) {
                document.getElementById("sort-three-p").innerHTML = a + " " + c + " " + b + "!";
            } else {
                document.getElementById("sort-three-p").innerHTML = c + " " + a + " " + b + "!";
            }
        }
    } else {
        if (b > c) {
            if (a > c) {
                document.getElementById("sort-three-p").innerHTML = b + " " + a + " " + c + "!";
            } else {
                document.getElementById("sort-three-p").innerHTML = b + " " + c + " " + a + "!";
            }
        } else {
            document.getElementById("sort-three-p").innerHTML = c + " " + b + " " + a + "!";
        }
    }
}

//Write a script that asks for a digit (0-9), and depending on the input, shows the digit as a word (in English).
//Print “not a digit” in case of invalid input.
//Use a switch statement.

function DigitToString() {
    number = document.getElementById("digit-to-number-a").value;

    number = +number;

    switch (number) {
        case 1: document.getElementById("digit-to-number-p").innerHTML = "One"; break;
        case 2: document.getElementById("digit-to-number-p").innerHTML = "Two"; break;
        case 3: document.getElementById("digit-to-number-p").innerHTML = "Three"; break;
        case 4: document.getElementById("digit-to-number-p").innerHTML = "Four"; break;
        case 5: document.getElementById("digit-to-number-p").innerHTML = "Five"; break;
        case 6: document.getElementById("digit-to-number-p").innerHTML = "Six"; break;
        case 7: document.getElementById("digit-to-number-p").innerHTML = "Seven"; break;
        case 8: document.getElementById("digit-to-number-p").innerHTML = "Eight"; break;
        case 9: document.getElementById("digit-to-number-p").innerHTML = "Nine"; break;
        case 0: document.getElementById("digit-to-number-p").innerHTML = "Zero"; break;
        default: document.getElementById("digit-to-number-p").innerHTML = "Not a Digit!";
    }
}

//Write a script that reads the coefficients a, b and c of a quadratic equation
//ax2 + bx + c = 0 and solves it (prints its real roots).
//Calculates and prints its real roots.

function QuadraticEquation() {
    a = document.getElementById("quadratic-equation-a").value;
    b = document.getElementById("quadratic-equation-b").value;
    c = document.getElementById("quadratic-equation-c").value;

    a = +a;
    b = +b;
    c = +c;

    result = b * b - 4 * a * c;

    if (result < 0) {
        document.getElementById("quadratic-equation-p").innerHTML = "The equation has no real roots";
    } else if (!result) {
        document.getElementById("quadratic-equation-p").innerHTML = "x1 = x2 = " + (-b + Math.sqrt(result) * -1) / (2 * a);
    } else {
        document.getElementById("quadratic-equation-p").innerHTML = "x1 = " + (-b + Math.sqrt(result) * -1) / (2 * a) + " x2 = " + (-b + Math.sqrt(result) * 1) / (2 * a);
    }
}

//Write a script that finds the greatest of given 5 variables.
//Use nested if statements.

function BiggestOfFive() {
    a = document.getElementById("biggest-of-five-a").value;
    b = document.getElementById("biggest-of-five-b").value;
    c = document.getElementById("biggest-of-five-c").value;
    d = document.getElementById("biggest-of-five-d").value;
    e = document.getElementById("biggest-of-five-e").value;

    a = +a;
    b = +b;
    c = +c;
    d = +d;
    e = +e;

    biggest = a;

    if (b > biggest) {
        biggest = b;
    }

    if (c > biggest) {
        biggest = c;
    }

    if (d > biggest) {
        biggest = d;
    }

    if (e > biggest) {
        biggest = e;
    }

    document.getElementById("biggest-of-five-p").innerHTML = biggest
}

//Write a script that converts a number in the range [0…999] to words,
//corresponding to its English pronunciation.

function NumberToWords() {
    number = document.getElementById("number-to-words-number").value;

    number = +number;

    text = '',
        hundreds = Math.floor(number / 100) % 10,
        tens = Math.floor(number / 10) % 10,
        ones = number % 10;

    if (!hundreds && !tens && !ones) {
        text = 'zero';
    }

    if (hundreds) {
        text += getDigit(hundreds) + ' hundred';
    }

    if (tens || ones) {
        if (text.length) {
            text += ' and ';
        }

        if (tens) {
            if (tens == 1) {
                return text += (getTeens(tens * 10 + ones));
            }
            text += getTens(tens);
        }

        if (ones) {
            if (tens) {
                text += ' ';
            }

            text += getDigit(ones);
        }
    }

    document.getElementById("number-to-words-p").innerHTML = text;
}

function getDigit(digit) {
    switch (digit) {
        case 0: return 'zero';
        case 1: return 'one';
        case 2: return 'two';
        case 3: return 'three';
        case 4: return 'four';
        case 5: return 'five';
        case 6: return 'six';
        case 7: return 'seven';
        case 8: return 'eight';
        case 9: return 'nine';
        default: return '';
    }
};

function getTens(digit) {
    switch (digit) {
        case 2: return 'twenty';
        case 3: return 'thirty';
        case 4: return 'forty';
        case 5: return 'fifty';
        case 6: return 'sixty';
        case 7: return 'seventy';
        case 8: return 'eighty';
        case 9: return 'ninety';
        default: return '';
    }
};

function getTeens(digit) {
    switch (digit) {
        case 10: return 'ten';
        case 11: return 'eleven';
        case 12: return 'twelve';
        case 13: return 'thirteen';
        case 14: return 'fourteen';
        case 15: return 'fifteen';
        case 16: return 'sixteen';
        case 17: return 'seventeen';
        case 18: return 'eighteen';
        case 19: return 'nineteen';
        default: return '';
    }
}