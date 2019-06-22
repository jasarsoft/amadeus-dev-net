using System;
using Jasarsoft.AmadeusDev.Repo.Context;
using Jasarsoft.AmadeusDev.Repo.IRepositories;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;


namespace Jasarsoft.AmadeusDev.Repo
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly AmadeusDevContext context;
        private readonly IServiceProvider serviceProvider;

        public UnitOfWork(AmadeusDevContext context, IServiceProvider serviceProvider)
        {
            this.context = context;
            this.serviceProvider = serviceProvider;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
