var input,
    element,
    i,
    index,
    indexMid,
    indexEnd,
    len,
    wordLen,
    count,
    substr,
    tempStr,
    protocol,
    server,
    resource,
    isPalindrome = false,
    result = '',
    resultArr = [],
    inputArr = [],
    regExpression = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;

//Write a JavaScript function that reverses a string and returns it.

function reverseString() {
    input = document.getElementById("reverse-strig-input").value;

    len = input.length
    index = 0;
    resultArr = [];

    for (i = len - 1; i >= 0; i -= 1) {
        resultArr.push(input[i]);
        index += 1;
    }

    document.getElementById("reverse-strig-p").innerHTML = resultArr.join('') + " !";

    return result;
}

//Write a JavaScript function to check if in a given expression the brackets are put correctly.

function bracketCheck() {

    input = document.getElementById("bracket-check-input").value;
    count = 0;

    for (i = 0, len = input.length; i < len; i += 1) {
        element = input[i];

        if (element === '(') {
            count += 1;
        } else if (element === ')') {
            count -= 1;
        }

        if (count < 0) {
            break;
        }
    }

    if (!count) {
        document.getElementById("bracket-check-p").innerHTML = "This expression is correct!";
    } else {
        document.getElementById("bracket-check-p").innerHTML = "This expression is NOT correct!";
    }

    return input;
}

//Write a JavaScript function that finds how many times a substring
//is contained in a given text (perform case insensitive search).

function substringCount() {
    input = document.getElementById("substring-count-input").value.toLowerCase();
    substr = document.getElementById("substring-count-substr").value.toLowerCase();
    count = 0;
    index = 0;

    index = input.indexOf(substr, index);

    while (index >= 0) {
        index = input.indexOf(substr, index + 1);
        count += 1;
    }

    document.getElementById("substring-count-p").innerHTML = "Substring " + substr + " is contained " + (count == 1 ? "once" : count + " times") + " in the input!";
}

//You are given a text. Write a function that changes the text in all regions.
//<upcase>text</upcase> to uppercase.
//<lowcase>text</lowcase> to lowercase
//<mixcase>text</mixcase> to mix casing(random)

function changeText() {
    input = document.getElementById("change-text-input").value;
    index = 0;
    indexEnd = 0;

    //to Upper Case
    while (1) {

        index = input.indexOf('<upcase>', index);
        indexEnd = input.indexOf('</upcase>', indexEnd);

        if (index < 0) {
            break;
        }

        result = input.substring(index + 8, indexEnd);

        input = input.replace(input.substring(index, indexEnd + 9), result.toUpperCase());

        index += 1;
        indexEnd += 1;
    }


    //to Lower Case
    while (1) {

        index = input.indexOf('<lowcase>', index);
        indexEnd = input.indexOf('</lowcase>', indexEnd);

        if (index < 0) {
            break;
        }

        result = input.substring(index + 9, indexEnd);

        input = input.replace(input.substring(index, indexEnd + 10), result.toLowerCase());

        index += 1;
        indexEnd += 1;
    }


    //to Mixed Case
    while (1) {

        index = input.indexOf('<mixcase>', index);
        indexEnd = input.indexOf('</mixcase>', indexEnd);
        tempStr = '';

        if (index < 0) {
            break;
        }

        result = input.substring(index + 9, indexEnd);

        for (i = 0, len = result.length; i < len; i += 1) {
            if ((Math.random() * 10 | 0) % 2) {
                tempStr += result[i].toLowerCase();
            } else {
                tempStr += result[i].toUpperCase();
            }
        }

        result = tempStr;
        input = input.replace(input.substring(index, indexEnd + 10), result);

        index += 1;
        indexEnd += 1;
    }

    document.getElementById("change-text-p").innerHTML = input;
}

//Write a function that replaces non breaking white-spaces in a text with &nbsp;

function replaceSpace() {
    input = document.getElementById("replace-space-input").value.trim();
    index = input.indexOf(' ', index);

    while (1) {

        if (index < 0) {
            break;
        }

        input = input.replace(' ', '&amp;nbsp')
        index = input.indexOf(' ', index);
    }

    document.getElementById("replace-space-p").innerHTML = input;
}

//Write a function that extracts the content of a html page given as text.
//The function should return anything that is in a tag, without the tags.

function returnHTML() {
    input = document.getElementById("return-HTML-input").value;
    index = 0;
    indexEnd = 0;

    while (1) {
        index = input.indexOf('<', index);
        indexEnd = input.indexOf('>', indexEnd);

        if (index < 0) {
            break;
        }

        input = input.replace(input.substring(index, indexEnd + 1), '');

        index += 1;
        indexEnd += 1;
    }
    document.getElementById("return-HTML-p").innerHTML = input.trim();
}

//Write a script that parses an URL address given in the format: 
//[protocol]://[server]/[resource] and extracts from it the [protocol], [server] and [resource] elements.
//Return the elements in a JSON object.

function parseURL() {
    input = document.getElementById("parse-url-input").value.trim();
    protocol = '';
    server = '';
    resource = '';

    index = input.indexOf('://')

    protocol = input.substring(0, index)
    server = input.substring(index + 3, (input.indexOf('/', index + 3)));
    resource = input.substring((input.indexOf('/', index + 3)), input.length);

    document.getElementById("parse-url-p").innerHTML = "Protocol: " + protocol + " Server: " + server + " Resource: " + resource + " !";
}

//Write a JavaScript function that replaces in a HTML document given as string
//all the tags <a href="…">…</a> with corresponding tags [URL=…]…/URL].

function replaceA() {
    input = document.getElementById("replace-a-input").value;
    index = 0;
    indexMid = 0;
    indexEnd = 0;

    while (1) {
        index = input.indexOf('<a href="', index);



        if (index < 0) {
            break;
        }

        //replace <a href = "
        input = input.replace(input.substr(index, 8), '[URL=');

        indexMid = input.indexOf('">', indexMid);

        //replace ">
        input = input.replace(input.substr(indexMid, 2), ']')

        indexEnd = input.indexOf('</a>', indexEnd);

        //replace </a>
        input = input.replace(input.substr(indexEnd, 4), '[/URL]')

        index += 1;
        indexMid += 1;
        indexEnd += 1;
    }
    document.getElementById("replace-a-p").innerHTML = input.trim();
}

//Write a function for extracting all email addresses from given text.
//All sub-strings that match the format @… should be recognized as emails.
//Return the emails as array of strings.

function extractEmail() {
    input = document.getElementById("extract-email-input").value.trim();;
    inputArr = input.split(' ');
    resultArr = [];

    for (i = 0, len = inputArr.length; i < len; i += 1) {
        if (regExpression.test(inputArr[i])) {
            resultArr.push(inputArr[i]);
        }
    }
    document.getElementById("extract-email-p").innerHTML = resultArr.join(', ');
}

//Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".

function findPalindromes() {
    input = document.getElementById("find-palindromes-input").value.trim();
    input = input.replace(/[\.,-\/#!$%\^&\*;:{}=\-_`~()]/g, ' ');
    inputArr = input.split(' ');
    resultArr = [];

    for (i = 0, len = inputArr.length; i < len; i += 1) {
        isPalindrome = true;
        for (j = 0, wordLen = inputArr[i].length; j < wordLen / 2; j += 1) {
            if (!(inputArr[i][j] == inputArr[i][wordLen - j - 1])) {
                isPalindrome = false;
                break;
            }
        }
        if (isPalindrome) {
            resultArr.push(inputArr[i]);
        }
    }
    document.getElementById("find-palindromes-p").innerHTML = resultArr.join(', ');
}

