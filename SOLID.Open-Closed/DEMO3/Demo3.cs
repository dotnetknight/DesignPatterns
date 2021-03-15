using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Open_Closed.DEMO3
{
    public class Demo3
    {
        public enum Size
        {
            Small, Large
        }

        public enum Color
        {
            Red, Green, Blue, Black
        }

        public class Product
        {
            public string Name { get; set; }
            public Color Color { get; set; }
            public Size Size { get; set; }

            public Product(string name, Color color, Size size)
            {
                Name = name;
                Color = color;
                Size = size;
            }
        }

        public class Car
        {
            public string Name { get; set; }
            public Color Color { get; set; }

            public Car(string name, Color color)
            {
                Name = name;
                Color = color;
            }
        }

        public interface ISpecification<T>
        {
            bool IsSatisfied(T t);
        }

        public class ColorSpecification : ISpecification<Product>
        {
            private readonly Color color;

            public ColorSpecification(Color color)
            {
                this.color = color;
            }

            public bool IsSatisfied(Product product)
            {
                return product.Color == color;
            }
        }

        public class SizeSpecification : ISpecification<Product>
        {
            private readonly Size size;

            public SizeSpecification(Size size)
            {
                this.size = size;
            }

            public bool IsSatisfied(Product product)
            {
                return product.Size == size;
            }
        }

        public class CarColorSpecification : ISpecification<Car>
        {
            private readonly Color color;
            public CarColorSpecification(Color color)
            {
                this.color = color;
            }
            public bool IsSatisfied(Car car)
            {
                return car.Color == color;
            }
        }

        public class GreenAndSmallSpecification : ISpecification<Product>
        {
            private readonly ISpecification<Product> greenSpecification;
            private readonly ISpecification<Product> smallSpecification;

            public GreenAndSmallSpecification(ISpecification<Product> greenSpecification, ISpecification<Product> smallSpecification)
            {
                this.greenSpecification = greenSpecification;
                this.smallSpecification = smallSpecification;
            }

            public bool IsSatisfied(Product product)
            {
                return greenSpecification.IsSatisfied(product) && smallSpecification.IsSatisfied(product);
            }
        }

        public interface IFilter<T>
        {
            IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> specification);
        }

        public class FilterItems : IFilter<Product>
        {
            public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> specification)
            {
                foreach (var product in items)
                    if (specification.IsSatisfied(product))
                        yield return product;
            }
        }

        public class FilterCars : IFilter<Car>
        {
            public IEnumerable<Car> Filter(IEnumerable<Car> items, ISpecification<Car> specification)
            {
                foreach (var car in items)
                    if (specification.IsSatisfied(car))
                        yield return car;
            }
        }

        public void Execute()
        {
            var apple = new Product("Apple", Color.Green, Size.Small);
            var ball = new Product("Ball", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var cooperS = new Product("Mini-Cooper S", Color.Red, Size.Large);

            Product[] products = { apple, tree, cooperS, ball };
            var filterItems = new FilterItems();

            Console.WriteLine("Green products:");
            foreach (var product in filterItems.Filter(products, new ColorSpecification(Color.Green)))
            {
                Console.WriteLine($" - {product.Name} is green");
            }

            Console.WriteLine();

            Console.WriteLine("Green and small products");
            foreach (var product in filterItems.Filter(products,
                new GreenAndSmallSpecification(
                    new ColorSpecification(Color.Green),
                    new SizeSpecification(Size.Small))))
            {
                Console.WriteLine($" - {product.Name} is green and small");
            }

            Console.WriteLine();

            Console.WriteLine("Green cars");
            var carFilter = new FilterCars();
            var bentley = new Car("Bentley", Color.Green);
            var shevyCamaro = new Car("Shevy Camaro", Color.Green);
            var astonMartin = new Car("Aston Martin", Color.Black);

            Car[] cars = { bentley, shevyCamaro, astonMartin };

            foreach (var car in carFilter.Filter(cars, new CarColorSpecification(Color.Green)))
            {
                Console.WriteLine($" - {car.Name} is a green car");
            }

            Console.ReadLine();
        }
    }
}