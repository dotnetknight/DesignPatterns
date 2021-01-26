using System;
using System.Collections.Generic;
using System.Linq;

namespace SOLID.DependencyInversion
{
//    High-level modules should not depend on low-level modules, both should depend on abstractions.
//    Abstractions should not depend on details.Details should depend on abstractions.
    public enum Gender
    {
        Male,
        Female
    }
    public enum Position
    {
        Administrator,
        Manager,
        Executive
    }
    public class Employee
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public Position Position { get; set; }
    }

    public interface IEmployeeSearchable
    {
        IEnumerable<Employee> EmployeesByGenderAndPosition(Gender gender, Position position);
    }

    public class EmployeeManager : IEmployeeSearchable
    {
        private readonly List<Employee> _employees;
        public EmployeeManager()
        {
            _employees = new List<Employee>();
        }

        public void AddEmployee(Employee employee)
        {
            _employees.Add(employee);
        }

        public IEnumerable<Employee> EmployeesByGenderAndPosition(Gender gender, Position position)
            => _employees.Where(emp => emp.Gender == gender && emp.Position == position);
    }

    public class EmployeeStatistics
    {
        private readonly IEmployeeSearchable _emp;

        public EmployeeStatistics(IEmployeeSearchable emp)
        {
            _emp = emp;
        }
        public int CountFemaleManagers() =>
        _emp.EmployeesByGenderAndPosition(Gender.Female, Position.Manager).Count();
    }

    class Program
    {
        static void Main(string[] args)
        {
            var empManager = new EmployeeManager();

            empManager.AddEmployee(new Employee { Name = "Leen", Gender = Gender.Female, Position = Position.Manager });
            empManager.AddEmployee(new Employee { Name = "Mike", Gender = Gender.Male, Position = Position.Administrator });

            var stats = new EmployeeStatistics(empManager);

            Console.WriteLine($"Number of female managers in our company is: {stats.CountFemaleManagers()}");
        }
    }
}
