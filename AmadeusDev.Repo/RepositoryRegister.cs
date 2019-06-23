using Jasarsoft.AmadeusDev.Repo.IRepositories;
using Jasarsoft.AmadeusDev.Repo.Repositories;
using Microsoft.Extensions.DependencyInjection;
namespace Jasarsoft.AmadeusDev.Repo
{
    public static class RepositoryRegister
    {
        public static void AddRepositories(this IServiceCollection service)
        {
            service.AddTransient<IUnitOfWork, UnitOfWork>();

            
        }
    }
}
