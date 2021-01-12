using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Open_Closed.DEMO2
{
    public class SizeSpecification : ISpecification<Product>
    {
        private Size size;
        public SizeSpecification(Size size)
        {
            this.size = size;
        }
        public bool IsSatisfied(Product t)
        {
            return t.Size == size;
        }
    }
}
