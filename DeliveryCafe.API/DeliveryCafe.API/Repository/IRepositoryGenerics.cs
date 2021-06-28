using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCafe.API.Repository
{
    public interface IRepositoryGenerics<T>
    {
        bool CheckDuplicity(T value);
    }
}
