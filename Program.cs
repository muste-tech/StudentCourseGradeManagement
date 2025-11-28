using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Mustakim
{
    public class Program
    {
        static void Main()
        {
            List<Employee> employee = new List<Employee>
            {
                new Employee{Id=1, Name="John", Department="IT", Salary=50000, Age=25 },
                 new Employee{Id=2, Name="Jane", Department="HR", Salary=45000, Age=30 },
                  new Employee{Id=3, Name="Bob", Department="IT", Salary=60000, Age=35 },
                   new Employee{Id=4, Name="Alice", Department="Finance", Salary=55000, Age=28 },
                    new Employee{Id=5, Name="Charlie", Department="IT", Salary=52000, Age=32 }
            };

            var departmEnts = employee.Where(s => s.Department == "IT");
            Console.Write("Employees in the IT department are: ");
            foreach (var department in departmEnts)
            {

                Console.WriteLine(department.Name + " ");
                
            }

            var salaries = employee.Where(s => s.Salary > 50000);
            Console.Write("Employees with salary greter than 50k are:  ");
            foreach (var salary in salaries)
            {

                Console.WriteLine(salary.Name + " ");
            }
            var ages = employee.Where(s => s.Age > 25 && s.Age <= 35);
            Console.Write("Employees between age 25 to 35 are: ");
            foreach (var age in ages)
            {

                Console.WriteLine(age.Name + " ");
            }
            var employeeNames = employee.Select(s => s.Name);
            Console.Write("Names of alll employees are: ");
            foreach (var names in employeeNames)
            {

                Console.WriteLine(names + " ");
            }
            var decendbysalary = employee.OrderByDescending(s => s.Salary);
            Console.Write("Employees name by decending salary: ");
            foreach (var item in decendbysalary)
            {
                Console.WriteLine(item.Name);
            }

            var sortbyname = employee.OrderBy(s => s.Name);
            Console.Write("Employees sorted by name : ");
            foreach (var item in sortbyname)
            {
                Console.WriteLine(item.Name);
            }

            var sortbydepart = employee.OrderBy(s => s.Department);
            Console.Write("Employees sorted by department : ");
            foreach (var item in sortbydepart)
            {
                Console.WriteLine(item.Department);
            }
            var salaryave = employee.Average(s => s.Salary);
            Console.Write("Employees salary average : ");
            Console.WriteLine(salaryave);

            var maxsalary = employee.Max(s => s.Salary);
            Console.Write("Employees with highest salary : ");

            Console.WriteLine(maxsalary);
            var minsalary = employee.Min(s => s.Salary);
            Console.Write("Employees with Lowest salary : ");

            Console.WriteLine(minsalary);

            var totalsalary = employee.Sum(s => s.Salary);
            Console.Write("Employee Total salary expenditure : ");

            Console.WriteLine(totalsalary);
            List<Order> orders = new List<Order>
            {
                     new Order{OrderId= 1,CustomerName="Alice", OrderDate=new DateTime(2024, 1, 15),TotalAmount=150.50m,Status="Completed" },
                      new Order{OrderId= 2,CustomerName="Bob", OrderDate=new DateTime(2024, 1, 20),TotalAmount=200.75m,Status="Pending" },
                       new Order{OrderId= 3,CustomerName="Alice", OrderDate=new DateTime(2024, 2, 5),TotalAmount=75.25m,Status="Completed" },
                        new Order{OrderId= 4,CustomerName="Charlie", OrderDate=new DateTime(2024, 2, 10),TotalAmount=300.00m,Status="Cancelled" },
                         new Order{OrderId= 5,CustomerName="Bob", OrderDate=new DateTime(2024, 2, 15),TotalAmount=125.00m,Status="Completed" },
            };
            var totalamount = orders.GroupBy(s => s.CustomerName)

            .Select(g => new
            {
                CustomerName = g.Key,
                TotalAmount = g.Sum(s => s.TotalAmount)
            }
            );
            Console.WriteLine("Total amount by each customer: ");
            foreach (var amount in totalamount)
            {
                Console.WriteLine($"Customer {amount.CustomerName}: {amount.TotalAmount}");
            }
            var completedorder = orders.Where(s => s.Status == "Completed" && s.OrderDate == new DateTime(2024, 2, 5) && s.OrderDate == new DateTime(2024, 2, 10) && s.OrderDate == new DateTime(2024, 2, 15));
            Console.WriteLine("Completed orders from feb 2024: ");
            foreach (var order in completedorder)
            {
                Console.WriteLine($"order {order.OrderId}: {order.OrderDate}");
            }
            var morethanone = orders.GroupBy(s => s.CustomerName)
            .Where(s => s.Count() > 1)
            .Select(s => s.Key);
            foreach (var customer in morethanone)
            {
                Console.WriteLine($"Customer {customer}");
            }
            var orderamount = orders.GroupBy(s => s.Status)
            .Select(d => new
            {
                Status = d.Key,
                TotalAmount = d.Average(s => s.TotalAmount)
            }
            );

            Console.WriteLine(" Here is ths average order amonut by status: ");
            foreach (var order in orderamount)
            {
                Console.WriteLine(order);
            }

            var recentorder = orders.Where(s => s.OrderId <= 3);
            Console.WriteLine(" Here is the recent order for each customers: ");
            foreach (var order in recentorder)
            {
                Console.WriteLine("Date:" + order.OrderDate);
            }
            List<Student> students = new List<Student>
            {
                new Student
                {
                    StuentId = 1, Name = "John",
                    Grades = new List<CourseGrade>
                    {
                        new CourseGrade
                        {
                            CourseName = "Math", Grade = 85, Credits = 3
                        },
                        new CourseGrade
                        {
                            CourseName = "Science", Grade = 92, Credits = 4
                        },
                        new CourseGrade
                        {
                            CourseName = "History", Grade = 78, Credits = 3
                        }

                    }
                },
                new Student
                {
                    StuentId = 2, Name = "Jane",
                    Grades = new List<CourseGrade>
                    {
                        new CourseGrade
                        {
                            CourseName = "Math", Grade = 90, Credits = 3
                        },
                        new CourseGrade
                        {
                            CourseName = "Science", Grade = 88, Credits = 4
                        },
                        new CourseGrade
                        {
                            CourseName = "History", Grade = 95, Credits = 3
                        }

                    }
                }
            };

            var calculateGpa = students.Select(s => new
            {
                StudentId = s.StuentId,
                Name = s.Name,
                Gpa = s.Grades.Sum(g => ConvertGradeTo4Scale(g.Grade) * g.Credits) / (double)s.Grades.Sum(g => (double)g.Credits)
            }).ToList();
             Console.WriteLine($"Student GPAs");
            foreach (var GPA in calculateGpa)
            {
                Console.WriteLine($"Student {GPA.StudentId}: {GPA.Name}, GPA:{GPA.Gpa:F2}");
            }


             Console.WriteLine($"High GPA Students:");
            var highGpaStudent = calculateGpa.Where(s => s.Gpa >= 3.5).ToList();
            foreach (var gpa in highGpaStudent)
            {
                Console.WriteLine($"Student Name:{gpa.Name} GPA:{gpa.Gpa:F3}");
            }

            var average = students.SelectMany(s => s.Grades)
            .GroupBy(g => g.CourseName)
            .Select(g => new
            {
                CourseName = g.Key,
                AverageGrade = g.Average(c => c.Grade)
            }).ToList();
             Console.WriteLine($"Course Averages:");
            foreach (var gpa in average)
            {
                Console.WriteLine($"Course:{gpa.CourseName}, Average Grade: {gpa.AverageGrade:F2}");
            }

            var tookScience = students.Where(s => s.Grades.Any(g => g.CourseName == "Science")).ToList();
            Console.WriteLine($"Student who Took Science: ");
            foreach (var student in tookScience)
            {
                Console.WriteLine($"Took Science {student.Name}");
            }
            var lowestAveargeGrade = average.OrderBy(s => s.AverageGrade).FirstOrDefault();
                Console.WriteLine($"Hardest course:");
                Console.WriteLine($" Course: {lowestAveargeGrade.CourseName}, Average Grade: {lowestAveargeGrade.AverageGrade:F2}");
       

        }
                   public static double ConvertGradeTo4Scale(double Grade)
        {
            if (Grade >= 90) return 4.0;
            else if (Grade >= 80) return 3.0;
            else if (Grade >= 70) return 2.0;
            else if (Grade >= 60) return 1.0;
            else return 0.0;
     

        }
    }
}