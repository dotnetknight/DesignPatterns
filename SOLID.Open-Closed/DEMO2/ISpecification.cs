using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Open_Closed.DEMO2
{
    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }
}
