using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a collection of students
            List<Student> students = new List<Student>
        {
            new Student { Name = "Alice", Age = 20, GPA = 3.5 },
            new Student { Name = "Bob", Age = 22, GPA = 3.2 },
            new Student { Name = "Charlie", Age = 19, GPA = 3.8 },
            // Add more students as needed
        };

            // LINQ query to filter students with GPA greater than 3.5
            var highGpaStudents = students.Where(s => s.GPA > 3.5);

            // LINQ query to order students by GPA in descending order
            var orderedStudents = students.OrderByDescending(s => s.GPA);

            // Display the results
            Console.WriteLine("High GPA Students:");
            foreach (var student in highGpaStudents)
            {
                Console.WriteLine($"{student.Name} - Age: {student.Age}, GPA: {student.GPA}");
            }

            Console.WriteLine("\nOrdered Students by GPA:");
            foreach (var student in orderedStudents)
            {
                Console.WriteLine($"{student.Name} - Age: {student.Age}, GPA: {student.GPA}");
            }

            // Example of data manipulation - calculating the average GPA
            double averageGpa = students.Average(s => s.GPA);
            Console.WriteLine($"\nAverage GPA: {averageGpa}");
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double GPA { get; set; }
    }

}
