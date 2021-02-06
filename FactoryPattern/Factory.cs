using System;

namespace Factories.Factory
{
    //A factory is an object which is used for creating other objects”. In technical terms, we can say that a factory is a class with a method. That method will create and return different types of objects based on the input parameter, it received.

    public enum CoordinateSystem
    {
        Cartesian,
        Polar
    }

    public class Point
    {
        private double x, y;

        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }

        public static class Factory
        {
            public static Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y);
            }

            public static Point NewPolarPoint(double rho, double theta)
            {
                return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
            }
        }
    }

    class Factory
    {
        static void Main(string[] args)
        {
            var point = Point.Factory.NewPolarPoint(10.2, 5);
            Console.WriteLine(point);
        }
    }
}