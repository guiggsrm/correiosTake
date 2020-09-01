using Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Services
{
    public interface IService
    {
        IServiceWrapper ServiceWrapper { get; }
        IRepositoryWrapper RepositoryWrapper { get; }
    }
}
