using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            Console.WriteLine("Sum of Numbers");
            Console.WriteLine(numbers.Sum());

            //TODO: Print the Average of numbers
            Console.WriteLine("Average of Numbers");
            Console.WriteLine(numbers.Average());

            //TODO: Order numbers in ascending order and print to the console
            Console.WriteLine("Order in Ascending");
            numbers.OrderBy(numbers  => numbers).ToList().ForEach(numbers => Console.WriteLine(numbers));
            //TODO: Order numbers in descending order and print to the console
            Console.WriteLine("Order in Descending");
            numbers.OrderByDescending(numbers => numbers).ToList().ForEach(numbers => Console.WriteLine(numbers));
            //TODO: Print to the console only the numbers greater than 6
            Console.WriteLine("Numbers greater than 6");
            numbers.Where(numbers => numbers > 6).ToList().ForEach(numbers=> Console.WriteLine(numbers));

            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("Random 4 order of numbers");

            var sortNumbers = numbers.OrderByDescending(numbers => numbers);

            foreach(var number in sortNumbers.Take(4))
            {
                Console.WriteLine(number);
            }

            //TODO: Change the value at index 4 to your age, then print the numbers in descending order
            Console.WriteLine("Add age at index 4 then print desending");
            numbers.Select((number, index) => index == 4 ? 42 : number).OrderByDescending(number => number).ToList().ForEach(number => Console.WriteLine(number));

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            Console.WriteLine("Vault Dwellers with C and S for first name please report to the OverSeerer");
            var selectedVaulter = employees.Where(dweller => dweller.FirstName.StartsWith('C') || dweller.FirstName.StartsWith('S')).OrderBy(dweller => dweller.FirstName);
            foreach(var employee in selectedVaulter)
            {
                Console.WriteLine($"Farm duty is Assigned to {employee.FirstName} {employee.LastName}");
            }
            Console.WriteLine();
            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            Console.WriteLine("Vault Dwellers with following name and age please report to OverSeerer");
            var oldVaulters = employees.Where(dweller => dweller.Age > 26).OrderBy(dweller => dweller.Age).ThenBy(dweller => dweller.FirstName);

            foreach (var oldVaulter in oldVaulters)
            {
                Console.WriteLine($"{ oldVaulter.FullName}, {oldVaulter.Age}");
            }
            Console.WriteLine();

            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var oldTimers = employees.Where(dweller => dweller.YearsOfExperience <= 10 && dweller.Age > 35);
            Console.WriteLine($"Dwellers with highest years of vault experence: {oldTimers.Sum(dwellers => dwellers.YearsOfExperience)}");
            Console.WriteLine();

            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            Console.WriteLine($"Dwellers with high age and there average years of vault experence: {oldTimers.Average(dwellers => dwellers.YearsOfExperience)}");
            Console.WriteLine();
            //TODO: Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Barton", "Thorn", 30, 15)).ToList();
            foreach (var employee in employees)
            {
                Console.WriteLine($"Name: {employee.FullName}, Age: {employee.Age}, Years of Experience: {employee.YearsOfExperience}");
            }

            Console.WriteLine();

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
