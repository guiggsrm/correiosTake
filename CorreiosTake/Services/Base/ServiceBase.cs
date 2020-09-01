using Contracts.Repository;
using Contracts.Services;
using Entidades.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Base
{
    public abstract class ServiceBase : IService
    {
        public ServiceBase(CorreiosContext correiosContext, IServiceWrapper serviceWrapper, IRepositoryWrapper repositoryWrapper)
        {
            this.Context = correiosContext;
            this.ServiceWrapper = serviceWrapper;
            this.RepositoryWrapper = repositoryWrapper;
        }

        protected CorreiosContext Context;

        public IServiceWrapper ServiceWrapper { get; }

        public IRepositoryWrapper RepositoryWrapper { get; }
    }
}
