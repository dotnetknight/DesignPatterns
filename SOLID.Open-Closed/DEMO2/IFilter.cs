using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Open_Closed.DEMO2
{
    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> specification);
    }
}
