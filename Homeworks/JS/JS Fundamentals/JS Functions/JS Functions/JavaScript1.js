var number,
    digit,
    digitArr,
    positionArr,
    len,
    i,
    j,
    text,
    word,
    checkbox,
    regexString,
    count,
    arr = [],
    secondArr = [],
    obj = {};

//Write a function that returns the last digit of given integer as an English word.

function englishDigit() {
    digitArr = ['Zero', 'One', 'Two', 'Three', 'Four', 'Five', 'Six', 'Seven', 'Eight', 'Nine'];
    number = document.getElementById("english-digit-input").value;

    if (isNaN(number)) {
        document.getElementById("english-digit-p").innerHTML = "Imput is not a number!";
    } else {
        digit = number % 10;
        document.getElementById("english-digit-p").innerHTML = digitArr[digit] + "!";
    }
}

//Write a function that reverses the digits of given decimal number.

function reverseNumber() {
    number = document.getElementById("reverse-number-input").value;
    arr = [];

    if (isNaN(number)) {
        document.getElementById("reverse-number-p").innerHTML = "Imput is not a number!";
    } else {
        for (i = number.length; i > 0; i -= 1) {
            arr.push(number[i - 1]);
        }
        document.getElementById("reverse-number-p").innerHTML = arr.join('') + "!";
    }

}

//Write a function that finds all the occurrences of word in a text.
//The search can be case sensitive or case insensitive.
//Use function overloading.

function searchWord() {
    text = document.getElementById("search-word-text").value;
    text = text.trim();
    text = text.replace(/([,.*+?^=!:${}()|\[\]\/\\])/g, '');
    word = document.getElementById("search-word-word").value;
    word = word.trim();

    if (insensitive.checked == true) {
        word = word.toLowerCase();
        text = text.toLowerCase();
    }

    arr = text.split(' ');

    for (i = 0, len = arr.length, count = 0; i < len; i += 1) {
        if (arr[i] == word) {
            count += 1;
        }
    }

    if (count != 1) {
        document.getElementById("search-word-p").innerHTML = "The word " + word + " occurres " + count + " times in the text!"
    } else {
        document.getElementById("search-word-p").innerHTML = "The word " + word + " occurres once in the text!"
    }
}

//Write a function to count the number of div elements on the web page

function countDivs() {
    count = document.getElementsByTagName('div').length;
    document.getElementById("count-divs-p").innerHTML = "Sadly there are " + count + " DIVs in this HTML page! But i am sure the code works corectly!";
}

//Write a function that counts how many times given number appears in given array.
//Write a test function to check if the function is working correctly.

function numberInArray() {
    arr = document.getElementById("number-count-array").value.trim().split(' ');
    obj = {};

    for (i = 0, len = arr.length; i < len; i += 1) {
        if (obj[arr[i]]) {
            obj[arr[i]] += 1;
        } else {
            obj[arr[i]] = 1;
        }
    }

    number = document.getElementById("number-count-number").value.trim();

    if (!obj[number]) {
        document.getElementById("number-count-p").innerHTML = "Number doesnt appear in this array!"
    } else {
        document.getElementById("number-count-p").innerHTML = "Number appears " + (obj[number] == 1 ? " once " : (obj[number] + " times ")) + "in this array!";
    }
}

//Write a function that checks if the element at given position in given array of integers
//is bigger than its two neighbours (when such exist).

function biggerThanNeighbours() {
    arr = document.getElementById("bigger-than-neighbours-array").value.trim().split(' ');
    number = document.getElementById("bigger-than-neighbours-number").value;
    number = +number;

    if (isNaN(number) || number >= arr.length) {
        document.getElementById("bigger-than-neighbours-p").innerHTML = "Invalid position!";
    } else if (number == 0 || number == arr.length - 1) {
        document.getElementById("bigger-than-neighbours-p").innerHTML = "Element doesn't have two neighbours!";
    } else if (arr[number] > arr[number - 1] && arr[number] > arr[number + 1]) {
        document.getElementById("bigger-than-neighbours-p").innerHTML = "Element is bigger than its two neighbours!";
    } else {
        document.getElementById("bigger-than-neighbours-p").innerHTML = "Element is NOT bigger than its two neighbours!";
    }
}

//Write a function that returns the index of the first element in array that
//is larger than its neighbours or -1, if there’s no such element.
//Use the function from the previous exercise.

function firstBiggerThanNeighbours() {
    arr = document.getElementById("first-bigger-than-neighbours-array").value.trim().split(' ');
    positionArr = ['first', 'second', 'third', 'forth', 'fifth', 'sixth', 'seventh', 'eighth', 'nineth'];

    for (i = 1, len = arr.length; i < len - 1; i += 1) {
        arr[i] = +arr[i];
        if (arr[i] > arr[i - 1] && arr[i] > arr[i + 1]) {
           
            if (i < 10) {
                document.getElementById("first-bigger-than-neighbours-p").innerHTML = "First element bigger than its neightbours is " + arr[i] + " and it is at the " + positionArr[i] + " position!";
                return;
            } else {
                document.getElementById("first-bigger-than-neighbours-p").innerHTML = "First element bigger than its neightbours is " + arr[i] + " and it is at the " + (i + 1) + "th position!";
                return;
            }
        }
        document.getElementById("first-bigger-than-neighbours-p").innerHTML = "No element is bigger than its two neighbours!";
    }
}