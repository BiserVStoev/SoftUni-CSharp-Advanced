using System;
using System.Collections.Generic;
using Students_Directory;
using System.Linq;

class ClassStudent
{
    //I made all of the tasks from 1 through 10 in 1 project with different methods. To use each one you have to uncomment the method that you want to use.
    static void Main()
    {
        List<Student> students = new List<Student>()
        {
            new Student("Billy", "Romero", 50, 801231, "02 6123456", "tt@yahoo.com",
                new List<int>() {4, 2, 6, 5, 3}, 1),
            new Student("Tonka", "Kokova", 40, 801242, "0896123454", "ou@abv.bg",
                new List<int>() {6, 4, 6, 5, 6}, 2),
            new Student("Stoyan", "Yankov", 15, 801253, "+3593489624", "what@gmail.com",
                new List<int>() {2, 2, 6, 5, 3}, 1),
            new Student("Dimitar", "Popov", 18, 801214, "+359 2 6123450", "ii@outlook.com",
                new List<int>() {4, 2, 3, 5, 3}, 2),
            new Student("Kiril", "Evstatiev", 22, 801275, "0896123448", "kk@gmail.com",
                new List<int>() {2, 2, 3, 5, 3}, 3),
            new Student("Kameliya", "Videnova", 50, 801214, "0896123446", "ee@abv.bg",
                new List<int>() {4, 4, 4, 5, 3}, 4),
            new Student("Ivanka", "Petrova", 38, 801225, "0896123414", "samo@abv.bg",
                new List<int>() {4, 4, 4, 5, 3}, 4)
        };

        Problem2StudentsByGroup(students);
        //Problem3StudentsByFirstAndLastName(students);
        //Problem4StudentsByAge(students);
        //Problem5ASortStudents(students);
        //Problem5BSortStudents(students);
        //Problem6FilterStudentsByEmailAndDomain(students);
        //Problem7FilterStudentsByPhone(students);
        //Problem8ExcellentStudents(students);
        //Problem9WeakStudents(students);
        //Problem10StudentsEnrolledIn2014(students);
    }
    static void Problem2StudentsByGroup(List<Student> students)
    {
        var result = from student in students
            where student.GroupNumber == 2
            orderby student.FirstName
            select student
        ;
        Console.WriteLine("PROBLEM 2: ");
        foreach (var student in result)
        {
            Console.WriteLine("Name: {0} {1}, Age: {2}, Faculty Number: {3} " +
                                  "\n\tPhone: {4}, Email: {5} \n\tGrades: {{{6}}}",  student.FirstName, student.LastName, student.Age, student.FacultyNumber,
                    student.Phone, student.Email, string.Join(", ", student.Marks));
        }
        Console.WriteLine();
    }

    static void Problem3StudentsByFirstAndLastName(List<Student> students)
    {
        var result = from student in students
                     where student.FirstName.CompareTo(student.LastName) < 0
                                select student;
        ;
        Console.WriteLine("PROBLEM 3: ");
        foreach (var student in result)
        {
            Console.WriteLine("Name: {0} {1}, Age: {2}, Faculty Number: {3} " +
                                  "\n\tPhone: {4}, Email: {5} \n\tGrades: {{{6}}}",
                    student.FirstName, student.LastName, student.Age, student.FacultyNumber,
                    student.Phone, student.Email, string.Join(", ", student.Marks));
        }
        Console.WriteLine();
    }

    static void Problem4StudentsByAge(List<Student> students)
    {
        var result = from student in students
                     where student.Age >= 18 && student.Age <= 24
                     select new { student.FirstName, student.LastName, student.Age };
        ;
        Console.WriteLine("PROBLEM 4: ");
        foreach (var student in result)
        {
            Console.WriteLine("Name: {0} {1}, Age: {2} ",
                    student.FirstName, student.LastName, student.Age);
        }
        Console.WriteLine();
    }

    static void Problem5ASortStudents(List<Student> students)
    {
        var result = from student in students
                     orderby student.FirstName descending, student.LastName descending
                     select student;
        ;
        Console.WriteLine("PROBLEM 5A: ");
        foreach (var student in result)
        {
            Console.WriteLine("Name: {0} {1}, Age: {2}, Faculty Number: {3} " +
                                  "\n\tPhone: {4}, Email: {5} \n\tGrades: {{{6}}}",
                    student.FirstName, student.LastName, student.Age, student.FacultyNumber,
                    student.Phone, student.Email, string.Join(", ", student.Marks));
        }
        Console.WriteLine();
    }
    static void Problem5BSortStudents(List<Student> students)
    {
        var result = students.OrderByDescending(student => student.FirstName).
            ThenByDescending(student => student.LastName);
        ;
        Console.WriteLine("PROBLEM 5B: ");
        foreach (var student in result)
        {
            Console.WriteLine("Name: {0} {1}, Age: {2}, Faculty Number: {3} " +
                                  "\n\tPhone: {4}, Email: {5} \n\tGrades: {{{6}}}",
                    student.FirstName, student.LastName, student.Age, student.FacultyNumber,
                    student.Phone, student.Email, string.Join(", ", student.Marks));
        }
        Console.WriteLine();
    }

    static void Problem6FilterStudentsByEmailAndDomain(List<Student> students)
    {
        var result = from student in students
                     where student.Email.Contains("abv.bg")
                     select student;
        ;
        Console.WriteLine("PROBLEM 6: ");
        foreach (var student in result)
        {
            Console.WriteLine("Name: {0} {1}, Age: {2}, Faculty Number: {3} " +
                                  "\n\tPhone: {4}, Email: {5} \n\tGrades: {{{6}}}",
                    student.FirstName, student.LastName, student.Age, student.FacultyNumber,
                    student.Phone, student.Email, string.Join(", ", student.Marks));
        }
        Console.WriteLine();
    }

    static void Problem7FilterStudentsByPhone(List<Student> students)
    {
        var result = from student in students
                     where student.Phone.StartsWith("02") || student.Phone.StartsWith("+3592") || student.Phone.StartsWith("+359 2")
                     select student;
        ;
        Console.WriteLine("PROBLEM 7: ");
        foreach (var student in result)
        {
            Console.WriteLine("Name: {0} {1}, Age: {2}, Faculty Number: {3} " +
                                  "\n\tPhone: {4}, Email: {5} \n\tGrades: {{{6}}}",
                    student.FirstName, student.LastName, student.Age, student.FacultyNumber,
                    student.Phone, student.Email, string.Join(", ", student.Marks));
        }
        Console.WriteLine();
    }

    static void Problem8ExcellentStudents(List<Student> students)
    {
        var result = from student in students
                     where student.Marks.Contains(6)
                     select new { FullName = student.FirstName + " " + student.LastName, student.Marks };
        ;
        Console.WriteLine("PROBLEM 8: ");
        foreach (var student in result)
        {
            Console.WriteLine(student.FullName + ": " + string.Join(", ", student.Marks));
        }
        Console.WriteLine();
    }

    static void Problem9WeakStudents(List<Student> students)
    {
        var result = students
                .Where(student => student.Marks.Count(mark => mark == 2) == 2)
                .Select(student => new { FullName = student.FirstName + " " + student.LastName, student.Marks });
        ;
        Console.WriteLine("PROBLEM 9: ");
        foreach (var student in result)
        {
            Console.WriteLine(student.FullName + ": " + string.Join(", ", student.Marks));
        }
        Console.WriteLine();
    }

    static void Problem10StudentsEnrolledIn2014(List<Student> students)
    {
        var result = students
            .Where(student => student.FacultyNumber%100 == 14);

        ;
        Console.WriteLine("PROBLEM 10: ");
        foreach (var student in result)
        {
            Console.WriteLine("Name: {0} {1}, Age: {2}, Faculty Number: {3} " +
                                  "\n\tPhone: {4}, Email: {5} \n\tGrades: {{{6}}}",
                    student.FirstName, student.LastName, student.Age, student.FacultyNumber,
                    student.Phone, student.Email, string.Join(", ", student.Marks));
        }
        Console.WriteLine();
    }
}
