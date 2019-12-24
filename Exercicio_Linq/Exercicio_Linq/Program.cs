using Exercicio_Linq.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Exercicio_Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();

            Console.Write("Enter Salary:");
            double limit = double.Parse(Console.ReadLine());

            List<Employee> employees = new List<Employee>();

            try
            {

                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] fields = sr.ReadLine().Split(',');
                        string name = fields[0];
                        string email = fields[1];
                        double salary = double.Parse(fields[2], CultureInfo.InvariantCulture);
                        employees.Add(new Employee(name, email, salary));
                    }
                }

                var r1 = employees.Where(e => e.Salary > limit).OrderBy(e => e.Email).Select(e => e.Email);

                Console.WriteLine("Email of people whose salary is more than " + limit + ":");

                foreach (string email in r1)
                {
                    Console.WriteLine(email);
                }

                var r2 = employees.Where(e => e.Name == "M").Average(e => e.Salary);
                Console.WriteLine("Sum of salary of people whose name starts with 'M':" + r2.ToString("0.00"));
                //C: \Users\Wenderson\Documents\employee.txt
            }
            catch
            {
                Console.WriteLine("Error Try again");
            }
        }
    }
}
