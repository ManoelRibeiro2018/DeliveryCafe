using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCafe.API.Interface.Especification
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T Entity);
        bool VerifyExistEntity(T Entity);
    }
}
