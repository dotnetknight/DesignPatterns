using System;
using System.Collections.Generic;

namespace Builder
{
    //Builder design pattern falls under the category of "Creational" design patterns. This pattern is used to build a complex object by using a step by step approach.
    class Program
    {
        class Director
        {
            public void Construct(IBuilder builder)
            {
                builder.BuildPartA();
                builder.BuildPartB();
            }
        }

        public interface IBuilder
        {
            void BuildPartA();
            void BuildPartB();
            Product Product();
        }

        public class ConcreteBuilder1 : IBuilder
        {
            private readonly Product product = new Product();

            public void BuildPartA()
            {
                product.Add("PartA");
            }

            public void BuildPartB()
            {
                product.Add("PartB");
            }

            public Product Product()
            {
                return product;
            }
        }

        public class ConcreteBuilder2 : IBuilder
        {
            private readonly Product product = new Product();

            public void BuildPartA()
            {
                product.Add("PartX");
            }

            public void BuildPartB()
            {
                product.Add("PartY");
            }

            public Product Product()
            {
                return product;
            }
        }

        public class Product
        {
            private readonly List<string> parts = new List<string>();

            public void Add(string part)
            {
                parts.Add(part);
            }

            public void Show()
            {
                Console.WriteLine("\nProduct Parts -------");
                foreach (string part in parts)
                    Console.WriteLine(part);
            }
        }

        static void Main(string[] args)
        {
            // Create director and builders

            Director director = new Director();

            IBuilder b1 = new ConcreteBuilder1();
            IBuilder b2 = new ConcreteBuilder2();

            // Construct two products

            director.Construct(b1);
            Product p1 = b1.Product();
            p1.Show();

            director.Construct(b2);
            Product p2 = b2.Product();
            p2.Show();
        }
    }
}
