var number,
    width,
    height,
    binaryNum,
    x,
    y,
    a,
    b,
    h,
    area;

//Write an expression that checks if given integer is odd or even.

function OddOrEven() {

    number = document.getElementById("odd-or-even").value;

    number = +number;

    if (!(number % 2)) {
        document.getElementById("odd-or-even-p").innerHTML = "Number is Even!";
    } else {
        document.getElementById("odd-or-even-p").innerHTML = "Number is Odd!";
    }
}

//Write a boolean expression that checks for given integer if it can be divided (without remainder)
//by 7 and 5 in the same time.

function DividedBy7and5() {

    number = document.getElementById("divisible-by-7-and-5").value;

    number = +number;

    if (!(number % 5) && !(number % 7)) {
        document.getElementById("divisible-by-7-and-5-p").innerHTML = "Number can be devided by 5 and 7 at the same time!";
    } else if (!(number % 5)) {
        document.getElementById("divisible-by-7-and-5-p").innerHTML = "Number can be devided by 5 but not by 7!";
    } else if (!(number % 7)) {
        document.getElementById("divisible-by-7-and-5-p").innerHTML = "Number can be devided by 7 but not by 5!";
    } else {
        document.getElementById("divisible-by-7-and-5-p").innerHTML = "Number cannot be devided neither by 5, nor by 7!";
    }
}

//Write an expression that calculates rectangle’s area by given width and height.

function CalculateRectangleArea() {
    width = document.getElementById("rectangle-width").value;
    height = document.getElementById("rectangle-height").value;

    area = width * height;

    document.getElementById("calculaterectangle-area-p").innerHTML = "Rectangle area is " + area + "!";
}

//Write an expression that checks for given integer if its third digit (right-to-left) is 7.

function CheckThirdDigit() {
    number = document.getElementById("check-third-digit").value;
    
    number = +number;

    if (((number / 100) | 0) % 10 == 7) {
        document.getElementById("check-third-digit-p").innerHTML = "Third digit is 7!";
    } else {
        document.getElementById("check-third-digit-p").innerHTML = "Third digit is not 7!";
    }
}

//Write a boolean expression for finding if the bit #3 (counting from 0) of a given integer.
//The bits are counted from right to left, starting from bit #0.
//The result of the expression should be either 1 or 0.

function CheckBinaryNumber() {
    number = document.getElementById("binary-check").value;

    number = +number;

    binaryNum = number >> 3;

    document.getElementById("binary-check-p").innerHTML = "The third bit of " + number + " is " + (binaryNum & 1) + "!";
}

//Write an expression that checks if given point P(x, y) is within a circle K({0,0}, 5). 
//{0,0} is the centre and 5 is the radius

function PointInCircle() {
    x = document.getElementById("point-in-circle-x").value;
    y = document.getElementById("point-in-circle-y").value;

    x = +x;
    y = +y;

    if (x ^ 2 + y ^ 2 <= 5 ^ 2) {
        document.getElementById("point-in-circle-p").innerHTML = "Given point is inside the circle!";
    } else {
        document.getElementById("point-in-circle-p").innerHTML = "Given point is not inside the circle!";
    }
}

//Write an expression that checks if given positive integer number n (n ≤ 100) is prime.

function CheckIfIsPrime() {
    number = document.getElementById("is-prime").value;

    number = +number;

    if (number > 100 || number < 0) {
        document.getElementById("is-prime-p").innerHTML = "Number must be less or equal to 100!";
    } else {
        for (var i = 2; i <= Math.sqrt(number) ; i++) {
            if (number % i == 0) {
                document.getElementById("is-prime-p").innerHTML = "Number is not prime!";
                break;
            } else {
                document.getElementById("is-prime-p").innerHTML = "Number is prime!";
            }
        }
    }
}

//Write an expression that calculates trapezoid's area by given sides a and b and height h.

function CalculateTrapezoidArea() {
    a = document.getElementById("trapezoid-area-a").value;
    b = document.getElementById("trapezoid-area-b").value;
    h = document.getElementById("trapezoid-area-h").value;

    area = ((a * b) / 2) * h;

    document.getElementById("trapezoid-area-p").innerHTML = "Trapezoid's area is " + area + "!";
}

//Write an expression that checks for given point P(x, y) if it is within the circle K( (1,1), 3)
//and out of the rectangle R(top=1, left=-1, width=6, height=2).

function CheckGivenPoint() {
    x = document.getElementById("check-point-x").value;
    y = document.getElementById("check-point-y").value;

    x = +x;
    y = +y;

    if ((x - 1) * (x - 1) + (y - 1) * (y - 1) <= 3 * 3 && !((x >= -1 && x <= -1 + 6) && (y <= 1 && y >= 1 - 2))) {
        document.getElementById("check-point-p").innerHTML = "This point is inside the circle and outside the rectangle";
    } else {
        document.getElementById("check-point-p").innerHTML = "This point is not inside the circle and outside the rectangle";
    }
}