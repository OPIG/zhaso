using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Zhaso.Interfaces
{
    public interface IService<T> : IService where T : EntityBase
    {
        IRepository<T> Repository { get; }
    }
}
