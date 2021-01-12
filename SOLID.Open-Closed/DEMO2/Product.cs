using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Open_Closed.DEMO2
{
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
}