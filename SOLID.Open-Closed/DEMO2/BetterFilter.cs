using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Open_Closed.DEMO2
{
    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> specification)
        {
            foreach (var item in items)
                if (specification.IsSatisfied(item))
                    yield return item;
        }
    }
}
