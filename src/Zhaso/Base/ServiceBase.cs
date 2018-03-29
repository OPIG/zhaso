using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Zhaso.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Zhaso
{
    public class ServiceBase<T> : IService<T> where T : EntityBase
    {
        public IRepository<T> Repository { get; private set; }
        public ServiceBase(IRepository<T> repository)
        {
            Repository = repository;
        }
    }
}
