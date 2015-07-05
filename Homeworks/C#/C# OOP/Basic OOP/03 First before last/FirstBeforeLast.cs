//Problem 3. First before last

//    Write a method that from a given array of students finds all students 
//whose first name is before its last name alphabetically.
//    Use LINQ query operators.

//Problem 4. Age range

//    Write a LINQ query that finds the first name and last name of all students 
//with age between 18 and 24.

//Problem 5. Order students

//    Using the extension methods OrderBy() and ThenBy() with lambda expressions sort 
//the students by first name and last name in descending order.
//    Rewrite the same with LINQ.


namespace _03_First_before_last
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class FirstBeforeLast
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[8];
            students[0] = new Student("Pesho", "Ivanov", 12);
            students[1] = new Student("Ivan", "Peshev", 23);
            students[2] = new Student("Stamat", "Dimitrov", 19);
            students[3] = new Student("Matei", "Goshov", 66);
            students[4] = new Student("Bill", "Gates", 23);
            students[5] = new Student("Pesho", "Todorov", 27);
            students[6] = new Student("Pesho", "Ivanov", 27);
            students[7] = new Student("Gosho", "Mateev", 42);

            //All students

            Console.WriteLine("All students:\n");

            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine("Student " + (i + 1) + ": {0}", students[i]);
            }

            var result = FirstNameBeforeLast(students);

            //Only students whose first name is before their last alphabetically

            Console.WriteLine("\nStudents whose first name is before their last alphabetically:\n");

            foreach (var student in result)
            {
                Console.WriteLine(student);
            }

            //Only students whose age is between 20 and 30

            Console.WriteLine("\nStudents whose age is between 20 and 30:\n");

            var ageRange = FindPeopleOfCertainAge(students, 20, 30);

            foreach (var student in ageRange)
            {
                Console.WriteLine(student);
            }

            //Sort using OrderBy() and ThenBy()

            Console.WriteLine("\nStudents sorted by first and then last name using lambda expressions:\n");

            var sortedStudents = students.OrderByDescending(x => x.FirstName).ThenByDescending(x => x.LastName);

            foreach (var student in sortedStudents)
            {
                Console.WriteLine(student);
            }

            //Sort using OrderBy() and ThenBy()

            Console.WriteLine("\nStudents sorted by first and then last name using LINQ:\n");

            var sortedStudents2 =
            from student in students
            orderby student.FirstName descending, student.LastName descending
            select student;

            foreach (var student in sortedStudents2)
            {
                Console.WriteLine(student);
            }
        }

        private static IEnumerable<Student> FirstNameBeforeLast(Student[] students)
        {
            IEnumerable<Student> result =
            from student in students
            where student.FirstName.CompareTo(student.LastName) < 0
            select student;
            return result;
        }
        private static IEnumerable<Student> FindPeopleOfCertainAge(Student[] students, int startAge, int endAge)
        {
            IEnumerable<Student> result =
            from student in students
            where student.Age >= startAge && student.Age <= endAge
            select student;
            return result;
        }
    }
}
