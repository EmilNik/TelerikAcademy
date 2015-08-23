/* 
Create a function that:
*   Takes an array of students
    *   Each student has:
        *   `firstName`, `lastName` and `age` properties
        *   Array of decimal numbers representing the marks         
*   **finds** the student with highest average mark (there will be only one)
*   **prints** to the console  'FOUND_STUDENT_FULLNAME has an average score of MARK_OF_THE_STUDENT'
    *   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
*   **Use underscore.js for all operations**
*/

function solve(){
    return function (students) {
        var student = _.chain(students)
            .map(function(item) {
                var i, len,
                    averageMark,
                    sum = 0;
                
                item.fullName = item.firstName + ' ' + item.lastName;
                
                for(i = 0, len = item.marks.length; i < len; i += 1) {
                    sum += item.marks[i];
                }
                
                averageMark = sum / len;
                
                item.averageMark = averageMark;
                
                return item;
            })
            .max(function(item) {
                return item.averageMark;
            })
            .value();
            
            console.log(student.fullName + ' has an average score of ' + student.averageMark);
    };
}

module.exports = solve;
