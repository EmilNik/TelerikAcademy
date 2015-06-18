//Write functions for working with shapes in standard Planar coordinate system.
//Points are represented by coordinates P(X, Y)
//Lines are represented by two points, marking their beginning and ending L(P1(X1,Y1), P2(X2,Y2))
//Calculate the distance between two points.
//Check if three segment lines can form a triangle.

function buildPoint(x, y) {
    return {
        x: x,
        y: y
    };
}

function buildLine(point1, point2) {
    return {
        p1: point1,
        p2: point2,
        length: pointDistance(point1, point2)
    };
}

function pointDistance(p1, p2) {
    var dx = p1.x - p2.x;
    var dy = p1.y - p2.y;
    return Math.sqrt(dx * dx + dy * dy);
}

function canBeTriangle(l1, l2, l3) {
    if (l1.length >= l2.length + l3.length || l2.length >= l1.length + l3.length || l3.length >= l2.length + l1.length) {
        return false;
    } else {
        return true;
    }
    return undefined;
}

var p1 = buildPoint(1, 1),
	p2 = buildPoint(4, 5),
	p3 = buildPoint(-10, -1),
	p4 = buildPoint(-5, 11),
	p5 = buildPoint(13, 10),
	p6 = buildPoint(7, 2);

var l1 = buildLine(p1, p2),
	l2 = buildLine(p3, p4),
	l3 = buildLine(p5, p6),
	l4 = buildLine(p1, p2);

console.log('l1 length (p1, p2 distance): ' + l1.length);
console.log('l2 length (p3, p4 distance): ' + l2.length);
console.log('l3 length (p5, p6 distance): ' + l3.length);

console.log('l1,l2,l3 can form triangle: ' + canBeTriangle(l1, l2, l3));
console.log('l1,l2,l1 can form triangle: ' + canBeTriangle(l1, l2, l1));

//Write a function that removes all elements with a given value.
//Attach it to the array type.
//Read about prototype and how to attach methods.

if (!Array.hasOwnProperty('removeAll')) {
    Array.prototype.removeAll = function (item) {
        var i,
			length = this.length;

        for (i = 0; i < length; i += 1) {
            if (this[i] === item) {
                this.splice(i, 1);
                i -= 1;
                length -= 1;
            }
        }
    }
}

var arr = [1, 2, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, '1'];
arr.removeAll(1); //arr = [2,4,3,4,111,3,2,'1'];
console.log(arr);

//Write a function that makes a deep copy of an object.
//The function should work for both primitive and reference types.

var oldObject = {
    x: {
        z: 7
    },
    y: 7
};

function deepCopy(oldObject) {
    return JSON.parse(JSON.stringify(oldObject));
}

var newObject = deepCopy(oldObject);

newObject.x.z = 0;

console.log(oldObject);
console.log(newObject);
//Write a function that checks if a given object contains a given property.

function hasProperty(obj, prop) {
    for (objProp in obj) {
        if (objProp === prop) {
            return true;
        }
    }
    return false;
}

var obj = {
    prop1: 1,
    prop2: 2
};

console.log(hasProperty(obj, 'prop1'));
console.log(hasProperty(obj, 'prop3'));

//Write a function that finds the youngest person in a given array of people and prints his/hers full name
//Each person has properties firstname, lastname and age.

function buildPerson(fname, lname, age) {
    return {
        fname: fname,
        lname: lname,
        age: age
    };
}

var gosho = buildPerson('gosho', 'georgiev', 30);
var ivan = buildPerson('ivan', 'ivanov', 27);
var misho = buildPerson('hristo', 'stoichkov', 28);

var people = [gosho, ivan, misho];
youngest(people);

function youngest(people) {
    var minAge = people[0].age;
    var minIndex = 0;
    for (i in people) {
        if (people[i].age < minAge) {
            minAge = people[i].age;
            minIndex = i;
        }
    }
    console.log(people[minIndex].fname + ' ' + people[minIndex].lname);
}

//Write a function that groups an array of people by age, first or last name.
//The function must return an associative array, with keys - the groups, and values - arrays with people in this groups
//Use function overloading (i.e. just one function)

function buildPerson(fname, lname, age) {
    return {
        fname: fname,
        lname: lname,
        age: age
    };
}

var gosho = buildPerson('gosho', 'georgiev', 25);
var ivan = buildPerson('ivan', 'ivanov', 23);
var misho = buildPerson('misho', 'mihailov', 26);
var misho2 = buildPerson('misho', 'ivanov', 26);


var people = [gosho, ivan, misho, misho2];

function groupPeopleBy(peopleArr, key) {
    if (peopleArr.length === 0) {
        return null;
    }

    // check to see if given key exists in the objects of the array
    if (!peopleArr[0].hasOwnProperty(key)) {
        return null;
    }

    var groupedPeople = {},
		i;

    for (i in peopleArr) {
        // check if current object`s key value exists as property name in the resulting associative array and if it doesn`t create it as empty array
        var groupProperty = peopleArr[i][key];

        if (!groupedPeople.hasOwnProperty(groupProperty)) {
            groupedPeople[groupProperty] = [];
        }
        // if current object`s key value exists as property name in the resulting associative array, add current object to this property in the associative array. This property is also an array, because we would have created it in the previous if statement
        groupedPeople[groupProperty].push(peopleArr[i]);
    }

    return groupedPeople;
}

var groupedByAge = groupPeopleBy(people, 'age');
console.log(groupedByAge);
var groupByFname = groupPeopleBy(people, 'fname');
console.log(groupByFname);
var groupByLname = groupPeopleBy(people, 'lname');
console.log(groupByLname);