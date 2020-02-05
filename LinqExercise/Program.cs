using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            //Print the Sum and Average of numbers
            int mSum = numbers.Sum();
                Console.WriteLine($"Sum Method Syntax: {mSum}");
            var mAverage = numbers.Average();
                Console.WriteLine($"Average Method Syntax: {mAverage}");
            int qSum = (from num in numbers select num).Sum();
                Console.WriteLine($"Sum Query Syntax: {qSum}");
            var qAverage = (from num in numbers select num).Average();
                Console.WriteLine($"Average Query Syntax: {qAverage}");

            //Order numbers in ascending order and decsending order. Print each to console.
            Console.WriteLine("Ascending Order Method Syntax:");
            var mAscend = numbers.OrderBy(num => num); 
                foreach (var item in mAscend)
                {
                    Console.WriteLine(item);
                }
            Console.WriteLine("Descending Order Method Syntax:"); 
            var mDescend = numbers.OrderByDescending(num => num); 
                foreach (var item in mDescend) 
                {
                    Console.WriteLine(item); 
                }
            Console.WriteLine("Ascending Order Query Syntax:");
            var qAscend = (from num in numbers orderby num select num).ToArray(); 
                foreach (var item in qAscend)
                {
                    Console.WriteLine(item);
                }
            Console.WriteLine("Descending Order Query Syntax:");
            var qDescend = (from num in numbers orderby num descending select num).ToArray(); 
                foreach (var item in qDescend)    
                {
                Console.WriteLine(item);
                }

            //Print to the console only the numbers greater than 6
            Console.WriteLine("Greater > 6 Method Syntax:");
            IEnumerable<int> mFilter = numbers.Where(num => num > 6); 
                foreach (int item in mFilter)
                {
                Console.WriteLine(item);
                }
            Console.WriteLine("Greater > 6 Query Syntax:");
            IEnumerable<int> qFilter = from num in numbers where num > 6 select num; 
                foreach (int item in qFilter)
                {
                Console.WriteLine(item);
                }
          
            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine($"Ascending and First Four Order Method Syntax:");
            var mAscendFirst4 = numbers.OrderBy(num => num); 
                foreach (var item in mAscendFirst4.Take(4))
                {
                Console.WriteLine(item);
                }
            Console.WriteLine("Ascending and First Four Order Query Syntax:");
                foreach (var item in qAscend.Take(4))
                {
                Console.WriteLine(item);
                }

            //Change the value at index 4 to your age, then print the numbers in decsending order
            Console.WriteLine("Replace Index and Descending Order Method Syntax:");
            numbers.SetValue(29, 4);
            var mIndexDescend = numbers.OrderByDescending(num => num);
                foreach (var item in mIndexDescend)
                {
                Console.WriteLine(item);
                }

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            Console.WriteLine("First Names Starts with 'C' or 'S' Ascending Order Query Syntax:");
            var resultList = employees.Where(employee => employee.FirstName.StartsWith('C') || employee.FirstName.StartsWith('S'));
            foreach (var employee in resultList.OrderBy(e => e.FirstName))
            {
                Console.WriteLine($"Name: {employee.FirstName}");
            }

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            Console.WriteLine("Full Name and Age > 26 Order Query Syntax:");
            var overAge26 = employees.Where(e => e.Age > 26).OrderBy(e => e.Age).ThenBy(e => e.FirstName);
            foreach (var employee in overAge26)
            {
                Console.WriteLine($"Name: {employee.FirstName,-25} Age: {employee.Age}");
            }

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            var sumList = employees.Where(e => e.YearsOfExperience > 10 && e.Age > 35);
            var sum = sumList.Sum(e => e.YearsOfExperience);
                Console.WriteLine($"Total years of experience over 35 years old: {sum}");

            var avgList = employees.Where(e => e.YearsOfExperience > 10 && e.Age > 35);
            var avg = avgList.Sum(e => e.YearsOfExperience);
            Console.WriteLine($"Average years of experience over 35 years old: {avg}");

            //Add an employee to the end of the list without using employees.Add()
            employees.Append(new Employee("Paul", "John", 1, 2));

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
