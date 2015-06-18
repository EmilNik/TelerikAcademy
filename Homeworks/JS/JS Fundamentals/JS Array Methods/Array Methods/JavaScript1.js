//Write a function for creating persons.
//Each person must have firstname, lastname, age and gender (true is female, false is male)
//Generate an array with ten person with different names, ages and genders

function getPerson(fname, lname, age, gender) {
    return {
        fname: fname,
        lname: lname,
        age: age,
        gender: gender
    }
}

function generatePeople(count) {
    count = count || 20;
    var fnamesMen = ['Gosho', 'Pesho', 'Ivan', 'Niki', 'Ivailo', 'Angel', 'Kalin'];
    var lnamesMen = ['Georgiev', 'Petrov', 'Ivanov', 'Kokoshkov', 'Nikolov', 'Kalinov'];
    var fnamesWomen = ['Penka', 'Stanka', 'Slavka', 'Kitka', 'Chaika', 'Salfetka', 'Asena'];
    var lnamesWomen = ['Georgieva', 'Petrova', 'Ivanova', 'Kokoshkova', 'Pesheva', 'Komshiiska'];

    var pplArr = [];
    var fname,
        lname,
        age,
        gender;
    for (var i = 0; i < count; i += 1) {
        if (Math.round(Math.random())) {
            fname = fnamesMen[(Math.random() * fnamesMen.length) | 0];
            lname = lnamesMen[(Math.random() * lnamesMen.length) | 0];
            gender = 'male';
        } else {
            fname = fnamesWomen[(Math.random() * fnamesWomen.length) | 0];
            lname = lnamesWomen[(Math.random() * lnamesWomen.length) | 0];
            gender = 'female';
        }
        age = Math.random() * 50 | 0;
        pplArr.push(getPerson(fname, lname, age, gender));
    }

    return pplArr;
}

var pplArr = generatePeople(15);
console.log(pplArr);

//Write a function that checks if an array of person contains only people of age (with age 18 or greater)
//Use only array methods and no regular loops (for, while)

function checkAge() {
    for (var i = 0, len = pplArr.length; i < len; i += 1) {
        if (this.age < 18) {
            console.log("Not all people are above 18!")
            return;
        }
    }
    console.log("All people are above 18!")
}

//Write a function that prints all underaged persons of an array of person
//Use Array#filter and Array#forEach
//Use only array methods and no regular loops (for, while)

var underagedPplArr = pplArr.filter(function (person) {
    return person.age < 18;
});

underagedPplArr.forEach(function (person) {
    console.log(person.fname + ' ' + person.lname + ' ' + person.age);
})

//Write a function that calculates the average age of all females, extracted from an array of persons
//Use Array#filter
//Use only array methods and no regular loops (for, while)

var femalesArr = pplArr.filter(function (person) {
    return person.gender === 'female';
})
console.log(femalesArr);

var avgFemaleAge = femalesArr.reduce(function (previousValue, currentValue) {
    return previousValue + currentValue.age;
}, 0) / femalesArr.length;

console.log(avgFemaleAge);

//Write a function that finds the youngest male person in a given array of people and prints his full name
//Use only array methods and no regular loops (for, while)
//Use Array#find

if (!Array.prototype.find) {
    Array.prototype.find = function (callback) {
        var i, len = this.length;
        for (i = 0; i < len; i += 1) {
            if (callback(this[i], i, this)) {
                return this[i];
            }
        }
    }
}

var youngest = findYoungest(pplArr, 'm');
console.log(youngest);

function findYoungest(pplArr, gender) {
    var minAge = pplArr.reduce(function (previousValue, currentValue) {
        if (gender === 'm' || gender === 'f') {
            if (previousValue > currentValue.age && currentValue.gender === gender) {
                return currentValue.age;
            } else {
                return previousValue;
            }
        } else {
            if (previousValue > currentValue.age) {
                return currentValue.age;
            } else {
                return previousValue;
            }
        }
    }, 200);
    var youngest = pplArr.find(function (person) {
        if (person.age === minAge) {
            return true;
        } else {
            return false;
        }

    });
    return youngest.fname + ' ' + youngest.lname;
}

//Write a function that groups an array of persons by first letter of first name and returns the groups as a JavaScript Object
//Use Array#reduce
//Use only array methods and no regular loops (for, while)

var groupedPplArr = groupByFirstLetter(pplArr);
console.log(groupedPplArr);

function groupByFirstLetter(pplArr) {
    var result = pplArr.reduce(function (grouped, person) {
        var firstLetter = person.fname[0].toLowerCase();
        if (!grouped.hasOwnProperty(firstLetter)) {
            grouped[firstLetter] = [];
        }
        grouped[firstLetter].push(person);
        return grouped;
    }, {});

    return result;
}