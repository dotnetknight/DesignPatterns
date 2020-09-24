using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Open_Closed
{
    //As a continuation, we are going to create class which will inherit from the BaseSalaryCalculator class.
    //Because it is obvious that our calculation depends on the developer’s level, we are going to create our new classes in that manner:
    public class JuniorDevSalaryCalculator : BaseSalaryCalculator
    {
        public JuniorDevSalaryCalculator(DeveloperReport developerReport)
            : base(developerReport)
        {
        }
        public override double CalculateSalary() => DeveloperReport.HourlyRate * DeveloperReport.WorkingHours;
    }
}
