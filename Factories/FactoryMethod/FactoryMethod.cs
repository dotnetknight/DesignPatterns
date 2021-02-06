using System;

namespace Factories.FactoryMethod
{
    //Factory Method defines a method, which should be used for creating objects instead of direct constructor call.
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

        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }

        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }
    }

    class FactoryMethod
    {
        //static void Main(string[] args)
        //{
        //    var point = Point.NewPolarPoint(2, 3);
        //    Console.WriteLine(point);
        //}
    }
}