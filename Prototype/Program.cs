using System;

namespace Prototype
{
    //Prototype Design Pattern specifies the kind of objects to create using a prototypical instance, and create new objects by copying this prototype.
    //To simplify the above definition, we can say that, the Prototype Design Pattern gives us a way to create new objects from the existing instance of the object. That means it clone the existing object with its data into a new object. If we do any changes to the cloned object (i.e. new object) then it does not affect the original object.

    //Points to Remember:
    // The MemberwiseClone method is part of the System.Object class and it creates a shallow copy of the given object. 
    //MemberwiseClone Method only copies the non-static fields of the object to the new object
    //In the process of copying, if a field is a value type, a bit by bit copy of the field is performed.If a field is a reference type, the reference is copied but the referenced object is not.

    class Program
    {
        public class Employee
        {
            public string Name { get; set; }
            public string Department { get; set; }

            public Employee Clone()
            {
                return (Employee)this.MemberwiseClone();
            }
        }

        static void Main(string[] args)
        {
            Employee emp1 = new Employee
            {
                Name = "Bruce",
                Department = "IT"
            };

            Employee emp2 = emp1.Clone();
            emp2.Name = "Clark";

            Console.WriteLine("Emplpyee 1: ");
            Console.WriteLine("Name: " + emp1.Name + ", Department: " + emp1.Department);

            Console.WriteLine("Emplpyee 2: ");
            Console.WriteLine("Name: " + emp2.Name + ", Department: " + emp2.Department);

            Console.Read();
        }
    }
}
